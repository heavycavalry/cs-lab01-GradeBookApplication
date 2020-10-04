using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook

    {

        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {

            Type = GradeBookType.Ranked;

        }

        public override char GetLetterGrade(double averageGrade)
        {
            var n = Students.Count;

            if (n < 5)
            {
                throw new InvalidOperationException();
            }
            int counter = 0;
            foreach (Student s in this.Students)
            {
                foreach (double grade in s.Grades)
                {
                    if (averageGrade < grade)
                    {
                        counter += 1;
                    }
                }
            }
            int betterPercent = counter * 100 / n;

            if (betterPercent < 20)
            {
                return 'A';
            }
            if (betterPercent < 40)
            {
                return 'B';
            }
            if (betterPercent < 60)
            {
                return 'C';
            }
            if (betterPercent < 80)
            {
                return 'D';
            }

            return 'F';



        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();

            }

        }

        public override void CalculateStudentStatistics(string name)
        {   
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else { 
            base.CalculateStudentStatistics(name);
        }
        }
    }
}