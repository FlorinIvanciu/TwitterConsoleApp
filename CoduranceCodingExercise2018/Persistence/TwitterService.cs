using CoduranceCodingExercise2018.Core;
using CoduranceCodingExercise2018.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoduranceCodingExercise2018.Persistence
{
    public class TwitterService : ITwitterService
    {
        public string UserName(string input)
        {
            return GetInfo(input,Get.Username);
        }

        public string Post(string input)
        {
            return GetInfo(input, Get.Post);
        }

        public string UserToFollow(string input)
        {
            return GetInfo(input, Get.UserToFollow);
        }
        private string GetInfo(string input, Get type)
        {
            string output = string.Empty;
            if (input.Trim().Length == 0)
                output = "";
            else
            {
                switch (type)
                {
                    case Get.Username:
                        output = input.Split(' ').First();
                        break;
                    case Get.Post:
                        output = input.Remove(0, (UserName(input) + " -> ").Length);
                        break;
                    case Get.UserToFollow:
                        output = input.Remove(0, (UserName(input) + " follows ").Length);
                        break;
                }
            }
            return output;
        }
        enum Get
        {
            Username,
            Post,
            UserToFollow
        }

        public string TimePosted(DateTime dt)
        {
            TimeSpan ts = (DateTime.Now - dt);
            string spanTime = "(now)";
            if (ts.Days > 0)
            {
                spanTime = string.Format("({0} day{1} ago)", ts.Days, ts.Days > 1 ? "s" : "");
            }
            else if (ts.Hours > 0)
            {
                spanTime = string.Format("({0} hour{1} ago)", ts.Hours, ts.Hours > 1 ? "s" : "");
            }
            else if (ts.Minutes > 0)
            {
                spanTime = string.Format("({0} minute{1} ago)", ts.Minutes, ts.Minutes > 1 ? "s" : "");
            }
            else if (ts.Seconds > 0)
            {
                spanTime = string.Format("({0} second{1} ago)", ts.Seconds, ts.Seconds > 1 ? "s" : "");
            }
            return spanTime;
        }

        public bool UserExists(List<User> users, string username)
        {
            if (users.Any(x => x.UserName == username))
                return true;
            return false;
        }
    }
}
