using System.IO;
using System;
using System.Collections.Generic;
namespace Nitemare3D
{
    public class Game : Menu
    {
        Pcx hud = new Pcx(Dat.Uif[ImageConsts.UI_HUD]);
        int[] music = new int[]
        {
            MidiConsts.MIDI_E1M1,
            MidiConsts.MIDI_INTERMISSION
        };




        public static Player player;





        public Game(int episode, int level)
        {
            Console.WriteLine("game");
            songid = music[1];
            pcx = hud;
            this.level = level;


            player = Entity.Create<Player>();

            Level.LoadMap(level, episode);

        }


        int level = 0;

        public override void Update()
        {
            songid = music[level];
        }
    }
}