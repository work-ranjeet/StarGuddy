using StarGuddy.Api.Models.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Dto
{
    public class DancingStyleDto
    {
        public long Id { get; set; }

        public long? SelectedValue { get; set; }

        public long Value { get; set; }

        public string Name { get; set; }
    }
}
