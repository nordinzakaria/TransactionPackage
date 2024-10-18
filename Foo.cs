using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionPackage
{
    public class Foo
    {
        public string Id {  get; set; } 

        public Foo() { }
        public Foo(string id)
        {
            Id = id;
        }
    }
}
