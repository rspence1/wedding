using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingApi.ModelDBO
{
    public class IGuest
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Address { get; set; }
        int AttendingState { get; set; }
        bool IsPlusOne { get; set; }
        string Message { get; set; }
    }
}
