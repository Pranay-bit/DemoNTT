using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_NTT.Models
{
   
        public class MemberClaims
        {
            public string MemberID { get; set; }
            public DateTime ClaimDate { get; set; }
            public string ClaimAmount { get; set; }

        public static MemberClaims FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            MemberClaims dailyValues = new MemberClaims();
            dailyValues.MemberID = Convert.ToString(values[0]);
            dailyValues.ClaimDate = Convert.ToDateTime(values[1]);
            dailyValues.ClaimAmount = Convert.ToString(values[2]);
            return dailyValues;
        }
    }

        public class Member
    {
        public string MemberID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set;  }
        public IList<MemberClaims> memberClaims { get; set; }

        public static Member FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Member person = new Member();
            person.MemberID = Convert.ToString(values[0]);
            person.EnrollmentDate = Convert.ToDateTime(values[1]);
            person.FirstName = Convert.ToString(values[2]);
            person.LastName = Convert.ToString(values[3]);
            return person;
        }

    }



    
}