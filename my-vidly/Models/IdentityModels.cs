using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace my_vidly.Models
{
	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class ApplicationUser : IdentityUser
	{
		[Required]
		[StringLength(255)]
		public string DrivingLicense { get; set; }

		[Required]
		[StringLength(50)]
		public override string PhoneNumber { get; set; }

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			return userIdentity;
		}
	}

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}

		//register DbSet for Models
		public System.Data.Entity.DbSet<my_vidly.Models.Customer> Customers { get; set; }
		public System.Data.Entity.DbSet<my_vidly.Models.Movie> Movies { get; set; }
		public DbSet<MembershipType> MembershipTypes { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Rental> Rentals { get; set; }
	}
}