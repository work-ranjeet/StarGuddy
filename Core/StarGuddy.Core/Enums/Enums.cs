using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Core.Enums
{
    public enum ExpertLavel
    {
        Beginner = 1,
        Intermediate = 10,
        Expert = 20
    }

    public enum ImageType
    {
        AllImage = 0,
        HeadShotActive = 1,
        GallaryImage = 2
    }

    public enum ApprovalStatus
    {
        ApprovalPending = 1,
        ApprovalInProgress = 11,
        NotApproved = 21,
        Approved = 111
    }

}
