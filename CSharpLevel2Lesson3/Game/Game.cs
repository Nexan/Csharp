using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Shapes;
using System.IO;

namespace SpaceBattleGame
{
    public delegate void Message();
    public delegate void Log(DateTime date, string message);

    /// <summary>
    /// Основной класс, реализующий создание и движение космических объектов.
    /// </summary>
    public static partial class Game
    {
        private static Timer _timer = new Timer();
        private static Timer _timerAid = new Timer();
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }
        private static List<BaseObject> _objs;
        private static Asteroid[] _asteroids;
        private static Random rnd;
        private static Ship _ship;
        private static Bullet _bullet;
        private static Aid _aid;
        private static int asteroidCount;
        private static int score;
        private static StreamWriter logFile;

        static Game()
        {
            rnd           = new Random();
            _objs         = new List<BaseObject>();
            _asteroids    = new Asteroid[10];
            asteroidCount = _asteroids.Length;
            _ship         = new Ship(new Point(10, 400), new Point(5, 5), new Size(30, 26));
            score         = 0;
            _timer        = new Timer { Interval = 100 };
            _timerAid     = new Timer { Interval = 1000 };
            logFile = new StreamWriter("_log.txt", true);
        }

        // Дейтсвия при закрытии программы.
        public static void Finalize()
        {
            _ship.Logging(DateTime.Now, "Игра завершена.");
            logFile.Close();
        }

        #region Методы инициализации игры
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

            // Подключаем обработчики событий
            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;
            Ship.MessageWin += Win;
            Ship.LogEvent   += LogToFile;
            Ship.LogEvent   += LogToConsole;

            Load();

            _timer.Start();
            _timer.Tick += Timer_Tick;
            _timerAid.Start();
            _timerAid.Tick += CheckCreateAid;

            _ship.Logging(DateTime.Now, "Игра начата.");
        }

        /// <summary>
        /// Создает новые космические тела.
        /// </summary>
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
        #endregion
    }
}
