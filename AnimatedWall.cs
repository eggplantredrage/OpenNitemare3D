using System;
namespace Nitemare3D
{
    public class AnimatedWall : TileEntity
    {
        AnimationHandler anim = new AnimationHandler();
        int startSprite;
        public AnimatedWall(int start, int count)
        {
            anim.current = new Animation(start, start + count, 1000 / count);
            anim.index = start;
        }
        public override void Create(int id)
        {
            startSprite = Level.tilemap[x, y];
        }

        public override void OnShoot()
        {
        }

        public override void OnUse()
        {
        }

        public override void Update()
        {
            Level.tilemap[x, y] = (byte)anim.index;
            anim.Update();
        }
    }
}