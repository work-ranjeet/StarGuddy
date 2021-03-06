﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Data.Entities.Interface
{
    public interface IJobSubGroup
    {
        long Id { get; set; }
        string Name { get; set; }
        int Code { get; set; }
        int SelectedCode { get; set; }
        string Detail { get; set; }
        int DisplayOrder { get; set; }
        bool IsActive { get; set; }
        bool IsDeleted { get; set; }
        DateTime? DttmCreated { get; set; }
        DateTime? DttmModified { get; set; }
    }
}
