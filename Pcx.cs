using System.IO;
using System;
namespace Nitemare3D
{
    public sealed class Pcx
    {
        const int PcxHeaderStart = 65; //we don't really need much of the header
        const int PcxDataStart = 128;

        const int Width = 320;
        const int Height = 200;

        public byte[,] ImageData = new byte[Width, Height];

        byte[,] DecodePixels(BinaryReader reader)
        {
            byte[,] output = new byte[Width, Height];
            int y = 0;
            int x = 0;
            int bytesPerScanline = 320;


            while (y < 200)
            {
                var readByte = reader.ReadByte();

                var repeatCount = (readByte & 0x3F);

                if (!(x >= bytesPerScanline))
                {
                    if (0xC0 == (readByte & 0xC0))
                    {
                        readByte = reader.ReadByte();

                        while (repeatCount > 0)
                        {
                            output[x, y] = readByte;
                            repeatCount -= 1;
                            x += 1;
                        }
                    }
                    else
                    {
                        output[x, y] = readByte;
                        x += 1;
                    }
                }

                if (x >= bytesPerScanline)
                {
                    x = 0;
                    y += 1;
                }
            }
            return output;
        }



        public Pcx(byte[] data)
        {
            using (var reader = new BinaryReader(new MemoryStream(data)))
            {

                reader.BaseStream.Position = PcxHeaderStart;

                byte colorPlaneCount = reader.ReadByte();

                UInt16 scaleLineColorPlane = reader.ReadUInt16();

                reader.BaseStream.Position = PcxDataStart;


                ImageData = DecodePixels(reader);
                reader.BaseStream.Position++; //random last byte



            }
        }
    }
}