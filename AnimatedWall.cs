using System;
namespace Nitemare3D
{
    public class AnimatedWall : Tile
    {
        AnimationHandler anim = new AnimationHandler();
        int startSprite;
        public AnimatedWall(int start, int count)
        {
            anim.LoadAnimation(new Animation(start, count, 1000 / count));
        }
        public override void Create()
        {
            textureID = anim.index;
            startSprite = anim.index;
        }

        public override void OnShoot()
        {
        }


        public override void Update()
        {
            textureID = anim.index;
            anim.Update();
        }
    }
}