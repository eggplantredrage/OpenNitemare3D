using System;
namespace Nitemare3D
{
    public class DumbObject : Entity, ISprite
    {
        public int spriteIndex { get;set; }
        public Vec2 spritePosition{get;set;} = new Vec2();
        public bool visible{get;set;} = true;
        public float yOffset{get;set;}
        public bool raised = false;
        public DumbObject(int index, bool raised = false)
        {
            spriteIndex = index;
            Game.player.AddSprite(this);
            this.raised = raised;

            if(raised)
            {
                yOffset = 64 + Img.current.entries[index].height;
            }
        }


        public override void Update()
        {
            spritePosition = position;
        }
    }
}