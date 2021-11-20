using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kickerino;

namespace KickerinoUnitTest
{
    [TestClass]
    public class Form1UnitTest
    {
        [TestMethod]
        public void playerNameAndJerseyCheck()
        {
            // arrange
            Project testProject = new Project();


            // act
            testProject.Players.Add(new Player { Name = "Test01", JerseyNumber = 10 });
            testProject.Players.Add(new Player { Name = "tEmPoRaRy", JerseyNumber = 01 });
            testProject.Players.Add(new Player { Name = "hulunkus", JerseyNumber = 17 });

            // assert
            string playerName01 = testProject.Players[0].Name;
            Assert.AreEqual("Test01", playerName01);

            int jerseyNumber01 = testProject.Players[0].JerseyNumber;
            Assert.AreEqual(10, jerseyNumber01);

            string playerName02 = testProject.Players[0].Name;
            Assert.AreEqual("Test01", playerName02);

            int jerseyNumber02 = testProject.Players[0].JerseyNumber;
            Assert.AreEqual(10, jerseyNumber02);

            string playerName03 = testProject.Players[0].Name;
            Assert.AreEqual("Test01", playerName03);

            int jerseyNumber03 = testProject.Players[0].JerseyNumber;
            Assert.AreEqual(10, jerseyNumber03);


        }
    }
}
