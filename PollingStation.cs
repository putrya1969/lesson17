using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson17
{
    class PollingStation
    {
        public List<Vote> Votes { get; set; }

        public PollingStation()
        {
            Votes = new List<Vote>();

        }

        public void Process()
        {
            bool ExitVote = false;
            do
            {
                Console.Clear();
                ViewStartMenu();
                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                        {
                            Console.Clear();

                            ViewListOfVotes();
                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            Votes.Add(CreateVote());
                            break;
                        }
                    case "3":
                        {
                            Console.Clear();
                            var voter = RegisterVoter();
                            if (voter != null)
                            {
                                Console.WriteLine("Enter id of vote from list");
                                ViewListOfVotes();
                                if (InputChecker.IsNumber(Console.ReadLine(), out int input) && input<Votes.Count)
                                {
                                    var vote = Votes[input];
                                    Console.WriteLine(vote);
                                    vote.Voting(voter);
                                }
                            }
                            break;
                        }
                    case "4":
                        {
                            Console.Clear();
                            Console.WriteLine("Enter id of vote from list");
                            ViewListOfVotes();
                            if (InputChecker.IsNumber(Console.ReadLine(), out int input) && input < Votes.Count)
                            {
                                var vote = Votes[input];
                                Console.WriteLine($"{vote.Topic}");
                                vote.PrintResult();
                            }
                            break;
                        }
                    case "x":
                        {
                            ExitVote = true;
                            break;
                        }
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
            } while (!ExitVote);
        }

        Vote CreateVote()
        {
            Console.WriteLine("Enter vote topic");
            var header = Console.ReadLine();
            Console.WriteLine("Enter number of vote subjects");
            InputChecker.IsNumber(Console.ReadLine(), out int numbers);
            return new Vote(header, numbers);
        }

        public void ViewStartMenu()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<<Welcome to our polling station>>");
            stringBuilder.AppendLine("To view the list of votes\t '1'");
            stringBuilder.AppendLine("To creating vote\t\t '2'");
            stringBuilder.AppendLine("For voting press\t\t '3'");
            stringBuilder.AppendLine("To view voting results\t\t '4'");
            stringBuilder.AppendLine("For quit \t\t\t 'X'");
            Console.WriteLine(stringBuilder);
        }

        void ViewListOfVotes()
        {
            Console.WriteLine("List of votes");
            foreach (var item in Votes)
            {
                Console.WriteLine($"{Votes.IndexOf(item)}. {item.Topic}");
            }
        }

        Voter RegisterVoter()
        {
            Console.WriteLine("Please enter your age");
            InputChecker.IsNumber(Console.ReadLine(), out int age);
            if (age < 16)
            {
                Console.WriteLine("Your Age less 16 y.o. - you can't vote");
                return null;
            }
            Console.WriteLine("Please enter your last name");
            var lastName = InputChecker.IsValidInput(Console.ReadLine());
            Console.WriteLine("Please enter your first name");
            var firstName = InputChecker.IsValidInput(Console.ReadLine());
            var voter = new Voter(lastName, firstName, age);
            return voter;
        }
    }

    public static class IEnumerableList
    {
        public static bool InRange<T>(this List<T> value, int index)
        {
            return (index >= 0) && (value.Count > index);
        }
    }
}
