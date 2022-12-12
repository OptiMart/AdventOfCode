using AoC.Puzzles.Common.IntCodeComputer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.IntCodeComputer.Instructions.Base
{
    public enum ParameterMode
    {
        Position = 0,
        Imidiate = 1,
        Relative = 2,
    }

    public abstract class BaseInstruction : IInstructions
    {
        #region Data
        private long[] _parameters;
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
        public bool CheckInstruction(long code)
        {
            if (code % 100 == OPCode)
                return true;

            return false;
        }

        public bool CheckInstruction(Memory memory, int index)
        {
            var opCode = memory.GetFromAddress(index);

            if (!CheckInstruction(opCode))
                return false;

            InitParameter();
            LoadParameterModes(opCode);
            LoadParameter(memory, index);

            return true;
        }

        //public virtual int ExecuteInstruction(Memory memory, ref int index, LinkedList<int> inStack = null, LinkedList<int> outStack = null)
        //{
        //    DoLoadParameter(memory, inStack);
        //    DoCalculation();
        //    DoSaveResult(memory, outStack);

        //    //IncreaseIndex(ref index);
        //    return OPCode;
        //}

        public virtual int ExecuteInstruction(OpHelper opHelper)
        {
            DoLoadParameter(opHelper);
            DoCalculation();
            DoSaveResult(opHelper);

            IncreaseIndex(opHelper.InstructionPointer);

            return OPCode;
        }

        protected abstract void DoLoadParameter(OpHelper opHelper);
        protected abstract void DoCalculation();
        protected abstract void DoSaveResult(OpHelper opHelper);

        protected void IncreaseIndex(InstructionPointer pointer)
        {
            pointer.IncresePointer(ParameterCount + 1);
            ClearParameter();
        }

        private void InitParameter()
        {
            _parameters = new long[ParameterCount];
            _paraMode = new ParameterMode[ParameterCount];
        }

        private void ClearParameter()
        {
            _parameters = null;
            _paraMode = null;
        }

        public void LoadParameterModes(long opCode)
        {
            var modes = opCode / 100;

            for (int i = 0; i < ParameterCount; i++)
            {
                int temp = (int)(modes % 10);
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

        public long GetParameter(int parameterID)
        {
            if (parameterID <= 0 || parameterID > ParameterCount)
                throw new InvalidOperationException("Ungültiger Parameteraufruf");

            return _parameters[parameterID - 1];
        }

        public long GetParameterValue(int parameterID, OpHelper opHelper)
        {
            switch (GetParameterMode(parameterID))
            {
                case ParameterMode.Position:
                    return opHelper.Memory.GetFromAddress((int)GetParameter(parameterID));
                case ParameterMode.Imidiate:
                    return GetParameter(parameterID);
                case ParameterMode.Relative:
                    return opHelper.Memory.GetFromAddress((int)(GetParameter(parameterID) + opHelper.RelativeBase));
                default:
                    break;
            }

            throw new ArgumentException("Ungültiger Parametermode");
        }

        public void PutParameter(Memory memory, int parameterID, long value)
        {
            if (parameterID <= 0 || parameterID > ParameterCount)
                throw new InvalidOperationException("Ungültiger Parameteraufruf");

            if (_paraMode[parameterID - 1] == ParameterMode.Imidiate)
                throw new InvalidOperationException("Ungültiger Parametermode für Output");

            memory.SaveAtAddress((int)_parameters[parameterID - 1], value);
        }

        public void PutParameterValue(int parameterID, long value, OpHelper opHelper)
        {
            if (parameterID <= 0 || parameterID > ParameterCount)
                throw new InvalidOperationException("Ungültiger Parameteraufruf");

            switch (GetParameterMode(parameterID))
            {
                case ParameterMode.Position:
                    opHelper.Memory.SaveAtAddress(_parameters[parameterID - 1], value);
                    break;
                case ParameterMode.Imidiate:
                    throw new InvalidOperationException("Ungültiger Parametermode für Output");
                case ParameterMode.Relative:
                    opHelper.Memory.SaveAtAddress(_parameters[parameterID - 1] + opHelper.RelativeBase, value);
                    break;
                default:
                    throw new ArgumentException("Ungültiger Parametermode");
            }
        }

        #endregion
    }
}
