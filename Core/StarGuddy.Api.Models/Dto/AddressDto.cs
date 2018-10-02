using System;
using System.Collections.Generic;
using System.Text;

namespace StarGuddy.Api.Models.Dto
{
    public class AddressDto
    {        
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string AppOrHouseName { get; set; }

        public string CityOrTown { get; set; }

        public string Country { get; set; }

        public string Flat { get; set; }

        public string LandMark { get; set; }

        public string LineOne { get; set; }

        public string LineTwo { get; set; }

        public string StateOrProvince { get; set; }

        public string ZipOrPostalCode { get; set; }
    }
}
