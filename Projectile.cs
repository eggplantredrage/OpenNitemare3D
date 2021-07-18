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
            anim.index = animations[(int)type].frames[0].index;
            anim.current = animations[(int)type];
            Game.player.AddSprite(this);
        }

        public override void Update()
        {
            anim.Update();
            position += direction * speed * Time.dt;
            spritePosition = position;
            spriteIndex = anim.index;
        }
    }
}