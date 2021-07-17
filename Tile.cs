namespace Nitemare3D
{
    public enum TileState
    {
        solid,
        opening,
        closing
    }

    public class Tile
    {
        public int textureID = -1;
        public bool thin = false;
        public bool door = false;
        public byte x,y;
        public bool flip = false;
        float openAmount = 0;
        public TileState state = TileState.solid;
        
        public void UpdateDoorState()
        {
            switch (state)
            {
                case TileState.solid:
                    break;
                case TileState.opening:
                    openAmount += Time.dt;
                    if(openAmount > 1)
                    {
                        openAmount = 1;
                        state = TileState.solid;
                    }
                    break;
                case TileState.closing:
                    break;
            }
            
        }

        public virtual void OnUse(){}
        public virtual void Create(){}
        public virtual void OnShoot(){}
        public virtual void Update(){}
    }
}