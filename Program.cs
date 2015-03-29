using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(DoSomethingAsync);
            task.Start();
            task.Wait();
            Console.ReadLine();       
        }

        static async void DoSomethingAsync()
        {
            const string connectionString = "mongodb://localhost:27017";

            // Create a MongoClient object by using the connection string
            var client = new MongoClient(connectionString);

            //Use the MongoClient to access the server
            var database = client.GetDatabase("test");

            //get mongodb collection
            var collection = database.GetCollection<Entity>("entities");
            await collection.InsertOneAsync(new Entity { Name = "Jack" });

        }
    }

    public class Entity
    {
        public ObjectId _id { get; set; }
        public string Name { get; set; }
    }
}
