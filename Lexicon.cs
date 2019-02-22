using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialTalk.net
{
    public class Lexicon
    {
        private readonly Dictionary<string, SentenceWord> words;

        public Lexicon()
        {
            words = new Dictionary<string, SentenceWord>();
        }

        public IEnumerable<SentenceWord> Words()
        {
            return words.Values;
        }

        public void ManageWord(SentenceWord sentenceWord)
        {
            var word = sentenceWord.Word;

            if (words.ContainsKey(word))
            {
                var existingWord = words[word];

                existingWord.CanStartSentence = existingWord.CanStartSentence ? existingWord.CanStartSentence : sentenceWord.CanStartSentence;
                existingWord.CanEndSentence = existingWord.CanEndSentence ? existingWord.CanEndSentence : sentenceWord.CanEndSentence;

                foreach (var followingWord in sentenceWord.GetPossibleFollowingWords())
                {
                    existingWord.AddPossibleFollowingWord(followingWord);
                }

                words[word] = existingWord;
            }
            else
            {
                words.Add(word, sentenceWord);
            }
        }
    }
}
