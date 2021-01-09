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

        // Show the moods
        public Task<List<Mood>> GetMoodAsync()
        {
            return _database.Table<Mood>().ToListAsync();
        }

        // Save moods
        public Task<int> SaveMoodAsync(Mood mood)
        {
            return _database.InsertAsync(mood);
        }

        // Delete moods
        public Task<int> DeleteMoodAsync(Mood mood)
        {
            return _database.DeleteAsync(mood);
        }

        // Save moods
        public Task<int> UpdateMoodAsync(Mood mood)
        {
            return _database.UpdateAsync(mood);
        }
    }
}
