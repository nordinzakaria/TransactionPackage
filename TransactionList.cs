using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TransactionPackage
{
    public class TransactionList
    {
        public static int MAX = 100;

        // data 
        private List<Transaction> transactions; // transactions is an Array object

        // constructor -
        // 1) no return type
        // 2) name is that of the class
        // 3) usually used for initialization
        public TransactionList()
        {
            transactions = new List<Transaction>();
        }

        public TransactionList(int num)
        {
            transactions = new List<Transaction>(num);
        }

        // operations
        public void Init(int num)
        {
            transactions = new List<Transaction>(num);
        }

        // how to complete this?????
        public void Add(Transaction transaction)
        {
            transactions.Add(transaction);
        }

        

        public void Display()
        {
            for (int i = 0; i < transactions.Count; i++)
            {
                Console.WriteLine(transactions[i].Val);
            }
        }
    }
}
