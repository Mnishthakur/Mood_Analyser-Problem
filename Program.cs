using System;
using System.Reflection;

public class MoodAnalyser
{
    private string message;

    public string AnalyseMood()
    {
        if (message.Contains("happy", StringComparison.OrdinalIgnoreCase))
            return "HAPPY";
        else if (message.Contains("sad", StringComparison.OrdinalIgnoreCase))
            return "SAD";
        else
            return "UNKNOWN";
    }
}

public class Program
{
    public static void Main()
    {
        MoodAnalyser moodAnalyser = new MoodAnalyser();

        // Use reflection to set the message field
        Type moodAnalyserType = typeof(MoodAnalyser);
        FieldInfo messageField = moodAnalyserType.GetField("invalidField", BindingFlags.NonPublic | BindingFlags.Instance);

        try
        {
            if (messageField != null)
            {
                // Set the message value using reflection
                messageField.SetValue(moodAnalyser, "I am feeling Happy");

                // Invoke AnalyseMood method using reflection
                MethodInfo analyseMoodMethod = moodAnalyserType.GetMethod("AnalyseMood");
                string mood = (string)analyseMoodMethod.Invoke(moodAnalyser, null);

                // Assert the mood is "HAPPY"
                if (mood == "HAPPY")
                {
                    Console.WriteLine("Mood: " + mood);
                }
                else
                {
                    Console.WriteLine("Mood is not HAPPY.");
                }
            }
            else
            {
                throw new FieldAccessException("Unable to find the 'message' field in MoodAnalyser class.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
