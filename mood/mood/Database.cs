using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;



namespace Mood
{
   public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            //Establishing the conection
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Mood>().Wait();
        }

        // Show the registers
        public Task<List<Mood>> GetPeopleAsync()
        {
            return _database.Table<Mood>().ToListAsync();
        }

        // Save registers
        public Task<int> SavePersonAsync(Mood contact)
        {
            return _database.InsertAsync(contact);
        }

        // Delete registers
        public Task<int> DeletePersonAsync(Mood contact)
        {
            return _database.DeleteAsync(contact);
        }

        // Save registers
        public Task<int> UpdatePersonAsync(Mood contact)
        {
            return _database.UpdateAsync(contact);
        }
    }
}
}
