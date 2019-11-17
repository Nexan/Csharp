using System;

namespace WF_GuessNumber
{
    class GuessNumberPlay
    {
        private int guessNumber;
        private int stepsCount;
        private int userNumber;
        private Random rnd;

        #region Свойства
        public int GuessNumber
        {
            get { return guessNumber; }
        }

        public int StepsCount
        {
            get { return stepsCount; }
        }

        public int UserNumber
        {
            get { return userNumber; }
        }
        #endregion

        public int SetUserNumber(int userNumber)
        {
            this.userNumber = userNumber;
            stepsCount++;

            return userNumber;
        }

        public int ResetStepsCount()
        {
            return (stepsCount = 0);
        }

        public int GenerateNumber()
        {
            return (guessNumber = rnd.Next(1, 101));
        }

        public void StartGame()
        {
            ResetStepsCount();
            GenerateNumber();
        }

        public int CheckNumber()
        {
            if (userNumber == guessNumber)
            {
                return 0;
            }
            if (stepsCount == 6)
            {
                return 2;
            }
            if (userNumber < guessNumber)
            {
                return -1;
            }

            return 1;
        }

        public GuessNumberPlay()
        {
            rnd        = new Random();
            stepsCount = 0;
        }
    }
}
