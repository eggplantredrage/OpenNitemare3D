using System;
namespace Nitemare3D
{
    public class MainMenu : Menu
    {
        const uint textX = 110;
        const uint textY = 60;

        float enterTime = .1f;
        float enterTimer = 0f;

        Pcx menu = new Pcx(Dat.Uif[ImageConsts.MENU_MAIN]);

        void LoadSoundEditor()
        {
            FadeOut(new SoundEditor(), 1f);
        }

        public MainMenu()
        {
            songid = MidiConsts.MIDI_FANTASIA;
            pcx = menu;
            menufunctions[0] = (Action)SelectLevel;
            menufunctions[5] = (Action)LoadSoundEditor;

        }


        string[] mainMenuItems = new string[]
        {
            "New game",
            "Configure game...",
            "Load game...",
            "Instructions",
            "Demo",
            "Sound Editor",
            "Quit"
        };




        Action[] menufunctions = new Action[6];



        void SelectLevel()
        {


            FadeOut(new LevelSelect(), 1f);

        }

        int selection = 0;
        public override void Update()
        {
            enterTimer += Time.dt;
            if (enterTimer > enterTime)
            {


                if (Input.IsKeyDown(KeyboardKey.Down))
                {
                    enterTimer = 0;
                    selection++;
                }
                if (Input.IsKeyDown(KeyboardKey.Up))
                {
                    enterTimer = 0;
                    selection--;
                }

                if (selection < 0) { selection = 0; }
                if (selection >= mainMenuItems.Length) { selection = mainMenuItems.Length - 1; }

                if (Input.IsKeyDown(KeyboardKey.Enter))
                {
                    menufunctions[selection].Invoke();
                }
            }

            for (uint i = 0; i < mainMenuItems.Length; i++)
            {
                int color = (selection == i) ? 175 : 254;
                uint y = textY + (i * 15);
                GameWindow.DrawText(textX, y, mainMenuItems[i], color);
            }


        }
    }
}