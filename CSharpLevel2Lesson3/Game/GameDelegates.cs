using System;
using System.Windows.Forms;
using System.Drawing;
using Shapes;

namespace SpaceBattleGame
{
    public static partial class Game
    {
        #region Методы событий
        /// <summary>
        /// Завершение игры в случае проигрыша.
        /// </summary>
        public static void Finish()
        {
            _timer.Stop();
            _timerAid.Stop();

            Draw();

            _ship.Logging(DateTime.Now, "Проигрыш. У корабля закончилась энергия.");
            Buffer.Graphics.DrawString("Game over!!!"
                                        , new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline)
                                        , Brushes.White, 200, 100);
            Buffer.Render();
        }

        /// <summary>
        /// Завершение игры в случае победы.
        /// </summary>
        public static void Win()
        {
            _timer.Stop();
            _timerAid.Stop();

            Draw();

            _ship.Logging(DateTime.Now, "Выигрыш. Были уничтожены все астероиды.");
            Buffer.Graphics.DrawString("Win!!!"
                                        , new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline)
                                        , Brushes.Yellow, 200, 100);
            Buffer.Render();
        }

        /// <summary>
        /// Обработка нажатия клавиш.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                _bullet = new Bullet(new Point(_ship._Pos.X + _ship._Size.Width, _ship._Pos.Y + _ship._Size.Height / 2)
                                        , new Point(4, 0)
                                        , new Size(4, 1));
            if (e.KeyCode == Keys.Up)
                _ship.Up();
            if (e.KeyCode == Keys.Down)
                _ship.Down();
        }
        #endregion

        #region Методы логирования
        public static void LogToConsole(DateTime date, string message)
        {
            Console.WriteLine($"{date}: {message}");
        }
        public static void LogToFile(DateTime date, string message)
        {
            logFile.WriteLine($"{date}: {message}");
        }
        #endregion
    }
}
