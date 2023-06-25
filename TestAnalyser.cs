using Microsoft.VisualStudio.TestTools.UnitTesting;
class MoodAnalyser
{
    private string message;

    public MoodAnalyser()
    {
        message = "";
    }

    public MoodAnalyser(string message)
    {
        this.message = message;
    }

    public string AnalyseMood()
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
        moodAnalyser = new MoodAnalyser(message);
        string result = moodAnalyser.AnalyseMood();
        Assert.AreEqual("SAD", result);
    }

    [TestMethod]
    public void TestAnalyseMood_AnyMessage_ReturnsHappy()
    {
        string message = "I am in Any Mood";
        moodAnalyser = new MoodAnalyser(message);
        string result = moodAnalyser.AnalyseMood();
        Assert.AreEqual("HAPPY", result);
    }
}

}

