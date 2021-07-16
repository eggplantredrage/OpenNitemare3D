namespace Nitemare3D
{
    //basically just an entity with a reference to a tile (door, destructible wall, animated tile, etc)
    public abstract class TileEntity
    {
        public bool flipped = false;
        public int x, y;
        public abstract void OnUse();
        public abstract void OnShoot();
        public abstract void Update();

        public abstract void Create(int id);


    }

    public enum TileType
    {
        NULL,
        DR01,
        DR02,
        DR03,
        DR04,
        DR05,
        DR06,
        DR07,
        DR08,
        DR09,
        LR01,
        LR02,
        LR03,
        LR04,
        LR05,
        LR06,
        LR07,
        KI01,
        KI02,
        KI03,
        KI04,
        KI05A,
        KI05B,

        KI05C,
        KI07,
        KI08,
        HA01,
        HA02,
        HA03,
        HA04,
        HA05,
        HA06,
        GA01,
        GA02,
        GA03,
        GA04,
        OF01,
        OF02,
        OF03,
        OF04,
        OF05,
        BR01,
        BR02,
        BR03,
        BR04,
        BR05,
        BR06,
        CL01,
        CL02,
        CL03,
        BR07,
        BR08,
        BR09,
        BR10,
        BR11,
        KI09,
        BR13,
        BR14,
        KI10,
        BR16,
        BR17,
        BR18A,
        KI12,
        BR18C




    }
}