using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoduranceCodingExercise2018.Core.Models;
using CoduranceCodingExercise2018.Core;
using Microsoft.Extensions.DependencyInjection;
using CoduranceCodingExercise2018.Persistence;

namespace CoduranceCodingExercise2018
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var service = new ServiceCollection()
                .AddSingleton<ITwitterRepository, TwitterRepository>()
                .AddSingleton<ITwitterService, TwitterService>();
            var serviceProvider = service.BuildServiceProvider();
            var app = serviceProvider.GetService<ITwitterRepository>();
            var appGet = serviceProvider.GetService<ITwitterService>();

            List<User> Users = new List<User>();
            tweet();
            void Tweet(string command)
            {
                if (command.Trim().Length == 0)
                    tweet("Please provide the command!");
                if (command.Contains("->"))
                    app.AddUser(Users, appGet.UserName(command), appGet.Post(command));
                else if (command.Contains("follows"))
                {
                    if (!appGet.UserExists(Users, appGet.UserName(command)))
                        tweet("User doesn't exist!");
                    if (!appGet.UserExists(Users, appGet.UserToFollow(command)))
                        tweet("User to follow doesn't exist!");
                    app.FollowUser(Users, appGet.UserName(command), appGet.UserToFollow(command));
                }
                else if (command.Contains("wall"))
                {
                        tweet("User doesn't exist!");
                    foreach (WallInfo w in app.GetWall(Users, appGet.UserName(command)))
                        Console.WriteLine("{0} - {1} {2}", w.UserName, w.Message, appGet.TimePosted(w.TimeAdded));
                }
                else
                {
                    if (!appGet.UserExists(Users, appGet.UserName(command)))
                        tweet("User doesn't exist!");
                    foreach (Info i in app.GetTimeLine(Users, appGet.UserName(command)))
                        Console.WriteLine("{0} {1}", i.Message, appGet.TimePosted(i.TimeAdded));
                }
                tweet();
            }
            void tweet(string input="")
            {
                if (input.Length>0)
                Console.WriteLine(input);
                Tweet(Console.ReadLine());
            }
        }
    }

}
