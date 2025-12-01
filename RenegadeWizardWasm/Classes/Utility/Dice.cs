using System.Numerics;

namespace RenegadeWizard.Classes.Utility
{
    public static class Dice
    {

        ///asdsadasdsadasdsadasdasdasdas
        private static Random _random = new Random();
        public static int Roll(int num, int side)
        {
            int total = 0;

            for (int i = 0; i < num; i++)
            {
                total += _random.Next(1, side + 1); // Random number between 1 and 'side' (inclusive)
            }

            return total;
        }

    }


}
