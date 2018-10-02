using StarGuddy.Api.Models.UserJobs;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Search
{
    public class TalentGroup: JobGroupModel
    {
        public string ImageUrl { get; set; }

        public int MemberCount { get; set; }
    }
}
