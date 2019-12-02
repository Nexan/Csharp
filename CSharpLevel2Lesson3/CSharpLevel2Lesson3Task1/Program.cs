using System;
using System.Windows.Forms;
using SpaceBattleGame;

namespace CSharpLevel2Lesson3Task1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}
