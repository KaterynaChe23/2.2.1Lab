using System;
using System.Text;
using System.Transactions;

namespace labMyTime
{
    public struct MyTime
    {
        private int hour, minute, second;

        public MyTime(int hour, int minute, int second)
        {
            
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }
        public override string ToString()
        {
            return $"{hour}:{minute.ToString("00")}:{second.ToString("00")}";
        }
        public int Hour
        {
            get { return hour; }
            set{ hour = value;
                if (hour < 0 || hour >= 24)
                    throw new ArgumentOutOfRangeException("Години мають перебувати в діапазоні від 0 до 24");
            }
        }

        public int Minute
        {
            get { return minute; }
            set { minute = value;
                if (minute < 0 || minute >= 60)
                    throw new ArgumentOutOfRangeException("Хвилини мають перебувати в діапазоні від 0 до 60");
            }
        }
        public int Second
        {
            get { return second; }
            set{second = value;
                if (second < 0 || second >= 60)
                    throw new ArgumentOutOfRangeException("Секунди мають перебувати в діапазоні від 0 до 60");
            }
        }
        public static int ToSecondsSinceMidnight(MyTime time)
        {
            return time.Hour * 3600 + time.Minute * 60 + time.Second;
        }
        public static MyTime TimeFromSecondsSinceMidnight(int seconds)
        {
            int secondsPerDay = 60 * 60 * 24;
            seconds %= secondsPerDay;
            if (seconds < 0)
                seconds += secondsPerDay;//додаємо секунди одного дня, щоб отримати позитивне значення
            int hours = seconds / 3600;
            int minutes = (seconds / 60) % 60;
            int remainingSeconds = seconds % 60;
            return new MyTime(hours, minutes, remainingSeconds);
        }
        
        public MyTime AddOneSecondToTime(MyTime time)
        {
            int totalSeconds = ToSecondsSinceMidnight(time) + 1;
            return TimeFromSecondsSinceMidnight(totalSeconds);
        }

        public MyTime AddOneMinuteToTime(MyTime time)
        {
            int totalSeconds = ToSecondsSinceMidnight(time) + 60;
            return TimeFromSecondsSinceMidnight(totalSeconds);
        }
        public MyTime AddOneHourToTime(MyTime time)
        {
            int totalSeconds = ToSecondsSinceMidnight(time) + 3600;
            return TimeFromSecondsSinceMidnight(totalSeconds);
        }
        public MyTime AddSecondsToTime(MyTime time, int seconds)
        {
            int totalSeconds = ToSecondsSinceMidnight(time) + seconds;
            return TimeFromSecondsSinceMidnight(totalSeconds);
        }

        public int Difference(MyTime otherTime)
        {
            return ToSecondsSinceMidnight(this) - ToSecondsSinceMidnight(otherTime);
        }
        public static string DetermineLesson(MyTime currentTime)
        {
            MyTime[] startTimes = {
    new MyTime(8, 0, 0),
    new MyTime(9, 40, 0),
    new MyTime(11, 20, 0),
    new MyTime(13, 0, 0),
    new MyTime(14, 40, 0),
    new MyTime(16, 10, 0),
    new MyTime(17, 40, 0)
};
            MyTime[] endTimes =
            {
    new MyTime(9, 20, 0),
    new MyTime(11, 0, 0),
    new MyTime(12, 40, 0),
    new MyTime(14, 20, 0),
    new MyTime(16, 0, 0),
    new MyTime(17, 30, 0)
};

            int currentSeconds = ToSecondsSinceMidnight(currentTime);
            if (currentSeconds < ToSecondsSinceMidnight(startTimes[0])) return "Пари ще не почалися";
            if (currentSeconds > ToSecondsSinceMidnight(endTimes[5])) return "Пари вже скінчилися";
            for (int i = 0; i < startTimes.Length - 1; i++)
            {
                if (IsTimeInRange(currentTime, startTimes[i], startTimes[i + 1]))
                {
                    if (IsTimeInRange(currentTime, startTimes[i], endTimes[i]))
                        return $"{i + 1}-а пара";
                    else
                        return $"Перерва між {i + 1}-ю та {i + 2}-ю парою";
                }
            }

            return "Пари вже скінчилися";
        }

        public static bool IsTimeInRange(MyTime startTime, MyTime finishTime, MyTime checkTime)
        {
            int startSeconds = ToSecondsSinceMidnight(startTime); int finishSeconds = ToSecondsSinceMidnight(finishTime);
            int checkSeconds = ToSecondsSinceMidnight(checkTime); if (finishSeconds < startSeconds)
            {
                finishSeconds = 24 * 60 * 60 + finishSeconds;
            }
            return startSeconds <= checkSeconds && checkSeconds <= finishSeconds;
        }

    }
}
