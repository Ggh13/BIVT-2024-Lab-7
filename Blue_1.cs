using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab_7
{
    public class Blue_1
    {
        public class HumanResponse: Response
        {
            private string surname;
            public string Surname => this.surname;
            public HumanResponse(string name, string surname) : base (name)
            {
                this.surname = surname;
            }

            public override void Print()
            {
                Console.Write("Name: ");
                Console.WriteLine(Name);

                Console.Write("Surname: ");
                Console.WriteLine(surname);

                Console.Write("Votes: ");
                Console.WriteLine(votes);
            }

            public override int CountVotes(Response[] responses)
            {
                if(this.Surname == null || responses == null)
                {
                    this.votes = 0;
                    return 0;
                }
                int count = 0;
                foreach (var response in responses)
                {
                    HumanResponse response2 = response as HumanResponse;
                    if (response2 != null && response2.Name == Name && response2.Surname == Surname)
                    {
                        count++;
                    }
                }

                this.votes = count;
                return count;
            }
        }
        public class Response
        {

            private string name;
            
            protected int votes;

            public virtual void Print()
            {
                Console.Write("Name: ");
                Console.WriteLine(name);

                Console.Write("Votes: ");
                Console.WriteLine(votes);
            }
            public string Name => this.name;

            public int Votes => this.votes;

            public Response(string name)
            {
                this.name = name;
                this.votes = 0;
            }

            public virtual int CountVotes(Response[] responses)
            {
                if(this.name == null || responses == null)
                {
                    this.votes = 0;
                    return 0;
                }
                int count = 0;
                foreach (var response in responses)
                {
                    if (response.Name == this.Name)
                    {
                        count++;
                    }
                }

                this.votes = count;
                return count;
            }
        }
    }
}
