using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingApi.Dao
{
    public class Invitation
    {
        int Id { get; set; }
        DateTime Sent { get; set; }
        List<Guest> Guests { get; }
        string LoginCode { get; }

        public Invitation(List<Guest> guests, string loginCode)
        {
            Guests = guests;
            LoginCode = generateLoginCode();
        }

        private string generateLoginCode()
        {
            return "123456";
        }
    }
}
