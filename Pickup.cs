namespace Nitemare3D
{
    public enum PickupType
    {
        RedKey,
        GreenKey,
        BlueKey,
        YellowKey,
        RedIDCard,
        YellowIDCard,
        RedPotion,
        BluePotion,
        Eyeball,
        CrystallBall,
        PlasmaPistol,
        MagicWand,
        Pistol,
        AutoPlasmaPistol

    }
    public class Pickup : Entity, ISprite
    {

        public int spriteIndex {get; set;}
        public Vec2 spritePosition{get;set;} = new Vec2();

        AnimationHandler anim = new AnimationHandler();


        static Animation[] animations = new Animation[]
        {
            new Animation(189, 1, 125), //red key
            new Animation(190, 1, 125), //green key
            new Animation(191, 1, 125), //blue key
            new Animation(192, 1, 125), //yellow key
            new Animation(193, 1, 125), //red card
            new Animation(194, 1, 125), //yellow card
            new Animation(204, 4, 125), //red potion
            new Animation(208, 4, 125), //blue potion
            new Animation(215, 6, 125), //eye thing
            new Animation(221, 6, 125), //crystal ball
            new Animation(235, 1, 125), //plasma pistol
            new Animation(236, 1, 125), //magic wand
            new Animation(237, 1, 125), //revolver
            new Animation(238, 1, 125)  //plasma auto pistol

        };

        PickupType type;

        public Pickup(PickupType type)
        {
            this.type = type;
            anim.current = animations[(int)type];
            Game.player.AddSprite(this);
            anim.index = animations[(int)type].frames[0].index;
        }

        public override void Update()
        {
            anim.Update();
            spriteIndex = anim.index;
            spritePosition = position;

            if((int)position.X == (int)Game.player.position.X && (int)position.Y == (int)Game.player.position.Y)
            {
                OnTouchPlayer();
            }
        }

        void OnTouchPlayer()
        {
            Entity.Remove(this);
            
        }
    }
}