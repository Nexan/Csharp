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
        #endregion
    }
}