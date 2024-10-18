using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionPackage
{
    public class Employee
    {
        public string Name { get; set; }
        public string ID { get; set; }

        public Employee() { }   
        public Employee(string name, string id) 
        { 
            Name = name;
            ID = id;
        }
    }
}
