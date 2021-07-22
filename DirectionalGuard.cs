using System;
namespace Nitemare3D
{

    
    public class DirectionalGuard : Entity, ISprite
    {
        public GuardType type;
        byte angle; //8 possible angles;

        public int spriteIndex {get; set;}
        public Vec2 spritePosition{get;set;} = new Vec2();
        public bool visible{get;set;} = true;
        public float yOffset{get;set;}

        Vec2 velocity = new Vec2();
        Direction direction;
        float speed = 1f;



        

        public DirectionalGuard(GuardType type, Direction dir)
        {
            switch (type)
            {
                case GuardType.HumanGreen:
                    texOffset = 482;
                    break;
                case GuardType.HumanBlue:
                    texOffset = 434;
                    break;
                case GuardType.Witch:
                    break;
                case GuardType.Robot:
                    break;
                case GuardType.Penelope:
                    break;
                case GuardType.DRHammerstein:
                    break;
            }
            this.direction = dir;
            Game.player.AddSprite(this);
        }

        int texOffset;

        GuardState state = GuardState.patrol;
        /*
            Nitemare 3D has certain tiles used to guide the patrol state of certain guards,
            pretty clever I think
        */


        Vec2 MoveInCompassDirection()
        {
            switch (direction)
            {
                case Direction.NorthWest:
                    return new Vec2(-1, -1);
                case Direction.North:
                    return new Vec2(0, -1);
                case Direction.NorthEast:
                    return new Vec2(1, -1);
                case Direction.East:
                    return new Vec2(1, 0);
                case Direction.SouthEast:
                    return new Vec2(1, 1);
                case Direction.South:
                    return new Vec2(0, 1);
                case Direction.SouthWest:
                    return new Vec2(-1, 1);
                case Direction.West:
                    return new Vec2(-1, 0);
                default:
                    return new Vec2();
            }

        }
        void UpdatePatrol()
        {
            var x = MathF.Round(position.X);
            var y = MathF.Round(position.Y);
            var tile = Level.tilemap[(int)x, (int)y];

            //never eat soggy waffles
            switch(tile.type)
            {
                case WallType.turningpointN:
                    direction = Direction.North;
                    break;
                case WallType.turningpointNE:
                    direction = Direction.NorthEast;
                    break;
                case WallType.turningpointNW:
                    direction = Direction.NorthWest;
                    break;
                case WallType.turningpointE:
                    direction = Direction.East;
                    break;
                case WallType.turningpointS:
                    direction = Direction.South;
                    break;
                case WallType.turningpointSE:
                    direction = Direction.SouthEast;
                    break;
                case WallType.turningpointSW:
                    direction = Direction.SouthWest;
                    break;
                case WallType.turningpointW:
                    direction = Direction.West;
                    break;
                
            
            }
            velocity = MoveInCompassDirection();
        }
        void UpdateGuard()
        {
            switch (state)
            {
                case GuardState.idle:
                    break;
                case GuardState.chasing:
                    break;
                case GuardState.attacking:
                    break;
                case GuardState.dead:
                    break;
                case GuardState.patrol:
                    UpdatePatrol();
                    break;
            }
        }
    

        
        void HandleAnimation()
        {

        }

        public override void Update()
        {
            //todo calculate direction from velocity
            HandleAnimation();
            UpdateGuard();



            position += velocity * speed * Time.dt;


            spritePosition = position;

            spriteIndex = texOffset + (int)direction * 4;


        }
    }
}