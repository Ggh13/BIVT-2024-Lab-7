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
            public WomanTeam[] WomanTeams
            {
                get
                {
                    if (womanTeams == null)
                    {
                        return null;
                    }
                    return womanTeams;
                }


            }
            public ManTeam[] ManTeams {
                get
                {
                    if(manTeams == null)
                    {
                        return null;
                    }
                    return manTeams;
                }
                

            }
            public Group(string name)
            {
                this.name = name;
                womanTeams = new WomanTeam[0];
                manTeams = new ManTeam[0];
                indMan = 0;
                indWoMan = 0;
            }

            public void Add(Team team)
            {
                if (manTeams == null)
                {
                    manTeams = new ManTeam[0];
                }

                if (team is ManTeam && manTeams.Length < 12)
                {
                    ManTeam[] copy = new ManTeam[manTeams.Length + 1];
                    Array.Copy(manTeams, copy, manTeams.Length);
                    manTeams = copy;
                    manTeams[manTeams.Length-1] = team as ManTeam;
                        
                    
                }

                if (womanTeams == null)
                {
                    womanTeams = new WomanTeam[0];
                }

                if (team is WomanTeam && womanTeams.Length < 12)
                {

                    WomanTeam[] copy = new WomanTeam[womanTeams.Length + 1];
                    Array.Copy(womanTeams, copy, womanTeams.Length);
                    womanTeams = copy;
                    womanTeams[womanTeams.Length - 1] = team as WomanTeam;

                   

                }


            }
        

            public void Add(Team[] teams)
            {
                if (teams == null || teams.Length == 0)
                {
                    return;
                }
                for (int i = 0; i < teams.Length; i++)
                    {
                        Add(teams[i]);
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
                SortC(manTeams);
                SortC(womanTeams);
                
            }

            public static Group Merge(Group team1, Group team2, int size)
            {
                
                Team[] menN = MergeC(team1.manTeams, team2.womanTeams, size);
                Team[] womanN = MergeC(team1.manTeams, team2.womanTeams, size);

                Group res = new Group("Финалисты");

                res.Add(menN);
                res.Add(womanN);
                return res;

            }




            public static Team[] MergeC(Team[] group1, Team[] group2, int size)
            {
                Team[] result = new Team[size];
                int n = 0;
                int i = 0; int j = 0;
                while (i < size / 2 && j < size / 2)
                {
                    if (group1[i].TotalScore >= group2[j].TotalScore)
                    {
                        result[n] = group1[i++];
                        n = n + 1;
                    }
                    else
                    {
                        result[n] = group2[j++];
                        n = n + 1;
                    }
                }

                while (i < size / 2)
                {
                    result[n] = group1[i++];
                    n = n + 1;
                }
                while (j < size / 2)
                {
                    result[n] = group2[j++];
                    n = n + 1;
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