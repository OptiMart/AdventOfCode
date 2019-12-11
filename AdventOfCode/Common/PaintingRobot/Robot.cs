using AoC.AdventOfCode.Common.IntCodeComputer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.PaintingRobot
{
    public enum PaintColor
    {
        Black = 0,
        White = 1,
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
    }

    public enum Turn
    {
        TurnLeft = 0,
        TurnRight = 1,
    }

    public class Robot
    {
        #region Constructor
        public Robot()
        {

        }

        #endregion

        #region Properties
        public Computer CPU { get; private set; }
        public PaintArea PaintArea { get; private set; } = new PaintArea();
        public int PositionX { get; private set; } = 0;
        public int PositionY { get; private set; } = 0;
        public int DirectionX { get; private set; } = 0;
        public int DirectionY { get; private set; } = -1;
        public Direction Direction { get; private set; } = Direction.Up;

        #endregion

        #region Methods
        public void LoadProgram(string input)
        {
            CPU = new Computer(input);
            CPU.LoadDefaultInstructionSet();
        }

        private void Initialize()
        {
            PaintArea = new PaintArea();
            PositionX = 0;
            PositionY = 0;
            DirectionX = 0;
            DirectionY = -1;
            Direction = Direction.Up;
        }

        public void StartPainting(int startColor = 0)
        {
            Initialize();

            if (startColor != 0)
                SetColorUnderRobot(startColor);

            int exitCode;
            CPU.InputStack.AddLast((int)GetColorUnderRobot());
            do
            {
                exitCode = CPU.StartExecution();

                if (exitCode == 3)
                {
                    var color = CPU.OutputStack.First();
                    CPU.OutputStack.RemoveFirst();
                    var direction = CPU.OutputStack.First();
                    CPU.OutputStack.RemoveFirst();

                    SetColorUnderRobot(color);
                    MoveRobot((Turn)direction);
                    CPU.InputStack.AddLast((int)GetColorUnderRobot());
                }
            } while (exitCode != 99);
        }

        private void SetColorUnderRobot(long color)
        {
            PaintArea.SetColorToCoord(PositionX, PositionY, (PaintColor)color);
        }

        private void MoveRobot(Turn direction)
        {
            int x = DirectionX;
            int y = DirectionY;

            if (direction == Turn.TurnLeft)
            {
                x = DirectionY;
                y = DirectionX * -1;

            }
            else if (direction == Turn.TurnRight)
            {
                x = DirectionY * -1;
                y = DirectionX;
            }

            DirectionX = x;
            DirectionY = y;

            PositionX += DirectionX;
            PositionY += DirectionY;
        }

        private PaintColor GetColorUnderRobot()
        {
            return PaintArea.GetColorFromCoord(PositionX, PositionY);
        }

        #endregion
    }
}
