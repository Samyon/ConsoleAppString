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
            string resStr = "";
            var words = new List<WordCl>();
            foreach (var word in input.Split(' '))
            {
                if (word != "") words.Add(new WordCl { Word = word });
            }



            for (int i = 0; i < words.Count; i++)
            {
                words[i].Current = true;
                resStr = string.Join("", words.Where(x => x.Current).Select(x => x.Word + x.Space));

                if (resStr.Length == line_width)
                {
                    result += resStr;
                    if (i < words.Count - 1) result += "\n";
                    foreach (var item in words.Where(x => x.Current))
                    {
                        item.Current = false;
                    }
                    continue;
                }

                if (resStr.Length > line_width)
                {
                    words[i].Current = false;
                    i -= 1;
                    words[i].Space = words[i].Space.Remove(words[i].Space.Length - 1);
                    result += Fill(line_width, words);
                    if (i < words.Count - 1) result += "\n";
                    continue;
                }

                if ((i == words.Count - 1) && (resStr.Length < line_width))
                {
                    result += Fill(line_width, words);
                }

                words[i].Space += " ";
            }//for i



            return result;
        }

        string Fill(int line_width, List<WordCl> words)
        {
            string resStr = "";
            var currentWords = words.Where(x => x.Current).ToList();
            int count = currentWords.Count();
            for (int i = 0; ; i++)
            {
                if ((i == count - 1) || (count == 1))
                {
                    i = 0;
                }
                currentWords[i].Space += " ";

                resStr = string.Join("", currentWords.Select(x => x.Word + x.Space));
                if (resStr.Length == line_width)
                {
                    break;
                }
            }


            foreach (var item in currentWords)
            {
                item.Current = false;
            }
            return resStr;
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
