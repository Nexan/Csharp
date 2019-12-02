using System;
using System.Drawing;
using SpaceBattleGame;

namespace Shapes
{
    /// <summary>
    /// Астероид.
    /// </summary>
    class Asteroid : BaseObject, ICloneable, IComparable
    {
        public int Power { get; set; } = 3;

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }

        #region Реализация методов интерфейсов
        public object Clone()
        {
            Asteroid asteroid = new Asteroid(new Point(Pos.X, Pos.Y)
                                                , new Point(Dir.X, Dir.Y)
                                                , new Size(Size.Width, Size.Height))
            {
                Power = Power
            };

            return asteroid;
        }

        int IComparable.CompareTo(object obj)
        {
            if (obj is Asteroid)
            {
                if (Power > (obj as Asteroid).Power)
                    return 1;
                if (Power < (obj as Asteroid).Power)
                    return -1;
                else
                    return 0;
            }
            throw new ArgumentException("Parameter is not а Asteroid!");
        }
        #endregion

        #region Перегруженные абстрактные методы
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(GameImages.asterImage, new Rectangle(Pos, Size));
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X + Size.Width < 0)
            {
                Pos.X = Game.Width + Size.Width;
            }
        }
        #endregion
    }
}