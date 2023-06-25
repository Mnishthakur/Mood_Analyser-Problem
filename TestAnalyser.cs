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
        try
        {
            if (message is null)
                throw new ArgumentNullException("message", "Mood message cannot be null.");

            if (message.ToLower().Contains("sad"))
                return "SAD";
            else
                return "HAPPY";
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception occurred: " + ex.Message);
            return "HAPPY";
        }
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

    [TestMethod]
    public void TestAnalyseMood_NullMessage_ReturnsHappy()
    {
        string message = null;
        moodAnalyser = new MoodAnalyser(message);
        string result = moodAnalyser.AnalyseMood();
        Assert.AreEqual("HAPPY", result);
    }
}

