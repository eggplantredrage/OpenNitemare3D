using System;
using System.IO;
using System.Runtime.InteropServices;
using SFML.System;
namespace Nitemare3D
{
    class Program
    {

        [DllImport("X11")]
        extern public static int XInitThreads();
        static void Main(string[] args)
        {

            XInitThreads();

            Dat.Load();


            GameWindow.Init();
            Input.Init();

            Img i = new Img("data/IMG.1");

            Clock dt = new Clock();

            Menu.currentMenu = new StartMenu();




            while (GameWindow.IsOpen())
            {
                MusicPlayer.Play(Menu.currentMenu.songid);
                Time.dt = dt.Restart().AsSeconds();
                GameWindow.Clear();

                Entity.UpdateEntites();

                GameWindow.DrawFrameBuffer();
                GameWindow.DrawPcx();
                Level.Update();
                if (!Menu.currentMenu.fading)
                {
                    Menu.currentMenu.Update();
                }

                Input.Update();

                Menu.currentMenu.UpdateFading();
                GameWindow.Display();
            }




        }
    }
}
