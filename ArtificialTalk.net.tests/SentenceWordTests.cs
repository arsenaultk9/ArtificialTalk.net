using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ArtificialTalk.net.tests
{
    [TestFixture]
    public class SentenceWordTests
    {
        private const string DefaultWord = "Hello";
        private const string PossibleNextWordA = "World";
        private const string PossibleNextWordB = "George";

        [Test]
        public void SentenceWordHasWord()
        {
            var word = new SentenceWord(DefaultWord);
            Assert.AreEqual(DefaultWord, word.Word);
        }

        [Test]
        public void SentenceWordCannotBeEmpty()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new SentenceWord(""));
            Assert.AreEqual("Word", exception.ParamName);
        }

        [Test]
        public void SentenceWordCannotContainSpaces()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new SentenceWord("a b"));
            Assert.AreEqual("Word", exception.ParamName);
        }

        [Test]
        public void SentenceWordCanSpecifyPossibleFollowingWords()
        {
            // ARRANGE
            var word = new SentenceWord(DefaultWord);

            // ACT
            word.AddPossibleFollowingWord(PossibleNextWordA);
            word.AddPossibleFollowingWord(PossibleNextWordB);

            // ASSERT
            Assert.IsTrue(word.GetPossibleFollowingWords().Contains(PossibleNextWordA));
            Assert.IsTrue(word.GetPossibleFollowingWords().Contains(PossibleNextWordB));
        }

        [Test]
        public void SentenceWordCannotSpecifyPossibleFollowingWithSpaceInIt()
        {
            var word = new SentenceWord(DefaultWord);
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => word.AddPossibleFollowingWord(" "));
            Assert.AreEqual("possibleNextWord", exception.ParamName);
        }

        [Test]
        public void WithSentenceWordWithNextFollowingWord_WhenAddingSameFollowingWord_OnlyOneCopyOfWordIsContained()
        {
            // ARRANGE
            var word = new SentenceWord(DefaultWord);

            // ACT
            word.AddPossibleFollowingWord(PossibleNextWordA);
            word.AddPossibleFollowingWord(PossibleNextWordA);

            // ASSERT
            Assert.AreEqual(1, word.GetPossibleFollowingWords().Count(w => w == PossibleNextWordA));
        }

        [Test]
        public void CanSpecifyWhenWordCouldStartsSentence()
        {
            var word = new SentenceWord(DefaultWord, true);
            Assert.AreEqual(true, word.CanStartSentence);
        }

        [Test] 
        public void CanSpecifyWhenWordCouldEndSentence()
        {
            var word = new SentenceWord(DefaultWord, canEndSentence: true);
            Assert.AreEqual(true, word.CanEndSentence);
        }
    }
}
