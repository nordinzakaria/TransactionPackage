using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionPackage    // declare the collection(namespace)
                                // where a particular class belong
{
    public class Transaction
    {
        public string Id { get; set;  }
        public float Val {  get; set; }
        public DateTime Date { get; set; }
        public Employee Employee { get; set; } = new Employee();

        public Transaction() { }
        public Transaction(float val, DateTime date, string id)
        {
            Val = val;
            Date = date;
            Id = id;
        }

            public Transaction(float val, DateTime date) 
        {
            Val = val;
            Date = date;

            Id = date.Ticks.ToString();
        }
    }
}