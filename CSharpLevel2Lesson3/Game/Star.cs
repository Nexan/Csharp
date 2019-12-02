using System.Drawing;
using SpaceBattleGame;

namespace Shapes
{
    /// <summary>
    /// Звезда.
    /// </summary>
    class Star : BaseObject
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        #region Перегруженные абстрактные методы
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.Yellow, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.Yellow, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X > Game.Width)
            {
                Pos.X = 0;
            }
        }
        #endregion
    }
}