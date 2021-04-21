using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.Utilities.Helpers
{
    public static class CommentHelper
    {
        public static bool HasToShowForUserId(IEnumerable<System.Security.Claims.Claim> claims, int? commentUserId)
        {
            return int.TryParse(
            claims.FirstOrDefault(x => x.Type == "UserId") == null ?
            "" : claims.FirstOrDefault(x => x.Type == "UserId").Value,
            out int userId)
            && commentUserId == userId;
        }
    }
}
