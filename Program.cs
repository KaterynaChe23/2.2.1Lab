using labMyTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labMyTime
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Console.WriteLine("Введіть момент часу: ");
            int[] inputTime = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            MyTime currentTime = new MyTime(inputTime[0], inputTime[1], inputTime[2]);

            Console.WriteLine("Виберіть метод: ");
            int choice;
            bool validInput = int.TryParse(Console.ReadLine(), out choice);

            if (!validInput || choice < 0 || choice > 9)
                throw new ArgumentOutOfRangeException("Вибраний метод має знаходитися в діапазоні від 0 до 9");

            switch (choice)
            {
                case 0:
                    Console.WriteLine(currentTime.ToString());
                    break;
                case 1:
                    Console.WriteLine(MyTime.ToSecondsSinceMidnight(currentTime));
                    break;
                case 2:
                    Console.WriteLine("Введіть кількість секунд");
                    int seconds = int.Parse(Console.ReadLine());
                    Console.WriteLine(MyTime.TimeFromSecondsSinceMidnight(seconds));
                    break;
                case 3:
                    Console.WriteLine(currentTime.AddOneSecondToTime(currentTime));
                    break;
                case 4:
                    Console.WriteLine(currentTime.AddOneMinuteToTime(currentTime));
                    break;
                case 5:
                    Console.WriteLine(currentTime.AddOneHourToTime(currentTime));
                    break;
                case 6:
                    Console.WriteLine("Введіть кількість секунд, які треба додати");
                    int secondsToAdd = int.Parse(Console.ReadLine());
                    Console.WriteLine(currentTime.AddSecondsToTime(currentTime, secondsToAdd));
                    break;
                case 7:
                    Console.WriteLine("Введіть другий момент часу: ");
                    int[] secondInputTime = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                    MyTime otherTime = new MyTime(secondInputTime[0], secondInputTime[1], secondInputTime[2]);

                    int difference = currentTime.Difference(otherTime);
                    Console.WriteLine(difference);
                    break;
                case 8:
                    Console.WriteLine(MyTime.DetermineLesson(currentTime));
                    break;
                case 9:
                    Console.WriteLine("Введіть стартовий момент часу: ");
                    int[] startInputTime = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                    MyTime startTime = new MyTime(startInputTime[0], startInputTime[1], startInputTime[2]); 
                    Console.WriteLine("Введіть кінцевий момент часу: ");
                    int[] finishInputTime = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                    MyTime finishTime = new MyTime(finishInputTime[0], finishInputTime[1], finishInputTime[2]);
                    if (MyTime.IsTimeInRange(startTime, finishTime, currentTime))
                        Console.WriteLine("Обраний момент часу знаходиться в діапазоні");
                    else
                        Console.WriteLine("Обраний момент часу не знаходиться в діапазоні");
                    break;
            }
        }
    }
}
