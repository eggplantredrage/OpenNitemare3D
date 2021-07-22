namespace Nitemare3D
{
    public class HiddenPanel : Entity, IUsable
    {
        HiddenPanel neighbor = null;
        Tile current;
        public override void Start()
        {
            current = Level.tilemap[(int)position.X, (int)position.Y];
            current.thin = true;
            GetNeighbor();
            hasCollision = false;
        }

        void GetNeighbor() //checks if this is a double wide door
        {
            int x = (int)position.X;
            int y = (int)position.Y;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int neighbour_x = x + i;
                    int neighbour_y = y + j;
                    if (i == 0 && j == 0)
                    {
                    }
                    else if (neighbour_x < 0 || neighbour_y < 0 || neighbour_x >= 64 || neighbour_y >= 64)
                    {
                    }
                    else if (Level.tilemap[neighbour_x, neighbour_y].textureID == current.textureID)
                    {
                        //flipped[x, y] = true;
                        //bit hacky but yeah
                        foreach(var entity in Entity.entities)
                        {
                            var ex = (int)entity.position.X;
                            var ey = (int)entity.position.Y;
                            if(neighbour_x == ex && neighbour_y == ey)
                            {
                                if(entity is HiddenPanel panel)
                                {
                                    neighbor = panel; //should probably find a more efficient way to do this lool
                                }
                            }
                        }
                    }
                }
            }
        }

        public void OnUse()
        {
            SoundEffect.PlaySound(SoundConsts.HIDDENPANEL_OPEN);
            Level.tilemap[(int)position.X, (int)position.Y].state = TileState.opening;
            current.obstacle = false;
            current.textureID = -1;

            neighbor?.OnUse();
        }
    }
}