using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Domain.ValueObjects
{
   public class Publication
    {
        public int Edition { get; set; }
        public int Year { get; set; }

        public Publication(int edition, int year)
        {
            Edition = edition;
            Year = year;
        }
    }
}
