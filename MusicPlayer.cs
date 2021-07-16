using MeltySynth;
using System;
using System.IO;
namespace Nitemare3D
{
    public static class MusicPlayer
    {
        static MidiPlayer player = new MidiPlayer("TimGM6mb.sf2");
        static int songid;
        public static void Init(string sfFile)
        {
            player = new MidiPlayer(sfFile);
        }
        public static void Play(int id)
        {
            if (id == songid)
            {
                return;
            }
            Console.WriteLine("Playing song " + id);
            player.Play(new MidiFile(new MemoryStream(Dat.Snd[id])), true);
            songid = id;
        }
    }
}