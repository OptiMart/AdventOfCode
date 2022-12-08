using System.Collections.Generic;
using System.Linq;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Day7_2022 test = new Day7_2022();
            test.calculate();

        }
    }


    class Day7_2022
    {
        readonly string[] lines = System.IO.File.ReadLines("./../../../../AdventOfCode/bin/Debug/Input/2022/Input_Day07.txt").ToArray();

        public void calculate()
        {
            string path = ""; // to keep track of where we are
            List<string> folders = new(); // list of all folders
            Dictionary<string, int> filesSizes = new(); // Dictionary with all files and sizes
            Dictionary<string, int> foldersSizes = new(); // Dictionary with all folders and sizes

            // add the root
            folders.Add("/");

            //Creating a list with all folders and a dictionary with all files
            foreach (string line in lines)
            {
                // if it starts with cd .., remove the path until the last . which is the / in this filesystem
                if (line.StartsWith("$ cd .."))
                {
                    path = path[..path.LastIndexOf(".")]; // /.folder.folder. -> /.folder.folder
                    path = path[..(path.LastIndexOf(".") + 1)]; // /.folder.folder -> /.folder.
                }
                // if it start with a cd, add that to the path + . which indicates new level
                else if (line.StartsWith("$ cd "))
                {
                    path += line[5..] + ".";
                }
                // if it starts with a dir, add the directory to the list of folders
                else if (line.StartsWith("dir"))
                {
                    folders.Add(path + line[4..]);
                }
                else if (line.StartsWith("$ ls"))
                {
                    // $ ls doesn't do anything
                }
                // if it is a file, add the file to the file dictionary where key = path incl filename and value = size
                else
                {
                    filesSizes.Add(path + line[line.IndexOf(" ")..], int.Parse(line[..line.IndexOf(" ")]));
                }
            }

            int answerToPart1 = 0;
            int answerToPart2 = 70000000; // setting this to the maximum memory since we want to compare with a large number initially

            // Loop through all folders and add all files that starts with that folder path - they belong in that folder
            foreach (string folder in folders)
            {
                int size = 0;
                foreach (KeyValuePair<string, int> file in filesSizes)
                {
                    if (file.Key.StartsWith(folder))
                    {
                        size += file.Value;
                    }
                }

                // Store the folder with size for part 2 
                foldersSizes.Add(folder, size);

                // Part 1 is about adding all folders with size < 100000
                if (size < 100000)
                {
                    answerToPart1 += size;
                }
            }

            // Space we are allowed to use: 70000000 - 30000000. Space we are currently using: Size of root folder. 
            // So we need to delete the smallest folder that are larger than Root size - (70000000-30000000)
            int spaceNeeded = foldersSizes["/"] - 40000000;
            foreach (KeyValuePair<string, int> folder in foldersSizes)
            {
                if (folder.Value > spaceNeeded && folder.Value < answerToPart2)
                {
                    answerToPart2 = folder.Value;
                }
            }

            System.Console.WriteLine("Answer part 1: " + answerToPart1 + ", and part 2: " + answerToPart2);
        }
    }
}
