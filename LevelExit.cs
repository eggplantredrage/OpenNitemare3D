using System;
namespace Nitemare3D
{
    public class LevelExit : TileEntity
    {
        public override void Create(int id)
        {
        }

        public override void OnShoot()
        {
        }

        public override void OnUse()
        {
            Level.LoadMap(1, 1);
        }

        public override void Update()
        {
        }
    }
}