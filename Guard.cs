using System;
namespace Nitemare3D
{
    public enum GuardType //theres probably other monster types I haven't played a full run in a while
    {
        Frankenstein,
        Bat,
        Mummy,
        Skeleton,
        HumanGreen,
        HumanBlue,
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
        dead,
        patrol,
        roar
    }

    public enum GuardAnimation
    {
        idle,
        walk,
        roar,
        die,
        attack
    }

    public class Guard : Entity, ISprite
    {
        public int spriteIndex {get; set;}
        public Vec2 spritePosition{get;set;} = new Vec2();
        public bool visible{get;set;} = true;
        public float yOffset{get;set;}

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
            new Animation(SPRITE_FRANKENSTEIN_START + 1, 6, 125), //frankenstein walk
            new Animation(328, 3, 500, false), //frankenstein roar
            new Animation(SPRITE_FRANKENSTEIN_START + 9, 11, 333, false), //frankenstein die
            new Animation(SPRITE_FRANKENSTEIN_START + 12, 3, 333, true), //frankenstein attack

            new Animation(SPRITE_BAT_START, 1, 125),//bat idle
            new Animation(SPRITE_BAT_START+1, 3, 125),//bat fly
            new Animation(SPRITE_BAT_START, 1, 500, false), //bat roar
            new Animation(SPRITE_BAT_START + 9, 11, 125, false), //bat die
            new Animation(SPRITE_BAT_START+4, 8, 125), //bat attack

            new Animation(SPRITE_MUMMY_START, 1, 125), //mummy idle
            new Animation(SPRITE_MUMMY_START, 6, 125), //mummy walk
            new Animation(SPRITE_MUMMY_START, 6, 500), //mummy roar
            new Animation(SPRITE_MUMMY_START + 7, 3, 125, false), //mummy die
            new Animation(SPRITE_MUMMY_START + 10, 2, 125), //mummy attack
            new Animation(SPRITE_SKELETON_START, 1, 125), //skeleton idle
            new Animation(SPRITE_SKELETON_START, 3, 125), //skeleton walk
            new Animation(382, 4, 125, false), //skeleton die
            new Animation(374, 3, 125, false), //skeleton roar
            new Animation(378, 4, 125) //skeleton attack

        };

        bool PlayAnim(GuardAnimation animation)
        {
            return anim.LoadAnimation(animations[(int)type * Enum.GetValues<GuardAnimation>().Length + (int)animation]);
        }



        public Guard(GuardType type)
        {
            this.type = type;
            PlayAnim(GuardAnimation.idle);
            Game.player.AddSprite(this);

            switch (type)
            {
                case GuardType.Frankenstein:
                    attackTime = 2.5f;
                    break;
                case GuardType.Bat:
                    break;
                case GuardType.Mummy:
                    break;
                case GuardType.Skeleton:
                    attackRange = 10;
                    attackTime = 5;
                    break;
                case GuardType.HumanGreen:
                    break;
                case GuardType.HumanBlue:
                    break;
                case GuardType.Witch:
                    break;
                case GuardType.Gargorle:
                    break;
                case GuardType.Robot:
                    break;
                case GuardType.Penelope:
                    break;
                case GuardType.DRHammerstein:
                    break;
            }

            attackTimer = attackTime;

        }

        float roarTimer = 0;
        float roarTime = .5f;

        float attackTime, attackTimer;



        int range = 3;
        int attackRange = 1;
        void UpdateIdle()
        {
            PlayAnim(GuardAnimation.idle);
            var dist = Vec2.Distance(position, Game.player.position);
            if(dist <= range)
            {
                state = GuardState.roar;
            }
        }
        bool moving = false;


