using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace OnlineStrategyGame.Base.Security
{
    public static class ClaimStaticManager
    {
        public static Claim GetNewPlayerClaim()
        {
            return new Claim("NewPlayer", "NewPlayer");
        }
        public static Claim GetActivePlayerClaim()
        {
            return new Claim("ActivePlayer", "ActivePlayer");
        }
    }
}
