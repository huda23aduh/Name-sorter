using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Tests that we expect to return true.
            string[] arr_name = {
                "Orson Milka Iddins",
                "Erna Dorey Battelle",
                "Flori Chaunce Franzel",
                "Odetta Sue Kaspar",
                "Leonerd Adda Mitchell Monaghan",
                "Hailey Annakin",
                "Leonerd Adda Micheli Monaghan",
                "Avie Annakin"
            };
            var lines = new List<string>(arr_name)
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

            foreach (var s in lines)
            {
                Console.WriteLine(s.Name + " " + s.Firstname);
            }
        }
    }
}
