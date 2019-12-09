using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.IntcodeComputer
{
    public class Memory
    {
        #region Data
        private long[] _content;

        #endregion

        #region Constructor
        public Memory() : this(string.Empty)
        {
        }

        public Memory(string input, char separator = ',')
        {
            LoadMemory(input, separator);
        }

        #endregion

        #region Properties
        public long[] Content => _content;
        
        #endregion

        #region Methods
        public void LoadMemory(string inString, char separator = ',')
        {
            var inArr = inString.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            int count = inArr.Length;

            _content = new long[count];

            for (int i = 0; i < count; i++)
            {
                if(!long.TryParse(inArr[i], out Content[i]))
                    throw new InvalidOperationException($"Fehlerhafter input string an Position: {i}");
            }
        }

        public long GetFromAddress(int index)
        {
            if (index < 0)
                throw new InvalidOperationException("Index außerhalb des Bereichs");
            else if (index >= Content.Length)
                ExpandMemory(index + 1);

            return Content[index];
        }

        public void SaveAtAddress(int index, long value)
        {
            if (index < 0)
                throw new InvalidOperationException("Index außerhalb des Bereichs");
            else if (index >= Content.Length)
                ExpandMemory(index + 1);

            Content[index] = value;
        }

        public void SaveAtAddress(long index, long value)
        {
            if (index < 0 || index >= int.MaxValue)
                throw new InvalidOperationException("Index außerhalb des Bereichs");
            else if (index >= Content.Length)
                ExpandMemory((int)index + 1);

            Content[index] = value;
        }

        private void ExpandMemory(int newSize)
        {
            Array.Resize(ref _content, newSize);

        }

        #endregion
    }
}
