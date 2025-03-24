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
            public string Surname
            {
                get
                {
                    if (surname == null)
                        return null;
                    return surname;
                }
            }
            public HumanResponse(string name, string surname) : base (name)
            {
                this.surname = surname;
                this.votes = 0;
            }

            public virtual void Print()
            {
                Console.Write("Name: ");
                Console.WriteLine(Name);

                Console.Write("Surname: ");
                Console.WriteLine(surname);

                Console.Write("Votes: ");
                Console.WriteLine(votes);
            }

            public virtual int CountVotes(HumanResponse[] responses)
            {

                int count = 0;
                foreach (var response in responses)
                {
                    if (response.Name == this.Name && response.Surname == this.Surname)
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
            public string Name
            {
                get
                {
                    if (name == null)
                        return null;
                    return name;
                }
            }

            public int Votes
            {
                get
                {
                    if (votes == null)
                        return 0;
                    return votes;
                }
            }

            public Response(string name)
            {
                this.name = name;
                this.votes = 0;
            }

            public virtual  int CountVotes(Response[] responses)
            {

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
