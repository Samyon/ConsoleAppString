namespace ConsoleAppString
{
    public class Transform1 : ITransform
    {
        public string Go(string input, int line_width)
        {
            string result = "";
            var words2 = input.Split(' ').ToList();
            words2.RemoveAll(string.IsNullOrEmpty);
            string?[] words = words2.ToArray();

            var wordsLength = words.Length;
            int beginWord = 0;
            int count = 0;
            int totalWords = 0;

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
                        count -= words[i].Length + 1;
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


    }
}
