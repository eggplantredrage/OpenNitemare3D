using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System.IO;
using System;
namespace Nitemare3D
{
    public static class GameWindow
    {
        public static uint width = 320;
        public static uint height = 200;
        static Image renderTarget;
        public static float scale;

        public static byte[] pal = new byte[1924];
        static Text sfText = new Text("DEBUG", new Font("data/FFFFORWA.TTF"), 7);

        public static byte[,] frameBuffer;
        public static RenderWindow sfWindow;
        static RectangleShape rect;

        public static void Init()
        {

            //load config
            var config = File.ReadAllLines("config.ini");
            width = uint.Parse(config[0]);
            uint fps = uint.Parse(config[1]);

            height = (uint)(width / 1.6f);

            //to simulate tall pixels
            uint winHeight = (uint)(height * 1.2f);
            
            scale = width / 320;
            
            //init window
            sfWindow = new RenderWindow(new VideoMode(width, winHeight), Game.gameTitle);
            renderTarget = new Image(width, height);
            sfWindow.SetFramerateLimit(fps);
            sfWindow.Closed += (sender, e) => sfWindow.Close();
            sfWindow.Resized += (sender, e) => PreserveAspectRatio();

            rect = new RectangleShape(new Vector2f(width, winHeight));

            //init framebuffer
            frameBuffer = new byte[width, height];



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
            sfText.Position = new Vector2f(x, y) * scale;
            sfText.DisplayedString = text;
            sfText.Scale = new Vector2f(scale, scale);
            var r = pal[3 * (color)];
            var g = pal[3 * (color) + 1];
            var b = pal[3 * (color) + 2];


            sfText.FillColor = new Color(r, g, b);
            sfWindow.Draw(sfText);
        }
        

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
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
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


                    for(int px = (int)(tx * scale); px < (int)(tx * scale + scale); px++)
                    {
                        for(int py = (int)(ty * scale); py < (int)(ty * scale + scale); py++)
                        {
                            frameBuffer[(int)(position.X * scale) + px, (int)(position.Y * scale) + py] = i;
                        }
                    }

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

                    for(int px = (int)(x * scale); px < (int)(x * scale + scale); px++)
                    {
                        for(int py = (int)(y * scale); py < (int)(y * scale + scale); py++)
                        {
                            frameBuffer[px,py] = i;
                        }
                    }
                }
            }
        }
    }
}