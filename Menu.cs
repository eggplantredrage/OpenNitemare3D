using System;
using System.Collections.Generic;
namespace Nitemare3D
{
    public abstract class Menu
    {
        public Pcx pcx;
        public int songid;
        public abstract void Update();

        public static Menu currentMenu;

        Menu nextMenu;
        public bool fading = false;
        public byte alpha = 255;
        float fade = 255;
        float fadeAmount = 0;

        float loadTimer = 0;
        float loadTime = .25f;
        public void UpdateFading()
        {
            fade -= fadeAmount * Time.dt;
            alpha = (fade > 0) ? (byte)fade : (byte)0;
            if (fade < 1)
            {
                loadTimer += Time.dt;
                if (loadTimer > loadTime)
                {
                    currentMenu = nextMenu;
                }

            }
        }

        public void LoadPrevious()
        {

        }

        public void FadeOut(Menu nextMenu, float fadeTime)
        {
            fading = true;
            fadeAmount = 255f / fadeTime;
            this.nextMenu = nextMenu;
        }


        static List<Menu> menus = new List<Menu>();
    }
}