using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace AnalyserTest
{
    class MoodAnalyser
{
    public string AnalyseMood(string message)
    {
        return "SAD";
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
    public void TestAnalyseMood_SadMessage_ReturnsSad()
    {
        string message = "I am in Sad Mood";
        string result = moodAnalyser.AnalyseMood(message);
        Assert.AreEqual("SAD", result);
    }
}


        [TestMethod]
        public void TestAnalyseMood_NoKeyword_ReturnsUnableToDetermine()
        {
            string message = "I went for a walk.";
            string result = moodAnalyser.AnalyseMood(message);
            Assert.AreEqual("Unable to determine the mood.", result);
        }
}


