using System.Collections.Generic;

namespace CoduranceCodingExercise2018.Core.Models
{
    public class User
    {
        public string UserName { get; set; }
        public List<string> FollowingUsers { get; set; }
        public List<Info> Info { get; set; }

        public User(string username, string message)
        {
            UserName = username;
            FollowingUsers = new List<string>();
            FollowingUsers.Add(username);
            Info = new List<Info>();
            Info.Add(new Info(message));
        }
    }
}
