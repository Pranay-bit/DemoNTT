using CsvHelper;
using Demo_NTT.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo_NTT.Controllers
{
    public class ClaimsController : ApiController
    {
        [Route("Claims/{ClaimDate}")]
        public IHttpActionResult GetAllClaimsBasedOnDate(string ClaimDate)
        {

            if (ClaimDate.Length > 0)
            {

                List<MemberClaims> memberClaims = File.ReadAllLines("D:\\Project\\Demo_NTT\\Demo_NTT\\CSV\\Claim.csv")
                                               .Skip(1)
                                               .Select(v => MemberClaims.FromCsv(v)).Where(x => x.ClaimDate == Convert.ToDateTime(ClaimDate))
                                               .ToList();

                List<Member> members = File.ReadAllLines("D:\\Project\\Demo_NTT\\Demo_NTT\\CSV\\Member.csv")
                                               .Skip(1)
                                               .Select(v => Member.FromCsv(v))
                                               .ToList();

                if (members.Count > 0)
                {
                    for (int i = 0; i < members.Count; i++)
                    {
                        members[i].memberClaims = memberClaims.FindAll(x => x.MemberID == members[i].MemberID);
                    }


                    var membersHavingClaims = members.Where(p => p.memberClaims.Count > 0);


                    return Ok(membersHavingClaims);


                }
                else
                {
                    return Ok("Members are not present in files");
                }
            }

            return BadRequest("Given date is empty");




        }
    }
        
    
}
