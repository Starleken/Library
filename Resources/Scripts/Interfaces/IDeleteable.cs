using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLearn.Resources.Scripts
{
    internal interface IDeleteable : ITabular
    {
        int? GetId();
    }
}
