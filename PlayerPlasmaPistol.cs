namespace Nitemare3D
{
    public class PlayerPlasmaPistol : PlayerWeapon
    {
        public PlayerPlasmaPistol()
        {
            texture = ImageConsts.UI_PLASMAGUN;
            fireTime = .3f;
            fireSound = SoundConsts.WEAPON_PLASMA;
        }
        public override void Fire()
        {
            var p = new Projectile(Game.player.direction, ProjectileType.Plasma);
            Entity.Add(p, Game.player.position);
        }
    }
}