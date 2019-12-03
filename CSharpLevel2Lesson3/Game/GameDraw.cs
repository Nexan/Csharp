using System;
using System.Drawing;
using Shapes;

namespace SpaceBattleGame
{
    public static partial class Game
    {
        /// <summary>
        /// Обновляет изображение по таймеру.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        /// <summary>
        /// Обновляет положение объектов.
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();

            _bullet?.Update();
            if (_ship.Collision(_aid))
            {
                _timerAid.Interval = rnd.Next(30000, 60000);
                _ship.Energy += Math.Min(10, 100 - _ship.Energy);
                _aid = null;
            }
            _aid?.Update();
            if (_aid != null && _aid._Pos.X + _aid._Size.Width <= 0)
            {
                _timerAid.Interval = rnd.Next(30000, 60000);
                _aid = null;
            }

            for (var i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null)
                    continue;
                _asteroids[i].Update();

                // проверяем попадание пули в астероид
                if (_bullet != null && _bullet.Collision(_asteroids[i]))
                {
                    System.Media.SystemSounds.Hand.Play();
                    score += _asteroids[i]._Size.Height;
                    _asteroids[i] = null;
                    asteroidCount--;
                    _bullet = null;
                    if (asteroidCount == 0)
                        _ship?.Win();
                    _ship.Logging(DateTime.Now, $"Попадание пулей в астероид. Осталось астероидов: {asteroidCount}. Количество очков: {score}");
                    continue;
                }

                // проверяем столкновение корабля с астероидом
                if (!_ship.Collision(_asteroids[i]))
                    continue;
                
                _ship?.EnergyLow(rnd.Next(1, 10));
                System.Media.SystemSounds.Asterisk.Play();
                _ship.Logging(DateTime.Now, $"Столкновение с астероидом. Осталось энергии: {_ship.Energy}");

                if (_ship.Energy <= 0)
                    _ship?.Die();
            }
        }

        /// <summary>
        /// Выводит изображение на экран.
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);

            foreach (BaseObject obj in _objs)
            {
                obj.Draw();
            }

            foreach (Asteroid a in _asteroids)
            {
                a?.Draw();
            }

            _bullet?.Draw();
            _ship?.Draw();
            _aid?.Draw();

            ShowLabels();

            Buffer.Render();
        }

        private static void ShowLabels()
        {
            if (_ship != null)
            {
                Buffer.Graphics.DrawString("Энергия: " + _ship.Energy, SystemFonts.DefaultFont, Brushes.Green, 0, 0);
                Buffer.Graphics.DrawString("Осталось астероидов: " + asteroidCount, SystemFonts.DefaultFont, Brushes.White, 90, 0);
                Buffer.Graphics.DrawString("Очки: " + score, SystemFonts.DefaultFont, Brushes.Red, 245, 0);
            }
        }
    }
}