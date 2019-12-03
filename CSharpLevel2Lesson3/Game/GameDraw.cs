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
        /// Обновление позиции аптечки.
        /// </summary>
        private static void AidUpdate()
        {
            // проверяем столкновение корабля с аптечкой
            if (_ship.Collision(_aid))
            {
                _timerAid.Interval = rnd.Next(30000, 60000);
                _ship.Energy += Math.Min(10, 100 - _ship.Energy);
                _aid = null;
            }

            _aid?.Update();

            // аптечка вылетела за экран
            if (_aid != null && _aid._Pos.X + _aid._Size.Width <= 0)
            {
                _timerAid.Interval = rnd.Next(30000, 60000);
                _aid = null;
            }
        }

        /// <summary>
        /// Обновление позиции пули.
        /// </summary>
        /// <param name="asteroid"></param>
        /// <returns></returns>
        private static bool BulletUpdate(ref Asteroid asteroid)
        {
            // проверяем попадание пули в астероид
            if (_bullet != null && _bullet.Collision(asteroid))
            {
                System.Media.SystemSounds.Hand.Play();

                _bullet = null;

                score += asteroid._Size.Height;
                asteroid = null;
                asteroidCount--;
                if (asteroidCount == 0)
                    _ship?.Win();

                _ship.Logging(DateTime.Now, $"Попадание пулей в астероид. Осталось астероидов: {asteroidCount}. Количество очков: {score}");

                return true;
            }

            return false;
        }

        /// <summary>
        /// Проверяем столкновение корабля с астероидом
        /// </summary>
        /// <param name="asteroid"></param>
        /// <returns></returns>
        private static bool ShipCollision(ref Asteroid asteroid)
        {
            if (_ship.Collision(asteroid))
            {
                System.Media.SystemSounds.Asterisk.Play();

                _ship?.EnergyLow(rnd.Next(1, 5));
                _ship.Logging(DateTime.Now, $"Столкновение с астероидом. Осталось энергии: {_ship.Energy}");

                if (_ship.Energy <= 0)
                    _ship?.Die();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Обновляет положение объектов.
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();

            _bullet?.Update();
            AidUpdate();

            for (var i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null)
                    continue;
                _asteroids[i].Update();

                if (BulletUpdate(ref _asteroids[i]))
                    continue;

                ShipCollision(ref _asteroids[i]);
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
                Buffer.Graphics.DrawString("Очки: " + score, SystemFonts.DefaultFont, Brushes.Yellow, 245, 0);
            }
        }
    }
}