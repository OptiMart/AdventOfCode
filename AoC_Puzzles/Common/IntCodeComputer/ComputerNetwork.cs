using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Puzzles.Common.IntCodeComputer
{
    public class ComputerNetwork
    {
        #region Data
        private bool _doubleNATPacket = false;
        
        #endregion

        #region Constructor
        public ComputerNetwork(string program, int count = 1)
        {
            InitializeComputers(program, count);
        }

        #endregion

        #region Properties
        public List<Computer> Computers { get; private set; } = new List<Computer>();
        public List<Tuple<int, int, int>> Packets { get; private set; }
        public Tuple<long, long, long> LastNATPacket { get; private set; }
        public Tuple<long, long> LastSentPacket { get; private set; }

        #endregion

        #region Methods
        private void InitializeComputers(string program, int count = 1)
        {
            //Computer[] cpus = new Computer[50];

            for (int i = 0; i < count; i++)
            {
                Computer cpu = new Computer(program) { Address = i };
                cpu.LoadDefaultInstructionSet();
                cpu.Initialize();
                cpu.StartExecution();
                cpu.PushInput(i, true);
                Computers.Add(cpu);
            }
        }

        public void StartComputing(bool stopFirst)
        {
            int count = 0;
            int count1 = 0;
            do
            {
                foreach (var cpu in Computers)
                {
                    SendPackets(cpu);

                    if (cpu.LastExitCode == 99)
                        continue;

                    cpu.PushInput(-1, true);
                }

                count1 = CheckNetworkState(count1);

                count++;
            } while ((LastNATPacket is null || !stopFirst) && !_doubleNATPacket);

        }

        private int CheckNetworkState(int count1)
        {
            if (!(LastNATPacket is null) && !Computers.Any(x => x.OutputStack.Count > 0 || x.InputStack.Count > 0))
            {
                Tuple<long, long> packet = new Tuple<long, long>(LastNATPacket.Item2, LastNATPacket.Item3);

                if (LastSentPacket?.Equals(packet) == true)
                {
                    _doubleNATPacket = true;
                    return ++count1;
                }

                Computers[0].PushInput(packet.Item1);
                Computers[0].PushInput(packet.Item2);

                LastSentPacket = packet;
            }

            return ++count1;
        }

        private bool CheckPackets(Computer cpu)
        {
            bool result = false;

            foreach (var packet in Packets.FindAll(p => p.Item1 == cpu.Address))
            {
                cpu.PushInput(packet.Item2);
                cpu.PushInput(packet.Item3);

                result = true;
            }

            Packets.RemoveAll(p => p.Item1 == cpu.Address);

            return result;
        }

        private void SendPackets(Computer cpu)
        {
            while (cpu.OutputStack.Count > 0)
            {
                long target = (long)cpu.PopOutput();
                long x = (long)cpu.PopOutput();
                long y = (long)cpu.PopOutput();

                if (target == 255)
                {
                    //Tuple<long, long, long> NATpacket = new Tuple<long, long, long>(target, x, y);
                    //if (NATpacket.Equals(LastNATPacket))
                    //    _doubleNATPacket = true;
                    LastNATPacket = new Tuple<long, long, long>(target, x, y);
                }
                else
                    SendPacketToAddress(target, x, y);
            }
        }

        private void SendPacketToAddress(long address, long x, long y)
        {
            var target = Computers.FirstOrDefault(v => v.Address == address);

            if (target is null)
                throw new InvalidOperationException("Ungültiger Zielcomputer");

            target.PushInput(x, true);
            target.PushInput(y, true);
        }

        #endregion
    }
}
