using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Name_sorter
{
    class Program
    {
        static string the_dir = AppDomain.CurrentDomain.BaseDirectory; //working directory
        static string inputfileextension = ".txt"; //input file extension

        static void Main(string[] args)
        {
            mainProcessFunc("unsorted-names-listaa");
        }

        private static void mainProcessFunc(string filename)
        {
            Stopwatch stopwatch = Stopwatch.StartNew(); //creates and start the instance of Stopwatch
            
            var aa = File.Exists(the_dir + filename + inputfileextension);

            if(!aa)
            {
                Console.WriteLine("File input not exists in working directory.");
                Console.WriteLine("Please check again.");
                Console.ReadLine();
            }
            else
            {
                //main process of name-sort
                var lines = File.ReadLines(the_dir + filename + inputfileextension)
                .Select(item => {
                    int lastSpace = item.LastIndexOf(' ');
                    return new
                    {
                        Name = item.Substring(0, lastSpace).Trim(),
                        Firstname = item.Substring(lastSpace, item.Length - lastSpace).Trim()
                    };
                })
                .OrderBy(x => x.Firstname)
                .ThenBy(x => x.Name)
                .ToList();

                StringBuilder outputLines = new StringBuilder(); //declare stringbuilder
                                                                 //iterate list and append to string builder variable
                foreach (var s in lines)
                {
                    outputLines.AppendLine(s.Name + " " + s.Firstname);
                }

                Console.WriteLine(outputLines); //print to screen

                File.WriteAllText(the_dir + "sorted-names-list.txt", outputLines.ToString()); //write outputfile

                //code for count execution time
                System.Threading.Thread.Sleep(500);
                stopwatch.Stop();
                Console.WriteLine("execution time : " + stopwatch.ElapsedMilliseconds + " ms");
                Console.ReadLine();
            }
        }

        private bool fileCheckingFunc(string filename)
        {
            return File.Exists(the_dir + filename + inputfileextension);
        }
    }
}
