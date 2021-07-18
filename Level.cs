using System;
using System.IO;
using System.Collections.Generic;

/*
this file is ridicously long
*/
namespace Nitemare3D
{
    public static class Level
    {
        public static int levelCount;

        public static Tile[,] tilemap = new Tile[64, 64];

        static void SpawnMapObject(int id, int x, int y)
        {
            if(id == 0){return;}
            var position = new Vec2(x, y) + .5f;

            var type = (ObjectType)id;
            Entity ent = null;


            switch (type)
            {
                case ObjectType.Nothing:
                    break;
                case ObjectType.StartpositionN:
                    Game.player.position = position;
                    Game.player.SetRotation(-90);
                    break;
                case ObjectType.StartpositionE:
                    Game.player.position = position;
                    Game.player.SetRotation(0);
                    break;
                case ObjectType.StartpositionS:
                    Game.player.position = position;
                    Game.player.SetRotation(90);
                    break;
                case ObjectType.StartpositionW:
                    Game.player.position = position;
                    Game.player.SetRotation(180);
                    break;
                case ObjectType.Key1red:
                    ent = new Pickup(PickupType.RedKey);
                    break;
                case ObjectType.Key2green:
                    ent = new Pickup(PickupType.GreenKey);
                    break;
                case ObjectType.Key3blue:
                    ent = new Pickup(PickupType.BlueKey);
                    break;
                case ObjectType.Key4yellow:
                    ent = new Pickup(PickupType.YellowKey);
                    break;
                case ObjectType.Idcard1red:
                    ent = new Pickup(PickupType.RedIDCard);
                    break;
                case ObjectType.Idcard2yellow:
                    ent = new Pickup(PickupType.YellowIDCard);
                    break;
                case ObjectType.Officedesk:

                    break;
                case ObjectType.Diningroomtable:
                    ent = new DumbObject(199);
                    break;
                case ObjectType.Globeceilinglamp:
                    break;
                case ObjectType.Chandelierceilinglamp:
                    break;
                case ObjectType.Livingroomstandardlamp:
                    break;
                case ObjectType.Hallstandardlamp:
                    break;
                case ObjectType.Redpotionfullstrength:
                    break;
                case ObjectType.Bluepotionhalfstrength:
                    break;
                case ObjectType.Tombstonewithgrass:
                    break;
                case ObjectType.Tombstoneplain:
                    break;
                case ObjectType.Tombstonewithflower:
                    break;
                case ObjectType.Tombstonepushable:
                    break;
                case ObjectType.Magiceye:
                    ent = new Pickup(PickupType.Eyeball);
                    break;
                case ObjectType.Crystalball:
                    ent = new Pickup(PickupType.CrystallBall);
                    break;
                case ObjectType.Couch:
                    ent = new DumbObject(227);
                    break;
                case ObjectType.Easychair:
                    ent = new DumbObject(228);
                    break;
                case ObjectType.Bedsideview:
                    ent = new DumbObject(229);
                    break;
                case ObjectType.Bedfrontview:
                    ent = new DumbObject(230);
                    break;
                case ObjectType.Pentagramred:
                    break;
                case ObjectType.Pentagramgreen:
                    break;
                case ObjectType.Pentagramblue:
                    break;
                case ObjectType.Pentagramyellow:
                    break;
                case ObjectType.Singleboltplasmagun:
                    ent = new Pickup(PickupType.PlasmaPistol);
                    break;
                case ObjectType.Magicwand:
                    ent = new Pickup(PickupType.MagicWand);
                    break;
                case ObjectType.Pistol:
                    ent = new Pickup(PickupType.Pistol);
                    break;
                case ObjectType.Multiboltplasmagun:
                    ent = new Pickup(PickupType.AutoPlasmaPistol);
                    break;
                case ObjectType.Silverbullets:
                    break;
                case ObjectType.Plasmapowercell:
                    break;
                case ObjectType.Spellbookwandpower:
                    break;
                case ObjectType.Scroll01532:
                    break;
                case ObjectType.Scroll080993:
                    break;
                case ObjectType.Scroll372535:
                    break;
                case ObjectType.Firelarge:
                    break;
                case ObjectType.Firemedium:
                    break;
                case ObjectType.Firesmall:
                    break;
                case ObjectType.FlamingtorchP:
                    break;
                case ObjectType.Tallpotplantyellow:
                    break;
                case ObjectType.SmallpotplantredP:
                    break;
                case ObjectType.SmallpotplantyellowP:
                    break;
                case ObjectType.TV:
                    break;
                case ObjectType.Radio:
                    break;
                case ObjectType.BushP:
                    break;
                case ObjectType.Tree:
                    break;
                case ObjectType.Safe:
                    break;
                case ObjectType.Trunk:
                    break;
                case ObjectType.Boxone:
                    break;
                case ObjectType.Boxpileoftwo:
                    break;
                case ObjectType.Boxpileofthree:
                    break;
                case ObjectType.CeilingStalactite1:
                    break;
                case ObjectType.FloorStalagmite1:
                    break;
                case ObjectType.CeilingStalactite2:
                    break;
                case ObjectType.FloorandCeilingStals:
                    break;
                case ObjectType.CeilingStalactite3:
                    break;
                case ObjectType.FloorStalagmite2:
                    break;
                case ObjectType.Pedestal:
                    break;
                case ObjectType.StatueDemon:
                    break;
                case ObjectType.StatueDrHamerstein:
                    break;
                case ObjectType.Urnlarge:
                    break;
                case ObjectType.UrnsmallP:
                    break;
                case ObjectType.Urnsmallwvegetation:
                    break;
                case ObjectType.Urnlargewvegetation:
                    break;
                case ObjectType.Pedestalwhite:
                    break;
                case ObjectType.Pedestalwhitewflowers:
                    break;
                case ObjectType.Pedestallargewflowers:
                    break;
                case ObjectType.Pedestalsmallwflowers1P:
                    break;
                case ObjectType.Pedestalsmallwflowers2P:
                    break;
                case ObjectType.Specialmissileimpact:
                    break;
                case ObjectType.Secretpanel:
                    ent = new HiddenPanel();
                    break;
                case ObjectType.BatN:
                    ent = new Guard(GuardType.Bat);
                    break;
                case ObjectType.BatE:
                    ent = new Guard(GuardType.Bat);
                    break;
                case ObjectType.BatS:
                    ent = new Guard(GuardType.Bat);
                    break;
                case ObjectType.BatW:
                    ent = new Guard(GuardType.Bat);
                    break;
                case ObjectType.FrankensteinN:
                    ent = new Guard(GuardType.Frankenstein);
                    break;
                case ObjectType.FrankensteinE:
                    ent = new Guard(GuardType.Frankenstein);
                    break;
                case ObjectType.FrankensteinS:
                    ent = new Guard(GuardType.Frankenstein);
                    break;
                case ObjectType.FrankensteinW:
                    ent = new Guard(GuardType.Frankenstein);
                    break;
                case ObjectType.MummyN:
                    ent = new Guard(GuardType.Mummy);
                    break;
                case ObjectType.MummyE:
                    ent = new Guard(GuardType.Mummy);
                    break;
                case ObjectType.MummyS:
                    ent = new Guard(GuardType.Mummy);
                    break;
                case ObjectType.MummyW:
                    ent = new Guard(GuardType.Mummy);
                    break;
                case ObjectType.Dancers:
                    break;
                case ObjectType.SkeletonN:
                    ent = new Guard(GuardType.Skeleton);
                    break;
                case ObjectType.SkeletonE:
                    ent = new Guard(GuardType.Skeleton);
                    break;
                case ObjectType.SkeletonS:
                    ent = new Guard(GuardType.Skeleton);
                    break;
                case ObjectType.SkeletonW:
                    ent = new Guard(GuardType.Skeleton);
                    break;
                case ObjectType.MrsHN:
                    break;
                case ObjectType.MrsHE:
                    break;
                case ObjectType.MrsHS:
                    break;
                case ObjectType.MrsHW:
                    break;
                case ObjectType.ZeldaN:
                    break;
                case ObjectType.ZeldaE:
                    break;
                case ObjectType.ZeldaS:
                    break;
                case ObjectType.ZeldaW:
                    break;
                case ObjectType.VampiraN:
                    break;
                case ObjectType.VampiraE:
                    break;
                case ObjectType.VampiraS:
                    break;
                case ObjectType.VampiraW:
                    break;
                case ObjectType.Baddie1NBluecoat:
                    break;
                case ObjectType.Baddie1E:
                    break;
                case ObjectType.Baddie1S:
                    break;
                case ObjectType.Baddie1W:
                    break;
                case ObjectType.Baddie1MN:
                    break;
                case ObjectType.Baddie1ME:
                    break;
                case ObjectType.Baddie1MS:
                    break;
                case ObjectType.Baddie1MW:
                    break;
                case ObjectType.Baddie2NGreencoat:
                    break;
                case ObjectType.Baddie2E:
                    break;
                case ObjectType.Baddie2S:
                    break;
                case ObjectType.Baddie2W:
                    break;
                case ObjectType.Baddie2MN:
                    break;
                case ObjectType.Baddie2ME:
                    break;
                case ObjectType.Baddie2MS:
                    break;
                case ObjectType.Baddie2MW:
                    break;
                case ObjectType.DraculaN:
                    break;
                case ObjectType.DraculaE:
                    break;
                case ObjectType.DraculaS:
                    break;
                case ObjectType.DraculaW:
                    break;
                case ObjectType.CemetarywallGargoyleN:
                    break;
                case ObjectType.CemetarywallGargoyleE:
                    break;
                case ObjectType.CemetarywallGargoyleS:
                    break;
                case ObjectType.CemetarywallGargoyleW:
                    break;
                case ObjectType.GardenwallGargoyleN:
                    break;
                case ObjectType.GardenwallGargoyleE:
                    break;
                case ObjectType.GardenwallGargoyleS:
                    break;
                case ObjectType.GardenwallGargoyleW:
                    break;
                case ObjectType.PenelopeN:
                    break;
                case ObjectType.PenelopeE:
                    break;
                case ObjectType.PenelopeS:
                    break;
                case ObjectType.PenelopeW:
                    break;
                case ObjectType.PenelopeMN:
                    break;
                case ObjectType.PenelopeME:
                    break;
                case ObjectType.PenelopeMS:
                    break;
                case ObjectType.PenelopeMW:
                    break;
                case ObjectType.DrHamersteinN:
                    break;
                case ObjectType.DrHamersteinE:
                    break;
                case ObjectType.DrHamersteinS:
                    break;
                case ObjectType.DrHamersteinW:
                    break;
                case ObjectType.DrHamersteinMN:
                    break;
                case ObjectType.DrHamersteinME:
                    break;
                case ObjectType.DrHamersteinMS:
                    break;
                case ObjectType.DrHamersteinMW:
                    break;
                case ObjectType.CannonN:
                    break;
                case ObjectType.CannonE:
                    break;
                case ObjectType.CannonS:
                    break;
                case ObjectType.CannonW:
                    break;
                case ObjectType.SafeKeyred:
                    break;
                case ObjectType.SafeKeygreen:
                    break;
                case ObjectType.SafeKeyblue:
                    break;
                case ObjectType.SafeKeyyellow:
                    break;
                case ObjectType.SafeIDcardred:
                    break;
                case ObjectType.SafeIDcardyellow:
                    break;
                case ObjectType.TrunkPentagramHealth:
                    break;
                case ObjectType.TrunkPentagramAmmo:
                    break;
                case ObjectType.TrunkPentagramEyes:
                    break;
                case ObjectType.TrunkPentagramBalls:
                    break;
                case ObjectType.TrunkKeyred:
                    break;
                case ObjectType.creditcard:
                    break;
                case ObjectType.VISAcreditcard:
                    break;
                case ObjectType.Missileflyingplasmabolt:
                    break;
                case ObjectType.Missileexplodingplasmabolt:
                    break;
                case ObjectType.Missileflyingspellstars:
                    break;
                case ObjectType.Missileexplodingspellstars:
                    break;
            }
            if (ent != null)
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
                    else if (tilemap[neighbour_x, neighbour_y].textureID == current.textureID && !tilemap[neighbour_x, neighbour_y].flip)
                    {
                        //flipped[x, y] = true;
                        tilemap[x,y].flip = true;
                    }
                }
            }

        }

        static public void CreateTile(int x, int y, int id)
        {
            
            Tile tile = new Tile();
            var type = (WallType)id;

            int texture = -1;

            switch (type)
            {
                case WallType.Invalid:
                    break;
                case WallType.DiningRoomPlain:
                    texture = 0;
                    break;
                case WallType.DiningRoomSmallPicture:
                    texture = 1;
                    break;
                case WallType.DiningRoomSconces:
                    tile = new AnimatedWall(2,2);
                    break;
                case WallType.DiningRoomHutch:
                    tile = new AnimatedWall(4,2);
                    break;
                case WallType.DiningRoomLargePicture:
                    tile = new AnimatedWall(6,2);
                    break;
                case WallType.DiningRoomWindow:
                    texture = 8;
                    break;
                case WallType.DiningRoomCurtains:
                    texture = 9;
                    tile = new Curtain();
                    break;
                case WallType.DiningRoomPanelR:
                    texture = 10;
                    Entity.Create<HiddenPanel>(x,y);
                    break;
                case WallType.DiningRoomPanelL:
                    texture = 11;
                    Entity.Create<HiddenPanel>(x,y);
                    break;
                case WallType.LivingRoomPlain:
                    texture = 12;
                    break;
                case WallType.LivingRoomCurtains:
                    texture = 13;
                    tile = new Curtain();
                    break;
                case WallType.LivingRoomWindow:
                    texture = 14;
                    break;
                case WallType.LivingRoomBookcase:
                    texture = 15;
                    break;
                case WallType.LivingRoomFireplace:
                    tile = new AnimatedWall(16,8);
                    break;
                case WallType.LivingRoomPanelRight:
                    texture = 24;
                    Entity.Create<HiddenPanel>(x,y);
                    break;
                case WallType.LivingRoomPanelLeft:
                    texture = 25;
                    Entity.Create<HiddenPanel>(x,y);
                    break;
                case WallType.KitchenSinkArea:
                    texture = 26;
                    break;
                case WallType.KitchenFusebox:
                    texture = 27; //todo fusebox
                    break;
                case WallType.KitchenStoveArea:
                    texture = 28;
                    break;
                case WallType.KitchenPlain:
                    texture = 29;
                    break;
                case WallType.KitchenDoorredkey:
                    texture = 30;
                    break;
                case WallType.KitchenDoorstairsup:
                    texture = 31;
                    break;
                case WallType.KitchenDoorstairsdown:
                    texture = 32;
                    break;
                case WallType.KitchenPanelRight:
                    texture = 33;
                    Entity.Create<HiddenPanel>(x,y);
                    break;
                case WallType.KitchenPanelLeft:
                    texture = 34;
                    Entity.Create<HiddenPanel>(x,y);
                    break;
                case WallType.BeigeHallwayPlain:
                    texture = 35;
                    break;
                case WallType.BeigeHallwayPanelRight:
                    texture = 36;
                    Entity.Create<HiddenPanel>(x,y);
                    break;
                case WallType.BeigeHallwayPanelLeft:
                    texture = 37;
                    Entity.Create<HiddenPanel>(x,y);
                    break;
                case WallType.GreyHallwayPlain:
                    texture = 38;
                    break;
                case WallType.GreyHallwayPanelRight:
                    texture = 39;
                    Entity.Create<HiddenPanel>(x,y);
                    break;
                case WallType.GreyHallwayPanelLeft:
                    texture = 40;
                    Entity.Create<HiddenPanel>(x,y);
                    break;
                case WallType.GardenPlain:
                    texture = 41;
                    break;
                case WallType.GardenEyesRight:
                    texture = 42;//todo animated garden stuff
                    break;
                case WallType.GardenEyesLeft:
                    texture = 43;
                    break;
                case WallType.GardenGargoyle:
                    texture = 44;
                    break;
                case WallType.OfficePlain:
                    texture = 45;
                    break;
                case WallType.OfficeDesk:
                    tile = new AnimatedWall(46, 2);
                    break;
                case WallType.OfficeCabinets:
                    texture = 48;
                    break;
                case WallType.OfficeChalkboard:
                    tile = new AnimatedWall(105, 6);
                    break;
                case WallType.OfficeSconces:
                    tile = new AnimatedWall(50, 2);
                    break;
                case WallType.Bedroom1Plain:
                    texture = 52;
                    break;
                case WallType.Bedroom1Window:
                    texture = 53;
                    break;
                case WallType.Bedroom1Dresser:
                    texture = 54;
                    break;
                case WallType.Bedroom1Mirror:
                    texture = 55;
                    break;
                case WallType.Bedroom31DoorGreenkey:
                    texture = 56;
                    break;
                case WallType.Bedroom13DoorGreenkey:
                    texture = 57;
                    break;
                case WallType.ClosetFull:
                    texture = 58;
                    break;
                case WallType.ClosetPanelRight:
                    texture = 59;
                    Entity.Create<HiddenPanel>(x,y);
                    break;
                case WallType.ClosetPanelLeft:
                    texture = 60;
                    Entity.Create<HiddenPanel>(x,y);
                    break;
                case WallType.Bedroom2Window:
                    texture = 61;
                    break;
                case WallType.Bedroom21DoorBluekey:
                    texture = 62;
                    break;
                case WallType.Bedroom12DoorBluekey:
                    texture = 63;
                    break;
                case WallType.Bedroom2Plain:
                    texture = 64;
                    break;
                case WallType.Bedroom2Picture:
                    texture = 65;
                    break;
                case WallType.Kitcheninsideout:
                    texture = 66;
                    break;
                case WallType.Bedroom3PanelRight:
                    texture = 67;
                    Entity.Create<HiddenPanel>(x,y);
                    break;
                case WallType.Bedroom3PanelLeft:
                    texture = 68;
                    Entity.Create<HiddenPanel>(x,y);
                    break;
                case WallType.Kitchenpatiodoor:
                    texture = 69;
                    Entity.Create<HiddenPanel>(x,y);
                    break;
                case WallType.Bedroom3Plain:
                    texture = 70;
                    break;
                case WallType.Bedroom3Window:
                    texture = 71;
                    break;
                case WallType.Bedroom33Doorgreenkey:
                    texture = 72;
                    break;
                case WallType.KitchenRefridgeratorhalftile:
                    texture = 73;
                    break;
                case WallType.Bedroom3Doorstairsdown:
                    texture = 74;
                    break;
                case WallType.BeigeHallStairsuphalftile:
                    texture = 75;
                    break;
                case WallType.BeigeHallStairsdownhalftile:
                    texture = 76;
                    break;
                case WallType.BeigeHallStairsupanddown:
                    texture = 77;
                    break;
                case WallType.BeigeHallStairsdownandup:
                    texture = 78;
                    break;
                case WallType.Bedroom4Curtain:
                    texture = 79;
                    tile = new Curtain();
                    break;
                case WallType.Bedroom4Plain:
                    texture = 80;
                    break;
                case WallType.Bedroom4Window:
                    texture = 81;
                    break;
                case WallType.AtticPlain:
                    texture = 82;
                    break;
                case WallType.AtticTarget:
                    texture = 83;
                    break;
                case WallType.AtticMiceSpider:
                    texture = 84;
                    break;
                case WallType.AtticBoxesMouse:
                    texture = 85;
                    break;
                case WallType.AtticWindow:
                    texture = 86;
                    break;
                case WallType.AtticClothing:
                    texture = 87;
                    break;
                case WallType.AtticTrunk:
                    texture = 88;
                    break;
                case WallType.LivingRoomLargePicture:
                    texture = 89;
                    break;
                case WallType.DiningRoomSmallBookcase:
                    texture = 90;
                    break;
                case WallType.CemeteryPlain:
                    texture = 91;
                    break;
                case WallType.CemeteryGargoyle:
                    texture = 92;
                    break;
                case WallType.CemeteryCross:
                    texture = 93;
                    break;
                case WallType.CemeteryExplodableDoor:
                    texture = 94;
                    break;
                case WallType.CemeteryDisappearinggargoyle:
                    texture = 95;
                    break;
                case WallType.GardenDisappearinggargoyle:
                    texture = 100;
                    break;
                case WallType.OfficeMorphingchalkboard:
                    texture = 97;
                    break;
                case WallType.Bedroom4Swirlingmirror:
                    tile = new AnimatedWall(111, 6);
                    break;
                case WallType.Cave1:
                    texture = 117;
                    break;
                case WallType.Cave2:
                    texture = 118;
                    break;
                case WallType.KitchendoorYellowkey:
                    texture = 119;
                    break;
                case WallType.AtticExplodableTarget:
                    texture  = 122; //???
                    break;
                case WallType.Bedroom32Doorgreenkey:
                    break;
                case WallType.Bedroom23Doorgreenkey:
                    break;
                case WallType.Bedroom11Doorgreenkey:
                    break;
                case WallType.DiningRoomcurtainVC:
                    break;
                case WallType.DiningRoomcurtainHC:
                    break;
                case WallType.LivingRoomcurtainVC:
                    break;
                case WallType.LivingRoomcurtainHC:
                    break;
                case WallType.Bedroom4curtainVC:
                    break;
                case WallType.Bedroom4curtainHC:
                    break;
                case WallType.PatiodoorV:
                    break;
                case WallType.PatiodoorH:
                    break;
                case WallType.Jambforpatiodoors:
                    break;
                case WallType.LockeddoorredkeyVL:
                    break;
                case WallType.LockeddoorredkeyHL:
                    break;
                case WallType.LockeddoorgreenkeyVL:
                    break;
                case WallType.LockeddoorgreenkeyHL:
                    break;
                case WallType.LockeddoorbluekeyVL:
                    break;
                case WallType.LockeddoorbluekeyHL:
                    break;
                case WallType.LockeddooryellowkeyVL:
                    break;
                case WallType.LockeddooryellowkeyHL:
                    break;
                case WallType.Jambforlockeddoors:
                    break;
                case WallType.BedroomclosetdoorV:
                    break;
                case WallType.BedroomclosetdoorH:
                    break;
                case WallType.Jambforclosetdoor:
                    break;
                case WallType.DumbWaiter1bottom:
                    tile = new AnimatedWall(130, 16);
                    Entity.Create<Warp>(x,y);
                    break;
                case WallType.DumbWaiter1Top:
                    tile = new AnimatedWall(146, 16);
                    break;
                case WallType.DumbWaiter2bottom:
                    tile = new AnimatedWall(130, 16);
                    Entity.Create<Warp>(x,y);
                    break;
                case WallType.DumbWaiter2Top:
                    tile = new AnimatedWall(146, 16);
                    Entity.Create<Warp>(x,y);
                    break;
                case WallType.KitchenStairsup1:
                    break;
                case WallType.Bedroom3Stairsdown1:
                    break;
                case WallType.KitchenStairsup2:
                    break;
                case WallType.KitchenStairsdown2:
                    break;
                case WallType.KitchenStairsup3:
                    break;
                case WallType.BeigeHalldown3:
                    break;
                case WallType.BeigeHallup4:
                    break;
                case WallType.BeigeHalldown4:
                    break;
                case WallType.BeigeHallup5:
                    break;
                case WallType.BeigeHallupanddown5:
                    break;
                case WallType.Bedroom3down5:
                    break;
                case WallType.Gatewaytonextlevel:
                    break;
                case WallType.Gatewaytoskipalevel:
                    break;
                case WallType.Transportationchamberlefthalf:
                    break;
                case WallType.Transportationchamberrighthalf:
                    break;
                case WallType.Transportationchamberdoor1VI:
                    break;
                case WallType.Transportationchamberdoor1HI:
                    break;
                case WallType.Transportationchamberdoor2VI:
                    break;
                case WallType.Transportationchamberdoor2HI:
                    break;
                case WallType.Jambforchamberdoor:
                    break;
                case WallType.ElevatordoorV:
                    break;
                case WallType.ElevatordoorH:
                    break;
                case WallType.Jambforelevatordoor:
                    break;
                case WallType.OtherBR1Plain:
                    break;
                case WallType.OtherBR1Window:
                    break;
                case WallType.OtherBR1Dresser:
                    break;
                case WallType.OtherBR1Mirror:
                    break;
                case WallType.OtherBR1PanelRight:
                    break;
                case WallType.OtherBR1PanelLeft:
                    break;
                case WallType.Definesdancingguardslevel9:
                    break;
                case WallType.Trigger1:
                    break;
                case WallType.Trigger2:
                    break;
                case WallType.Floordeafguard:
                    break;
                case WallType.Floor1:
                    break;
                case WallType.Floor2:
                    break;
                case WallType.Floor3:
                    break;
                case WallType.Floor4:
                    break;
                case WallType.Floor5:
                    break;
                case WallType.Floor6:
                    break;
                case WallType.Floor7:
                    break;
                case WallType.Floor8:
                    break;
                case WallType.Floor9:
                    break;
                case WallType.Floor10:
                    break;
                case WallType.Floor11:
                    break;
                case WallType.Floor12:
                    break;
                case WallType.Floor13:
                    break;
                case WallType.Floor14:
                    break;
                case WallType.Floor15:
                    break;
                case WallType.Floor16:
                    break;
                case WallType.Floor17:
                    break;
                case WallType.Floor18:
                    break;
                case WallType.Floor19:
                    break;
                case WallType.Floor20:
                    break;
                case WallType.Floor21:
                    break;
                case WallType.Floor22:
                    break;
                case WallType.Floor23:
                    break;
                case WallType.Floor24:
                    break;
                case WallType.Floor25:
                    break;
                case WallType.Floor26:
                    break;
                case WallType.Floor27:
                    break;
                case WallType.Floor28:
                    break;
                case WallType.Floor29:
                    break;
                case WallType.Floor30:
                    break;
                case WallType.Floor31:
                    break;
                case WallType.Floor32:
                    break;
                case WallType.Floor33:
                    break;
                case WallType.Floor34:
                    break;
                case WallType.Floor35:
                    break;
                case WallType.Floor36:
                    break;
                case WallType.Floor37:
                    break;
                case WallType.retreatarrowN:
                    break;
                case WallType.retreatarrowNE:
                    break;
                case WallType.retreatarrowE:
                    break;
                case WallType.retreatarrowSE:
                    break;
                case WallType.retreatarrowS:
                    break;
                case WallType.retreatarrowSW:
                    break;
                case WallType.retreatarrowW:
                    break;
                case WallType.retreatarrowNW:
                    break;
                case WallType.retreatdeadend:
                    break;
                case WallType.turningpointN:
                    break;
                case WallType.turningpointNE:
                    break;
                case WallType.turningpointE:
                    break;
                case WallType.turningpointSE:
                    break;
                case WallType.turningpointS:
                    break;
                case WallType.turningpointSW:
                    break;
                case WallType.turningpointW:
                    break;
                case WallType.turningpointNW:
                    break;
                case WallType.fleefordoor:
                    break;
                case WallType.Safecombination333:
                    break;
                case WallType.Safecombination01532:
                    break;
                case WallType.Safecombination080993:
                    break;
                case WallType.Safecombination372535:
                    break;
                case WallType.Safecombination5:
                    break;
                case WallType.Safecombination6:
                    break;
                case WallType.Explodablegardenhedge:
                    break;
                case WallType.Genericexplodingwall:
                    break;
            }
            tile.x = (byte)x;
            tile.y = (byte)y;
            tile.textureID = texture;
            tilemap[x,y] = tile;
            tilemap[x,y].Create();
            HandleFlip(x, y);
        }



        public static void LoadMap(int id, int episode)
        {
            var map = new BinaryReader(File.OpenRead("data/MAP." + episode));

            map.BaseStream.Position = 514;
            var data = map.ReadBytes((int)map.BaseStream.Length);

            int x = 0, y = 0;
            int j = 0;

            for(int tx = 0; tx < 64; tx++)
            {
                for(int ty = 0; ty < 64; ty++)
                {
                    tilemap[tx,ty] = new Tile();
                }
            }

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
            foreach (var tile in tilemap)
            {
                tile?.Update();
            }
        }


    }
}