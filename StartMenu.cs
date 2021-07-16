using System;
namespace Nitemare3D
{
    public class StartMenu : Menu
    {
        Pcx menu = new Pcx(Dat.Uif[ImageConsts.MENU_MAIN]);
        Pcx start = new Pcx(Dat.Uif[ImageConsts.MENU_STARTSCREEN]);
        public StartMenu()
        {
            songid = MidiConsts.MIDI_HAUNTED_HOUSE_THEME;
            pcx = start;
        }


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
                FadeOut(new MainMenu(), .5f);
            }
        }
    }
}