using System;
using SFML.System;
using SFML.Audio;
using MeltySynth;

/*
C# Synth (http://csharpsynthproject.codeplex.com):
Copyright (C) 2014 Alex Veltsistas

TinySoundFont (https://github.com/schellingb/TinySoundFont):
Copyright (C) 2017-2018 Bernhard Schelling (Based on SFZero, Copyright (C) 2012 Steve Folta, https://github.com/stevefolta/SFZero)

MeltySynth:
Copyright (C) 2021 Nobuaki Tanaka

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
of the Software, and to permit persons to whom the Software is furnished to do
so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

namespace Nitemare3D
{

    public class MidiPlayer : IDisposable
    {
        private MidiSoundStream stream;

        public MidiPlayer(string soundFontPath)
        {
            stream = new MidiSoundStream(soundFontPath, 44100);
        }

        public void Play(MidiFile midiFile, bool loop)
        {
            stream.SetMidiFile(midiFile, loop);
        }

        public void Dispose()
        {
            if (stream != null)
            {
                stream.Dispose();
                stream = null;
            }
        }



        private class MidiSoundStream : SoundStream
        {
            private Synthesizer synthesizer;
            private float[] left;
            private float[] right;

            private MidiFileSequencer sequencer;

            private int blocksPerBatch;
            private int batchLength;
            private short[] batch;

            private object mutex;

            public MidiSoundStream(string soundFontPath, int sampleRate)
            {
                synthesizer = new Synthesizer(soundFontPath, sampleRate);
                left = new float[synthesizer.BlockSize];
                right = new float[synthesizer.BlockSize];

                sequencer = new MidiFileSequencer(synthesizer);

                var blockDuration = (double)synthesizer.BlockSize / synthesizer.SampleRate;
                blocksPerBatch = (int)Math.Ceiling(0.02 / blockDuration);
                batchLength = synthesizer.BlockSize * blocksPerBatch;
                batch = new short[2 * batchLength];

                mutex = new object();

                Initialize(2, (uint)sampleRate);

                Volume = 50;
            }

            public void SetMidiFile(MidiFile midiFile, bool loop)
            {
                lock (mutex)
                {
                    sequencer.Play(midiFile, loop);
                }

                if (Status == SoundStatus.Stopped)
                {
                    Play();
                }
            }

            protected override bool OnGetData(out short[] samples)
            {
                lock (mutex)
                {
                    var t = 0;

                    for (var i = 0; i < blocksPerBatch; i++)
                    {
                        sequencer.ProcessEvents();
                        synthesizer.Render(left, right);

                        for (var j = 0; j < left.Length; j++)
                        {
                            var sampleLeft = (int)(32768 * left[j]);
                            if (sampleLeft < short.MinValue)
                            {
                                sampleLeft = short.MinValue;
                            }
                            else if (sampleLeft > short.MaxValue)
                            {
                                sampleLeft = short.MaxValue;
                            }

                            var sampleRight = (int)(32768 * right[j]);
                            if (sampleRight < short.MinValue)
                            {
                                sampleRight = short.MinValue;
                            }
                            else if (sampleRight > short.MaxValue)
                            {
                                sampleRight = short.MaxValue;
                            }

                            batch[t++] = (short)sampleLeft;
                            batch[t++] = (short)sampleRight;
                        }
                    }

                    samples = batch;
                }

                return true;
            }

            protected override void OnSeek(SFML.System.Time timeOffset)
            {
                PlayingOffset = SFML.System.Time.FromMilliseconds((timeOffset.AsMilliseconds()) / 1000 * 44100);


            }


        }
    }

}