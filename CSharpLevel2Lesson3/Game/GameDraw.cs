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
            for (var i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null)
                    continue;
                _asteroids[i].Update();

                if (_bullet != null && _bullet.Collision(_asteroids[i]))
                {
                    System.Media.SystemSounds.Hand.Play();
                    score += _asteroids[i]._Size.Height;
                    _objs.Remove(_asteroids[i]);
                    _asteroids[i] = null;
                    asteroidCount--;
                    _bullet = null;
                    if (asteroidCount == 0)
                        _ship?.Win();
                    continue;
                }

                if (!_ship.Collision(_asteroids[i]))
                    continue;
                _ship?.EnergyLow(rnd.Next(1, 10));
                System.Media.SystemSounds.Asterisk.Play();
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

            if (_ship != null)
            {
                Buffer.Graphics.DrawString("Energy: " + _ship.Energy, SystemFonts.DefaultFont, Brushes.Green, 0, 0);
                Buffer.Graphics.DrawString("Left asteroids: " + asteroidCount, SystemFonts.DefaultFont, Brushes.White, 100, 0);
                Buffer.Graphics.DrawString("Score: " + score, SystemFonts.DefaultFont, Brushes.Red, 250, 0);
            }

            Buffer.Render();
        }
    }
}