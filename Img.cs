using System;
using System.IO;
using System.Collections.Generic;
using SFML.Graphics;
namespace Nitemare3D
{
	public class BitmapImage
	{
		public byte width, height;
		public byte[,] data;
	}
	public class Img
	{
		public static Img current;
		public List<BitmapImage> entries = new List<BitmapImage>();


		void LoadEntries(List<UInt32> offsets, BinaryReader reader)
		{

			reader.BaseStream.Position = offsets[0];
			while (reader.BaseStream.Position != reader.BaseStream.Length)
			{
				BitmapImage image = new BitmapImage();

				image.width = reader.ReadByte();
				image.height = reader.ReadByte();

				image.data = new byte[image.width, image.height];

				reader.BaseStream.Position += 8; //idk what the 8 bytes are lolll


				for (int x = 0; x < image.width; x++)
				{
					for (int y = 0; y < image.height; y++)
					{
						image.data[x, y] = reader.ReadByte();
					}
				}

				int id = entries.Count;
				entries.Add(image);

			}


		}

		public Img(string file)
		{
			BinaryReader reader = new BinaryReader(File.OpenRead(file));
			reader.BaseStream.Position = 4;

			//honestly we don't even need the offsets since each entry has a width and height
			//smh David Gray
			List<UInt32> offsets = new List<UInt32>(); 
			int retval = 0;
			UInt32 offset;
			UInt32 lowestOffset = 0xFFFFFFFF;

			do
			{
				offset = reader.ReadUInt32();
				retval++;
				if (offset != 0)
				{
					offsets.Add(offset);
					if (offset < lowestOffset)
					{
						lowestOffset = offset;
					}
				}
			} while (reader.BaseStream.Position <= lowestOffset);


			LoadEntries(offsets, reader);
			reader.BaseStream.Close();
			current = this;
		}
	}
}