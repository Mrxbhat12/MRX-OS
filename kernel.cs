using Cosmos.System;
using Cosmos.System.Graphics;
using System;
using System.Drawing;
using MRX_OS.UI;
using MRX_OS.Apps;

namespace MRX_OS
{
    public class Kernel : Sys.Kernel
    {
        private Canvas canvas;
        private Desktop desktop;

        protected override void BeforeRun()
        {
            Console.WriteLine("MRX OS is booting...");
        }

        protected override void Run()
        {
            if (canvas == null)
            {
                // الحصول على الكانفاس وتعيين الوضع
                canvas = FullScreenCanvas.GetFullScreenCanvas();
                Canvas.SetMode(canvas.Mode);

                // عرض شاشة التمهيد
                BootScreen.Show(canvas);

                // تهيئة سطح المكتب
                desktop = new Desktop(canvas);
                desktop.Init();
            }

            // عرض الواجهة
            desktop.Render();
            desktop.HandleInput();
        }
    }
}