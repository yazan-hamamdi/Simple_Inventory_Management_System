

namespace SimpleInventoryManagementSystem
{
    public static class InputHelper
    {
        public static string ReadString(string str)
        {
            Console.Write(str);
            return Console.ReadLine();
        }

        public static decimal ReadDecimal(string str, decimal minValue = decimal.MinValue)
        {
            decimal value;
            Console.Write(str);
            while (!decimal.TryParse(Console.ReadLine(), out value) || value < minValue)
            {
                Console.Write($"Invalid input You must enter a value greater than : {minValue} ");
            }
            return value;
        }

        public static int ReadInt(string str, int minValue = int.MinValue)
        {
            int value;
            Console.Write(str);
            while (!int.TryParse(Console.ReadLine(), out value) || value < minValue)
            {
                Console.Write($"Invalid input You must enter a value greater than : {minValue} ");
            }
            return value;
        }

    }
}
