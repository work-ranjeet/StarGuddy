using StarGuddy.Api.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Profile
{
    public class UserActingModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public int ActingExperianceCode { get; set; }

        public string ActingExperiance { get; set; }

        public int AgentNeedCode { get; set; }

        public string Experiance { get; set; }

        public List<LanguageDto> Languages { get; set; }

        public List<AccentsDto> Accents { get; set; }

        public List<AuditionsAndJobsGroupDto> AuditionsAndJobsGroup { get; set; }
    }
}
