using System.Drawing;
using SpaceBattleGame;

namespace Shapes
{
    /// <summary>
    /// Аптечка.
    /// </summary>
    class Aid : BaseObject
    {
        public Aid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        #region Перегруженные абстрактные методы
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(GameImages.aidImage, new Rectangle(Pos, Size));
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
        }
        #endregion
    }
}