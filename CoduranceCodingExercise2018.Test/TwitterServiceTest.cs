using System;
using CoduranceCodingExercise2018.Core;
using CoduranceCodingExercise2018.Persistence;
using Moq;
using NUnit.Framework;

namespace CoduranceCodingExercise2018.TestCoco
{
    [TestFixture]
    public class TwitterServiceTest
    {


        [Test]
        public void GetUser_WhenCalled_ShouldReturnString()
        {
            //arrange 
            var service = new TwitterService();

            //act 
           var result =  service.GetUserName("florin hello");

            //assert
            Assert.That(result, Is.EqualTo("florin"));
        }

        [Test]
        public void GetUser_TextEmptyOrNull_ShouldReturnException()
        {
            //arrange 
            var service = new TwitterService();

            //act 
            var result = service.GetUserName("");

            //assert
            Assert.That(result, Is.EqualTo("No command found"));
        }
    }
}
