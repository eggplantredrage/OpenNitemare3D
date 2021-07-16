namespace Nitemare3D
{
    public class FuseBox : TileEntity
    {
        public override void Create(int id)
        {
            Level.tilemap[x, y] = 27;
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