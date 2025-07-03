using Cosmos.System.Graphics;
using System.Drawing;

namespace MRX_OS.UI
{
    public static class Drawing
    {
        public static void DrawFilledRectangle(Canvas canvas, Color color, int x, int y, int width, int height)
        {
            for (int i = x; i < x + width; i++)
            {
                for (int j = y; j < y + height; j++)
                {
                    if (i >= 0 && j >= 0 && i < canvas.Mode.Width && j < canvas.Mode.Height)
                        canvas.DrawPoint(color, i, j);
                }
            }
        }

        public static void DrawString(Canvas canvas, string text, PCScreenFont font, Color color, int x, int y)
        {
            canvas.DrawString(text, font, color, x, y);
        }

        public static void DrawString(Bitmap bmp, string text, PCScreenFont font, Color color, int x, int y)
        {
            var canvas = FullScreenCanvas.GetFullScreenCanvas();
            canvas.DrawString(text, font, color, x, y);
        }
    }
}