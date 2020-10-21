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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeamsGames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Game_Id = c.Int(),
                        GuestTeam_Id = c.Int(),
                        HomeTeam_Id = c.Int(),
                        Team_Id = c.Int(),
                        Team_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FootballGames", t => t.Game_Id)
                .ForeignKey("dbo.Teams", t => t.GuestTeam_Id)
                .ForeignKey("dbo.Teams", t => t.HomeTeam_Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id1)
                .Index(t => t.Game_Id)
                .Index(t => t.GuestTeam_Id)
                .Index(t => t.HomeTeam_Id)
                .Index(t => t.Team_Id)
                .Index(t => t.Team_Id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamsGames", "Team_Id1", "dbo.Teams");
            DropForeignKey("dbo.TeamsGames", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.TeamsGames", "HomeTeam_Id", "dbo.Teams");
            DropForeignKey("dbo.TeamsGames", "GuestTeam_Id", "dbo.Teams");
            DropForeignKey("dbo.TeamsGames", "Game_Id", "dbo.FootballGames");
            DropIndex("dbo.TeamsGames", new[] { "Team_Id1" });
            DropIndex("dbo.TeamsGames", new[] { "Team_Id" });
            DropIndex("dbo.TeamsGames", new[] { "HomeTeam_Id" });
            DropIndex("dbo.TeamsGames", new[] { "GuestTeam_Id" });
            DropIndex("dbo.TeamsGames", new[] { "Game_Id" });
            DropTable("dbo.TeamsGames");
            DropTable("dbo.Teams");
            DropTable("dbo.FootballGames");
        }
    }
}
