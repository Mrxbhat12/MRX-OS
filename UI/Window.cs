using Cosmos.System.Graphics;
using System;
using System.Drawing;

namespace MRX_OS.UI
{
    public abstract class Window
    {
        public int X, Y;
        public int Width = 250;
        public int Height = 150;
        public string Title;
        private bool dragging = false;
        private int offsetX, offsetY;

        public Window(int x, int y, string title)
        {
            X = x;
            Y = y;
            Title = title;
        }

        public void Draw(Canvas canvas)
        {
            // خلفية النافذة
            Drawing.DrawFilledRectangle(canvas, Color.LightGray, X, Y, Width, Height);
            // شريط العنوان
            Drawing.DrawFilledRectangle(canvas, Color.DarkSlateGray, X, Y, Width, 20);
            Drawing.DrawString(canvas, Title, PCScreenFont.Default, Color.White, X + 5, Y + 3);

            // محتوى النافذة
            DrawContent(canvas, X, Y + 20);
        }

        public void HandleInput()
        {
            if (Cosmos.System.MouseManager.MouseState == Cosmos.System.MouseState.Left)
            {
                int mx = (int)Cosmos.System.MouseManager.X;
                int my = (int)Cosmos.System.MouseManager.Y;

                if (!dragging && mx >= X && mx <= X + Width && my >= Y && my <= Y + 20)
                {
                    dragging = true;
                    offsetX = mx - X;
                    offsetY = my - Y;
                }

                if (dragging)
                {
                    X = mx - offsetX;
                    Y = my - offsetY;
                }
            }
            else
            {
                dragging = false;
            }
        }

        public abstract void DrawContent(Canvas canvas, int x, int y);
    }
}