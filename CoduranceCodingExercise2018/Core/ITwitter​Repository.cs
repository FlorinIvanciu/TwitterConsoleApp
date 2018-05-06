using System.Collections.Generic;
using CoduranceCodingExercise2018.Core.Models;

namespace CoduranceCodingExercise2018.Core
{
    public interface ITwitterRepository
    {
        void AddUser(List<User> users, string username, string message);
        void FollowUser(List<User> users, string username, string userToFollow);
        List<WallInfo> GetWall(List<User> users, string username);
        List<Info> GetTimeLine(List<User> users, string username);
    }
}