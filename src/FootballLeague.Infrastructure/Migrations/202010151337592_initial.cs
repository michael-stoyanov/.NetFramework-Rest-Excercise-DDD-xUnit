namespace FootballLeague.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FootballMatches",
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
            DropForeignKey("dbo.FootballMatches", "Home_Id", "dbo.Teams");
            DropForeignKey("dbo.FootballMatches", "Guest_Id", "dbo.Teams");
            DropIndex("dbo.FootballMatches", new[] { "Home_Id" });
            DropIndex("dbo.FootballMatches", new[] { "Guest_Id" });
            DropTable("dbo.Teams");
            DropTable("dbo.FootballMatches");
        }
    }
}
