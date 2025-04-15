using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public class Blue_2
    {
        public abstract class WaterJump
        {
            private string name;
            private int bank;
            private Participant[] participants;

            public string Name => name;
            public int Bank => bank;
            public Participant[] Participants => participants;

            public abstract double[] Prize { get; }

            public WaterJump(string name, int bank)
            {
                this.name = name;
                this.bank = bank;
                participants = new Participant[0];

            }

            public void Add(Participant participant)
            {
                if (participants == null)
                {
                    return;
                }
                Array.Resize(ref participants, participants.Length + 1);
                participants[participants.Length - 1] = participant;

            }
            public void Add(Participant[] participants)
            {
                if (this.participants == null)
                {
                    return;
                }
                for (int i = 0; i < participants.Length; i++)
                {
                    Add(participants[i]);
                }
            }
        }
        public class WaterJump3m : WaterJump
        {
            public WaterJump3m(string name, int bank) : base(name, bank)
            {
            }
            public override double[] Prize
            {
                get
                {
                    if (Participants == null)
                    {
                        return null;
                    }
                    if (Participants.Length < 3)
                    {
                        return null;
                    }
                    double[] prize = new double[3];
                    prize[0] = 0.5 * Bank;
                    prize[1] = 0.3 * Bank;
                    prize[2] = 0.2 * Bank;
                    return prize;
                }
            }
        }
        public class WaterJump5m : WaterJump
        {
            public WaterJump5m(string name, int bank) : base(name, bank)
            {
            }
            public override double[] Prize
            {
                get
                {
                    if (Participants == null)
                    {
                        return null;
                    }
                    if (Participants.Length < 3)
                    {
                        return null;
                    }
                    int count = Math.Min(10, Participants.Length / 2);

                    double[] prize = new double[count];
                    double percent = 20.0 / count;

                    for (int i = 0; i < count; i++)
                    {
                        prize[i] += percent * Bank / 100;
                    }
                    prize[0] += 0.4 * Bank;
                    prize[1] += 0.25 * Bank;
                    prize[2] += 0.15 * Bank;
                    return prize;
                }
            }
        }
        public struct Participant
        {
            private string name;
            private string surname;
            private int[,] marks;

            private int ind;

            public string Name 
            { 
                get 
                { 
                    return name; 
                } 
            }
            public string Surname 
            { 
                get 
                { 
                    return surname; 
                } 
            }
            public int[,] Marks
            {
                get
                {
                    if (marks == null)
                    {
                        return null;
                    }
                    int[,] results = new int[marks.GetLength(0), marks.GetLength(1)];
                    for (int i = 0; i < results.GetLength(0); i++)
                    {
                        for (int j = 0; j < results.GetLength(1); j++)
                        {
                            results[i, j] = marks[i, j];
                        }
                    }
                    return results;
                }
            }
            public int TotalScore
            {
                get
                {
                    if (marks == null)
                    {
                        return 0;
                    }
                    int sum = 0;
                    for (int i = 0; i < marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < marks.GetLength(1); j++)
                        {
                            sum += marks[i, j];
                        }
                    }
                    return sum;
                }
            }


            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                marks = new int[2, 5];

                ind = 0;
            }


            public void Jump(int[] result)
            {
                if (result == null || marks == null || ind > 1)
                {
                    return;
                }
                    for (int j = 0; j < marks.GetLength(1); j++)
                {
                    marks[ind, j] = result[j];
                }
                ind++;

            }

            public static void Sort(Participant[] partics)
            {
                if (partics == null)
                {
                    return;
                }
                for (int i = 0; i < partics.Length - 1; i++)
                {
                    for (int j = 0; j < partics.Length - i - 1; j++)
                    {
                        if (partics[j].TotalScore < partics[j + 1].TotalScore)
                        {
                            (partics[j], partics[j + 1]) = (partics[j + 1], partics[j]);
                        }
                    }
                }
            }
            public void Print()
            {
                Console.Write(Name);
                Console.Write(" ");
                Console.Write(Surname);
                Console.Write(" ");
                Console.Write(TotalScore);
            }
        }
    }
}