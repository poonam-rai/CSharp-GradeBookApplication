using System;
using System.Collections.Generic;
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

            if (base.ListStudents.Count())
                throw new invalidoperationexception("must have more than 5 students");


            return base.getlettergrade(averagegrade);
        }
    }
}

//extra