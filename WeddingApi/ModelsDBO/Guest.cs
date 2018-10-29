using System;
using System.Collections.Generic;

namespace WeddingApi.ModelsDBO
{
    public partial class Guest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int AttendingState { get; set; }
        public bool IsPlusOne { get; set; }
        public string Message { get; set; }
        public Guid? InvitationId { get; set; }

        public Invitation Invitation { get; set; }
    }
}
