using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.IntcodeComputer
{
    public class Memory
    {
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
        public int[] Content { get; private set; }
        
        #endregion

        #region Methods
        public void LoadMemory(string inString, char separator = ',')
        {
            var inArr = inString.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            int count = inArr.Length;

            Content = new int[count];

            for (int i = 0; i < count; i++)
            {
                if(!int.TryParse(inArr[i], out Content[i]))
                    throw new InvalidOperationException($"Fehlerhafter input string an Position: {i}");
            }
        }

        public int GetFromAddress(int index)
        {
            if (index < 0 || index >= Content.Length)
                throw new InvalidOperationException("Index außerhalb des Bereichs");

            return Content[index];
        }

        public void SaveAtAddress(int index, int value)
        {
            if (index < 0 || index >= Content.Length)
                throw new InvalidOperationException("Index außerhalb des Bereichs");

            Content[index] = value;
        }

        #endregion
    }
}
