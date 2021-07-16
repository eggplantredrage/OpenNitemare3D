namespace Nitemare3D
{
    public class PlayerMagicWand : PlayerWeapon
    {
        public PlayerMagicWand()
        {
            texture = ImageConsts.UI_MAGICWAND;
            fireTime = .3f;
            fireSound = new SoundEffect(SoundConsts.WEAPON_MAGICWAND);
        }
        public override void Fire()
        {

        }
    }
}