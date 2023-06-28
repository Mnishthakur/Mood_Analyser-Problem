using System;
using System.Reflection;

public class MoodAnalyser
{
    private string message;

    public string Message
    {
        get { return message; }
        set { message = value; }
    }

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

public class Program
{
    public static void Main()
    {
        string initialMessage = "I am feeling happy today";
        MoodAnalyser moodAnalyser = new MoodAnalyser(initialMessage);
        Console.WriteLine("Initial Mood: " + moodAnalyser.AnalyseMood());

        // Use reflection to modify the mood dynamically
        string newMessage = "I am feeling sad now";
        Type moodAnalyserType = typeof(MoodAnalyser);
        PropertyInfo messageProperty = moodAnalyserType.GetProperty("Message");

        if (messageProperty != null)
        {
            messageProperty.SetValue(moodAnalyser, newMessage);

            // After modifying the message, analyze the mood again
            Console.WriteLine("Modified Mood: " + moodAnalyser.AnalyseMood());
        }
        else
        {
            Console.WriteLine("Unable to find the 'Message' property in MoodAnalyser class.");
        }
    }
}
