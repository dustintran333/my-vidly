using System.Collections.Generic;

namespace my_vidly.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	public partial class AlterNameMBT : DbMigration
	{
		public override void Up()
		{
			var Mbt = new List<KeyValuePair<string, int>>()
			{
				new KeyValuePair<string, int>("Pay as You Go",1),
				new KeyValuePair<string, int>("Monthly",2),
				new KeyValuePair<string, int>("Quarterly",3),
				new KeyValuePair<string, int>("Annual",4),

			};
			foreach (var i in Mbt)
				Sql($"UPDATE MembershipTypes SET Name = '{i.Key}' WHERE Id={i.Value}");
		}
		
		public override void Down()
		{
		}
	}
}
