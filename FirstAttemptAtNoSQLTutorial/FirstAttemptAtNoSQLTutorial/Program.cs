using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Mongo
using MongoDB.Bson;
using MongoDB.Driver;

namespace FirstAttemptAtNoSQLTutorial
{
  
    class Program
    {
        static void Main(string[] args)
        {
            //MongoServer server = MongoServer.Create();            

            MongoClient client=new MongoClient();
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("myTestDB");

            using (server.RequestStart(db))
            {
                var col = db.GetCollection("employees");

                //col.Insert(new BsonDocument { { "name", "John" }, { "last", "Smith" } });
                //col.Insert(new BsonDocument { { "name", "Jane" }, { "last", "Smith" } });

                var cursor = col.FindAll();
                foreach (var item in cursor)
                {
                    string name = (string)item["name"];
                    string last = (string)item["last"];
                    Console.WriteLine("{0} {1}", name, last);
                }
            }
        }
    }
}
