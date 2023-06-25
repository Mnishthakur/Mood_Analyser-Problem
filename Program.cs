using System;
namespace moodanalyser
{
  class MoodAnalyser:
    def __init__(self):
        self.happy_keywords = ["happy", "joyful", "excited", "great"]
        self.sad_keywords = ["sad", "unhappy", "miserable", "terrible"]
        
    def analyseMood(self, message):
        message = message.lower()
        
        if any(keyword in message for keyword in self.happy_keywords):
            return "Happy"
        elif any(keyword in message for keyword in self.sad_keywords):
            return "Sad"
        else:
            return "Unable to determine the mood."
}
