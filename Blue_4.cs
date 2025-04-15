using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab_7.Blue_4;

namespace Lab_7
{
    public class Blue_4
    {
        public abstract class Team
        {
            private string name;
            private int[] score;
            public string Name 
            { 
                get
                {
                    return name;
                } 
            }
            public int[] Scores
            {
                get
                {
                    if (score == null)
                    {
                        return null;
                    }
                    int[] results = new int[score.Length];
                    int count = 0;
                    for (int i = 0; i < score.Length; i++)
                    {
                        results[count++] = score[i];
                    }
                    return results;
                }
            }
            public int TotalScore
            {
                get
                {
                    if (score == null)
                    {
                        return 0;
                    }
                    int sum = 0;
                    for (int i = 0; i < score.Length; i++)
                    {
                        sum += score[i];
                    }
                    return sum;
                }
            }

            public Team(string name)
            {
                this.name = name;
                score = new int[0];
            }

            public void PlayMatch(int result)
            {
                if (score == null)
                {
                    return;
                }
                Array.Resize(ref score, score.Length + 1);
                score[score.Length - 1] = result;
            }

            public void Print()
            {
                Console.Write(Name);
                Console.Write(" ");
                Console.WriteLine(TotalScore);
            }
        }
        public class ManTeam : Team
        {
            public ManTeam(string name) : base(name)
            {
            }
        }
        public class WomanTeam : Team
        {
            public WomanTeam(string name) : base(name)
            {
            }
        }
        public class Group
        {
            private string name;
            public string Name
            {
                get
                {
                    return name;
                }
            }

            private Team[] manteams;

            public Team[] ManTeams
            {
                get
                {
                    return manteams;
                }
            }


            private Team[] womanteams;

            public Team[] WomanTeams
            {
                get
                {
                    return womanteams;
                }
            }

            private int indman;
            private int indcount;

            
            
            

            public Group(string name)
            {
                this.name = name;
                manteams = new Team[12];
                womanteams = new Team[12];

                indman = 0;
                indcount = 0;
            }

            public void Add(Team team)
            {
                if (team is ManTeam manteam && indman < manteams.Length)
                {
                    manteams[indman++] = manteam;
                }
                else if (team is WomanTeam womanteam && indcount < womanteams.Length)
                {
                    womanteams[indcount++] = womanteam;
                }
            }
            public void Add(Team[] teams)
            {
                foreach (Team team in teams)
                {
                    Add(team);
                }
            }
            public void SortC(Team[] team)
            {
                if (team == null)
                {
                    return;
                }
                for (int i = 0; i < team.Length; i++)
                {
                    for (int j = 0; j < team.Length - i - 1; j++)
                    {
                        if (team[j + 1].TotalScore > team[j].TotalScore)
                        {
                            (team[j], team[j + 1]) = (team[j + 1], team[j]);
                        }
                    }
                }
            }
            public void Sort()
            {
                SortC(manteams);
                SortC(womanteams);
            }

            public static Group Merge(Group group1, Group group2, int size)
            {
                Group merged = new Group("Финалисты");
                merged.Add(MergeC(group1.manteams, group2.manteams, size));
                merged.Add(MergeC(group1.womanteams, group2.womanteams, size));
                return merged;
            }
            public static Team[] MergeC(Team[] teams1, Team[] teams2, int size)
            {
                if (teams1 == null || teams2 == null)
                {
                    return null;
                }
                Team[] resultteam = new Team[size];
                int i = 0, j = 0, ind = 0;
                while (i < size / 2 && j < size / 2)
                {
                    if (teams1[i].TotalScore >= teams2[j].TotalScore)
                    {
                        resultteam[ind++] = teams1[i++];
                    }
                    else
                    {
                        resultteam[ind++] = teams2[j++];
                    }
                }
                while (i < size / 2)
                {
                    resultteam[ind++] = teams1[i++];
                }
                while (j < size / 2)
                {
                    resultteam[ind++] = teams2[j++];
                }
                return resultteam;
            }
            public void Print(Team[] teams)
            {
                Console.Write(Name);
                Console.Write(" ");
                Console.WriteLine(teams);
            }
        }
    }
}