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
        public TransactionList list {  get; set; }


        private const string FIREBASE_PROJID = "cashtransaction-2f8c9"; // must be ID of your Firestore db
        private FirestoreDb db;


        public Business() { }

        public void initFirestore()
        {
            FirebaseApp.Create();
            db = FirestoreDb.Create(FIREBASE_PROJID);
            Console.WriteLine("Created Cloud Firestore client with project ID: {0}", FIREBASE_PROJID);
        }



    }
}
