using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialTalk.net
{
    public class SentenceAnalyser
    {
        public IEnumerable<SentenceWord> Analyse(string sentence)
        {
            var words = new List<SentenceWord>();

            var sentenceWords = sentence.Split(Convert.ToChar(" "));

            for (var wordIndex = 0; wordIndex < sentenceWords.Count(); wordIndex++)
            {
                var wordInSentence = sentenceWords[wordIndex];

                var isFirstWord = sentenceWords.First() == wordInSentence;
                var isLastWord = sentenceWords.Last() == wordInSentence;

                var sentenceWord = new SentenceWord(wordInSentence, isFirstWord, isLastWord);
                var nextWordIndex = wordIndex + 1;

                if (nextWordIndex < sentenceWords.Count())
                {
                    sentenceWord.AddPossibleFollowingWord(sentenceWords[wordIndex + 1]);
                }

                words.Add(sentenceWord);
            }

            return words;
        }
    }
}
