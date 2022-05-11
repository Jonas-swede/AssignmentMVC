

using System;


namespace Assignment_MVC.Models
{
    public class GuessingGameModel
    {
        public bool Error { get; set; }
        public bool Correct { get; set; }
        public int Number { get; set; }
        public int High { get; set; }
        public GuessingGameModel()
        {
        }

        public void GuessNumber(int number)
        {
            Error = number <= 0 || number > 100 ? true : false;
            Correct = number == Number ? true : false;
            High = number > Number ? 2 : 1;
        }

        public int NewNumber()
        {
            Random rnd = new Random();
            return rnd.Next(0, 100);
        }
    }
}
