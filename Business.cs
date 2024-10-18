using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;


namespace TransactionPackage
{
    public class Business
    {
        public TransactionList TransList {  get; set; }


        private const string FIREBASE_PROJID = "cashtransaction-2f8c9"; // must be ID of your Firestore db
        private FirestoreDb db;

        public Business() 
        {
            TransList = new TransactionList();
        }

        public void initFirestore()
        {
            FirebaseApp.Create();
            db = FirestoreDb.Create(FIREBASE_PROJID);
            Console.WriteLine("Created Cloud Firestore client with project ID: {0}", FIREBASE_PROJID);
        }

        public async Task SaveTransaction(Transaction transaction)
        {
            CollectionReference collectionRef = db.Collection("transactions");
            DocumentReference docRef = collectionRef.Document(transaction.Id);

            Dictionary<string, object> values = new Dictionary<string, object>
                  {   // key        // value
                    { "Id",            transaction.Id},
                    { "Value",         transaction.Val.ToString()},
                    { "Date",          transaction.Date.ToString() },
                    { "Employee.Name", transaction.Employee.Name },
                    { "Employee.Id",   transaction.Employee.ID }
                  };

            Console.WriteLine("Adding doc with ID " + docRef.Id);
            await docRef.SetAsync(values);
        }

        public async Task RestoreTransactions()
        {
            Query collectionQuery = db.Collection("transactions");
            QuerySnapshot allQuerySnapshot = await collectionQuery.GetSnapshotAsync();

            TransList.Clear();
            foreach (DocumentSnapshot documentSnapshot in allQuerySnapshot.Documents)
            {
                Dictionary<string, object> data = documentSnapshot.ToDictionary();
                float val = float.Parse(data["Value"].ToString());
                DateTime date = DateTime.Parse(data["Date"].ToString());
                Transaction trans = new Transaction(val, date, data["Id"].ToString());
                trans.Employee = new Employee(data["Employee.Name"].ToString(),
                                              data["Employee.Id"].ToString());

                TransList.Add(trans);
            }

        }

        public async Task DelTransaction(string data)
        {
            Console.WriteLine("Deleting  " + data);
            CollectionReference collectionRef = db.Collection("transactions");
            DocumentReference docRef = collectionRef.Document(data);
            await docRef.DeleteAsync();
        }

    }
}
