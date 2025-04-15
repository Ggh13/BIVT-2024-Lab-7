using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public class Blue_3
    {
        public class Participant
        {
            private string name;
            private string surname;
            protected int[] penaltytimes;

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
            public int[] Penalties
            {
                get
                {
                    if (penaltytimes == null) 
                    {
                        return null;
                    }

                    int[] results = new int[penaltytimes.Length];
                    Array.Copy(penaltytimes, results, results.Length);
                    return results;
                }
            }
            public int Total
            {
                get
                {
                    if (penaltytimes == null)
                    {
                        return 0;
                    }
                    int sum = 0;
                    for (int i = 0; i < penaltytimes.Length; i++)
                    {
                        sum += penaltytimes[i];
                    }
                    return sum;
                }
            }
            public virtual bool IsExpelled
            {
                get
                {
                    if (penaltytimes == null)
                    {
                        return false;
                    }
                    for (int i = 0; i < penaltytimes.Length; i++)
                    {
                        if (penaltytimes[i] == 10)
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }

            public Participant(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
                penaltytimes = new int[0];
            }

            public virtual void PlayMatch(int time)
            {
                if (penaltytimes == null)
                {
                    return;
                }
                Array.Resize(ref penaltytimes, penaltytimes.Length + 1);
                penaltytimes[penaltytimes.Length - 1] = time;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null)
                {
                    return;
                }
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j + 1].Total < array[j].Total)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
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
                Console.Write(Total);
                Console.Write(" ");
                Console.WriteLine(IsExpelled);
            }
        }
        public class BasketballPlayer : Participant
        {
            public BasketballPlayer(string name, string surname) : base(name, surname)
            {
                penaltytimes = new int[0];
            }
            public override bool IsExpelled
            {
                get
                {
                    if (penaltytimes == null)
                    {
                        return false;
                    }
                    int count = 0;
                    for (int i = 0; i < penaltytimes.Length; i++)
                    {
                        if (penaltytimes[i] == 5) count++;
                    }
                    if (Total > 2 * penaltytimes.Length || count > 0.1 * penaltytimes.Length)
                    {
                        return true;
                    }
                    return false;
                }
            }
            public override void PlayMatch(int foul)
            {
                if (penaltytimes == null)
                {
                    return;
                }
                if (foul < 0 || foul > 5)
                {
                    return;
                }
                base.PlayMatch(foul);

            }
        }
        public class HockeyPlayer : Participant
        {
            private static int totaltime;
            private static int count;
            public HockeyPlayer(string name, string surname) : base(name, surname)
            {
                penaltytimes = new int[0];
                count++;
            }
            public override void PlayMatch(int time)
            {
                if (penaltytimes == null)
                {
                    return;
                }

                base.PlayMatch(time);
                totaltime += time;
            }
            public override bool IsExpelled
            {
                get
                {
                    if (penaltytimes == null)
                    {
                        return false;
                    }
                    for (int i = 0; i < penaltytimes.Length; i++)
                    {
                        if (penaltytimes[i] == 10)
                        {
                            return true;
                        }
                    }
                    if (Total > 0.1 * totaltime / count)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }
    }
}