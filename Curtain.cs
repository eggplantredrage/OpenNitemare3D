using System;
namespace Nitemare3D
{
    public class Curtain : TileEntity
    {
        const int LIVINGROOMCURTAIN_RED_SPRITE = 9;


        TileType type;
        public Curtain(TileType type)
        {
            this.type = type;
        }


        public override void Create(int id)
        {
            switch (type)
            {


                case TileType.DR07:
                    Level.tilemap[x, y] = LIVINGROOMCURTAIN_RED_SPRITE;
                    break;
                case TileType.LR02:
                    Level.tilemap[x, y] = LIVINGROOMCURTAIN_RED_SPRITE;
                    break;
                default:
                    break;
            }
        }

        public override void OnShoot()
        {
        }

        public override void OnUse()
        {
        }

        public override void Update()
        {
        }
    }
}