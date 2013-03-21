using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Mongo
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace FirstAttemptAtNoSQLTutorial
{
    [BsonIgnoreExtraElements(true)]
    class Person
    {
        public BsonObjectId _id { get; set; }
        public string name { get; set; }
        //public string mid { get; set; }
        public string last { get; set; }        
    }

    class TypedEntityProgram
    {
        //Have field in db, but no have in class
        static void Main(string[] args)
        {
            MongoClient client = new MongoClient();
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("myTestDB");

            using (server.RequestStart(db))
            {
                var col = db.GetCollection<Person>("employees");

                //col.Insert(new Person { name = "John", mid = "m.", last = "Terry" });

                var cursor = col.FindAllAs<Person>();
                foreach (var item in cursor)
                {
                    //Console.WriteLine("{0} {1} {2}", item.name, item.mid, item.last);
                    Console.WriteLine("{0} {1}", item.name, item.last);
                }
            }
        }
    }
}
