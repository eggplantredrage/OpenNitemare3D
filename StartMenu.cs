using System;
namespace Nitemare3D
{
    public class StartMenu : Scene
    {
        Pcx menu = new Pcx(Dat.Uif[ImageConsts.MENU_MAIN]);
        Pcx start = new Pcx(Dat.Uif[ImageConsts.MENU_STARTSCREEN]);


        float blinkTimer = 0;
        const int bpm = 126;
        const float blinkTime = 60f / bpm;

        void Blink()
        {
        }

        bool canStart = false;

        public override void Update()
        {
            if (blinkTimer > blinkTime)
            {
                canStart = true;

            }


            blinkTimer += Time.dt;

            if (Input.IsKeyDown(KeyboardKey.Enter) && canStart)
            {
                FadeOut(Scene.LEVEL_MAINMENU, .5f);
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void Load()
        {
            songid = MidiConsts.MIDI_HAUNTED_HOUSE_THEME;
            pcx = start;
        }

        public override void UnLoad()
        {
        }
    }
}