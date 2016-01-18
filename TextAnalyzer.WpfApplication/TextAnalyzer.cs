using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer.WpfApplication
{
    public class TextAnalyzer
    {
        public int NumberOfSentence { get; set; }
        public int NumberofWords { get; set; }
        public List<WordFrequency> WordFrequencies { get; set; }
    }

    public class WordFrequency
    {
        public WordFrequency()
        {
            WordName = string.Empty;
            Occcurance = 0;
        }

        public string WordName { get; set; }
        public int Occcurance { get; set; }
    }
}
