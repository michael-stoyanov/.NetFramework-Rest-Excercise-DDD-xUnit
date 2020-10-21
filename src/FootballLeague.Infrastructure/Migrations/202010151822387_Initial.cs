namespace FootballLeague.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FootballGames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HomeTeamResult = c.Int(nullable: false),
                        GuestTeamResult = c.Int(nullable: false),
                        Guest_Id = c.Int(),
                        Home_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Guest_Id)
                .ForeignKey("dbo.Teams", t => t.Home_Id)
                .Index(t => t.Guest_Id)
                .Index(t => t.Home_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FootballGames", "Home_Id", "dbo.Teams");
            DropForeignKey("dbo.FootballGames", "Guest_Id", "dbo.Teams");
            DropIndex("dbo.FootballGames", new[] { "Home_Id" });
            DropIndex("dbo.FootballGames", new[] { "Guest_Id" });
            DropTable("dbo.Teams");
            DropTable("dbo.FootballGames");
        }
    }
}
