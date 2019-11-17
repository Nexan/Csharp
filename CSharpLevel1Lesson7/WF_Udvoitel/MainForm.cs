/* Михеев Константин
    Задание 1:
        а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
        б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок. Игрок должен получить это число за минимальное количество ходов.
        в) *Добавить кнопку «Отменить», которая отменяет последние ходы. Используйте обобщенный класс Stack.
        Вся логика игры должна быть реализована в классе с удвоителем.
 */
using System;
using System.Windows.Forms;

namespace WF_Udvoitel
{
    public partial class MainForm : Form
    {
        private Udvoitel game;

        public MainForm()
        {
            game = new Udvoitel();

            InitializeComponent();

            DisableEnableButtons(false);
            btnReset.Enabled = false;
        }

        private void DisableEnableButtons(bool station)
        {
            btnCommand1.Enabled = station;
            btnCommand2.Enabled = station;
            btnCancelLastStep.Enabled = station;
            btnReset.Enabled    = true;
        }

        private void ResetGame()
        {
            lblNumber.Text       = game.ResetUserNumber().ToString();
            lblActionsCount.Text = game.ResetActionsCount().ToString();
        }

        public void CheckResult()
        {
            int result = game.CompareResultAndGuessNumbers();

            if (result == 0)
            {
                MessageBox.Show($"Вы получили число {game.GuessNumber} за {game.ActionsCount} ходов."
                                , "Поздравляем"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Information);
                DisableEnableButtons(false);
                return;
            }

            if (result == 1)
            {
                MessageBox.Show("Вы превысили загаданное компьютером число."
                                , "Вы проиграли"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Stop);
                DisableEnableButtons(false);
                return;
            }

            if (result == 2)
            {
                MessageBox.Show("Вы превысили максимальное количество попыток."
                                , "Вы проиграли"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Stop);
                DisableEnableButtons(false);
                return;
            }
        }


        #region Обработчики событий элементов формы
        private void btnCommand1_Click(object sender, EventArgs e)
        {
            lblNumber.Text       = game.IncrementUserNumber().ToString();
            lblActionsCount.Text = game.ActionsCount.ToString();

            CheckResult();
        }

        private void btnCommand2_Click(object sender, EventArgs e)
        {
            lblNumber.Text       = game.MultiplyOnTwoUserNumber().ToString();
            lblActionsCount.Text = game.ActionsCount.ToString();

            CheckResult();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Начать заново?"
                                , "Удвоитель"
                                , MessageBoxButtons.YesNo
                                , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ResetGame();
                DisableEnableButtons(true);
            }
        }

        private void menuItemPlay_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Компьютер выбирает число от 20 до 999\nВам предлагается получить это число\nза минимальное количество ходов.\nИграем?"
                                , "Удвоитель"
                                , MessageBoxButtons.YesNo
                                , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                captionGuessNumber.Text = $"Получите число {game.GenerateGuessNumber().ToString()} за {game.MinSteps.ToString()} ходов.";
                ResetGame();
                DisableEnableButtons(true);
            }
        }

        private void btnCancelLastStep_Click(object sender, EventArgs e)
        {
            lblNumber.Text = game.DeleteLastUserNumber().ToString();
            lblActionsCount.Text = game.ActionsCount.ToString();
        }
        #endregion
    }
}
