using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_3
{
    public class RetryPolicy
    {
        public int MaxAttempts { get; set; }
        public int InitialDelay { get; set; }
        public int MaxDelay { get; set; }
        public double BackoffMultiplier { get; set; }
        public double RandomizationFactor { get; set; }
    }

}
