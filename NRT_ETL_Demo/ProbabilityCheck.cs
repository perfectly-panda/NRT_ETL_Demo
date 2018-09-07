using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRT_ETL_Demo
{
    public static class ProbabilityCheck
    {

        public static bool ShouldCreate(int target, int currentValue)
        {

            double percent = 1F;

            Random rand = new Random();

            if (target > 0)
            {
                percent = 1F - (currentValue / target);

            }

            var variant = rand.NextDouble() - .5;

            percent = percent + variant;

            var testDouble = rand.NextDouble();

            return percent >= testDouble;
        }

        public static int PalletCount()
        {
            Random rand = new Random();

            return rand.Next(1, 200);
        }

    }
}
