using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System.IO;
using System;
namespace Nitemare3D
{
    public static class GameWindow
    {
        public const int width = 320;
        public const int height = 200;
        static Image renderTarget = new Image(width, height);

        public static byte[] pal = new byte[1924];
        static Text sfText = new Text("DEBUG", new Font("data/FFFFORWA.TTF"), 7);

        public static byte[,] frameBuffer = new byte[width, height];
        public static RenderWindow sfWindow = new RenderWindow(new VideoMode(320, 240), "Nitemare 3D");

        public static void Init()
        {
            sfWindow.SetFramerateLimit(30);
            sfWindow.Closed += (sender, e) => sfWindow.Close();
            sfWindow.Resized += (sender, e) => PreserveAspectRatio();

            //load pal
            BinaryReader reader = new BinaryReader(File.OpenRead("data/GAME.PAL"));
            reader.BaseStream.Position = 1156;
            pal = reader.ReadBytes(768);

            reader.BaseStream.Close();

            rect.Texture = new Texture(renderTarget);
            // rect.Position = new Vector2f(8, 4);
        }


        public static byte GetDarkenedPixel(byte pixel)
        {

            var pixelRow = pixel / 10;
            if (pixelRow == 0) { return 0; }
            var newPixel = pixel - 10;

            if (newPixel / 10 != pixelRow)
            {
                newPixel = pixel;
            }

            return (byte)newPixel;
        }


        //todo: bitmap fonts
        public static void DrawText(uint x, uint y, string text, int color)
        {
            sfText.Position = new Vector2f(x, y);
            sfText.DisplayedString = text;
            var r = pal[3 * (color)];
            var g = pal[3 * (color) + 1];
            var b = pal[3 * (color) + 2];


            sfText.FillColor = new Color(r, g, b);
            sfWindow.Draw(sfText);
        }
        static RectangleShape rect = new RectangleShape(new Vector2f(320, 240));

        public static void Clear()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    frameBuffer[x, y] = 0;
                }
            }

            sfWindow.DispatchEvents();
            sfWindow.Clear();
        }


        public static void DrawFrameBuffer()
        {
            for (int x = 0; x < 320; x++)
            {
                for (int y = 0; y < 200; y++)
                {
                    var i = frameBuffer[x, y];
                    if (i == 0) { continue; }
                    var r = pal[3 * (i)];
                    var g = pal[3 * (i) + 1];
                    var b = pal[3 * (i) + 2];
                    renderTarget.SetPixel((uint)x, (uint)y, new Color(r, g, b));
                }
            }
            sfWindow.Draw(rect);
        }
        public static void Display()
        {
            rect.Texture = new Texture(renderTarget);



            GC.Collect();



            sfWindow.Display();


        }

        static float AspectRatio = 1.33333333f;

        static void PreserveAspectRatio()//mm letterboxing
        {
            var m_window_width = sfWindow.Size.X;
            var m_window_height = sfWindow.Size.Y;
            float new_width = AspectRatio * m_window_height;
            float new_height = m_window_width / AspectRatio;
            float offset_width = (m_window_width - new_width) / 2.0f;
            float offset_height = (m_window_height - new_height) / 2.0f;
            View view = sfWindow.GetView();
            if (m_window_width >= AspectRatio * m_window_height)
            {
                view.Viewport = new FloatRect(offset_width / m_window_width, 0.0f, new_width / m_window_width, 1.0f);
            }
            else
            {
                view.Viewport = new FloatRect(0.0f, offset_height / m_window_height, 1.0f, new_height / m_window_height);
            }

            sfWindow.SetView(view);
        }

        public static bool IsOpen()
        {
            return sfWindow.IsOpen;
        }


        public static void DrawImg(int id, Vec2i position)
        {
            var img = Img.current.entries[id];

            for (int tx = 0; tx < img.width; tx++)
            {
                for (int ty = 0; ty < img.height; ty++)
                {
                    var i = img.data[tx, ty];
                    if (i == 31) { continue; } //white is transparent

                    frameBuffer[tx + position.X, ty + position.Y] = i;

                }
            }
        }

        public static void DrawPcx()
        {
            if (Scene.currentScene.pcx == null) { return; }
            for (int x = 0; x < 320; x++)
            {
                for (int y = 0; y < 200; y++)
                {
                    var i = Scene.currentScene.pcx.ImageData[x, y];
                    if (i == 0) { continue; } //don't draw black pixels
                    frameBuffer[x,y] = i;
                }
            }
        }
    }
}