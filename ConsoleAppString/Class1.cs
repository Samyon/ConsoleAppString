using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppString
{
    internal class Class1
    {




        public string Transform(string input, int line_width)
        {
            input = input.Trim();

            string result = "";
            var words = input.Split(' ');
            var wordsLength = words.Length;
            int beginWord = 0;
            int count = 0;
            int totalWords = 0;
            if (input == "")
            {
                return result;
            }

            for (int i = beginWord; i < wordsLength; i++)
            {
                count += words[i].Length;
                totalWords++;

                if (count == line_width)
                {
                    result += Fill(line_width, i, wordsLength, words,
                          ref count, ref totalWords, ref beginWord);
                    continue;
                }

                if (count > line_width)
                {

                    if (totalWords > 1)
                    {
                        totalWords--;
                        count -= words[i].Length+1;
                        i--;
                    }
                    result += Fill(line_width, i, wordsLength, words,
                          ref count, ref totalWords, ref beginWord);
                    continue;
                }

                if ((i == wordsLength - 1) && (count < line_width))
                {
                    result += Fill(line_width, i, wordsLength, words,
                             ref count, ref totalWords, ref beginWord);
                }

                count++;
            }//for i



            return result;
        }

        string Fill(int line_width, int EndWord, int wordsLength, string?[] words,
            ref int count, ref int totalWords, ref int beginWord)
        {
            string result = "";
            int advSpaces = 0;
            int minSpaces;
            int needSpaces = line_width - count;
            if (totalWords == 1)
            {
                if ((line_width - count) < 0)
                    result += words[EndWord];
                else
                    result += words[EndWord] + new String(' ', line_width - count);
            }
            else
            {
                minSpaces = needSpaces / (totalWords - 1) + 1;
                advSpaces = needSpaces % (totalWords - 1);

                int addSpace;
                for (int i1 = beginWord; i1 < EndWord; i1++)
                {
                    if ((i1 - beginWord) < advSpaces) addSpace = 1; else addSpace = 0;
                    if (i1 == wordsLength) minSpaces = 0;
                    result += words[i1] + new String(' ', minSpaces + addSpace);
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
                    Console.WriteLine(@"Ожидалось: _{0}_, Получилось: _{1}_", test.Item3, test.Item1);
                }



            }
        }
    }
}
