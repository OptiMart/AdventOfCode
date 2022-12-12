namespace AoC.AdventOfCode.Common.ElvDevice.FileSystem
{
    internal class ElvFilesystem
    {
        #region Constructor
        public ElvFilesystem()
        {
            Initialize();
        }

        #endregion

        #region Properties
        public ElvDirectory Root { get; set; }
        public ElvDirectory Location { get; set; }

        #endregion

        #region Methods
        public void Initialize()
        {
            Root = new ElvDirectory("/");
            ChangeDirectory("/");
        }

        public void ChangeDirectory(string dir)
        {
            switch (dir)
            {
                case "/":
                    Location = Root;
                    break;
                case "..":
                    if (Location.Parent != null)
                        Location = Location.Parent as ElvDirectory;
                    else
                        Console.WriteLine("Location.Parent is null");
                    break;
                default:
                    ElvDirectory loc = Location.Children.OfType<ElvDirectory>().First(x => x.Name == dir);
                    if (loc != null)
                        Location = loc;
                    else
                        Console.WriteLine("Location.Children.First is null");
                    break;
            }
        }

        public void AddDirectory(string name)
        {
            Location.AddDirectory(name);
        }

        public void AddFile(string name, long size)
        {
            Location.AddFile(name, size);
        }

        public void CalcDirectorySizes()
        {
            Root.CalcDirectorySize();
        }

        public long GetDirectorySizeSummary(Func<ElvDirectory, bool> predicate)
        {
            return Root.GetDirectorySizeSummary(-1, predicate);
        }

        public List<ElvDirectory> GetDirectory(Func<ElvDirectory, bool> predicate)
        {
            return Root.GetDirectory(predicate);
        }

        #endregion
    }
}