        Vec2 CalcNextPoint()
        {
            Vec2 current = new Vec2((int)MathF.Round(position.X), (int)MathF.Round(position.Y));
            Vec2[] points = new Vec2[5];
            points[0] = new Vec2(0, -1);
            points[1] = new Vec2(1, 0);
            points[2] = new Vec2(0, 1);
            points[3] = new Vec2(-1, 0);

            Vec2 closest = new Vec2(0,0);
            float closestDist = float.MaxValue;


            for(int i = 0; i < 4; i++)
            {
                if(Level.IsWalkable((int)current.X + (int)points[i].X, (int)current.Y + (int)points[i].Y, this))
                {
                    var dist = Vec2.Distance(new Vec2(current.X + points[i].X, current.Y + points[i].Y), Game.player.position);
                    if((int)dist < closestDist)
                    {
                        closestDist = dist;
                        closest = points[i];
                    }
                }
            

            }

            return closest;
        }
        Vec2 nextPosition = new Vec2();
        Vec2 targetPos = new Vec2();
        void UpdateChase()
        {
            PlayAnim(GuardAnimation.walk);

            var dist = Vec2.Distance(position, Game.player.position);
            if(dist <= attackRange)
            {
                state = GuardState.attacking;
                return;
            }

            moving = (targetPos.Equals(position.Rounded()));
            if(!moving)
            {
                nextPosition = CalcNextPoint();
                targetPos = position + nextPosition;
            }
            

            position += nextPosition * Time.dt;
        }


        void PlayRoar()
        {
            int snd = SoundConsts.GUARD_MONSTER_ALERT01;
            switch (type)
            {
                case GuardType.Frankenstein:
                    break;
                case GuardType.Bat:
                    snd = SoundConsts.GUARD_BAT_ALERT;
                    break;
                case GuardType.Mummy:
                    snd = SoundConsts.GUARD_MONSTER_ALERT02;
                    break;
                case GuardType.Skeleton:
                    snd = SoundConsts.GUARD_SKELETON_ALERT;
                    break;
                case GuardType.HumanGreen:
                    break;
                case GuardType.HumanBlue:
                    break;
                case GuardType.Witch:
                    snd = SoundConsts.GUARD_WITCH_ALERT01;
                    break;
                case GuardType.Gargorle:
                    break;
                case GuardType.Robot:
                    break;
                case GuardType.Penelope:
                    break;
                case GuardType.DRHammerstein:
                    break;
            }
            SoundEffect.PlaySound(snd);
        }


        public void ShootPlasma()
        {
            state = GuardState.dead;
        }

        void UpdateAttack()
        {
            var dist = Vec2.Distance(position, Game.player.position);
            if(dist > attackRange)
            {
                state = GuardState.chasing;
                return;
            }

            attackTimer += Time.dt;
            
            if(attackTimer > attackTime)
            {
                PlayAnim(GuardAnimation.attack);
                SoundEffect.PlaySound(SoundConsts.ATTACK_FRANKENSTEIN);
                attackTimer = 0;
            }else{
                PlayAnim(GuardAnimation.idle);
            }

        }


        void UpdateDead()
        {
            SoundEffect.PlaySound(SoundConsts.GUARD_HUMAN_DIE01);
            Entity.Remove(this);
            visible = false;
        }

        void UpdateState()
        {
            switch (state)
            {
                case GuardState.idle:
                    UpdateIdle();
                    break;
                case GuardState.chasing:
                    UpdateChase();
                    break;
                case GuardState.attacking:
                    UpdateAttack();
                    break;
                case GuardState.dead:
                    UpdateDead();
                    //or super death if you're a skeleton
                    break;
                case GuardState.patrol:
                    break;
                case GuardState.roar:
                    PlayAnim(GuardAnimation.roar);
                    PlayRoar();
                    roarTimer += Time.dt;
                    if(roarTimer > roarTime)
                    {
                        state = GuardState.chasing;
                        nextPosition = CalcNextPoint();
                        moving = true;
                        roarTimer = 0;
                    }
                    break;
            }
        }

        public override void Update()
        {
            UpdateState();
            anim.Update();
            spriteIndex = anim.index;
            spritePosition = position;
            
    
            if(type == GuardType.Bat && state != GuardState.idle)
            {
                yOffset += (32 - yOffset) * Time.dt;
            }
        }
    }
}