using System.Collections.Generic;

namespace DecompNumber.Domain.Models
{
    public class Decomposition
    {
        public int EntryNumber { get; set; }
        public List<int> PrimeNumbers { get; set; }
        public List<int> DividingNumbers { get; set; }
    }
}
