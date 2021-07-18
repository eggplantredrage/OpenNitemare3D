namespace Nitemare3D
{
    public class FuseBox : Tile
    {
        public override void Create()
        {
            Level.tilemap[x, y].textureID = 27;
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