using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppString
{
    public class Test
    {
        void WriteError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public void Go(ITransform transform)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"Тест начат, тестируется " + transform.GetType());
            Console.ForegroundColor = ConsoleColor.Black;
            bool testStatus = true;
            var test_cases = new[] {
                ("", 5, ""),
                ("test", 5, "test "),
                ("Lorem ipsum dolor sit amet consectetur adipiscing elit sed do eiusmod tempor incididunt ut labore et dolore magna aliqua", 12,
                 "Lorem  ipsum\ndolor    sit\namet        \nconsectetur \nadipiscing  \nelit  sed do\neiusmod     \ntempor      \nincididunt  \nut labore et\ndolore magna\naliqua      "),
                ("Lorem     ipsum    dolor", 17, "Lorem ipsum dolor")
            };

            foreach (var test in test_cases)
            {
                string str = transform.Go(test.Item1, test.Item2);
                if (test.Item3 != str)
                {
                    WriteError("Ожидалось: _" + test.Item3 + "_, Получилось: _" + str + "_");
                    testStatus = false;
                }
            }
            if (testStatus)
                Console.WriteLine("Всё ОК");
            else
                WriteError("В ходе тестирования были выявлены ошибки - см. логи");

            Console.WriteLine();
        }

    }
}
