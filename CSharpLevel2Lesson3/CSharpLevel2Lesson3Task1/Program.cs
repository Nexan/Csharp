using System;
using System.Windows.Forms;

namespace CSharpLevel2Lesson3Task1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            Game.Game.Init(form);
            form.Show();
            Game.Game.Draw();
            Application.Run(form);
        }
    }
}
