using System.Drawing;

namespace Shapes
{
    /// <summary>
    /// Базовый класс, для космических объектов.
    /// </summary>
    abstract class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        #region Свойства
        public Point _Pos
        {
            get { return Pos; }
        }
        public Size _Size
        {
            get { return Size; }
        }
        #endregion

        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        /// <summary>
        /// Проверяет столкновение данного объекта с объектом _object.
        /// </summary>
        /// <param name="_object"></param>
        /// <returns></returns>
        public bool Collision(BaseObject _object)
        {
            if (_object == null)
                return false;

            int thisX1 = _Pos.X;
            int thisX2 = _Pos.X + _Size.Width;
            int objectX1 = _object._Pos.X;
            int objectX2 = _object._Pos.X + _object._Size.Width;
            int thisY1 = _Pos.Y;
            int thisY2 = _Pos.Y + _Size.Height;
            int objectY1 = _object._Pos.Y;
            int objectY2 = _object._Pos.Y + _object._Size.Height;

            return ((objectX1 <= thisX1 && objectX2 >= thisX1)
                || (objectX1 <= thisX2 && objectX2 >= thisX2))
                && ((objectY1 <= thisY1 && objectY2 >= thisY1)
                || (objectY1 <= thisY2 && objectY2 >= thisY2));
        }

        #region Абстрактные методы
        public abstract void Draw();
        public abstract void Update();
        #endregion
    }
}