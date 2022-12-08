using AoC.AdventOfCode.Common.ElvDevice.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.ElvDevice
{
    internal class ElvDevice
    {
        #region Constructor
        public ElvDevice(long diskSpace)
        {
            DiskSpace = diskSpace;
        }

        #endregion

        #region Properties
        public ElvFilesystem Filesystem { get; private set; } = new ElvFilesystem();
        public long DiskSpace { get; private set; }
        public long FreeDiskSpace => DiskSpace - Filesystem.Root.Size;
        #endregion

        #region Methods
        public void ReadFilesystem(List<string> input)
        {
            bool ls = false;

            foreach (var line in input)
            {
                if (line[0] == '$')
                {
                    ls = false;
                    var cmd = line.Split(' ');
                    switch (cmd[1])
                    {
                        case "cd":
                            Filesystem.ChangeDirectory(cmd[2]);
                            break;
                        case "ls":
                            ls = true;
                            break;
                        default:
                            // Unbekannter Command
                            break;
                    }
                }
                else
                {
                    if (ls)
                    {
                        var info = line.Split(' ');

                        if (info[0] == "dir")
                        {
                            Filesystem.AddDirectory(info[1]);
                        }
                        else if (long.TryParse(info[0], out long size))
                        {
                            Filesystem.AddFile(info[1], size);
                        }
                        else
                        {
                            Console.WriteLine("Fehler ls");
                        }
                    }
                }
            }

            Filesystem.CalcDirectorySizes();
        }

        #endregion

    }
}
