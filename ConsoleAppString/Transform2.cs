namespace ConsoleAppString
{
    public class Transform2 : ITransform
    {
        class WordCl
        {
            public string Word = "";
            public string Space = "";
            public bool Current = false;
            public bool WorkedOut = false;
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

        public string Go(string input, int line_width)
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

    }
}
