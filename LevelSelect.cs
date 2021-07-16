namespace Nitemare3D
{
    public class LevelSelect : Menu
    {

        const uint textX = 110;
        const uint textY = 80;
        public LevelSelect()
        {
            songid = MidiConsts.MIDI_FANTASIA;
            pcx = new Pcx(Dat.Uif[ImageConsts.MENU_CHOOSEEPISODE]);
        }

        float enterTime = .1f;
        float enterTimer = 0f;
        int selection = 0;
        const int episodeCount = 3;
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
                if (selection >= episodeCount) { selection = episodeCount - 1; }

                if (Input.IsKeyDown(KeyboardKey.Enter))
                {
                    FadeOut(new Game(selection + 1, 0), 1f);
                }
            }

            for (uint i = 1; i <= episodeCount; i++)
            {
                int color = (selection + 1 == i) ? 175 : 254;
                uint y = textY + (i * 20) - 20;
                GameWindow.DrawText(textX, y, "Episode " + i, color);
            }
        }
    }
}