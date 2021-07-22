using System;
namespace Nitemare3D
{
    public enum ProjectileType
    {
        Plasma,
        Magic
    }
    public class Projectile : Entity, ISprite
    {


        static Animation[] animations = new Animation[]
        {
            new Animation(666, 2, 125), //plasma
            new Animation(671, 3, 125) //magic
        };

        AnimationHandler anim = new AnimationHandler();

        public int spriteIndex {get; set;}
        public bool visible{get;set;} = true;
        public Vec2 spritePosition{get;set;} = new Vec2();
        public float yOffset{get;set;}

        const float speed = 4;
        ProjectileType type;
        Vec2 direction;
        public Projectile(Vec2 direction, ProjectileType type)
        {
            this.direction = direction;
            this.type = type;
            anim.LoadAnimation(animations[(int)type]);
            Game.player.AddSprite(this);
            hasCollision = false;
        }

        public override void Update()
        {
            anim.Update();
            position += direction * speed * Time.dt;
            spritePosition = position;
            spriteIndex = anim.index;

            bool delete = false;

            
            foreach(var entity in entities)
            {
                if(entity.id == id || entity.id == Game.player.id){continue;}
                if(entity.position.Rounded().Equals(position.Rounded()))
                {
                    delete = entity.hasCollision;
                    entity.SendMessage("ShootPlasma");
                    return;
                }
            }

            if(!Level.IsWalkable((int)position.X, (int)position.Y, this))
            {
                delete = true;
            }

            if(delete){Entity.Remove(this); visible = false;}

        }
    }
}