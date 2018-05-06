using System;

namespace CoduranceCodingExercise2018.Core.Models
{
    public class WallInfo
    {
        public string UserName { get; set; }
        public string Message { get; set; }
        public DateTime TimeAdded { get; set; }
        public WallInfo(string userName, string message, DateTime timeAdded)
        {
            UserName = userName;
            Message = message;
            TimeAdded = timeAdded;
        }
    }
}
