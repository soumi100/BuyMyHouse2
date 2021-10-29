using Microsoft.Azure.Functions.Worker.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouseAgenet.Auth
{
    public class AuthorizationChecker
    {
        private IJwtTokenUtils _jwtTokenUtils;

        public AuthorizationChecker(IJwtTokenUtils jwtTokenUtils)
        {
            _jwtTokenUtils = jwtTokenUtils;
        }

        public bool IsAuthorized(HttpRequestData req)
        {
            var token = req.Headers.Contains("Authorization") ? req.Headers.GetValues("Authorization").FirstOrDefault()?.Split(" ").Last() : null;

            var userId = _jwtTokenUtils.ValidateToken(token);
            if (userId != null)
            {
                return true;
            }

            return false;
        }
    }
}
