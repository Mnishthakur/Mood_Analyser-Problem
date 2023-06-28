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

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        MoodAnalyser other = (MoodAnalyser)obj;
        return message == other.message;
    }

    public override int GetHashCode()
    {
        return message.GetHashCode();
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
        string message1 = "I am feeling happy today";
        string message2 = "I am feeling happy today";

        MoodAnalyserFactory factory = new MoodAnalyserFactory();
        MoodAnalyser moodAnalyser1 = factory.CreateMoodAnalyser(message1);
        MoodAnalyser moodAnalyser2 = factory.CreateMoodAnalyser(message2);

        bool areEqual = moodAnalyser1.Equals(moodAnalyser2);
        Console.WriteLine("Are MoodAnalyser objects equal? " + areEqual);
    }
}
