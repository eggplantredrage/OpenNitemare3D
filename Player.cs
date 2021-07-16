using System;
namespace Nitemare3D
{
    public class Player : Entity
    {
        public int health = 100;


        public Vec2 plane = new Vec2(0, 0.66f);

        float walkSpeed = 3;
        float runSpeed = 5;
        public float rotation = 0;

        const int weaponCount = 4;
        int weaponIndex = 0;
        PlayerWeapon[] weapons = new PlayerWeapon[4]
        {
            new PlayerPlasmaPistol(),
            new PlayerMagicWand(),
            new PlayerRevolver(),
            new PlayerAutoPistol()
        };

        BitmapImage wall;

        const int WallTextureSize = 64;

        const int RayHeight = 152;
        const int RayWidth = 304;
        void RenderRaycaster()
        {
            var direction = new Vec2(MathF.Cos(rotation), MathF.Sin(rotation)).Normalize();





            bool flipped = false; 

            for (int x = 0; x < RayWidth; x++)
            {
                float cameraX = 2 * x / (float)RayWidth - 1; 


                float rayDirX = direction.X + plane.X * cameraX;
                float rayDirY = direction.Y + plane.Y * cameraX;

                int mapX = (int)position.X;
                int mapY = (int)position.Y;


                Vec2 sideDist = new Vec2();

                float deltaDistX = Math.Abs(1 / rayDirX);
                float deltaDistY = Math.Abs(1 / rayDirY);

                float perpWallDist;


                Vec2i step = new Vec2i();

                int hit = 0; 
                int side = 0;

                if (rayDirX < 0)
                {
                    step.X = -1;
                    sideDist.X = (position.X - mapX) * deltaDistX;
                }
                else
                {
                    step.X = 1;
                    sideDist.X = (mapX + 1.0f - position.X) * deltaDistX;
                }
                if (rayDirY < 0)
                {
                    step.Y = -1;
                    sideDist.Y = (position.Y - mapY) * deltaDistY;
                }
                else
                {
                    step.Y = 1;
                    sideDist.Y = (mapY + 1.0f - position.Y) * deltaDistY;
                }


                //weird DDA algorithm that I don't understand
                while (hit == 0)
                {
                    if (sideDist.X < sideDist.Y)
                    {
                        sideDist.X += deltaDistX;
                        mapX += step.X;
                        side = 0;
                    }
                    else
                    {
                        sideDist.Y += deltaDistY;
                        mapY += step.Y;
                        side = 1;
                    }





                    if (mapX < 0 || mapY < 0) { hit = 1; break; }
                    if (mapX > 63 || mapY > 63) { hit = 1; break; }

                    var wall = Level.tilemap[mapX, mapY];
                    if (wall <= 149 && wall > -1) { hit = 1; }

                    if (hit == 1)
                    {
                        flipped = Level.flipped[mapX, mapY];
                        this.wall = Img.current.entries[wall];

                    }



                }



                //Calculate distance projected on camera direction (Euclidean distance will give fisheye effect!)
                if (side == 0) perpWallDist = (mapX - position.X + (1 - step.X) / 2) / rayDirX;
                else perpWallDist = (mapY - position.Y + (1 - step.Y) / 2) / rayDirY;

                //Calculate height of line to draw on screen
                int lineHeight = (int)(RayHeight / perpWallDist);

                //calculate lowest and highest pixel to fill in current stripe
                int drawStart = -lineHeight / 2 + (int)RayHeight / 2;
                if (drawStart < 0) drawStart = 0;
                int drawEnd = lineHeight / 2 + (int)RayHeight / 2;
                if (drawEnd >= (int)RayHeight) drawEnd = (int)RayHeight - 1;


                var stepAmount = 1.0 * WallTextureSize / lineHeight;
                var texPos = (drawStart - (int)RayHeight / 2 + lineHeight / 2) * stepAmount;


                float wallX; 
                if (side == 0) wallX = position.Y + perpWallDist * rayDirY;
                else wallX = position.X + perpWallDist * rayDirX;
                wallX -= (float)Math.Floor((wallX));



                int texX = (int)(wallX * 64);

                if (flipped && wall.width > 64)
                {
                    texX += 64;
                }


                //draw ceiling
                for (int y = 0; y < drawStart; y++)
                {
                    GameWindow.frameBuffer[8 + x, 4 + y] = ImageConsts.PALETTE_CEILING;
                }


                if (drawEnd < RayHeight && drawEnd > 0)
                {
                    //draw floor
                    for (int y = drawEnd; y < RayHeight; y++)
                    {
                        GameWindow.frameBuffer[8 + x, 4 + y] = ImageConsts.PALETTE_FLOOR;
                    }
                }


                for (int y = drawStart; y < drawEnd; y++)
                {

                    int texY = (int)texPos & (WallTextureSize - 1);
                    texPos += stepAmount;

                    byte color = wall.data[texX, texY];
                    GameWindow.frameBuffer[8 + x, 4 + y] = color;




                }


            }

            if (Input.IsKeyDown(KeyboardKey.Space))
            {
                var tileFacing = position + direction;
                var tx = (int)tileFacing.X;
                int ty = (int)tileFacing.Y;
                if (Level.specialTiles[tx, ty] != null)
                {
                    Level.specialTiles[tx, ty].OnUse();
                }

            }




        }




        void RenderWeapon()
        {
            GameWindow.DrawImg(weapons[weaponIndex].texture, ImageConsts.UI_WEAPONPOSITION);

            GameWindow.DrawImg(ImageConsts.UI_FACE_START, ImageConsts.UI_FACEPOSITION);

            var input = Input.GetNumberInput();

            if (input > 0 && input <= weaponCount)
            {
                fireTimer = 0;
                weaponIndex = input - 1;
            }

            fireTimer += Time.dt;
            if (Input.IsKeyDown(KeyboardKey.LControl))
            {
                if (fireTimer > weapons[weaponIndex].fireTime)
                {
                    fireTimer = 0;
                    weapons[weaponIndex].Fire();
                    SoundEffect.PlaySound(weapons[weaponIndex].fireSound);
                }

            }
        }



        public Player()
        {
            wall = Img.current.entries[1];


        }
        float fireTimer = 0;

        public void SetRotation(float angle)
        {
            float oldRot = rotation;
            float oldPlaneX = plane.X;


            rotation = angle * (3.14f / 180);
            plane.X = plane.X * (float)Math.Cos(rotation - oldRot) - plane.Y * (float)Math.Sin(rotation - oldRot);
            plane.Y = oldPlaneX * (float)Math.Sin(rotation - oldRot) + plane.Y * (float)Math.Cos(rotation - oldRot);
        }

        public override void Update()
        {
            RenderRaycaster();
            RenderWeapon();

            float oldRot = rotation;

            if (Input.IsKeyDown(KeyboardKey.Right))
            {
                rotation += 3 * Time.dt;
            }

            if (Input.IsKeyDown(KeyboardKey.Left))
            {
                rotation -= 3 * Time.dt;
            }

            if (Input.IsKeyDown(KeyboardKey.Up))
            {
                var direction = new Vec2(MathF.Cos(rotation), MathF.Sin(rotation)).Normalize();


                position += direction * (Time.dt * walkSpeed);



            }

            float oldPlaneX = plane.X;

            plane.X = plane.X * (float)Math.Cos(rotation - oldRot) - plane.Y * (float)Math.Sin(rotation - oldRot);
            plane.Y = oldPlaneX * (float)Math.Sin(rotation - oldRot) + plane.Y * (float)Math.Cos(rotation - oldRot);


        }
    }
}