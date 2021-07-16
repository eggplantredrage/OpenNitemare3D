namespace Nitemare3D
{
    public class PlayerPlasmaPistol : PlayerWeapon
    {
        public PlayerPlasmaPistol()
        {
            texture = ImageConsts.UI_PLASMAGUN;
            fireTime = .3f;
            fireSound = new SoundEffect(SoundConsts.WEAPON_PLASMA);
        }
        public override void Fire()
        {
        }
    }
}