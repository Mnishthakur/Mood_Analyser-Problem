using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace TestAnalyser
{
    enum MoodAnalysisError
{
    NULL_MOOD,
    EMPTY_MOOD
}

class MoodAnalysisException : Exception
{
    public MoodAnalysisError Error { get; }

    public MoodAnalysisException(MoodAnalysisError error, string message) : base(message)
    {
        Error = error;
    }
}

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
                throw new MoodAnalysisException(MoodAnalysisError.NULL_MOOD, "Mood message cannot be null.");

            if (string.IsNullOrWhiteSpace(message))
                throw new MoodAnalysisException(MoodAnalysisError.EMPTY_MOOD, "Mood message cannot be empty.");

            if (message.ToLower().Contains("sad"))
                return "SAD";
            else
                return "HAPPY";
        }
        catch (MoodAnalysisException ex)
        {
            Console.WriteLine("Exception occurred: " + ex.Message);
            throw;
        }
    }
}

class MoodAnalyserFactory
{
    public static MoodAnalyser CreateMoodAnalyserObject()
    {
        Type type = typeof(MoodAnalyser);
        ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
        MoodAnalyser moodAnalyser = (MoodAnalyser)constructor.Invoke(null);
        return moodAnalyser;
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
    public void TestAnalyseMood_NullMessage_ThrowsMoodAnalysisException()
    {
        string message = null;
        moodAnalyser = new MoodAnalyser(message);
        Assert.ThrowsException<MoodAnalysisException>(() => moodAnalyser.AnalyseMood());
    }

    [TestMethod]
    public void TestAnalyseMood_EmptyMessage_ThrowsMoodAnalysisException()
    {
        string message = "";
        moodAnalyser = new MoodAnalyser(message);
        Assert.ThrowsException<MoodAnalysisException>(() => moodAnalyser.AnalyseMood());
    }

    [TestMethod]
    public void TestCreateMoodAnalyserObject_ReturnsMoodAnalyserObject()
    {
        MoodAnalyser moodAnalyser = MoodAnalyserFactory.CreateMoodAnalyserObject();
        Assert.IsNotNull(moodAnalyser);
    }
}
}



