using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson17
{
    class Voter
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }

        public Voter(string lastName, string firstName, int age)
        {
            LastName = lastName;
            FirstName = firstName;
            Age = age;
        }

        bool IsValid()
        { 
            return (!string.IsNullOrEmpty(LastName)&&!string.IsNullOrEmpty(FirstName)&&Age!=0);
        }
    }
}
