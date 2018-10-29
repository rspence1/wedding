using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingApi.ModelDBO
{
    interface IUser
    {
        Guid Id { get; set; }
        string Username { get; set; }
        DateTime Created { get; set; }
        DateTime? LastLogin { get; set; }
    }
}
