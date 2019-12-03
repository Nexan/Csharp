/* Михеев Константин
    Задание 1:
        Добавить космический корабль, как описано в уроке.
    Задание 2:
        Доработать игру «Астероиды»:
        а. Добавить ведение журнала в консоль с помощью делегатов;
        б. * добавить это и в файл.
    Задание 3:
        Разработать аптечки, которые добавляют энергию.
    Задание 4:
        Добавить подсчет очков за сбитые астероиды.
 */
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
            Game.Finalize();
        }
    }
}
