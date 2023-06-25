using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace AnalyserTest
{
    class MoodAnalyser
    {
        public string AnalyseMood(string message)
        {
            string messageLower = message.ToLower();

            if (messageLower.Contains("happy"))
                return "Happy";
            else if (messageLower.Contains("sad"))
                return "Sad";
            else
                return "Unable to determine the mood.";
        }
    }

    [TestClass]
    public class TestAnalyser
    {
        private MoodAnalyser moodAnalyser;

        [TestInitialize]
        public void Setup()
        {
            moodAnalyser = new MoodAnalyser();
        }

        [TestMethod]
        public void TestAnalyseMood_HappyMessage_ReturnsHappy()
        {
            string message = "I am feeling great today!";
            string result = moodAnalyser.AnalyseMood(message);
            Assert.AreEqual("Happy", result);
        }

        [TestMethod]
        public void TestAnalyseMood_SadMessage_ReturnsSad()
        {
            string message = "I had a terrible day.";
            string result = moodAnalyser.AnalyseMood(message);
            Assert.AreEqual("Sad", result);
        }

        [TestMethod]
        public void TestAnalyseMood_NoKeyword_ReturnsUnableToDetermine()
        {
            string message = "I went for a walk.";
            string result = moodAnalyser.AnalyseMood(message);
            Assert.AreEqual("Unable to determine the mood.", result);
        }
    }


}


