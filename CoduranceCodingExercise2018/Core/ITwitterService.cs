using CoduranceCodingExercise2018.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoduranceCodingExercise2018.Core
{
    public interface ITwitterService
    {
        string UserName(string text);
        string Post(string text);
        string UserToFollow(string text);
        string TimePosted(DateTime dt);
        bool UserExists(List<User> users,string username);
    }
}
