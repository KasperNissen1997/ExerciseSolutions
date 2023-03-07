using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelPersistence.Models
{
    public class School
    {
        // Properties
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public School (string phone, string name, string address)
        {
            Phone = phone;
            Name = name;
            Address = address;
        }
    }
}
