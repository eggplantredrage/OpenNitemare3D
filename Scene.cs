using System;
using System.Collections.Generic;
namespace Nitemare3D
{

    //todo: fade in transition
    public abstract class Scene
    {
        public const int LEVEL_START = 0;
        public const int LEVEL_MAINMENU = 1;
        public const int LEVEL_LEVELSELECT = 2;
        public const int LEVEL_SOUNDEDITOR = 3;
        public const int LEVEL_GAME = 4;

        public Pcx pcx;
        public int songid;
        public abstract void Update();
        public abstract void Load();
        public abstract void UnLoad();
        static int currentMenu = 0;

        static List<Scene> menus = new List<Scene>();

        static int nextMenu;
        public bool fading = false;
        public byte alpha = 255;
        float fade = 255;
        float fadeAmount = 0;

        float loadTimer = 0;
        float loadTime = .25f;

        public static void Start()
        {
            menus[currentMenu].Load();
        }
        public void UpdateFading()
        {
            fade -= fadeAmount * Time.dt;
            alpha = (fade > 0) ? (byte)fade : (byte)0;
            if (fade < 1)
            {
                loadTimer += Time.dt;
                if (loadTimer > loadTime)
                {
                    menus[currentMenu].UnLoad();
                    menus[nextMenu].Load();
                    currentMenu = nextMenu;
                    
                }

            }
        }

        public static Scene currentScene{
            get{
                return menus[currentMenu];
            }
        }

        


        public static void AddScene(Scene scene)
        {
            menus.Add(scene);
        }

        public void FadeOut(int nextMenu, float fadeTime = 1f)
        {
            fading = true;
            fadeAmount = 255f / fadeTime;
            Scene.nextMenu = nextMenu;
        }


    }
}