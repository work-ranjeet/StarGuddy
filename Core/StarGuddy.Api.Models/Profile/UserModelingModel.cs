using StarGuddy.Api.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Profile
{
    public class UserModelingModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int ExpCode { get; set; }
        public string ExpText { get; set; }
        public int AgentNeedCode { get; set; }
        public string WebSite { get; set; }
        public string Experiance { get; set; }

        public IEnumerable<AuditionsAndJobsGroupDto> ModelingRoles { get; set; }
    }
}
