using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rollers.Domain.Models.Auth
{
    public class AuthOptions
    {
		public string Issuer { get; set; }
		public string Audience { get; set; }
		public string Secret { get; set; }
		public int TokenLifetime { get; set; }

		public SymmetricSecurityKey GetSummetricSecurityKey()
		{
			return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
		}

	}
}
