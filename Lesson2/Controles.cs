using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    static class Controles
    {
        public static bool controlDate(DateTime dt1, DateTime dt2)
        {
            if (dt1 >= dt2 || dt1 <= DateTime.Now) return false;
            else return true;
        }
    }
}
