using System.Drawing;
using SpaceBattleGame;

namespace Shapes
{
    /// <summary>
    /// Пуля.
    /// </summary>
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        #region Перегруженные абстрактные методы
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X + 15;
        }
        #endregion
    }
}