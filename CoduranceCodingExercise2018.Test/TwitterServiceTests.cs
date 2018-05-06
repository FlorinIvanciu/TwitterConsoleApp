using System;
using CoduranceCodingExercise2018.Persistence;
using NUnit.Framework;

namespace CoduranceCodingExercise2018.Test
{
    [TestFixture]
    public class TwitterServiceTests
    {
        private TwitterService ts;

        [SetUp]
        public void SetUp()
        {
           ts = new TwitterService();
        }
        
        [Test]
        public void GetUserName_WhenEmptyString_ReturnsEmptyString()
        {
            string input = "";
            string output = ts.UserName(input);
            Assert.AreEqual("", output);
        }
        [Test]
        public void GetUserName_WhenEmptySpace_ReturnsEmptyString()
        {
            string input = "   ";
            string output = ts.UserName(input);
            Assert.AreEqual("", output);
        }
        [Test]
        public void GetUserName_WhenOneWord_ReturnsOneWord()
        {
            string input = "florin";
            string output = ts.UserName(input);
            Assert.AreEqual("florin", output);
        }
        [Test]
        public void GetUserName_WhenTwoWords_ReturnsOneWord()
        {
            string input = "florin ->";
            string output = ts.UserName(input);
            Assert.AreEqual("florin", output);
        }
        [Test]
        public void GetUserName_WhenThreeWords_ReturnsOneWord()
        {
            string input = "florin -> this is a test";
            string output = ts.UserName(input);
            Assert.AreEqual("florin", output);
        }
        [Test]
        public void GetUserName_When_Timeline()
        {
            string input = "florin";
            string output = ts.UserName(input);
            Assert.AreEqual("florin", output);
        }
        [Test]
        public void GetUserName_When_Following()
        {
            string input = "florin follows bob";
            string output = ts.UserName(input);
            string output2 = ts.UserToFollow(input);
            Assert.AreEqual("florin", output);
            Assert.AreEqual("bob", output2);
        }
        [Test]
        public void GetPost()
        {
            string input = "florin -> this is a test";
            string output = ts.Post(input);
            Assert.AreEqual("this is a test", output);
        }

        [Test]
        public void TimePosted_Now()
        {
            DateTime dt = DateTime.Now;
            string output = ts.TimePosted(dt);
            Assert.AreEqual("(now)", output);
        }
        [Test]
        public void TimePosted_After1Second_Diff1Second()
        {
            DateTime dt = DateTime.Now.AddSeconds(-1);
            string output = ts.TimePosted(dt);
            Assert.AreEqual("(1 second ago)", output);
        }
        [Test]
        public void TimePosted_After2Seconds_Diff2Seconds()
        {
            DateTime dt = DateTime.Now.AddSeconds(-2);
            string output = ts.TimePosted(dt);
            Assert.AreEqual("(2 seconds ago)", output);
        }
        [Test]
        public void TimePosted_After1Minute_Diff1Minute()
        {
            DateTime dt = DateTime.Now.AddMinutes(-1);
            string output = ts.TimePosted(dt);
            Assert.AreEqual("(1 minute ago)", output);
        }
        [Test]
        public void TimePosted_After2Minutes_Diff2Minutes()
        {
            DateTime dt = DateTime.Now.AddMinutes(-2);
            string output = ts.TimePosted(dt);
            Assert.AreEqual("(2 minutes ago)", output);
        }
        [Test]
        public void TimePosted_After1Hour_Diff1Hour()
        {
            DateTime dt = DateTime.Now.AddHours(-1);
            string output = ts.TimePosted(dt);
            Assert.AreEqual("(1 hour ago)", output);
        }
        [Test]
        public void TimePosted_After2Hours_Diff2Hours()
        {
            DateTime dt = DateTime.Now.AddHours(-2);
            string output = ts.TimePosted(dt);
            Assert.AreEqual("(2 hours ago)", output);
        }
        [Test]
        public void TimePosted_After1Day_Diff1Day()
        {
            DateTime dt = DateTime.Now.AddDays(-1);
            string output = ts.TimePosted(dt);
            Assert.AreEqual("(1 day ago)", output);
        }
        [Test]
        public void TimePosted_After2Days_Diff2Days()
        {
            DateTime dt = DateTime.Now.AddDays(-2);
            string output = ts.TimePosted(dt);
            Assert.AreEqual("(2 days ago)", output);
        }
    }
}
