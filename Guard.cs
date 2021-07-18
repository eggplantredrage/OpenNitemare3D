namespace Nitemare3D
{
    public enum GuardType //theres probably other monster types I haven't played a full run in a while
    {
        Frankenstein,
        Bat,
        Mummy,
        Skeleton,
        Human,
        Witch,
        Gargorle,
        Robot,
        Penelope,
        DRHammerstein //big bad guy
    }

    public enum GuardState
    {
        idle,
        chasing,
        attacking,
        dead
    }

    public class Guard : Entity, ISprite
    {
        public int spriteIndex {get; set;}
        public Vec2 spritePosition{get;set;} = new Vec2();
        public bool visible{get;set;} = true;

        AnimationHandler anim = new AnimationHandler();
        GuardType type;
        GuardState state = GuardState.idle;
        byte health = 100;
        const int SPRITE_FRANKENSTEIN_START = 322;
        const int SPRITE_BAT_START = 310;
        const int SPRITE_MUMMY_START = 338;
        const int SPRITE_SKELETON_START = 370;

        static Animation[] animations = new Animation[]
        {
            new Animation(SPRITE_FRANKENSTEIN_START, 1, 125), //frankenstein idle
            new Animation(SPRITE_FRANKENSTEIN_START + 1, 8, 125), //frankenstein walk
            new Animation(SPRITE_FRANKENSTEIN_START + 9, 11, 333), //frankenstein die
            new Animation(SPRITE_FRANKENSTEIN_START + 12, 15, 333), //frankenstein attack
            new Animation(SPRITE_BAT_START, 1, 125),//bat idle
            new Animation(SPRITE_BAT_START+1, 3, 125),//bat fly
            new Animation(SPRITE_BAT_START+4, 8, 125), //bat attack
            new Animation(SPRITE_BAT_START + 9, 11, 125), //bat die
            new Animation(SPRITE_MUMMY_START, 1, 125), //mummy idle
            new Animation(SPRITE_MUMMY_START + 1, 6, 125), //mummy walk
            new Animation(SPRITE_MUMMY_START + 7, 3, 125), //mummy die
            new Animation(SPRITE_MUMMY_START + 10, 2, 125), //mummy attack
            new Animation(SPRITE_SKELETON_START, 1, 125), //skeleton idle
            new Animation(SPRITE_SKELETON_START, 4, 125), //skeleton walk
            new Animation(SPRITE_SKELETON_START, 1, 125)
        };

        public void Attack()
        {
            anim.current = animations[((int)type*4) + 1];
            anim.index = animations[(int)type+2].frames[0].index;
        }

        public Guard(GuardType type)
        {
            this.type = type;
            Attack();
            Game.player.AddSprite(this);
        }

        public override void Update()
        {
            anim.Update();
            spriteIndex = anim.index;
            spritePosition = position;
        }
    }
}