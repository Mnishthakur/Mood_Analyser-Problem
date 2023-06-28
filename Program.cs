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
        try
        {
            Type moodAnalyserType = Type.GetType("InvalidClassName"); // Provide the improper class name here
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
        catch (Exception ex)
        {
            throw new MoodAnalysisException("Error creating MoodAnalyser object", ex);
        }
    }
}

public class MoodAnalysisException : Exception
{
    public MoodAnalysisException(string message) : base(message)
    {
    }

    public MoodAnalysisException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string message = "I am feeling happy today";
            MoodAnalyserFactory factory = new MoodAnalyserFactory();
            MoodAnalyser moodAnalyser = factory.CreateMoodAnalyser(message);
            string mood = moodAnalyser.AnalyseMood();
            Console.WriteLine("Mood: " + mood);
        }
        catch (MoodAnalysisException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
