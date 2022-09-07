using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson17
{
    class Vote
    {
        public string Topic { get; set; }
        public VotingSubject[] VotingSubjects { get; set; }

        public Vote(string voteName, int countVotingSubjects)
        {
            Topic = voteName;
            VotingSubjects = new VotingSubject[countVotingSubjects];
            for (int i = 0; i < countVotingSubjects; i++)
            {
                Console.WriteLine($"Enter name of {i}. vote subject:");
                VotingSubjects[i] = CreateVotingPoint(InputChecker.IsValidInput(Console.ReadLine()));
            }
        }

        VotingSubject CreateVotingPoint(string votingSubject)
        {
            return new VotingSubject(votingSubject);
        }

        public override string ToString()
        {
            var result = Topic;
            for (int i = 0; i < VotingSubjects.Length; i++)
            {
                result += $"\n {i} {VotingSubjects[i].VotingSubjectName}";
            }
            return result;
        }

        VotingSubject GetVotingSubject(int position)
        {
            return VotingSubjects[position];
        }

        bool PositionValid(int position)
        {
            return (0 <= position) && (position < VotingSubjects.Length);
        }

        public void Voting(Voter voter)
        {
            Console.WriteLine("Enter id of vote subject for vote");
            if (InputChecker.IsNumber(Console.ReadLine(), out int voteSubjectId))
                if (VotingSubjects.InRange(voteSubjectId))
                    VotingSubjects[voteSubjectId].Voters.Add(voter);
                else
                    Console.WriteLine("Invalid input");
        }

        public void PrintResult()
        {
            Console.WriteLine($"Vote subjects name\t Count");
            foreach (var item in VotingSubjects)
            {
                Console.WriteLine($"{item.VotingSubjectName}\t{item.Voters.Count}");
            }
        }
    }

    static class ArrayExtension
    {
        public static bool InRange(this VotingSubject[] votingSubjects, int index)
        {
            return (0 <= index) && (index < votingSubjects.Length);
        }
    }
}
