using System;
using labMyTime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace MyTimeTest
{
    [TestClass]
    public class MyTimeTest
    {
        [TestMethod]
        public void ConstructorWithParameterOptions()
        {

            MyTime time = new MyTime(12, 33, 55);

            Assert.AreEqual(12, time.Hour);
            Assert.AreEqual(33, time.Minute);
            Assert.AreEqual(55, time.Second);

        }

        [TestMethod]
        public void Constructor_InvalidHour_ThrowsException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new MyTime(25, 33, 22));
        }
        [TestMethod]
        public void Constructor_InvalidMinute_ThrowsException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new MyTime(24, 63, 22));
        }
        [TestMethod]
        public void Constructor_InvalidSecond_ThrowsException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new MyTime(25, 33, 62));
        }

        [TestMethod]
        public void Checking_Parameters_Get()
        {
            MyTime time = new MyTime(12, 33, 55);

            int hour = time.Hour;
            int minute = time.Minute;
            int second = time.Second;

            Assert.AreEqual(12, hour);
            Assert.AreEqual(33, minute);
            Assert.AreEqual(55, second);

        }

        [TestMethod]
        public void Checking_Parameters_Set()
        {
            MyTime time = new MyTime(12, 33, 55);

            time.Hour = 13;
            time.Minute = 14;
            time.Second = 15;

            Assert.AreEqual(13, time.Hour);
            Assert.AreEqual(14, time.Minute);
            Assert.AreEqual(15, time.Second);
        }

        [TestMethod]
        public void Checking_ToSecondsSinceMidnight()
        {
            MyTime time = new MyTime(12, 33, 55);
            int exception = 45235;

            int actual = MyTime.ToSecondsSinceMidnight(time);

            Assert.AreEqual(exception, actual);
        }

        [TestMethod]
        public void Checking_TimeFromSecondsSinceMidnight()
        {
            int seconds = 45235;

            MyTime expected = new MyTime(12, 33, 55);

            MyTime actual = MyTime.TimeFromSecondsSinceMidnight(seconds);

            Assert.AreEqual(expected.Hour, actual.Hour);
            Assert.AreEqual(expected.Minute, actual.Minute);
            Assert.AreEqual(expected.Second, actual.Second);
        }

        [TestMethod]
        public void Checking_AddOneSecondToTime()
        {
            MyTime time = new MyTime(12, 33, 55);
            MyTime expected = new MyTime(12, 33, 56);

            MyTime actual = time.AddSecondsToTime(time, 1);

            Assert.AreEqual(expected.Hour, actual.Hour);
            Assert.AreEqual(expected.Minute, actual.Minute);
            Assert.AreEqual(expected.Second, actual.Second);
        }

        [TestMethod]
        public void Checking_AddOneMinuteToTime()
        {
            MyTime time = new MyTime(12, 33, 55);
            MyTime expected = new MyTime(12, 34, 55);

            MyTime actual = time.AddOneMinuteToTime(time);

            Assert.AreEqual(expected.Hour, actual.Hour);
            Assert.AreEqual(expected.Minute, actual.Minute);
            Assert.AreEqual(expected.Second, actual.Second);
        }

        [TestMethod]
        public void Checking_AddOneHourToTime()
        {
            MyTime time = new MyTime(12, 33, 55);
            MyTime expected = new MyTime(13, 33, 55);

            MyTime actual = time.AddOneHourToTime(time);

            Assert.AreEqual(expected.Hour, actual.Hour);
            Assert.AreEqual(expected.Minute, actual.Minute);
            Assert.AreEqual(expected.Second, actual.Second);
        }

        [TestMethod]
        public void Checking_AddSecondToTime()
        {
            MyTime time = new MyTime(11, 33, 55);
            int second = 30;

            MyTime result = new MyTime(11,34,25);

            MyTime actual = time.AddSecondsToTime(time, second);

            Assert.AreEqual(result.Hour, actual.Hour);
            Assert.AreEqual(result.Minute, actual.Minute);
            Assert.AreEqual(result.Second, actual.Second);
        }
        [TestMethod]
        public void Checking_Difference()
        {
            MyTime time1 = new MyTime(12, 33, 55);

            MyTime time2 = new MyTime(12, 34, 25);

            int excepted = -30;

            int actual = time1.Difference(time2);
            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void Test_NoLessonsStarted()
        {
            MyTime time = new MyTime(7, 22, 33);

            string actual = MyTime.DetermineLesson(time);

            string exñepted = "Ïàðè ùå íå ïî÷àëèñÿ";
            Assert.AreEqual(exñepted, actual);
        }

        [TestMethod]
        public void Test_LastLesson()
        {
            MyTime time = new MyTime(18, 30, 33);

            string actual = MyTime.DetermineLesson(time);

            string exñepted = "Ïàðè âæå ñê³í÷èëèñÿ";

            Assert.AreEqual(exñepted, actual);
        }

        [TestMethod]
        public void Test_FirstLesson()
        {
            MyTime time = new MyTime(8, 30, 33);

            string actual = MyTime.DetermineLesson(time);

            string exñepted = "1-a ïàðà";

            Assert.AreEqual(exñepted, actual);
        }


        [TestMethod]
        public void Test_SecondLesson()
        {
            MyTime time = new MyTime(9, 50, 30);

            string actual = MyTime.DetermineLesson(time);

            string expected = "2-a ïàðà";
            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        public void Test_BetweenFirstAndSecondLesson()
        {
            MyTime time = new MyTime(9, 30, 33);

            string actual = MyTime.DetermineLesson(time);

            string exñepted = "Ïåðåðâà ì³æ 1-þ òà 2-þ ïàðîþ";

            Assert.AreEqual(exñepted, actual);
        }


    }
}