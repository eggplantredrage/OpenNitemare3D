using System;
using System.IO;
using System.Collections.Generic;
namespace Nitemare3D
{
    public static class Level
    {
        public static int levelCount;

        public static int[,] tilemap = new int[64, 64];
        public static TileEntity[,] specialTiles = new TileEntity[64, 64];
        public static bool[,] flipped = new bool[64, 64];

        static void SpawnMapObject(int id, int x, int y)
        {
            if(id == 0){return;}
            var position = new Vec2(x, y) + .5f;

            var type = (ObjectType)id;
            Entity ent = null;
            ent = new DumbObject(197);

            switch (type)
            {
                case ObjectType.NULL:
                    break;
                case ObjectType.STARTN:
                    Game.player.position = position;
                    Game.player.SetRotation(-90);
                    break;
                case ObjectType.STARTE:
                    Game.player.position = position;
                    Game.player.SetRotation(0);
                    break;
                case ObjectType.STARTS:
                    Game.player.position = position;
                    Game.player.SetRotation(90);
                    break;
                case ObjectType.STARTW:
                    Game.player.position = position;
                    Game.player.SetRotation(180);
                    break;
                case ObjectType.Key1:
                    break;
                case ObjectType.Key2:
                    break;
                case ObjectType.Key3:
                    break;
                case ObjectType.Key4:
                    break;
                case ObjectType.Card1:
                    break;
                case ObjectType.Card2:
                    break;
                case ObjectType.Desk:
                    break;
                case ObjectType.DiningRoomTable:
                    break;
                case ObjectType.Lamp1:
                    break;
                case ObjectType.Lamp2:
                    break;
                case ObjectType.Lamp3:
                    break;
                case ObjectType.Lamp4:
                    break;
                case ObjectType.RedPotion:
                    break;
                case ObjectType.BluePotion:
                    break;
                case ObjectType.TombGrass:
                    break;
                case ObjectType.TombPlain:
                    break;
                case ObjectType.TombFlower:
                    break;
                case ObjectType.TombPushable:
                    break;
                case ObjectType.MagicEye:
                    break;
                case ObjectType.CrystalBall:
                    break;
                case ObjectType.Couch:
                    break;
                case ObjectType.EasyChair:
                    break;
                case ObjectType.BedSide:
                    break;
                case ObjectType.BedFront:
                    break;
                case ObjectType.PentaGramRed:
                    break;
                case ObjectType.PentagramGreen:
                    break;
                case ObjectType.PentagramBlue:
                    break;
                case ObjectType.PentagramYellow:
                    break;
                case ObjectType.WeaponPlasma:
                    break;
                case ObjectType.WeaponMagicWand:
                    break;
                case ObjectType.WeaponPistol:
                    break;
                case ObjectType.WeaponAutoPlasma:
                    break;
                case ObjectType.AmmoSilverBullet:
                    break;
                case ObjectType.AmmoPlasma:
                    break;
                case ObjectType.AmmoSpellBook:
                    break;
                case ObjectType.Scroll01532:
                    break;
                case ObjectType.Scroll080993:
                    break;
                case ObjectType.Scroll372535:
                    break;
                case ObjectType.FireL:
                    break;
                case ObjectType.FireM:
                    break;
                case ObjectType.FireS:
                    break;

                default:
                    break;
            }
            if(ent != null)
            {
                Entity.Add(ent, position);
            }
        }


