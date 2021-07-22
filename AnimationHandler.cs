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
        static int animCount = 0;
        public int id;
        public int duration; //duration in ms
        public List<AnimationFrame> frames = new List<AnimationFrame>();
        public bool loop;

        public Action onEnd;

        public Animation(int start, int count, int duration, bool loop = true, Action onEnd = null)
        {
            for (int i = start; i < start + count; i++)
            {
                AnimationFrame anim = new AnimationFrame();
                anim.index = i;
                frames.Add(anim);
            }

            id = animCount;
            animCount++;

            this.onEnd = onEnd;

            this.duration = duration;
            this.loop = loop;
        }
    }

    public sealed class AnimationHandler
    {

        public int index;
        int frameIndex = 0;
        Animation current;
        float timer;
        int currentID = -1;


        //returns false if asked to play the same animation or if the current animation is not completed
        public bool LoadAnimation(Animation anim)
        {

            if(currentID == anim.id){return false;}

            if(currentID > -1)
            {
                //return if current anim is not done
                if(frameIndex < current.frames.Count-1){return false;}
            }
            

            current = anim;
            currentID = anim.id;
            index = current.frames[0].index;
            timer = 0;
            frameIndex = 0;
            return true;
        }

        public void Update()
        {
            timer += Time.dt * 1000;
            if (timer > current.duration)
            {
                timer = 0;
                frameIndex++;
                if (frameIndex >= current.frames.Count)
                {
                    if (current.loop)
                    {
                        frameIndex = 0;
                    }
                    else
                    {
                        frameIndex = current.frames.Count-1;
                    }
                    current.onEnd?.Invoke();
                    timer = 0;
                }                


            }
            index = current.frames[frameIndex].index;
        }
    }
}