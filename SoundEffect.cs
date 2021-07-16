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
        const int soundOffset = 34;//everything before that is midi or blank

        static List<SoundEffect> effects = new List<SoundEffect>();

        public static void PlaySound(int id)
        {
            effects[id + soundOffset].Play();
        }

        public SoundEffect(int index)
        {
            //todo versioning
            var reader = new BinaryReader(new MemoryStream(Dat.Snd[index]));

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