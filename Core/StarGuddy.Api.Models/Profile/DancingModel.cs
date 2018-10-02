using StarGuddy.Api.Models.Dto;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace StarGuddy.Api.Models.Profile
{
    public class DancingModel 
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public int DanceAbilities { get; set; }

        public int ChoreographyAbilities { get; set; }

        public string DanceAbilitiesText { get; set; }

        public string ChoreographyAbilitiesText { get; set; }

        public int AgentNeed { get; set; }

        public string Experience { get; set; }

        public bool IsAttendedSchool { get; set; }

        public bool IsAgent { get; set; }

        public bool HasDanceStyle { get; set; }

        public List<DancingStyleDto> DnacingStyles { get; set; }
    } 
}
