namespace GradeBook 
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                switch(Average)
                {
                    case var d when d >= 90.0:
                        return 'A';
                    case var d when d >= 80.0 && d < 90.0:
                        return 'B';
                    case var d when d >= 70.0 && d < 80.0:
                        return 'C';
                    case var d when d >= 60.0 && d < 70.0:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }
        public double Sum;
        public int Count;

        public void Add(double num)
        {
            Sum += num;
            Count++;
            High = Math.Max(num, High);
            Low = Math.Min(num, Low);

        }
        public Statistics()
        {
            Sum = 0.0;
            Count = 0;
            High = double.MinValue;
            Low = double.MaxValue;
        }
    }
}