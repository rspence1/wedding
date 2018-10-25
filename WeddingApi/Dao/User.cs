using System;
using WeddingApi.ModelDBO;

namespace WeddingApi.Dao
{
    public class User : IUser
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
