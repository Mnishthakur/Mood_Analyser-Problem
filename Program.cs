using System.Numerics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Net.Mime.MediaTypeNames;

namespace AnalyserTest
{
    class Program
{
    static void Main(string[] args)
    {
        TestAnalyser test = new TestAnalyser();
        test.Setup();
        test.TestAnalyseMood_SadMessage_ReturnsSad();
    }
}
}



