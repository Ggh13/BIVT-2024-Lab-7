﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{


    public class Blue_3
    {
        public class HockeyPlayer: Participant
        {
            static int n = 0;
            static int totalFol = 0;
            public bool IsExpelled
            {
                get
                {
                    int folFive = 0;
                    int totalfols = 0;
                    for (int i = 0; i < penaltyTimes.Length; i++)
                    {
                        totalFol += penaltyTimes[i];
                        if (penaltyTimes[i] == 10)
                        {
                            return true;
                            
                        }
                    }
                    if(totalFol > (totalFol / n) / 10)
                    {
                        return false;
                    }
                    return false;
                }
            }

            public HockeyPlayer(string name, string surname) : base(name, surname)
            {
                this.penaltyTimes = new int[0];
                this.isExpelled = false;
                n += 1;

            }

            public virtual void PlayMatch(int time)
            {
                if (penaltyTimes == null)
                    return;

                int[] newArray = new int[penaltyTimes.Length + 1];


                Array.Copy(penaltyTimes, newArray, penaltyTimes.Length);

                penaltyTimes = newArray;
                penaltyTimes[penaltyTimes.Length - 1] = time;
                totalFol += time;
                if (time == 10)
                {
                    isExpelled = true;
                }
            }
        }
        public class BasketballPlayer: Participant
        {
            public bool IsExpelled
            {
                get
                {
                    int folFive = 0;
                    int totalfols = 0;
                    for(int i = 0; i < penaltyTimes.Length; i++)
                    {
                        if (penaltyTimes[i] == 5)
                        {
                            folFive++;
                            totalfols += penaltyTimes[i];
                        }
                    }
                    if(folFive > (penaltyTimes.Length / 10))
                    {
                        return true;
                    }
                    if(totalfols > penaltyTimes.Length * 2)
                    {
                        return true;
                    }
                    return false;
                }
            }
            public BasketballPlayer(string name, string surname): base(name, surname)
            {
                this.penaltyTimes = new int[0];
                this.isExpelled = false;
            }

            public virtual void PlayMatch(int time)
            {
                if (penaltyTimes == null)
                    return;

                int[] newArray = new int[penaltyTimes.Length + 1];


                Array.Copy(penaltyTimes, newArray, penaltyTimes.Length);

                penaltyTimes = newArray;
                penaltyTimes[penaltyTimes.Length - 1] = time;
             
            }
        }
        public class Participant
        {
            private string name;
            private string surname;
            protected int[] penaltyTimes;
            protected bool isExpelled;
            public void Print()
            {
                Console.Write("Name: ");
                Console.WriteLine(name);

                Console.Write("Surname: ");
                Console.WriteLine(surname);

                Console.Write("PenaltyTimes: ");
                for (int j = 0; j < penaltyTimes.Length; j++)
                {
                    Console.Write(penaltyTimes[j]);
                    Console.Write(" ");
                }
            }
            public string Name
            {
                get
                {
                    if (name == null)
                        return null;
                    return name;
                }
            }

            public string Surname
            {
                get
                {
                    if (surname == null)
                        return null;
                    return surname;
                }
            }

            public int[] Penalties
            {
                get
                {
                    if (penaltyTimes == null)
                        return null;
                    int[] copy = new int[penaltyTimes.Length];
                    Array.Copy(penaltyTimes, copy, penaltyTimes.Length);
                    return copy;
                }
            }

            public int Total
            {
                get
                {
                    if (penaltyTimes == null)
                        return 0;

                    int total = 0;
                    foreach (int time in penaltyTimes)
                    {
                        total += time;
                    }
                    return total;
                }
            }

            public virtual bool IsExpelled
            {
                get
                {
                    return isExpelled;
                }
            }


            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.penaltyTimes = new int[0];
                this.isExpelled = false;
            }

            public virtual void PlayMatch(int time)
            {
                if (penaltyTimes == null)
                    return;

                int[] newArray = new int[penaltyTimes.Length + 1];

               
                Array.Copy(penaltyTimes, newArray, penaltyTimes.Length);

                penaltyTimes = newArray;
                penaltyTimes[penaltyTimes.Length - 1 ] = time;
                if(time == 10)
                {
                    isExpelled = true;
                }
            }

            public static void Sort(Participant[] array)
            {
                Array.Sort(array, (x, y) => x.Total.CompareTo(y.Total));
            }
        }
    }
}
