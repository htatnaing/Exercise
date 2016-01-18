using System.Collections.Concurrent;

namespace TextAnalyzer.Interface
{
    public interface IWordFrequencyCounter
    {
        ConcurrentQueue<string> Sentences { get; }
        ConcurrentDictionary<string, int> WordFrequency { get; }
        void AddSentence(string sentence);
        void Calculate();
        void Reset();
    }
}
