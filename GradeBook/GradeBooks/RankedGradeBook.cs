using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    internal class RankedGradeBook:BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
             else
            {
                // continue here  Override `RankedGradeBook`'s `GetLetterGrade` method 
                double[] table = new double[Students.Count()];
                int i = 0;
                foreach (var student in Students)
                {
                    table[i] = student.AverageGrade;
                    i++;
                }
                bool change;
                do
                {
                    change = false;
                    for (int k = 0; k < table.Length - 1; k++)
                    {
                        double elem1 = table[k];
                        double elem2 = table[k + 1];
                        if (elem2 < elem1)
                        {
                            table[k] = elem2;
                            table[k + 1] = elem1;
                            change = true;
                        }
                    }
                } while (change);
                int pozycja = -1;
                for (int j = 0; j < Students.Count(); j++)
                {
                    if (table[j] == averageGrade) pozycja = j;
                }
                if (pozycja >= Students.Count() * 0.8)
                    return 'A';
                else if (pozycja >= Students.Count() * 0.6)
                    return 'B';
                else if (pozycja >= Students.Count() * 0.4)
                    return 'C';
                else if (pozycja >= Students.Count() * 0.2)
                    return 'D';
                else
                    return 'F';
            }
        }

        
    }
}
