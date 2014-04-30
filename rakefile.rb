# encoding: utf-8
require 'rubygems'
require 'rake/version_task'
Rake::VersionTask.new
require 'albacore'
require 'rake/clean'

OUTPUT = "build"
CONFIGURATION = 'Release'
SOLUTION_FILE = 'src/Devtist.sln'

CLEAN.include(OUTPUT)
CLEAN.include(FileList["src/**/#{CONFIGURATION}"])

Albacore.configure do |config|
    config.log_level = :verbose
    config.msbuild.use :net4
end

desc "Compiles solution"
task :default => [:clean, :compile, :publish, :package, :nuget_package]

desc "Generates AssemblyInfo files"
task :version do |asm|
    FileList["src/**/Properties/AssemblyInfo.*"].each { |assemblyfile|   
        asm = AssemblyInfo.new()
        asm.use(assemblyfile)
        asm.version = Version.current
        asm.file_version = Version.current
        asm.company_name = "Devtist"
        asm.product_name = "Devtist"
        asm.title = File.basename(File.dirname(File.dirname(assemblyfile)))
        asm.copyright = "(c) 2014 by Devtist (http://devtist.com/)"
        asm.execute
    }
end

desc "Compile solution file"
msbuild :compile => [:clean, :version] do |msb|
    msb.properties :configuration => CONFIGURATION
    msb.targets :Clean, :Build
    msb.solution = SOLUTION_FILE
end

desc "Gathers output files and copies them to the output folder"
task :publish => [:compile] do
    Dir.mkdir(OUTPUT)
    Dir.mkdir("#{OUTPUT}/binaries")

    FileUtils.cp_r FileList["src/**/#{CONFIGURATION}/*.dll", "src/**/#{CONFIGURATION}/*.pdb"].exclude(/obj\//).exclude(/.Tests/).exclude(/.Test/), "#{OUTPUT}/binaries"
end

desc "Zips up the built binaries for easy distribution"
zip :package => [:publish] do |zip|
    Dir.mkdir("#{OUTPUT}/packages")

    zip.directories_to_zip "#{OUTPUT}/binaries"
    zip.output_file = "Devtist-Latest.zip"
    zip.output_path = "#{OUTPUT}/packages"
end

desc "Generates NuGet packages for each project that contains a nuspec"
task :nuget_package => [:publish] do
    Dir.mkdir("#{OUTPUT}/nuget")
    nuspecs = FileList["src/**/*.nuspec"]
    root = File.dirname(__FILE__)

    # Copy all project *.nuspec to nuget build folder before editing
    FileUtils.cp_r nuspecs, "#{OUTPUT}/nuget"
    nuspecs = FileList["#{OUTPUT}/nuget/*.nuspec"]

    # Update the copied *.nuspec files to correct version numbers and other common values
    nuspecs.each do |nuspec|
        update_xml nuspec do |xml|
            # Override common values
            xml.root.elements["metadata/authors"].text = "Devtist"
            xml.root.elements["metadata/owners"].text = "Devtist"
            xml.root.elements["metadata/licenseUrl"].text = "https://github.com/devtist/Devtist/blob/master/license.txt"
            xml.root.elements["metadata/projectUrl"].text = "https://github.com/devtist/Devtist"
			xml.root.elements["metadata/version"].text = Version.current
            xml.root.elements["metadata/requireLicenseAcceptance"].text = "false"
            xml.root.elements["metadata/copyright"].text = "Copyright 2014 Devtist"
        end
    end

    # Generate the NuGet packages from the newly edited nuspec fileiles
    nuspecs.each do |nuspec|        
        nuget = NuGetPack.new
        nuget.command = "tools/nuget/nuget.exe"
        nuget.nuspec = "\"" + root + '/' + nuspec + "\""
        nuget.output = "#{OUTPUT}/nuget"
        nuget.parameters = "-Symbols", "-BasePath \"#{root}\""     #using base_folder throws as there are two options that begin with b in nuget 1.4
        nuget.execute
    end
end

desc "Pushes the nuget packages in the nuget folder up to the nuget gallery and symbolsource.org. Also publishes the packages into the feeds."
task :nuget_publish => [:nuget_package] do |task|
	if Kernel.is_windows? == true
		separator = "\\\\"
	else
		separator = "/"
	end
    nupkgs = FileList["#{OUTPUT}/nuget/*.nupkg"]
    nupkgs.each do |nupkg| 
		begin
			puts "Pushing #{nupkg}"
			nuget_push = NuGetPush.new
			nuget_push.command = "tools/nuget/nuget.exe"
			nuget_push.package = File.expand_path(nupkg).gsub("/", separator)
			nuget_push.create_only = false
			nuget_push.execute
		rescue
			puts "Skipping #{nupkg}"
		end
    end
end

def Kernel.is_windows?
  processor, platform, *rest = RUBY_PLATFORM.split("-")
	platform == 'mingw32'
end

def update_xml(xml_path)
    #Open up the xml file
    xml_file = File.new(xml_path)
    xml = REXML::Document.new xml_file
 
    #Allow caller to make the changes
    yield xml
 
    xml_file.close
         
    #Save the changes
    xml_file = File.open(xml_path, "w")
    formatter = REXML::Formatters::Default.new(5)
    formatter.write(xml, xml_file)
    xml_file.close
end