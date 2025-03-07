using System.IO;
using System;
using System.Collections.Generic;
namespace Nitemare3D
{
	public class Game : Scene
	{
		Pcx hud = new Pcx(Dat.Uif[ImageConsts.UI_HUD]);
		int[] music = new int[]
		{
			MidiConsts.MIDI_E1M1,
			MidiConsts.MIDI_INTERMISSION
		};
		public const string gameTitle = "Nitemare 3D 0.46";
		


		public static Player player;
		public static int episode = 1;
		public override void Load()
		{
			songid = music[1];
			pcx = hud;

			player = Entity.Create<Player>();

			Level.LoadMap(level, episode);
		}

		public override void UnLoad()
		{
		}

		public static int level = 0;

		public override void Update()
		{
			songid = music[level];
			//Entity.UpdateEntites();
			//player.RenderRaycaster();
		}
	}
}