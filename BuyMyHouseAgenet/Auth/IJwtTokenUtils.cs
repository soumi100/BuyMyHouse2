using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouseAgenet.Auth
{
    public interface IJwtTokenUtils
    {
        public string GenerateToken(User user);
        public int? ValidateToken(string token);
    }
}
