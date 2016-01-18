using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TextAnalyzer.Implementation;
using TextAnalyzer.Interface;

namespace TextAnalyzer.Tests.Steps
{
    [Binding]
    public sealed class WordFrequencyCounterStep
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        private IWordFrequencyCounter wordFrequencyCounter;
        private string _sentence = string.Empty;
        public WordFrequencyCounterStep()
        {
            this.wordFrequencyCounter = new WordFrequencyCounter();
        }

        [Given(@"I entered '(.*)' into the program")]
        public void GivenIHaveEnteredASentenceIntoTheWrodFrequencyCounter(string sentence)
        {
            wordFrequencyCounter.AddSentence(sentence);
        }

        [When(@"the calculation called")]
        public void WhenTheCalculationAreCalled()
        {
            wordFrequencyCounter.Calculate();
        }

        [When(@"get top record of concurrent queue")]
        public void WhenGetLastRecordOfConcrrentQueue()
        {
            wordFrequencyCounter.Sentences.TryPeek(out _sentence);
        }

        [When(@"the calculation and Reset are called")]
        public void WhenTheCalculationAndResetAreCalled()
        {
            wordFrequencyCounter.Calculate();
            Assert.IsTrue(wordFrequencyCounter.WordFrequency.Count>0);
            wordFrequencyCounter.Reset();
            Assert.IsTrue(wordFrequencyCounter.WordFrequency.Count == 0);
        }

        [Then(@"The sentence '(.*)' should exist")]
        public void ThenSentenceShouldExist(string sentence)
        {
            Assert.AreEqual(sentence, _sentence);
        }

        [Then(@"the same as given the sentence '(.*)'")]
        public void AndTheSameAsGivenTheSentence(string sentence)
        {
            string topSentence;
            wordFrequencyCounter.Sentences.TryPeek(out topSentence);
            Assert.AreEqual(sentence, topSentence);
        }

        [Then(@"the word's count should return '(.*)'")]
        public void TheWordCountShouldReturn(int count)
        {
            Assert.IsTrue(wordFrequencyCounter.WordFrequency.FirstOrDefault().Value ==count);
        }

        [Then(@"the total no of word should return '(.*)'")]
        public void TheTotalNoOfWordShouldReturn(int count)
        {
            Assert.IsTrue(wordFrequencyCounter.WordFrequency.Count == count);
        }

        [Then(@"the total no of word should return a distinct list of words in the sentence and the number of times they have occurred")]
        public void ThenTheResultShouldBe()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            result.Add("this",2);
            result.Add("is",2);
            result.Add("a",1);
            result.Add("statement",1);
            result.Add("and",1);
            result.Add("so",1);
            foreach (var key in wordFrequencyCounter.WordFrequency.Keys)
            {
                NUnit.Framework.Assert.AreEqual(result[key], wordFrequencyCounter.WordFrequency[key]);
            }
        }
    }
}
