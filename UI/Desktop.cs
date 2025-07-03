using Cosmos.System.Graphics;
using System;
using System.Drawing;
using MRX_OS.Apps;

namespace MRX_OS.UI
{
    public class Desktop
    {
        private Canvas canvas;
        private Bitmap logo;
        private Bitmap background;
        private string signature = "Made by Abdelrahman Seddini";

        private Window calcWindow;
        private Window termWindow;
        private Window noteWindow;

        public Desktop(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public void Init()
        {
            // تحميل الخلفية والشعار (يمكنك استبدالهم لاحقًا بصور حقيقية)
            background = new Bitmap(800, 600, ColorDepth.ColorDepth32);
            logo = new Bitmap(200, 100, ColorDepth.ColorDepth32);
            Drawing.DrawFilledRectangle(logo, Color.White, 0, 0, 200, 100);
            Drawing.DrawString(logo, "MRX OS", PCScreenFont.Default, Color.Black, 40, 40);

            // إنشاء النوافذ الثلاثة
            calcWindow = new Calculator(100, 100);
            termWindow = new Terminal(150, 150);
            noteWindow = new Notepad(200, 200);
        }

        public void Render()
        {
            canvas.Clear(Color.DarkBlue);

            // رسم الخلفية
            canvas.DrawImage(background, 0, 0);
            canvas.DrawImage(logo, 300, 50);

            // رسم التوقيع
            Drawing.DrawString(canvas, signature, PCScreenFont.Default, Color.White, 10, canvas.Mode.Height - 20);

            // رسم النوافذ
            calcWindow.Draw(canvas);
            termWindow.Draw(canvas);
            noteWindow.Draw(canvas);
        }

        public void HandleInput()
        {
            // دعم الماوس لتحريك النوافذ
            calcWindow.HandleInput();
            termWindow.HandleInput();
            noteWindow.HandleInput();
        }
    }
}