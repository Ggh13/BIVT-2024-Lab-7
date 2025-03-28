﻿using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Xml.Serialization;

namespace Lab_6
{
    public class Blue_2
    {


        public class WaterJump5m : WaterJump
        {
           
               public override double[] Prize
            {
                get
                {
                    if (Participants.Length < 3)
                        return new double[0];

                    int topCount = Math.Min(Math.Max(Participants.Length / 2, 3), 10);
                    double[] prizes = new double[topCount + 3];


                    prizes[0] = Bank * 0.4;
                    prizes[1] = Bank * 0.25;
                    prizes[2] = Bank * 0.15;
                    double remain = Bank * 0.2;
                    double topPrize = remain / topCount;

                    for (int i = 3; i < prizes.Length; i++)
                    {
                        prizes[i] = topPrize;
                    }

                    return prizes;
                }
            }

            public WaterJump5m(string tournamentName, int prizeFund) : base(tournamentName, prizeFund)
            {

            }

        }


        public class WaterJump3m: WaterJump
        {
            public override double[] Prize
            {
                get
                {
                    if (Participants.Length < 3)
                        return new double[0];

                    double[] prizes = new double[3];
                    prizes[0] = Bank * 0.5;
                    prizes[1] = Bank * 0.3; 
                    prizes[2] = Bank * 0.2;
                    return prizes;
                }
            }
        
        public WaterJump3m(string tournamentName, int prizeFund): base(tournamentName, prizeFund)
            {
                
            }

        }
        public abstract class WaterJump
        {
            private string name;
            private int bank;
            private Participant[] participants;
            public string Name => name;

            public int Bank => bank;

            public Participant[] Participants { get; set; }

            public abstract double[] Prize { get; }
            
            public WaterJump(string tournamentName, int prizeFund)
            {
                this.name = tournamentName;
                this.bank = prizeFund;
                this.participants = new Participant[0];
            }
            public void Add(Participant[] newP)
            {
                for (int i = 0; i < newP.Length; i++)
                {
                    Array.Resize(ref participants, participants.Length + 1);
                    participants[participants.Length - 1] = newP[i];
                }
            }

        }
        public struct Participant
        {
            private string name;
            private string surname;
            private int[,] marks;
            private int ind;

            public string Name => this.name;
            public string Surname => this.surname;

            public int[,] Marks
            {
                get
                {
                    if (this.marks == null || this.marks.GetLength(0) == 0 || this.marks.GetLength(1) == 0)
                    {
                        return null;
                    }
                    int[,] copy = new int[this.marks.GetLength(0), this.marks.GetLength(1)];
                    for (int i = 0; i < this.marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < this.marks.GetLength(1); j++)
                        {
                            copy[i, j] = this.marks[i, j];
                        }
                    }
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (this.marks == null || this.marks.GetLength(0) == 0 || this.marks.GetLength(1) == 0)
                    {
                        return 0;
                    }

                    int sum = 0;
                    for (int i = 0; i < this.marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < this.marks.GetLength(1); j++)
                        {
                            sum += this.marks[i, j];
                        }
                    }
                    return sum;
                }
            }

            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.marks = new int[2, 5];
                this.ind = 0;
            }

            public void Jump(int[] result)
            {
                if (this.marks == null || this.marks.GetLength(0) == 0 || this.marks.GetLength(1) == 0 || result == null || result.Length == 0 || this.ind > 1)
                {
                    return;
                }


                    for (int i = 0; i < 5; i++)
                    {
                        this.marks[this.ind, i] = result[i];
                    }
                    this.ind++;



                }
            

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0)
                {
                    return;
                }

                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j + 1].TotalScore > array[j].TotalScore)
                        {
                            (array[j + 1], array[j]) = (array[j], array[j + 1]);
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine(this.name);
                Console.WriteLine(this.surname);

                if (this.marks != null)
                {
                    for (int i = 0; i < this.marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < this.marks.GetLength(1); j++)
                        {
                            Console.Write(this.marks[i, j]);
                        }
                        Console.WriteLine();
                    }
                }

                Console.WriteLine(this.TotalScore);
            }
        }
    }
}