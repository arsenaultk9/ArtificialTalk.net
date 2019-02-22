using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtificialTalk.net;

namespace DaisyTalker
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random(DateTime.Now.Millisecond);
            var sentenceParser = new SentenceAnalyser();
            var lexicon = new Lexicon();

            Console.WriteLine("Hello!");
            lexicon.ManageWord(sentenceParser.Analyse("Hello!").Single());

            while (true)
            {
                var userInput = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    var words = sentenceParser.Analyse(userInput);

                    foreach (var sentenceWord in words)
                    {
                        lexicon.ManageWord(sentenceWord);
                    }
                }

                var sentenceParts = new List<string>();

                var firstWordPossibility = lexicon.Words().Where(w => w.CanStartSentence);
                var firstWordCount = firstWordPossibility.Count();
                var firstWord = firstWordPossibility.ElementAt(random.Next(0, firstWordCount));
                
                sentenceParts.Add(firstWord.Word);

                var nextWord = firstWord;
                while (!EndSentence(nextWord))
                {
                    var nextWordPossibilities = nextWord.GetPossibleFollowingWords().Count();
                    var nextWordString = nextWord.GetPossibleFollowingWords().ElementAt(random.Next(0, nextWordPossibilities));
                    nextWord = lexicon.Words().Single(w => w.Word == nextWordString);

                    sentenceParts.Add(nextWord.Word);
                }


                Console.WriteLine(string.Join(" ", sentenceParts));
            }    
        }

        private static bool EndSentence(SentenceWord currentWord)
        {
            var random = new Random(DateTime.Now.Millisecond);
            var canEndSentence = currentWord.CanEndSentence;
            canEndSentence = canEndSentence && random.Next(0, currentWord.GetPossibleFollowingWords().Count() + 1) == 0;

            return canEndSentence;
        }
    }
}
