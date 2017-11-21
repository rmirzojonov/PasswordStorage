using System;
using NUnit.Framework;
using PasswordStorage.Services;
using PasswordStorage;

namespace UnitTestApp1
{
    [TestFixture]
    public class TestsSample
    {
        AuthService authService;
        [SetUp]
        public void Setup() { authService = new AuthService(); }
        [Test]
        public void SaveCredentialsTest()
        {
            Assert.IsTrue(authService.SaveCredentials(App.Username, "12345"));
        }

        [Test]
        public void LoginTest()
        {
            Assert.IsTrue(authService.Login(App.Username, "1214234"));
        }

        [TearDown]
        public void Tear() { }

        [Test]
        public void Pass()
        {
            Console.WriteLine("test1");
            Assert.True(true);
        }

        [Test]
        public void Fail()
        {
            Assert.False(true);
        }

        [Test]
        [Ignore("another time")]
        public void Ignore()
        {
            Assert.True(false);
        }

        [Test]
        public void Inconclusive()
        {
            Assert.Inconclusive("Inconclusive");
        }
    }
}