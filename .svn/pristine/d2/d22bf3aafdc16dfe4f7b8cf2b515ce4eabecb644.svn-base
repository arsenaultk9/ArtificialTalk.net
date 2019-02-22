using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ArtificialTalk.net.tests
{
    [TestFixture]
    class SentenceAnalyserTests
    {
        private const string Word1 = "Hello";
        private const string Word2 = "Kurt";
        private const string Word3 = "Cobain";

        private readonly SentenceAnalyser sentenceAnalyser;

        public SentenceAnalyserTests()
        {
            sentenceAnalyser = new SentenceAnalyser();
        }

        [Test]
        public void SentenceAnalyserReturnsWordWhenAnalysingOneWord()
        {
            var word = sentenceAnalyser.Analyse(Word1);
            Assert.AreEqual(Word1, word.First().Word);
        }

        [Test]
        public void SentenceAnalyserReturnsWordsWhenAnalysingWordsSeperatedBySpace()
        {
            var sentenceWords = sentenceAnalyser.Analyse(string.Join(" ", Word1, Word2, Word3));
            Assert.AreEqual(Word1, sentenceWords.First().Word);
        }

        [Test]
        public void SentenceAnalyserSpecifiesWhenWordIsFirstInSentence()
        {
            var sentenceWords = sentenceAnalyser.Analyse(string.Join(" ", Word1, Word2, Word3));
            Assert.IsTrue(sentenceWords.First().CanStartSentence);
        }

        [Test]
        public void SentenceAnalyserSpecifiesWhenWordIsLastInSentence()
        {
            var sentenceWords = sentenceAnalyser.Analyse(string.Join(" ", Word1, Word2, Word3));
            Assert.IsTrue(sentenceWords.Last().CanEndSentence);
        }

        [Test]
        public void SentenceAnalyserSpecifiesWhichWordsFollow()
        {
            var sentenceWords = sentenceAnalyser.Analyse(string.Join(" ", Word1, Word2, Word3)).ToList();

            Assert.AreEqual(Word2, sentenceWords.ElementAt(0).GetPossibleFollowingWords().Single());
            Assert.AreEqual(Word3, sentenceWords.ElementAt(1).GetPossibleFollowingWords().Single());
        }
    }
}
