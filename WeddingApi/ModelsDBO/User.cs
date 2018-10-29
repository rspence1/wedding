using System;
using System.Collections.Generic;

namespace WeddingApi.ModelsDBO
{
    public partial class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
