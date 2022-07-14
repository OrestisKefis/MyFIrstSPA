using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ForceUser
    {
        public int ForceUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialiazation { get; set; }
        public string PhotoUrl { get; set; }
        public int Midichlorians { get; set; }
        public string Side { get; set; }
        public string  Rank { get; set; }
        public bool Deceased { get; set; }
        public string Description { get; set; }


        public ForceUser()
        {

        }

        public ForceUser(string firstName, string lastName, string specialiazation, string photoUrl, int midichlorians, string side, string rank, bool deceased, string description)
        {
            FirstName = firstName;
            LastName = lastName;
            Specialiazation = specialiazation;
            PhotoUrl = photoUrl;
            Midichlorians = midichlorians;
            Side = side;
            Rank = rank;
            Deceased = deceased;
            Description = description;
        }
    }
}
