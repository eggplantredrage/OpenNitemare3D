using SFML.Audio;
using System.IO;
using System;
using System.Collections.Generic;
namespace Nitemare3D
{

    public class SoundEffect
    {
        const int sampleRate = 10989;
        const int volumeModifier = 80;
        Sound sound;
        public const int soundOffset = 34;//everything before that is midi or blank(idk why there's blank entries)

        static List<SoundEffect> effects = new List<SoundEffect>();

        public static void PlaySound(int id)
        {
            effects[id - soundOffset].Play();
        }

        public static void LoadSounds()
        {
            for(int i = soundOffset; i < Dat.Snd.Count; i++)
            {
                SoundEffect sound = new SoundEffect(i);
                effects.Add(sound);
            }
        }

        public SoundEffect(int index)
        {
            //todo: proper VOC support
            var reader = new BinaryReader(new MemoryStream(Dat.Snd[index]));
            if(reader.BaseStream.Length <= 0){return;}

            var samples = reader.ReadBytes((int)reader.BaseStream.Length);

            var b = Array.ConvertAll(samples, c => (short)(c * volumeModifier));
            sound = new Sound(new SoundBuffer(b, 1, sampleRate));
            reader.BaseStream.Close();
        }

        public void Play()
        {
            sound?.Play();
        }
    }
}