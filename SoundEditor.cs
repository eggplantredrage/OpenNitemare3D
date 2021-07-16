using System.Collections.Generic;
using System.IO;
using System;
namespace Nitemare3D
{
	public class SoundEditor : Scene
	{

		int soundCount;
		int index = 0;
		string name = "";

		List<string> names = new List<string>();


		void LoadSoundNames()
		{
			var lines = File.ReadAllLines("SoundConsts.cs");

			for (int i = 0; i < names.Count; i++)
			{
				names[i] = lines[i + 4].Split(' ')[3];
			}
		}


		float inputTime = .3f;
		float inputTimer = .3f;

		public override void Update()
		{
			GameWindow.DrawText(0, 150, "Name: " + name, 31);
			GameWindow.DrawText(0, 160, "Left Click to play sound", 31);
			if (name.Length > 0)
			{
				names[index] = name;
			}
			GameWindow.DrawText(0, 230, "Press F5 to save, F1 to exit", 31);
			name += Input.text;


			inputTimer += Time.dt;

			if (Input.IsKeyDown(KeyboardKey.Left) && inputTimer > inputTime)
			{

				inputTimer = 0;
				index--;
				if(index < 0){index++;}
				name = names[index];
			}

			if (Input.IsKeyDown(KeyboardKey.Right) && inputTimer > inputTime)
			{
				inputTimer = 0;
				index++;
				if(index > Dat.Snd.Count){index--;}
				name = names[index];
			}

			if (Input.LeftClick() && inputTimer > inputTime)
			{
				inputTimer = 0;
				SoundEffect.PlaySound(SoundEffect.soundOffset + index);
			}

			if (Input.IsKeyDown(KeyboardKey.F5) && inputTimer > inputTime)
			{
				GenerateCSFile();
				inputTimer = 0;
			}

			if (Input.IsKeyDown(KeyboardKey.Backspace) && inputTimer > inputTime)
			{
				if (name.Length > 0)
				{
					name = name.Substring(0, name.Length - 1);
				}

			}

		}

		void GenerateCSFile()
		{
			var file = File.CreateText("SoundConsts.cs");

			file.WriteLine("namespace Nitemare3D\n{\n\tpublic static class SoundConsts\n\t{");

			for (int i = 0; i < names.Count; i++)
			{
				int index = SoundEffect.soundOffset + i;
				file.WriteLine("\t\tpublic const int " + names[i].Replace("\n", string.Empty) + " = " + index + ";");
			}

			file.WriteLine("\t}\n}");

			file.Close();
		}

		public override void Load()
		{
			soundCount = Dat.Snd.Count;
			songid = 0;
			//load sounds
			for (int i = SoundEffect.soundOffset; i < Dat.Snd.Count; i++)
			{
				var dat = Dat.Snd[i];
				names.Add("SND_" + i);
			}


			LoadSoundNames();

			name = names[index];
		}

		public override void UnLoad()
		{
		}
	}
}