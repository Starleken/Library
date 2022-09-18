using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLearn.Resources.Scripts
{
    internal class ReadingInterval
    {
        public DateTime ReadBeginning { get; set; }

        public DateTime ReadEnd { get; set; }

        public ReadingInterval(DateTime readBeginning, DateTime readEnd)
        {
            this.ReadBeginning = readBeginning;
            this.ReadEnd = readEnd;
        }
    }
}
