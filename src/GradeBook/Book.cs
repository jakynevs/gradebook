namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStats();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStats();
    }
    public class InMemoryBook : Book
    { 
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }
        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            } else  
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        public override event GradeAddedDelegate? GradeAdded;
        public override Statistics GetStats()
        {

            var result = new Statistics(); 

            var index = 0;

            do 
            {
                result.Add(grades[index]);
                index += 1;
            } while (index < grades.Count);
        
            return result;

        }

        private List<double> grades;
        

    }
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate? GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade); 
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStats()
        {
            var result = new Statistics();

            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }
}