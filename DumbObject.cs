using System;
namespace Nitemare3D
{
    public class DumbObject : Entity, ISprite
    {
        public int spriteIndex { get;set; }
        public Vec2 spritePosition{get;set;} = new Vec2();

        public DumbObject(int index)
        {
            spriteIndex = index;
            Game.player.AddSprite(this);
        }


        public override void Update()
        {
            spritePosition = position;
        }
    }
}