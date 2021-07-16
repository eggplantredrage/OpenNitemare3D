using static SFML.Window.Keyboard;
using SFML.Window;
using System;
namespace Nitemare3D
{

    public enum KeyboardKey
    {
        Enter = Key.Enter,
        Up = Key.Up,
        Down = Key.Down,
        Left = Key.Left,
        Right = Key.Right,
        Space = Key.Space,
        Num1 = Key.Num1,
        Num2 = Key.Num2,
        Num3 = Key.Num3,
        Num4 = Key.Num4,

        Backspace = Key.Backspace,

        LControl = Key.LControl,

        F1 = Key.F1,
        F2 = Key.F2,
        F3 = Key.F3,
        F4 = Key.F4,
        F5 = Key.F5
    }


    public static class Input
    {


        static int numberInput = -1;

        const float textInputTime = .1f;
        static float textInputTimer = 0;

        public static string text = string.Empty;
        static void OnTextEnter(object sender, TextEventArgs e)
        {
            if (textInputTime > textInputTimer) { return; }
            numberInput = -1;
            int num;
            bool isNumber = int.TryParse(e.Unicode, out num);
            if (isNumber)
            {
                numberInput = num;
            }


            if (e.Unicode == "\b" || e.Unicode == "\n")
            {
                return;
            }

            text = e.Unicode;



        }



        //returns -1 if input is not a number
        public static int GetNumberInput()
        {
            return numberInput;
        }

        public static bool LeftClick()
        {
            return Mouse.IsButtonPressed(Mouse.Button.Left);
        }

        public static void Update()
        {
            textInputTimer += Time.dt;
            text = string.Empty;
            numberInput = -1;
        }

        public static void Init()
        {
            GameWindow.sfWindow.TextEntered += new EventHandler<TextEventArgs>(OnTextEnter);
        }
        public static bool IsKeyDown(KeyboardKey key)
        {

            return IsKeyPressed((Key)key) && GameWindow.sfWindow.HasFocus();
        }

    }
}