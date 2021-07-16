namespace Nitemare3D
{
    public enum GuardType //theres probably other monster types I haven't played a full run in a while
    {
        Frankenstein,
        Human,
        Witch,
        Gargorle,
        Robot,
        Skeleton,
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

        AnimationHandler anim = new AnimationHandler();
        GuardType type;
        GuardState state = GuardState.idle;
        byte health = 100;
        const int SPRITE_FRANKENSTEIN_START = 322;
        const int FRANKENSTEIN_START = 0;

        static Animation[] animations = new Animation[]
        {
            new Animation(SPRITE_FRANKENSTEIN_START, SPRITE_FRANKENSTEIN_START, 125), //frankenstein idle
            new Animation(SPRITE_FRANKENSTEIN_START + 1, SPRITE_FRANKENSTEIN_START + 8, 125), //frankenstein walk
            new Animation(SPRITE_FRANKENSTEIN_START + 9, SPRITE_FRANKENSTEIN_START + 11, 333), //frankenstein die
            new Animation(SPRITE_FRANKENSTEIN_START + 12, SPRITE_FRANKENSTEIN_START + 15, 333) //frankenstein attack
        };

        public void Attack()
        {
            anim.current = animations[(int)type + 2];
        }

        public Guard(GuardType type)
        {
            this.type = type;
        }

        public override void Update()
        {
            spriteIndex = anim.index;
            spritePosition = position;
        }
    }
}