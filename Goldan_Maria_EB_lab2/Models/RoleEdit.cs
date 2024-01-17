using Microsoft.AspNetCore.Identity;

namespace Goldan_Maria_EB_lab2.Models
{
	public class RoleEdit
	{
		public IdentityRole Role { get; set; }
		public IEnumerable<IdentityUser> Members { get; set; }
		public IEnumerable<IdentityUser> NonMembers { get; set; }
	}
}
