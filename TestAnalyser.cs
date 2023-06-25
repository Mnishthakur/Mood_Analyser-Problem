using Microsoft.VisualStudio.TestTools.UnitTesting;
class MoodAnalyser
{
    public string AnalyseMood(string message)
    {
        if (message.ToLower().Contains("sad"))
            return "SAD";
        else
            return "HAPPY";
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

    [TestMethod]
    public void TestAnalyseMood_AnyMessage_ReturnsHappy()
    {
        string message = "I am in Any Mood";
        string result = moodAnalyser.AnalyseMood(message);
        Assert.AreEqual("HAPPY", result);
    }
}

