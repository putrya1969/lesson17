using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson17
{
    class VotingSubject
    {
        public string VotingSubjectName { get; set; }
        public List<Voter> Voters { get; set; }

        public VotingSubject(string votingSubjectName)
        {
            VotingSubjectName = votingSubjectName;
            Voters = new List<Voter>();
        }
    }
}
