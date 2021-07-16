using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
namespace Nitemare3D
{
    public sealed class Dat
    {
        public const string UifDir = "data/UIF.DAT";
        public const string SndDir = "data/SND.DAT";

        public static List<byte[]> Snd = new List<byte[]>();
        public static List<byte[]> Uif = new List<byte[]>();

        public static byte[] Pal = new byte[768];

        static List<byte[]> LoadDat(string file)
        {
            List<UInt32> offsets = new List<UInt32>();
            List<UInt16> lengths = new List<UInt16>();

            List<byte[]> output = new List<byte[]>();

            using (var reader = new BinaryReader(File.OpenRead(file), Encoding.Default, true))
            {


                while (true)
                {
                    var length = reader.ReadUInt16();
                    var offset = reader.ReadUInt32();


                    offsets.Add(offset);
                    lengths.Add(length);

                    if (offset + length == reader.BaseStream.Length)
                        break;

                }

                for (int i = 0; i < offsets.Count; i++)
                {
                    var offset = offsets[i];
                    var length = lengths[i];

                    reader.BaseStream.Position = offset;

                    output.Add(reader.ReadBytes(length));
                }

            }



            return output;
        }

        public static void Load()
        {
            Uif = LoadDat(UifDir);
            Snd = LoadDat(SndDir);

        }
    }
}