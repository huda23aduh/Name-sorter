using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Name_sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew(); //creates and start the instance of Stopwatch

            string the_dir = AppDomain.CurrentDomain.BaseDirectory;

            string inputfilename = "unsorted-names-list"; //input file name
            string inputfileextension = ".txt"; //input file extension

            //main process of name-sort
            var lines = File.ReadLines(the_dir + inputfilename + inputfileextension)
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
            Console.WriteLine("execution time : "+ stopwatch.ElapsedMilliseconds + " ms");
            Console.ReadLine();
        }
    }
}
