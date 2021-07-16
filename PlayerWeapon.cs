namespace Nitemare3D
{
    public abstract class PlayerWeapon
    {
        public int texture;
        public int ammo;
        public int fireSound;
        public float fireTime;


        public abstract void Fire();
    }
}