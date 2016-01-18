using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using TextAnalyzer.Interface;

namespace TextAnalyzer.Implementation
{
    public class WordFrequencyCounter : IWordFrequencyCounter
    {
        private readonly ConcurrentQueue<string> _sentences = new ConcurrentQueue<string>();
        public ConcurrentQueue<string> Sentences {get {return _sentences;} }
        private readonly ConcurrentDictionary<string, int> _wordFrequency = new ConcurrentDictionary<string, int>();
        public ConcurrentDictionary<string, int> WordFrequency { get { return _wordFrequency; } }
        
        public void AddSentence(string sentence)
        {
            _sentences.Enqueue(sentence);
        }
        
        private IEnumerable<string> SplitWord(string sentence)
        {
            char[] delimiters = { '\r', '\n' ,'\t',' ',',','.'};
            return sentence.Split(delimiters).Where(x=> x.Trim() !=string.Empty);
        }

        public void Reset()
        {
            if (_wordFrequency != null && _wordFrequency.Count > 0)
            {
                _wordFrequency.Clear();
            }
        }

        public void Calculate()
        {
            for (int count =0; count<_sentences.Count; count++)
            {
                string sentence;
                if (_sentences.TryDequeue(out sentence))

                if (string.IsNullOrEmpty(sentence)) continue;

                var words = SplitWord(sentence);
                foreach (var word in words)
                {
                    if (WordFrequency.ContainsKey(word.ToLower()))
                    {
                        WordFrequency[word.ToLower()]++;
                    }
                    else
                    {
                        if (WordFrequency.TryAdd(word.ToLower(), 1) == false)
                        {
                            throw new Exception("Add new word to WordFrequencyList failed.");
                        }
                    }
                }
            }
        }
    }
}
