using System;
using System.Collections.Generic;

namespace WF_Udvoitel
{
    public class Udvoitel
    {
        private int actionsCount;// количество ходов сделанных пользователем
        private int minSteps;// минимальное количество ходов расчитанное компьютером
        private int guessNumber;// загаданное число
        private int userNumber;// последнее число введенное пользователем
        private Random rnd;
        private Stack<int> Steps;// ходы пользователя кроме последнего

        #region Properties
        public int ActionsCount
        {
            get { return actionsCount; }
        }

        public int GuessNumber
        {
            get { return guessNumber; }
        }

        public int UserNumber
        {
            get { return userNumber; }
        }

        public int MinSteps
        {
            get { return minSteps; }
        }
        #endregion

        #region Вспомогательные методы
        // очистка ходов сделанных пользователем
        public int ResetActionsCount()
        {
            actionsCount = 0;
            Steps.Clear();

            return actionsCount;
        }

        // очистка последнего результата пользователя
        public int ResetUserNumber()
        {
            userNumber = 1;
            return userNumber;
        }

        public void ResetGame()
        {
            ResetActionsCount();
            ResetUserNumber();
        }

        // генератор числа
        public int GenerateGuessNumber()
        {
            guessNumber = rnd.Next(20, 1000);
            CountMinSteps();

            return guessNumber;
        }

        private int IncrementActionsCount()
        {
            return ++actionsCount;
        }

        private int DecrementActionsCount()
        {
            return --actionsCount;
        }

        // увеличивает результат пользователя на 1 и возвращает его
        public int IncrementUserNumber()
        {
            Steps.Push(userNumber);
            userNumber++;
            IncrementActionsCount();

            return userNumber;
        }

        // увеличивает результат пользователя в 2 раза и возвращает его
        public int MultiplyOnTwoUserNumber()
        {
            Steps.Push(userNumber);
            userNumber *= 2;
            IncrementActionsCount();

            return userNumber;
        }

        // сравнивает результат пользователя с загаданным числом
        // Возвращает:
        // -1 - результат меньше загаданного числа
        // 0 - результат равен загаданному числу
        // 1 - результат больше загаданного числа
        // 2 - превышено количество попыток
        public int CompareResultAndGuessNumbers()
        {
            if (actionsCount > minSteps)
            {
                return 2;
            }

            if (userNumber == guessNumber)
            {
                return 0;
            }
            if (userNumber < guessNumber)
            {
                return -1;
            }

            return 1;
        }

        // возвращает результат предыдущего хода и удаляет его из списка ходов
        public int DeleteLastUserNumber()
        {
            if (actionsCount != 0)
            {
                DecrementActionsCount();
                userNumber = Steps.Pop();
            }

            return userNumber;
        }

        // рассчитывает количество ходов для получения результата
        private void CountMinSteps()
        {
            int temp = guessNumber;
            minSteps = 0;

            while (temp != 1)
            {
                while(temp % 2 == 0)
                {
                    minSteps++;
                    temp /= 2;
                }

                if (temp != 1)
                {
                    minSteps++;
                    temp--;
                }
            }
        }
        #endregion

        public Udvoitel()
        {
            rnd = new Random();
            Steps = new Stack<int>();

            ResetGame();
            guessNumber = 1;
        }
    }
}
