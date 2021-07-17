namespace Nitemare3D
{
    public class Curtain : Tile
    {
        public override void OnUse()
        {
            SoundEffect.PlaySound(SoundConsts.CURTAIN_OPEN);
        }
    }
}