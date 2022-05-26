using System.Diagnostics;

namespace ADS
{
    internal class Range
    {
        private readonly PointClassDouble[] rangeClass;
        private readonly PointStructDouble[] rangeStruct;
        private readonly Stopwatch stopwatch;
        private TimeSpan classTime;
        private TimeSpan structTime;
        private int quantity;

        internal Range(int quantity)
        {
            rangeClass = new PointClassDouble[quantity];
            rangeStruct = new PointStructDouble[quantity];
            TimeReset();
            this.quantity = quantity;
            stopwatch = new();
            stopwatch.Restart();
            StructInit(quantity);
            stopwatch.Stop();
            structTime = stopwatch.Elapsed;
            stopwatch.Restart();
            ClassInit(quantity);
            stopwatch.Stop();
            classTime = stopwatch.Elapsed;
        }

        private void TimeReset()
        {
            classTime = new();
            structTime = new();
        }

        internal void DraftResult()
        {
            IO.SendLine($"Число элементов | Время структуры | Время класса    | Класс/Структура");
            IO.SendLine($"{quantity,15} | {structTime.TotalSeconds,15} | {classTime.TotalSeconds,15} | {classTime.TotalSeconds / structTime.TotalSeconds,15}");
        }

        #region Init

        private void ClassInit(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                rangeClass[i] = new PointClassDouble();
            }
        }

        private void StructInit(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                rangeStruct[i] = new PointStructDouble();
            }
        }

        #endregion

        #region Length

        internal void Test()
        {
            TimeReset();
            stopwatch.Restart();
            LenghtStruct();
            stopwatch.Stop();
            structTime = stopwatch.Elapsed;
            stopwatch.Restart();
            LenghtClass();
            stopwatch.Stop();
            classTime = stopwatch.Elapsed;
        }

        internal void TestWOSqrt()
        {
            TimeReset();
            stopwatch.Restart();
            LenghtStructWOSqrt();
            stopwatch.Stop();
            structTime = stopwatch.Elapsed;
            stopwatch.Restart();
            LenghtClassWOSqrt();
            stopwatch.Stop();
            classTime = stopwatch.Elapsed;
        }

        private void LenghtClass()
        {
            for (int i = 0; i < quantity; i++)
            {
                for (int j = i; j < quantity; j++)
                {
                    var pointFirst = rangeClass[i];
                    var pointSecond = rangeClass[j];
                    var tmp = Math.Sqrt(Math.Pow((pointFirst.X - pointSecond.X), 2) + Math.Pow((pointFirst.Y - pointSecond.Y), 2));
                }
            }
        }

        private void LenghtClassWOSqrt()
        {
            for (int i = 0; i < quantity; i++)
            {
                for (int j = i; j < quantity; j++)
                {
                    var pointFirst = rangeClass[i];
                    var pointSecond = rangeClass[j];
                    var tmp = Math.Pow((pointFirst.X - pointSecond.X), 2) + Math.Pow((pointFirst.Y - pointSecond.Y), 2);
                }
            }
        }

        private void LenghtStruct()
        {
            for (int i = 0; i < quantity; i++)
            {
                for (int j = i; j < quantity; j++)
                {
                    var pointFirst = rangeStruct[i];
                    var pointSecond = rangeStruct[j];
                    var tmp = Math.Sqrt(Math.Pow((pointFirst.X - pointSecond.X), 2) + Math.Pow((pointFirst.Y - pointSecond.Y), 2));
                }
            }
        }

        private void LenghtStructWOSqrt()
        {
            for (int i = 0; i < quantity; i++)
            {
                for (int j = i; j < quantity; j++)
                {
                    var pointFirst = rangeStruct[i];
                    var pointSecond = rangeStruct[j];
                    var tmp = Math.Pow((pointFirst.X - pointSecond.X), 2) + Math.Pow((pointFirst.Y - pointSecond.Y), 2);
                }
            }
        }

        #endregion

    }
}
