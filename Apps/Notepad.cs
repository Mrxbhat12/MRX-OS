using Cosmos.System.Graphics;
using System;
using System.Drawing;
using MRX_OS.UI;

namespace MRX_OS.Apps
{
    public class Notepad : Window
    {
        private string content = "";

        public Notepad(int x, int y) : base(x, y, "Notepad") { }

        public override void DrawContent(Canvas canvas, int x, int y)
        {
            Drawing.DrawString(canvas, content, PCScreenFont.Default, Color.Black, x + 5, y + 5);
        }

        public override void HandleInput()
        {
            base.HandleInput();

            if (KeyboardManager.TryReadKey(out var key))
            {
                if (key.Key == ConsoleKeyEx.Backspace)
                {
                    if (content.Length > 0)
                        content = content.Substring(0, content.Length - 1);
                }
                else
                {
                    char c = KeyboardManager.KeyToChar(key.Key, key.Modifiers);
                    if (!char.IsControl(c))
                        content += c;
                }
            }
        }
    }
}