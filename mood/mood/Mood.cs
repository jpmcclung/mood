using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Mood
{
    public class Mood
    {
        [PrimaryKey, AutoIncrement]
        public int Response { get; set; }

        public DateTime Date { get; set; }
    }
}
