using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static bool IsEndGame = false;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            //Console.SetBufferSize(80, 25);
            Thread myThread = new Thread(new ThreadStart(MissionImpossible));
            Walls walls = new Walls(80, 25);
            myThread.Start(); // запускаем поток
            walls.Draw();

            // Отрисовка точек			
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
            WriteGameOver();

           
            Console.ReadLine();
        }
        static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            IsEndGame = true;
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
        private static void MissionImpossible()
        {
            while (IsEndGame == false)
            {
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(932, 150);
                Thread.Sleep(150);
                Console.Beep(1047, 150);
                Thread.Sleep(150);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(699, 150);
                Thread.Sleep(150);
                Console.Beep(740, 150);
                Thread.Sleep(150);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(932, 150);
                Thread.Sleep(150);
                Console.Beep(1047, 150);
                Thread.Sleep(150);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(784, 150);
                Thread.Sleep(300);
                Console.Beep(699, 150);
                Thread.Sleep(150);
                Console.Beep(740, 150);
                Thread.Sleep(150);
                Console.Beep(932, 150);
                Console.Beep(784, 150);
                Console.Beep(587, 1200);
                Thread.Sleep(75);
                Console.Beep(932, 150);
                Console.Beep(784, 150);
                Console.Beep(554, 1200);
                Thread.Sleep(75);
                Console.Beep(932, 150);
                Console.Beep(784, 150);
                Console.Beep(523, 1200);
                Thread.Sleep(150);
                Console.Beep(466, 150);
                Console.Beep(523, 150);
            }
        }
    }
}
