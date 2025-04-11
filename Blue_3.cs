using System;
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


            public override bool IsExpelled
            {
                get
                {
                    if (n > 0)
                    {
                        return false;
                    }
                    int folFive = 0;
                    double avgP = totalFol / (double)n;
                    for (int i = 0; i < penaltyTimes.Length; i++)
                    {
                        totalFol += penaltyTimes[i];
                        if (penaltyTimes[i] == 10)
                        {
                            return true;
                            
                        }
                    }
                    if(totalFol > (avgP) * 0.1)
                    {
                        return true;
                    }
                    return false;
                }
            }

            public HockeyPlayer(string name, string surname) : base(name, surname)
            {
                n += 1;
                penaltyTimes = new int[0];

            }

            public override void PlayMatch(int time)
            {

                if (penaltyTimes == null)
                    return;

                base.PlayMatch(time);
                totalFol += time;
            }
        }
        public class BasketballPlayer: Participant
        {
            public override bool IsExpelled
            {
                get
                {
                    if (penaltyTimes == null) return false;
                    int count = 0;
                    for (int i = 0; i < penaltyTimes.Length; i++)
                    {
                        if (penaltyTimes[i] >= 5) count++;
                    }
                    for (int i = 0; i < penaltyTimes.Length; i++)
                    {
                        if (this.Total > 2 * penaltyTimes.Length || count > 0.1 * penaltyTimes.Length)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            public BasketballPlayer(string name, string surname): base(name, surname)
            {
                penaltyTimes = new int[0];
            }

            public override void PlayMatch(int fouls)
            {
                if (penaltyTimes == null || fouls < 0 || fouls > 5)
                {
                    return;
                }

               base.PlayMatch(fouls);
             
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
            public string Name => name;

            public string Surname => surname;

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
                    if (penaltyTimes == null) return false;
                    bool isExpelled = false;
                    for (int i = 0; i < penaltyTimes.Length; i++)
                    {
                        if (penaltyTimes[i] == 10)
                        {
                            isExpelled = true;
                            break;
                        }
                    }
                    return isExpelled;
                }
            }


            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                this.penaltyTimes = new int[0];
            }

            public virtual void PlayMatch(int time)
            {
                if (penaltyTimes == null)
                    return;

                int[] newArray = new int[penaltyTimes.Length + 1];


                int[] copy = new int[penaltyTimes.Length + 1];
                for (int i = 0; i < penaltyTimes.Length; i++)
                {
                    copy[i] = penaltyTimes[i];
                }
                copy[copy.Length - 1] = time;
                penaltyTimes = copy;

            }

            public static void Sort(Participant[] parts)
            {
                if (parts == null || parts.Length <= 1)
                    return;

                int n = parts.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - 1 - i; j++)
                    {
                        if (parts[j].Total > parts[j + 1].Total)
                        {
                            Participant temp = parts[j];
                            parts[j] = parts[j + 1];
                            parts[j + 1] = temp;
                        }
                    }
                    
                }
            }
        }
    }
}
