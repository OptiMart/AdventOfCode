using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.IntcodeComputer.Instructions
{
    public enum ParameterMode
    {
        Position = 0,
        Imidiate = 1
    }

    public abstract class BaseInstruction : IInstructions
    {
        #region Data
        private int[] _parameters;
        private ParameterMode[] _paraMode;

        #endregion

        #region Constructor
        protected BaseInstruction() : this(-1, 0)
        { }

        protected BaseInstruction(int opCode, int paramCount)
        {
            OPCode = opCode;
            ParameterCount = paramCount;
            InitParameter();
        }

        #endregion

        #region Properties
        public int OPCode { get; private set; }
        public int ParameterCount { get; private set; }

        #endregion

        #region Methods
        public bool CheckInstruction(int code)
        {
            if (code % 100 == OPCode)
                return true;

            return false;
        }

        public bool CheckInstruction(Memory memory, int index)
        {
            int opCode = memory.GetFromAddress(index);

            if (!CheckInstruction(opCode))
                return false;

            InitParameter();
            LoadParameterModes(opCode);
            LoadParameter(memory, index);

            return true;
        }

        public virtual int ExecuteInstruction(Memory memory, ref int index, Stack<int> stack = null)
        {
            DoLoadParameter(memory, stack);
            DoCalculation();
            DoSaveResult(memory, stack);

            IncreaseIndex(ref index);
            return OPCode;
        }

        protected abstract void DoLoadParameter(Memory memory, Stack<int> stack = null);
        protected abstract void DoCalculation();
        protected abstract void DoSaveResult(Memory memory, Stack<int> stack = null);
        
        private void IncreaseIndex(ref int index)
        {
            index += ParameterCount + 1;
            ClearParameter();
        }

        private void InitParameter()
        {
            _parameters = new int[ParameterCount];
            _paraMode = new ParameterMode[ParameterCount];
        }

        private void ClearParameter()
        {
            _parameters = null;
            _paraMode = null;
        }

        public void LoadParameterModes(int opCode)
        {
            int modes = opCode / 100;

            for (int i = 0; i < ParameterCount; i++)
            {
                int temp = modes % 10;
                if (Enum.IsDefined(typeof(ParameterMode), temp))
                    _paraMode[i] = (ParameterMode)(modes % 10);
                else
                    throw new InvalidOperationException("Falscher Parametermode");

                modes /= 10;
            }
        }

        public void LoadParameter(Memory memory, int index)
        {
            if (_parameters.Length != ParameterCount)
                InitParameter();

            for (int i = 0; i < ParameterCount; i++)
                _parameters[i] = memory.GetFromAddress(index + i + 1);
        }

        public ParameterMode GetParameterMode(int index)
        {
            if (index <= 0 || index > ParameterCount)
                throw new InvalidOperationException("Ungültiger Parameterindex");

            return _paraMode[index - 1];
        }

        public int GetParameter(int index)
        {
            if (index <= 0 || index > ParameterCount)
                throw new InvalidOperationException("Ungültiger Parameteraufruf");

            return _parameters[index - 1];
        }

        public void PutParameter(Memory memory, int parameterID, int value)
        {
            if (parameterID <= 0 || parameterID > ParameterCount)
                throw new InvalidOperationException("Ungültiger Parameteraufruf");

            if (_paraMode[parameterID - 1] == ParameterMode.Imidiate)
                throw new InvalidOperationException("Ungültiger Parametermode für Output");

            memory.SaveAtAddress(_parameters[parameterID - 1], value);
        }

        #endregion
    }
}
