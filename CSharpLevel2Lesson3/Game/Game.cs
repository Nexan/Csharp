/* Михеев Константин
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Shapes;

namespace SpaceBattleGame
{
    public delegate void Message();


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

        static Game()
        {
            rnd           = new Random();
            _objs         = new List<BaseObject>();
            _asteroids    = new Asteroid[10];
            asteroidCount = _asteroids.Length;
            _ship         = new Ship(new Point(10, 400), new Point(5, 5), new Size(50, 50));
            score         = 0;
            _timer        = new Timer { Interval = 100 };
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

            _timer.Start();
            _timer.Tick += Timer_Tick;
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
            Draw();
            Update();
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
