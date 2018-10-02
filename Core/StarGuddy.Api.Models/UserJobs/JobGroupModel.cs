using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.UserJobs
{
    public class JobGroupModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Code { get; set; }

        public int SelectedCode { get; set; }

        public string Detail { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}
