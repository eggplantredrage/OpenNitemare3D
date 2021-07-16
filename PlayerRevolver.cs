namespace Nitemare3D
{
    public class PlayerRevolver : PlayerWeapon
    {
        public PlayerRevolver()
        {
            texture = ImageConsts.UI_REVOLVER;
            fireSound = SoundConsts.WEAPON_REVOLVER01;
            fireTime = .5f;
        }

        public override void Fire()
        {
        }
    }
}