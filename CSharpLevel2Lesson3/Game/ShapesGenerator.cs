using System;
using System.Drawing;
using Shapes;

namespace SpaceBattleGame
{
    public static partial class Game
    {
        #region Генераторы новых объектов
        private static Star GenerateStar()
        {
            int r = rnd.Next(5, 50);
            return new Star(new Point(rnd.Next(0, Game.Width), rnd.Next(0, Game.Height)), new Point(-r / 7, r), new Size(3, 3));
        }

        private static Asteroid GenerateAsteroid()
        {
            int r = rnd.Next(5, 50);
            return new Asteroid(new Point(1000, rnd.Next(10, Game.Height - 10)), new Point(-r / 5, r), new Size(r, r));
        }

        private static Bullet GenerateBullet()
        {
            int r = rnd.Next(5, 50);
            return new Bullet(new Point(rnd.Next(-1000, -10), rnd.Next(0, Game.Height)), new Point(-r / 5, r), new Size(4, 1));
        }

        private static void CheckCreateAid(object sender, EventArgs e)
        {
            _timerAid.Interval = 1000;

            if (_ship.Energy > 0 && _ship.Energy < 100 && _aid == null)
                _aid = new Aid(new Point(1000, rnd.Next(20, Game.Height - 20)), new Point(15, 0), new Size(42, 36));
        }
        #endregion
    }
}