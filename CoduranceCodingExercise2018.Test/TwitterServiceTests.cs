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

    }
}
