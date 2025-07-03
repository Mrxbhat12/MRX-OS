using Cosmos.System.Graphics;
using System;
using System.Drawing;
using System.Threading;
using Cosmos.Audio;
using Cosmos.Audio.Core;

namespace MRX_OS.UI
{
    public static class BootScreen
    {
        public static void Show(Canvas canvas)
        {
            canvas.Clear(Color.Black);

            // رسم الشعار النصي
            canvas.DrawString("MRX OS", PCScreenFont.Default, Color.White, 350, 200);
            canvas.DrawString("Loading MRX OS...", PCScreenFont.Default, Color.Gray, 330, 250);

            // يمكنك أيضاً رسم علم الجزائر هنا كرمز أو صورة لاحقًا

            // تشغيل صوت التمهيد (تأكد من وجود boot.wav في Resources)
            try
            {
                // لا يوجد دعم مباشر لصوت WAV حاليًا في Cosmos، لذا هذا رمز رمزي placeholder
                // ضع هنا أي كود مستقبلًا بمجرد دعم الصوت
            }
            catch (Exception)
            {
                canvas.DrawString("Boot sound error", PCScreenFont.Default, Color.Red, 10, 10);
            }

            canvas.Display();
            Thread.Sleep(3000); // انتظار 3 ثوانٍ
        }
    }
}