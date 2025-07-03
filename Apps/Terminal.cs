using Cosmos.System.Graphics;
using System;
using System.Drawing;
using MRX_OS.UI;

namespace MRX_OS.Apps
{
    public class Terminal : Window
    {
        private string currentLine = "";
        private string output = "Welcome to MRX OS Terminal\nType 'about', 'help' or 'clear'";

        public Terminal(int x, int y) : base(x, y, "Terminal") { }

        public override void DrawContent(Canvas canvas, int x, int y)
        {
            Drawing.DrawString(canvas, output, PCScreenFont.Default, Color.Black, x + 5, y + 5);
            Drawing.DrawString(canvas, "> " + currentLine, PCScreenFont.Default, Color.Green, x + 5, y + 80);
        }

        public override void HandleInput()
        {
            base.HandleInput();

            if (KeyboardManager.TryReadKey(out var key))
            {
                if (key.Key == ConsoleKeyEx.Enter)
                {
                    if (currentLine == "about")
                        output += "\nCreated by Abdelrahman Seddini";
                    else if (currentLine == "help")
                        output += "\nCommands: about, help, clear";
                    else if (currentLine == "clear")
                        output = "";
                    else
                        output += "\nUnknown command: " + currentLine;

                    currentLine = "";
                }
                else if (key.Key == ConsoleKeyEx.Backspace)
                {
                    if (currentLine.Length > 0)
                        currentLine = currentLine.Substring(0, currentLine.Length - 1);
                }
                else
                {
                    char c = KeyboardManager.KeyToChar(key.Key, key.Modifiers);
                    if (!char.IsControl(c))
                        currentLine += c;
                }
            }
        }
    }
}