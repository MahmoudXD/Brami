using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Entity.User
{
	public class ApplicationUser : IdentityUser
	{
		public string FullName { get; set; }
		public string? RefreshToken { get; set; }
		public DateTime RefreshTokenExpiryTime { get; set; }
		public ICollection<Address> Addresses { get; set; }
	}
}
