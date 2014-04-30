namespace Devtist.Image.Exif.Tag
{
    public enum ExifTagCompressionType
    {
        Uncompressed = 1,
        CCITT1D = 2,
        T4 = 3,
        T6 = 4,
        Lzw = 5,
        JpegOldStyle = 6,
        Jpeg = 7,
        AdobeDeflate = 8,
        JBigBW = 9,
        JBigColor = 10,
        Jpeg99 = 99,
        Kodak262 = 262,
        Next = 32766
    }

    /*
32767	= Sony ARW Compressed
32769	= Packed RAW
32770	= Samsung SRW Compressed
32771	= CCIRLEW
32773	= PackBits
32809	= Thunderscan
32867	= Kodak KDC Compressed
32895	= IT8CTPAD
32896	= IT8LW
32897	= IT8MP
32898	= IT8BL
32908	= PixarFilm
32909	= PixarLog
32946	= Deflate
32947	= DCS
34661	= JBIG
34676	= SGILog
34677	= SGILog24
34712	= JPEG 2000
34713	= Nikon NEF Compressed
34715	= JBIG2 TIFF FX
34718	= Microsoft Document Imaging (MDI) Binary Level Codec
34719	= Microsoft Document Imaging (MDI) Progressive Transform Codec
34720	= Microsoft Document Imaging (MDI) Vector
34892	= Lossy JPEG
65000	= Kodak DCR Compressed
65535	= Pentax PEF Compressed
    */
}