        public static void HandleFlip(int x, int y)
        {
            var current = tilemap[x, y];

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
                    else if (tilemap[neighbour_x, neighbour_y] == current && !flipped[neighbour_x, neighbour_y])
                    {
                        flipped[x, y] = true;
                    }
                }
            }

        }

        static public void CreateTile(int x, int y, int id)
        {
            TileEntity t = null;
            var type = (TileType)id;

            int texture = -1;

            switch (type)
            {
                case TileType.NULL:
                    texture = -1;
                    break;
                case TileType.DR01:
                    texture = 0;
                    break;
                case TileType.DR02:
                    texture = 1;
                    break;
                case TileType.DR03:
                    t = new AnimatedWall(2, 2);
                    texture = 2;
                    break;
                case TileType.DR04:
                    t = new AnimatedWall(4, 2);
                    texture = 4;
                    break;
                case TileType.DR05:
                    t = new AnimatedWall(6, 2);
                    texture = 6;
                    break;
                case TileType.DR06:
                    texture = 8;
                    break;
                case TileType.DR07:
                    t = new Curtain(TileType.DR07);
                    break;
                case TileType.DR08:
                    t = new HiddenWall();
                    texture = 10;
                    break;
                case TileType.DR09:
                    t = new HiddenWall();
                    texture = 11;
                    break;
                case TileType.LR01:
                    texture = 12;
                    break;
                case TileType.LR02:
                    t = new Curtain(TileType.LR02);
                    break;
                case TileType.LR03:
                    texture = 14;
                    break;
                case TileType.LR04:
                    texture = 15;
                    break;
                case TileType.LR05:
                    t = new AnimatedWall(16, 8);
                    texture = 16;
                    break;
                case TileType.LR06:
                    texture = 24;
                    break;
                case TileType.LR07:
                    texture = 25;
                    break;
                case TileType.KI01:
                    texture = 26;
                    break;
                case TileType.KI02:
                    texture = 27;
                    break;
                case TileType.KI03:
                    texture = 28;
                    break;
                case TileType.KI04:
                    texture = 29;
                    break;
                case TileType.KI05A:
                    texture = 30;
                    t = new LevelExit();
                    break;
                case TileType.KI05B:
                    texture = 31;
                    break;
                case TileType.KI05C:
                    texture = 32;
                    break;
                case TileType.KI07:
                    texture = 33;
                    break;
                case TileType.KI08:
                    texture = 34;
                    break;
                case TileType.HA01:
                    texture = 35;
                    break;
                case TileType.HA02:
                    texture = 36;
                    break;
                case TileType.HA03:
                    texture = 37;
                    break;
                case TileType.HA04:
                    texture = 38;
                    break;
                case TileType.HA05:
                    texture = 39;
                    break;
                case TileType.HA06:
                    texture = 40;
                    break;
                case TileType.GA01:
                    texture = 41;
                    break;
                case TileType.GA02:
                    texture = 42;
                    break;
                case TileType.GA03:
                    texture = 43;
                    break;
                case TileType.GA04:
                    texture = 44;
                    break;
                case TileType.OF01:
                    texture = 45;
                    break;
                case TileType.OF02:
                    texture = 46;
                    t = new AnimatedWall(46, 2);
                    break;
                case TileType.OF03:
                    texture = 48;
                    break;
                case TileType.OF04:
                    texture = 105;
                    t = new AnimatedWall(105, 6); //why are you all the way in 105???
                    break;
                case TileType.OF05:
                    t = new AnimatedWall(50, 2);
                    break;
                case TileType.BR01:
                    texture = 52;
                    break;
                case TileType.BR02:
                    texture = 53;
                    break;
                case TileType.BR03:
                    texture = 54;
                    break;
                case TileType.BR04:
                    texture = 55;
                    break;
                case TileType.BR05:
                    texture = 56;
                    break;
                case TileType.BR06:
                    texture = 57;
                    break;
                case TileType.CL01:
                    texture = 58;
                    break;
                case TileType.CL02:
                    t = new HiddenWall();
                    texture = 59;
                    break;
                case TileType.CL03:
                    t = new HiddenWall();
                    texture = 60;
                    break;
                case TileType.BR07:
                    texture = 61;
                    break;
                case TileType.BR08:
                    texture = 62;
                    t = new Warp(0);
                    break;
                case TileType.BR09:
                    texture = 63;
                    t = new Warp(0);
                    break;
                case TileType.BR10:
                    texture = 64;
                    break;
                case TileType.BR11:
                    texture = 65;
                    break;
                case TileType.KI09:
                    texture = 66;
                    break;
                case TileType.BR13:
                    t = new HiddenWall();
                    texture = 67;
                    break;
                case TileType.BR14:
                    t = new HiddenWall();
                    texture = 68;
                    break;
                case TileType.KI10:
                    texture = 69; //nice
                    break;
                case TileType.BR16:
                    texture = 70;
                    break;
                case TileType.BR17:
                    texture = 71;
                    break;
                case TileType.BR18A:
                    t = new Warp(3);
                    texture = 72;
                    break;
                case TileType.KI12:
                    texture = 73;
                    break;
                default:
                    break;
            }
            tilemap[x, y] = texture;
            HandleFlip(x, y);


            if (!(t == null))
            {
                t.x = x;
                t.y = y;
                specialTiles[x, y] = t;
            }
            t?.Create(id);
        }



        public static void LoadMap(int id, int episode)
        {
            var map = new BinaryReader(File.OpenRead("data/MAP." + episode));
            specialTiles = new TileEntity[64, 64];
            flipped = new bool[64, 64];

            map.BaseStream.Position = 514;
            var data = map.ReadBytes((int)map.BaseStream.Length);

            int x = 0, y = 0;
            int j = 0;

            for (int i = id * 8192; i < (id * 8192) + 8192; i++)
            {


                if (i % 2 == 0)
                {
                    int mx = j % 64;
                    int my = j / 64;
                    //tilemap[mx,my] = data[i];
                    CreateTile(mx, my, data[i]);
                    j++;
                }
                else
                {
                    SpawnMapObject(data[i], x, y);

                    x++;
                    if (x == 64)
                    {
                        x = 0;
                        y++;
                    }
                }
            }

            map.BaseStream.Close();
        }

        public static void Update()
        {
            foreach (var tile in specialTiles)
            {
                tile?.Update();
            }
        }


    }
}