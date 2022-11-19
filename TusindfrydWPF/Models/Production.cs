using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TusindfrydWPF.Models
{
    public class Production
    {
        public int Id { get; private set; }

        public DateOnly Date { get; set; }
        public int StartAmount { get; set; }
        public int ExpectedAmount { get; private set; }
        public bool Finished { get; set; }

        
    }
}
