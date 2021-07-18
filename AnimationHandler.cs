using System;
using System.Collections.Generic;
namespace Nitemare3D
{

    public sealed class AnimationFrame
    {
        public int index;
        public Action action = null;
    }

    public sealed class Animation
    {
        public int duration; //duration in ms
        public List<AnimationFrame> frames = new List<AnimationFrame>();
        public bool loop;

        public Animation(int start, int count, int duration, bool loop = true)
        {
            for (int i = start; i < start + count; i++)
            {
                AnimationFrame anim = new AnimationFrame();
                anim.index = i;
                frames.Add(anim);
            }

            this.duration = duration;
            this.loop = loop;
        }
    }

    public sealed class AnimationHandler
    {

        public int index;
        public Animation current;
        float timer;

        public void Update()
        {
            timer += Time.dt * 1000;
            if (timer > current.duration)
            {
                timer = 0;
                int end = current.frames[current.frames.Count - 1].index;
                int start = current.frames[0].index;

                index++;
                if (index > end)
                {
                    if (current.loop)
                    {
                        index = current.frames[0].index;
                    }
                    else
                    {
                        index = end;
                    }
                }


            }
        }
    }
}