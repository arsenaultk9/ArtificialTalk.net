using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtificialTalk.net
{
    public class SentenceWord
    {
#region Members
        private string word;
        public string Word
        {
            get { return word; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Contains(" "))
                    throw new ArgumentOutOfRangeException("Word", "Word cannot be empty or contain spaces");

                word = value;
            }
        }

        private readonly HashSet<string> possibleFollowingWords;
        public bool CanStartSentence;
        public bool CanEndSentence;

#endregion

        public SentenceWord(string word, bool canStartSentence = false, bool canEndSentence = false)
        {
            Word = word;
            possibleFollowingWords = new HashSet<string>();
            CanStartSentence = canStartSentence;
            CanEndSentence = canEndSentence;
        }

        public void AddPossibleFollowingWord(string possibleNextWord)
        {
            if(string.IsNullOrWhiteSpace(possibleNextWord))
                throw new ArgumentOutOfRangeException("possibleNextWord", "Net words cannot contain space of nothing");

            possibleFollowingWords.Add(possibleNextWord);
        }

        public IEnumerable<string> GetPossibleFollowingWords()
        {
            return possibleFollowingWords;
        }
    }
}
