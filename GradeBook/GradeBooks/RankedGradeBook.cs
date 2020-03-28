using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook 
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {

            if (Students.Count() < 5)
                {
                throw new InvalidOperationException("you must have at least 5 students to do ranked grading");
            }
            //count the top 20% of number of students, then cast it to integer (int)
            var threshold = (int)Math.Ceiling(Students.Count * 0.2); 

            //order all of the grades in AverageGrade by descending, and add it to a list with the .ToList(); syntax
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            // pick up all the students who are in the top 20%  
            // we are always subtracting 1 because threshold got a normal integer count, but in a list the listing starts from 0 not 1
            if (averageGrade >= grades[threshold - 1])// e.g. list {98, 78, 66, 52, 44, 25,20,12  }
                return 'A';

            //multiply the threshold by 2 so now we pick up top 40% of students.
            else if (averageGrade >= grades[threshold * 2 - 1])
                return 'B';

            //multiply the threshold by  3 so we pick the top 60% of students
            else if (averageGrade >= grades[threshold * 3 - 1])
                return 'C';

            // last bit for grade D
            else if (averageGrade >= grades[threshold * 4 - 1])
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count() < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                    return;
                    }
                    
            else {
                base.CalculateStatistics();
            }
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count() < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}

//extra