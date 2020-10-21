namespace FootballLeague.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teamscoretableadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeamScores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalScore = c.Int(nullable: false),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Team_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamScores", "Team_Id", "dbo.Teams");
            DropIndex("dbo.TeamScores", new[] { "Team_Id" });
            DropTable("dbo.TeamScores");
        }
    }
}
