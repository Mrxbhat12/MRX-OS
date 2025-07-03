using Cosmos.System.Graphics;
using System;
using System.Drawing;
using MRX_OS.UI;

namespace MRX_OS.Apps
{
    public class Calculator : Window
    {
        private string input = "";
        private string result = "";

        public Calculator(int x, int y) : base(x, y, "Calculator") { }

        public override void DrawContent(Canvas canvas, int x, int y)
        {
            Drawing.DrawString(canvas, "Input: " + input, PCScreenFont.Default, Color.Black, x + 5, y + 5);
            Drawing.DrawString(canvas, "Result: " + result, PCScreenFont.Default, Color.Black, x + 5, y + 25);
        }

        public override void HandleInput()
        {
            base.HandleInput();

            if (KeyboardManager.TryReadKey(out var key))
            {
                if (key.Key == ConsoleKeyEx.Enter)
                {
                    try
                    {
                        result = new DataTable().Compute(input, null).ToString();
                    }
                    catch
                    {
                        result = "Error";
                    }
                    input = "";
                }
                else if (key.Key == ConsoleKeyEx.Backspace)
                {
                    if (input.Length > 0)
                        input = input.Substring(0, input.Length - 1);
                }
                else
                {
                    char c = KeyboardManager.KeyToChar(key.Key, key.Modifiers);
                    if (char.IsDigit(c) || "+-*/.".Contains(c))
                        input += c;
                }
            }
        }
    }
}