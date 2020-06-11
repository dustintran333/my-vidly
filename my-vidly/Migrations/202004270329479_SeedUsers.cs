namespace my_vidly.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	public partial class SeedUsers : DbMigration
	{
		public override void Up()
		{
			Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'df4171e5-a4f8-4339-908e-69f99cf39e3c', N'admin@mail.com', 0, N'ABmPGbPcJ+O8z3DmncM36xafQmIVUoUtl+V5/jY/pi4lO1+EnAffmnZ137EBDS0LDg==', N'beed05bd-4efb-4b73-985c-42551d398682', NULL, 0, 0, NULL, 1, 0, N'admin@mail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f387fe4e-d97a-452b-8ae5-7a3422803d06', N'guest@mail.com', 0, N'AIsd09esoSNmi8PbtnIL2SQY/dJf4/l2pJYIBefzmAAi8kDQG9GMUoqCTLWRWrY5Qw==', N'48769d82-6638-4528-a0c5-72e9e53c2887', NULL, 0, 0, NULL, 1, 0, N'guest@mail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ab80b49b-7e19-4f62-a92d-5466206300dc', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'df4171e5-a4f8-4339-908e-69f99cf39e3c', N'ab80b49b-7e19-4f62-a92d-5466206300dc')

");
		}
		
		public override void Down()
		{
		}
	}
}
