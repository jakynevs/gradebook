namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Gradebook of tontos");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStats();

            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"Average grade is {stats.Average:N1}");
            Console.WriteLine($"Lowest grade is {stats.Low:N1}");
            Console.WriteLine($"Highest grade is {stats.High:N1}");
            Console.WriteLine($"Letter grade is {stats.Letter}");

        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                if (input != null)
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine($"**");

                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine($"Grade was added ");
            
        }


    }
}

