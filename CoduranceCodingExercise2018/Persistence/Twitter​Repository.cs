using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoduranceCodingExercise2018.Core.Models;

namespace CoduranceCodingExercise2018.Core
{
    class Twitter​Repository : ITwitter​Repository
    {
        public void AddUser(List<User> users, string username, string message)
        {
            if (users.Any(x => x.UserName == username))
                users.Find(x => x.UserName == username).Info.Add(new Info(message));
            else
                users.Add(new User(username, message));
        }

        public void FollowUser(List<User> users, string username, string userToFollow)
        {
                users.Find(x => x.UserName == username).FollowingUsers.Add(userToFollow);
        }

        public List<WallInfo> GetWall(List<User> users, string username)
        {
                List<WallInfo> WallInfo = new List<WallInfo>();
                foreach (string name in users.Find(x => x.UserName == username).FollowingUsers)
                    foreach (User u in users)
                        if (u.UserName == name)
                            foreach (Info i in users.Find(x => x.UserName == name).Info)
                                WallInfo.Add(new WallInfo(name, i.Message, i.TimeAdded));
                WallInfo.Sort((a, b) => a.TimeAdded.CompareTo(b.TimeAdded));
                WallInfo.Reverse();
                return WallInfo;
        }

        public List<Info> GetTimeLine(List<User> users, string username)
        {
                List<Info> messages = new List<Info>();
                messages = users.Find(x => x.UserName == username).Info;
                messages.Sort((a, b) => a.TimeAdded.CompareTo(b.TimeAdded));
                messages.Reverse();
            return messages;
        }

    }
}
