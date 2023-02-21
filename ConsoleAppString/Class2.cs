using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppString
{
    internal class Class2
    {
        class WordCl
        {
            public string Word = "";
            public string Space = "";
            public bool Current = false;
            public bool WorkedOut = false;
        }


        public string Transform(string input, int line_width)
        {
            string result = "";
            string resStr;
            var words = new List<WordCl>();
            foreach (var word in input.Split(' '))
            {
                if (word!= "") words.Add(new WordCl { Word = word });
            }



            for (int i = 0; i < words.Count; i++)
            {
                words[i].Current = true;
                int currentWidth =  words[i].Word.Length;


                int count = words.Where(x => x.Current).Sum(x => x.Word.Length+x.Space.Length);




                if (count == line_width)
                {
                    words.Where(x => x.Current).Select(x=>x.Word+x.Space).
                    continue;
                }

                if (count > line_width)
                {
                    
                    words[i].Space.Remove(words[i].Space.Length-1);
                    words[i].Current = false;
                    i -= 1;


                    continue;
                }

                if ((i == words.Count - 1) && (count < line_width))
                {

                }

                words[i].Space += " ";
            }//for i



            return result;
        }

        string Fill(int line_width, int EndWord, int wordsLength, string?[] words,
            ref int count, ref int totalWords, ref int beginWord)
        {
            string result = "";
            int minSpaces;
            int needSpaces = line_width - count;
            if (totalWords == 1)
            {
                if ((line_width - count) < 0)
                    result += words[EndWord];
                else
                    result += words[EndWord] + new string(' ', line_width - count);
            }
            else
            {
                minSpaces = needSpaces / (totalWords - 1) + 1;
                int advSpaces = needSpaces % (totalWords - 1);

                int addSpace;
                for (int i1 = beginWord; i1 < EndWord; i1++)
                {
                    if ((i1 - beginWord) < advSpaces) addSpace = 1; else addSpace = 0;
                    if (i1 == wordsLength) minSpaces = 0;
                    result += words[i1] + new string(' ', minSpaces + addSpace);
                }
                result += words[EndWord];
            }
            totalWords = 0;
            beginWord = EndWord + 1;
            count = 0;

            if (EndWord < wordsLength - 1) result += "\n";
            return result;
        }



        public void Test()
        {
            var test_cases = new[] {
                ("", 5, ""),
                ("test", 5, "test "),
                ("Lorem ipsum dolor sit amet consectetur adipiscing elit sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", 12,
                 "Lorem  ipsum\ndolor    sit\namet        \nconsectetur \nadipiscing  \nelit  sed do\neiusmod     \ntempor      \nincididunt  \nut labore et\ndolore magna\naliqua      "),
                ("Lorem     ipsum    dolor", 17, "Lorem ipsum dolor")
            };


            foreach (var test in test_cases)
            {
                string str = Transform(test.Item1, test.Item2);
                if (test.Item3 != str)
                {
                    Console.WriteLine(@"Ожидалось: _{0}_, Получилось: _{1}_", test.Item3, str);
                }
            }
            Console.WriteLine(@"Всё ОК");
        }








    }
}
