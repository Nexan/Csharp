/* Михеев Константин
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Game
{
    public delegate void Message();
    
    /// <summary>
    /// Базовый класс, для космических объектов.
    /// </summary>
    abstract class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        public Point _Pos
        {
            get { return Pos; }
        }
        public Size _Size
        {
            get { return Size; }
        }

        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public bool Collision(BaseObject _object)
        {
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

        public abstract void Draw();
        public abstract void Update();
    }

    #region Классы - наследники BaseObject
    /// <summary>
    /// Звезда.
    /// </summary>
    class Star : BaseObject
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.Yellow, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.Yellow, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }

        public override void Update()
        {
            /*            Pos.X = Pos.X + Dir.X;
                        if (Pos.X < 0)
                            Pos.X = Game.Width + Size.Width;

                        Pos.Y = Pos.Y - Dir.Y;
                        if (Pos.Y < 0)
                            Pos.Y = Game.Height + Size.Height;*/
            Pos.X = Pos.X - Dir.X;
            if (Pos.X > Game.Width)
            {
                Pos.X = 0;
            }
        }
    }

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
    }

    /// <summary>
    /// Пуля.
    /// </summary>
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X + 15;
        }
    }

    /// <summary>
    /// Корабль.
    /// </summary>
    class Ship : BaseObject
    {
        private int _energy = 100;
        public int Energy => _energy;
        public static event Message MessageDie;
        public static event Message MessageWin;

        public void Die()
        {
            MessageDie?.Invoke();
        }

        public void Win()
        {
            MessageWin?.Invoke();
        }

        public void EnergyLow(int n)
        {
            _energy -= n;
        }

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(GameImages.shipImage, new Rectangle(Pos, Size));
        }

        public override void Update()
        {
        }

        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }

        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }
    }
    #endregion

    class GameObjectException: Exception
    {
        public GameObjectException(): base()
        {
        }

        public GameObjectException(string message) : base(message)
        {
        }
    }

    static class GameImages
    {
        public static Image asterImage;
        public static Image shipImage;

        static GameImages()
        {
            asterImage = Image.FromFile(@"..\..\asteroid96.png");
            shipImage = Image.FromFile(@"..\..\ship.png");
        }
    }


    /// <summary>
    /// Основной класс, реализующий создание и движение космических объектов.
    /// </summary>
    public static class Game
    {
        private static Timer _timer = new Timer();
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }
        private static List<BaseObject> _objs;
        private static Asteroid[] _asteroids;
        private static Random rnd;
        private static Ship _ship;
        private static Bullet _bullet;
        private static int asteroidCount;
        private static int score;
        private static bool gameIsEnd;

        static Game()
        {
            rnd     = new Random();
            _objs   = new List<BaseObject>();
            _asteroids  = new Asteroid[10];
            asteroidCount = _asteroids.Length;
            _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(50, 50));
            gameIsEnd = false;
            score = 0;
    }

        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            if (Width >= 1000 || Width < 0 || Height >= 1000 || Height < 0)
            {
                throw new ArgumentOutOfRangeException("Размер экрана должен быть неотрицательным числом, не превышающим 1000.");
            }
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;
            Ship.MessageWin += Win;

            Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                _bullet = new Bullet(new Point(_ship._Pos.X + _ship._Size.Width, _ship._Pos.Y + _ship._Size.Height / 2)
                                        , new Point(4, 0)
                                        , new Size(4, 1));
            if (e.KeyCode == Keys.Up)
                _ship.Up();
            if (e.KeyCode == Keys.Down)
                _ship.Down();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            if (gameIsEnd)
                return;

            Draw();
            Update();

            if (_ship.Energy <= 0 || asteroidCount == 0)
                gameIsEnd = true;
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();

            _bullet?.Update();
            for (var i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null) continue;
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
                Buffer.Graphics.DrawString("Asteroids: " + asteroidCount, SystemFonts.DefaultFont, Brushes.White, 100, 0);
                Buffer.Graphics.DrawString("Score: " + score, SystemFonts.DefaultFont, Brushes.Red, 200, 0);
            }

            Buffer.Render();
        }

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

        public static void Load()
        {
            for (var i = 0; i < 30; i++)
            {
                _objs.Add(GenerateStar());
            }

            for (var i = 0; i < _asteroids.Length; i++)
            {
                Asteroid aster = GenerateAsteroid();
                _asteroids[i]  = aster;
                _objs.Add(aster);
            }
        }

        public static void Finish()
        {
            _timer.Stop();
            Draw();
            Buffer.Graphics.DrawString("Game over!!!"
                                        , new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline)
                                        , Brushes.White, 200, 100);
            Buffer.Render();
        }

        public static void Win()
        {
            _timer.Stop();
            Draw();
            Buffer.Graphics.DrawString("Win!!!"
                                        , new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline)
                                        , Brushes.Yellow, 200, 100);
            Buffer.Render();
        }
    }
}
