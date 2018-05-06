using System;

namespace CoduranceCodingExercise2018.Core.Models
{
    public class Info
    {
        public string Message { get; set; }
        public DateTime TimeAdded { get; set; }
        public Info(string message)
        {
            Message = message;
            TimeAdded = DateTime.Now;
        }
    }
}
