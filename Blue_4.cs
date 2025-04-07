using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Lab_7.Blue_4;
using static Lab_7.Blue_5;

namespace Lab_7
{
    public class Blue_4
    {
        public class ManTeam : Team
        {
            public ManTeam(string name): base(name) 
            {


            }
        }

        public class WomanTeam : Team
        {
            public WomanTeam(string name) : base(name)
            {


            }
        }

        public abstract class Team
        {
            private string name;
            private int[] scores;

            public string Name => name;
            public int[] Scores
            {
                get
                {
                    if (scores == null)
                    {
                        return null;
                    }
                    int[] copy = new int[scores.Length];
                    Array.Copy(scores, copy, copy.Length);
                    return copy;
                }
            }

            public int TotalScore
            {
                get
                {
                    if (scores == null) return 0;

                    int total = 0;
                    for (int i = 0; i < scores.Length; i++)
                    {
                        total += scores[i];
                    }
                    return total;
                }
            }

            public Team(string name)
            {
                this.name = name;
                scores = new int[0];
            }

            public void PlayMatch(int result)
            {
                if (scores == null)
                {
                    return;
                }

                int[] newScores = new int[scores.Length + 1];

                for (int i = 0; i < scores.Length; i++)
                {
                    newScores[i] = scores[i];
                }
                newScores[newScores.Length - 1] = result;
                scores = newScores;
            }

            public void Print()
            {
                Console.Write(Name);
                Console.Write(" ");
                Console.WriteLine(TotalScore);
            }
        }

        public class Group
        {
            private string name;
            private WomanTeam[] womanTeams;
            private ManTeam[] manTeams;
            private int indMan;
            private int indWoMan;
            public string Name => name;
            public WomanTeam[] WomanTeams => womanTeams;
            public ManTeam[] ManTeams => manTeams;
            public Group(string name)
            {
                this.name = name;
                womanTeams = new WomanTeam[12];
                manTeams = new ManTeam[12];
                indMan = 0;
                indWoMan = 0;
            }

            public void Add(Team team)
            {
                if (manTeams == null)
                {
                    return;
                }

                if (team is ManTeam && indMan < manTeams.Length)
                {
                    
                        manTeams[indMan] = team as ManTeam;
                        indMan++;
                    
                }

                if (womanTeams == null)
                {
                    return;
                }

                if (team is WomanTeam && indMan < womanTeams.Length)
                {

                    womanTeams[indWoMan] = team as WomanTeam;
                    indWoMan++;

                }


            }
        

            public void Add(Team[] teams)
            {

                if(teams is WomanTeam)
                {
                    if (this.womanTeams == null || teams.Length == 0 || teams == null) return;

                    for (int i = 0; i < teams.Length; i++)
                    {
                        Add(teams[i]);
                    }
                }
                

            }
            public void Add(ManTeam[] teams)
            {
                if (teams is ManTeam)
                {
                    if (this.manTeams == null || teams.Length == 0 || teams == null) return;

                    for (int i = 0; i < teams.Length; i++)
                    {
                        Add(teams[i]);
                    }
                }
                
            }



            public void SortC(Team[] teams)
            {
                if (teams == null || teams.Length == 0) return;

                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - 1 - i; j++)
                    {
                        if (teams[j].TotalScore < teams[j + 1].TotalScore)
                        {
                            Team temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                    }
                }
            }
            public void Sort()
            {
                SortC(womanTeams);
                SortC(manTeams);
            }



            public static Group Merge(Group group1, Group group2, int size)
            {
                if (group1 == null || group2 == null) return null;

                Group result = new Group("Финалисты");

                Team[] manTeams = MergeC(group1.manTeams, group2.manTeams, size);
                Team[] womanTeams = MergeC(group1.womanTeams, group2.womanTeams, size);

                result.Add(manTeams);
                result.Add(womanTeams);

                return result;
            }


            public static Team[] MergeC(Team[] group1, Team[] group2, int size)
            {

                int i = 0; int j = 0;
                Team[] result = new Team[size];
                while (i < size / 2 && j < size / 2)
                {
                    if (group1[i].TotalScore >= group2[j].TotalScore)
                    {
                        result[i + j] = group1[i++];
                    }
                    else
                    {
                        result[i + j] = group1[i++];
                    }
                }
                while (i < size / 2)
                {
                    result[i + j] = group1[i++];
                }
                while (j < size / 2)
                {
                    result[i + j] = group1[j++];
                }
                return result;
            }

            public void Print()
            {
                Console.WriteLine(name);

                if (manTeams != null && manTeams.Length > 0)
                {
                    for (int i = 0; i < manTeams.Length; i++)
                    {
                        manTeams[i].Print();
                    }
                }

                if (womanTeams != null && womanTeams.Length > 0)
                {
                    for (int i = 0; i < womanTeams.Length; i++)
                    {
                        womanTeams[i].Print();
                    }
                }
            }
        }
    }
}