using System;
using System.Reflection;

public class MoodAnalyser
{
    private string message;

    public MoodAnalyser(string message)
    {
        this.message = message;
    }

    public string AnalyseMood()
    {
        if (message.Contains("happy", StringComparison.OrdinalIgnoreCase))
            return "Happy";
        else if (message.Contains("sad", StringComparison.OrdinalIgnoreCase))
            return "Sad";
        else
            return "Unknown";
    }
}

public class MoodAnalyserFactory
{
    public MoodAnalyser CreateMoodAnalyser(string message)
    {
        Type moodAnalyserType = typeof(MoodAnalyser);
        ConstructorInfo constructor = moodAnalyserType.GetConstructor(new Type[] { typeof(string) });

        if (constructor != null)
        {
            object[] constructorArgs = new object[] { message };
            MoodAnalyser moodAnalyser = (MoodAnalyser)constructor.Invoke(constructorArgs);
            return moodAnalyser;
        }
        else
        {
            throw new InvalidOperationException("Unable to find the parameterized constructor for MoodAnalyser.");
        }
    }
}

public class Program
{
    public static void Main()
    {
        string message = "I am feeling happy today";
        MoodAnalyserFactory factory = new MoodAnalyserFactory();
        MoodAnalyser moodAnalyser = factory.CreateMoodAnalyser(message);
        string mood = moodAnalyser.AnalyseMood();
        Console.WriteLine("Mood: " + mood);
    }
}
