using System;
using System.Collections.Generic;
using WeddingApi.ModelDBO;

namespace WeddingApi.Dao
{
    public class Guest : IGuest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int AttendingState { get; set; }
        public bool IsPlusOne { get; set; }
        public string Message { get; set; }

        public Invitation Invitation { get; set; }
    }
}
