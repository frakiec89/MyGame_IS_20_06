using System;

namespace MyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Игра хахаха");
            Console.WriteLine("Введите имя игрока");
            string name = Console.ReadLine();
            try
            {
                Game game = new Game(name, 10);

                while(true)
                {
                    game.NextStep();
                    Console.WriteLine("Для след хода нажмите enter");
                    Console.WriteLine();
                    Console.ReadLine();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
