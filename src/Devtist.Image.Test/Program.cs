using System;
using System.IO;
using System.Linq;

namespace Devtist.Image.Test
{
    class Program
    {
        static void Main()
        {
            var dir = new DirectoryInfo(@".\..\..\..\_Images\");
            foreach (var file in dir.GetFiles())
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine(file);
                try
                {
                    var data = ImageProcessor.RetrieveMetadata(file);
                    for (var i = 0; i < data.DirectoriesCount; i++)
                    {
                        Console.WriteLine("--- Directory " + i);
                        var tags = data.GetDirectory(i).ToArray();
                        foreach (var tag in tags)
                            Console.WriteLine(tag);
                    }
                }
                catch (Exception)
                {
                }
                Console.WriteLine("-----------------------------");
            }
            Console.ReadKey();
        }
    }
}
