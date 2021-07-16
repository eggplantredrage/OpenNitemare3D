namespace Nitemare3D
{
    public class PlayerAutoPistol : PlayerWeapon
    {
        public PlayerAutoPistol()
        {
            texture = ImageConsts.UI_AUTOPLASMAGUN;
            fireTime = .2f;
            fireSound = new SoundEffect(SoundConsts.WEAPON_PLASMA);
        }

        public override void Fire()
        {
        }
    }
}