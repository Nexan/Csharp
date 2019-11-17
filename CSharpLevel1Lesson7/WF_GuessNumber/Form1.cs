/* Михеев Константин
    Задание 2:
        Используя Windows Forms, разработать игру «Угадай число».
        Компьютер загадывает число от 1 до 100, а человек пытается
        его угадать за минимальное число попыток. Для ввода данных
        от человека используется элемент TextBox.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WF_GuessNumber
{
    public partial class MainForm : Form
    {
        GuessNumberPlay game;

        public MainForm()
        {
            game = new GuessNumberPlay();

            InitializeComponent();

            SetVisual(false);
        }

        private void SetVisual(bool status)
        {
            panelPlay.Visible = status;
            if (!status)
            {
                lblCurrentResult.Text = "";
                lblStepsCount.Text = "";
            }
        }

        private void CheckNumber()
        {
            int result = game.CheckNumber();

            if (result == 0)
            {
                MessageBox.Show("Вы угадали!"
                                , "Поздравляю"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Information);
                SetVisual(false);
                return;
            }
            if (result == 1)
            {
                lblCurrentResult.Text = "Загаданное число меньше.";
                lblCurrentResult.ForeColor = Color.Blue;
                return;
            }
            if (result == -1)
            {
                lblCurrentResult.Text = "Загаданное число больше.";
                lblCurrentResult.ForeColor = Color.Fuchsia;
                return;
            }
            if (result == 2)
            {
                MessageBox.Show($"Вы исчерпали все попытки!\nБыло загадано число {game.GuessNumber}."
                                , "Увы"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Stop);
                SetVisual(false);
                return;
            }
        }

        private void menuItemPlay_Click(object sender, EventArgs e)
        {
            game.StartGame();
            lblStepsCount.Text = $"Количество использованных попыток: {game.StepsCount}";
            SetVisual(true);
        }

        private void textUserAnswer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                string s = textUserAnswer.Text;
                textUserAnswer.Text = "";
                int temp;

                try
                {
                    temp = Convert.ToInt32(s);
                    game.SetUserNumber(temp);
                    lblStepsCount.Text = $"Количество использованных попыток: {game.StepsCount}";
                    CheckNumber();
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }
    }
}
