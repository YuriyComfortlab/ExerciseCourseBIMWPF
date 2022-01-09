using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRadius.Models
{
    static class Arith
    {
        public static double LengthCircle(int radius)
        {
            double lengthCircle = 2 * Math.PI * radius;
            return lengthCircle;
        }
    }
}
