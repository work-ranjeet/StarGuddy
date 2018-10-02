using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Dto
{
    public class AgentDto
    {
        public Guid Id { get; set; }

        public int SelectedValue { get; set; }

        public int Value { get; set; }

        public string Name { get; set; }
    }
}
