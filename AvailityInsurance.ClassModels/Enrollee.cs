using System;

namespace AvailityInsurance.Domain
{
    public class Enrollee
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Version { get; set; }
        public string InsuranceCompany { get; set; }

    }
}
