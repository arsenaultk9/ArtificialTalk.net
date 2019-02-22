using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ArtificialTalk.net.tests
{
    [TestFixture]
    class LexiconTests
    {
        private const string DefaultWord = "Hello";
        private const string PossibleFollowingWordOne = "World";
        private const string PossibleFollowingWordTwo = "Bob";

        [Test]
        public void AddedWordToLexiconIsAdded()
        {
            // ARRANGE
            var lexicon = new Lexicon();

            // ACT
            lexicon.ManageWord(new SentenceWord(DefaultWord));

            // ASSERT
            Assert.AreEqual(DefaultWord, lexicon.Words().Single().Word);
        }

        [Test]
        public void WhenWordExistsInLexicon_AddedWordIsSameAsOldVersion()
        {
            // ARRANGE
            var lexicon = new Lexicon();
            var sentenceWord = new SentenceWord(DefaultWord);

            // ACT
            lexicon.ManageWord(sentenceWord);
            lexicon.ManageWord(sentenceWord);

            // ASSERT
            Assert.IsTrue(lexicon.Words().Count(w => w.Word == DefaultWord) == 1);
            Assert.IsTrue(lexicon.Words().Count(w => w.CanStartSentence == false) == 1);
            Assert.IsTrue(lexicon.Words().Count(w => w.CanEndSentence == false) == 1);
        }

        [Test]
        public void WhenWordExistsInLexicon_AddedWordWithPossibleStartSentencePropertyOverridesAncientProperty()
        {
            // ARRANGE
            var lexicon = new Lexicon();
            var sentenceWord = new SentenceWord(DefaultWord);
            var updatedSentenceWord = new SentenceWord(DefaultWord, true);

            // ACT
            lexicon.ManageWord(sentenceWord);
            lexicon.ManageWord(updatedSentenceWord);

            var lexiconWord = lexicon.Words().First();

            // ASSERT
            Assert.AreEqual(DefaultWord, lexiconWord.Word);
            Assert.AreEqual(updatedSentenceWord.CanStartSentence, lexiconWord.CanStartSentence);
        }

        [Test]
        public void WhenWordExistsInLexiconCanStartSentence_AddedWordDoesNotOverridesAncientProperty()
        {
            // ARRANGE
            var lexicon = new Lexicon();
            var sentenceWord = new SentenceWord(DefaultWord, true);
            var updatedSentenceWord = new SentenceWord(DefaultWord);

            // ACT
            lexicon.ManageWord(sentenceWord);
            lexicon.ManageWord(updatedSentenceWord);

            var lexiconWord = lexicon.Words().First();

            // ASSERT
            Assert.AreEqual(DefaultWord, lexiconWord.Word);
            Assert.AreEqual(true, lexiconWord.CanStartSentence);
        }

        [Test]
        public void WhenWordExistsInLexicon_AddedWordWithPossibleEndSentencePropertyOverridesAncientProperty()
        {
            // ARRANGE
            var lexicon = new Lexicon();
            var sentenceWord = new SentenceWord(DefaultWord);
            var updatedSentenceWord = new SentenceWord(DefaultWord, canEndSentence: true);

            // ACT
            lexicon.ManageWord(sentenceWord);
            lexicon.ManageWord(updatedSentenceWord);

            var lexiconWord = lexicon.Words().First();

            // ASSERT
            Assert.AreEqual(DefaultWord, lexiconWord.Word);
            Assert.AreEqual(updatedSentenceWord.CanEndSentence, lexiconWord.CanEndSentence);
        }

        [Test]
        public void WhenWordExistsInLexiconCanEndSentence_AddedWordDoesNotOverridesAncientProperty()
        {
            // ARRANGE
            var lexicon = new Lexicon();
            var sentenceWord = new SentenceWord(DefaultWord, canEndSentence: true);
            var updatedSentenceWord = new SentenceWord(DefaultWord);

            // ACT
            lexicon.ManageWord(sentenceWord);
            lexicon.ManageWord(updatedSentenceWord);

            var lexiconWord = lexicon.Words().First();

            // ASSERT
            Assert.AreEqual(DefaultWord, lexiconWord.Word);
            Assert.AreEqual(true, lexiconWord.CanEndSentence);
        }

        [Test]
        public void WhenExistingWordInLexiconHasPossibleFollowingWord_SameWordWithPossibleFollowingWordIsAdded()
        {
            // ARRANGE
            var lexicon = new Lexicon();
            var sentenceWord = new SentenceWord(DefaultWord);
            sentenceWord.AddPossibleFollowingWord(PossibleFollowingWordOne);

            var updatedSentenceWord = new SentenceWord(DefaultWord);
            sentenceWord.AddPossibleFollowingWord(PossibleFollowingWordTwo);

            // ACT
            lexicon.ManageWord(sentenceWord);
            lexicon.ManageWord(updatedSentenceWord);

            var lexiconWord = lexicon.Words().First();

            // ASSERT
            Assert.AreEqual(PossibleFollowingWordOne, lexiconWord.GetPossibleFollowingWords().ElementAt(0));
            Assert.AreEqual(PossibleFollowingWordTwo, lexiconWord.GetPossibleFollowingWords().ElementAt(1));
        }

        [Test]
        public void LexiconCanContainMultipleWords()
        {
            // ARRANGE
            var lexicon = new Lexicon();
            var sentenceWord = new SentenceWord(DefaultWord);
            var updatedSentenceWord = new SentenceWord(PossibleFollowingWordOne);

            // ACT
            lexicon.ManageWord(sentenceWord);
            lexicon.ManageWord(updatedSentenceWord);

            var lexiconWords = lexicon.Words().ToList();

            // ASSERT
            Assert.AreEqual(DefaultWord, lexiconWords.ElementAt(0).Word);
            Assert.AreEqual(PossibleFollowingWordOne, lexiconWords.ElementAt(1).Word);
        }
    }
}
