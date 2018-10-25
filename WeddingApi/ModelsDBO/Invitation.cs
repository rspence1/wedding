using System;
using System.Collections.Generic;

namespace WeddingApi.ModelsDBO
{
    public partial class Invitation
    {
        public Invitation()
        {
            Guest = new HashSet<Guest>();
        }

        public Guid Id { get; set; }
        public string LoginCode { get; set; }
        public DateTime? Sent { get; set; }

        public ICollection<Guest> Guest { get; set; }
    }
}
