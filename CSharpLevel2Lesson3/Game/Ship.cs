using System;
using System.Drawing;
using SpaceBattleGame;

namespace Shapes
{
    /// <summary>
    /// Корабль.
    /// </summary>
    class Ship : BaseObject
    {
        private int _energy = 100;
        public int Energy
        {
            get { return _energy; }
            set { _energy = value; }
        }
           
        public static event Message MessageDie;
        public static event Message MessageWin;
        public static event Log LogEvent;

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public void EnergyLow(int n)
        {
            _energy -= n;
        }

        #region Методы событий
        public void Die()
        {
            MessageDie?.Invoke();
        }

        public void Win()
        {
            MessageWin?.Invoke();
        }

        public void Logging(DateTime date, string message)
        {
            LogEvent?.Invoke(date, message);
        }
        #endregion

        #region Перегруженные абстрактные методы
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(GameImages.shipImage, new Rectangle(Pos, Size));
        }

        public override void Update()
        {
        }
        #endregion

        #region Изменение координат корабля в простарнстве
        public void Up()
        {
            if (Pos.Y > 0)
                Pos.Y = Pos.Y - Dir.Y;
        }

        public void Down()
        {
            if (Pos.Y < Game.Height)
                Pos.Y = Pos.Y + Dir.Y;
        }
        #endregion
    }
}