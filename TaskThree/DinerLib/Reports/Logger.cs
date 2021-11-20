using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DinerLib.Reports
{
    public abstract class Logger<T> 
        where T : ILoggable
    {
        protected string connectionString;
        public void AddNote(T entity)
        {
            var note = new Note { CreateTime = entity.CreateTime, LogType = entity.LogType };
            var notes = new List<Note>();
            var serializer = JsonSerializer.Create();
            using (StreamReader sr = new StreamReader(connectionString))
            {
                JsonReader jr = new JsonTextReader(sr);
                notes = serializer.Deserialize<List<Note>>(jr) ?? new List<Note>();
            }
            notes.Add(note);
            using (StreamWriter sw = File.CreateText(connectionString))
            {
                serializer.Serialize(sw, notes);
            }
        }
        public string[] GetNotes()
        {
            var notes = new List<Note>();
            using (StreamReader sr = new StreamReader(connectionString))
            {
                var serializer = JsonSerializer.Create();
                JsonReader jr = new JsonTextReader(sr);
                notes = serializer.Deserialize<List<Note>>(jr);
            }
            var stringNotes = new string[notes.Count];
            for (int i = 0; i < stringNotes.Length; i++)
                stringNotes[i] = notes[i].ToString();
            return stringNotes;
        }

        private class Note : ILoggable
        {
            public string LogType { get; set; }
            public DateTime CreateTime { get; set; }

            public override string ToString()
            {
                return LogType + " " + CreateTime.ToString();
            }
        }
    }
}
