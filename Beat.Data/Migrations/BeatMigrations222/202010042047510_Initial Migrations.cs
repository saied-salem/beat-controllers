namespace Beat.Data.Migrations.BeatMigrations222
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Abbreviation = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        Leader_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Leader_Id)
                .Index(t => t.Leader_Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        University = c.String(),
                        Faculty = c.String(),
                        Department = c.String(),
                        Position = c.Int(nullable: false),
                        Committee_Id = c.Int(),
                        Track_Id = c.Int(),
                        Track_Id1 = c.Int(),
                        Event_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Committees", t => t.Committee_Id)
                .ForeignKey("dbo.Tracks", t => t.Track_Id)
                .ForeignKey("dbo.Tracks", t => t.Track_Id1)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .Index(t => t.Committee_Id)
                .Index(t => t.Track_Id)
                .Index(t => t.Track_Id1)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.Committees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbreviation = c.String(),
                        Leader_Id = c.Int(),
                        Track_Id = c.Int(),
                        Member_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Leader_Id)
                .ForeignKey("dbo.Tracks", t => t.Track_Id)
                .ForeignKey("dbo.Members", t => t.Member_Id)
                .Index(t => t.Leader_Id)
                .Index(t => t.Track_Id)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbreviation = c.String(),
                        Leader_Id = c.Int(),
                        Member_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Leader_Id)
                .ForeignKey("dbo.Members", t => t.Member_Id)
                .Index(t => t.Leader_Id)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Grade = c.String(),
                        Faculty = c.String(),
                        University = c.String(),
                        Event_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.Partners",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Abbreviation = c.String(),
                        Website = c.String(),
                        ContactNumber = c.String(),
                        ContactPerson = c.String(),
                        LogoUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Participants", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Members", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Events", "Leader_Id", "dbo.Members");
            DropForeignKey("dbo.Members", "Track_Id1", "dbo.Tracks");
            DropForeignKey("dbo.Tracks", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.Committees", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.Members", "Track_Id", "dbo.Tracks");
            DropForeignKey("dbo.Tracks", "Leader_Id", "dbo.Members");
            DropForeignKey("dbo.Committees", "Track_Id", "dbo.Tracks");
            DropForeignKey("dbo.Members", "Committee_Id", "dbo.Committees");
            DropForeignKey("dbo.Committees", "Leader_Id", "dbo.Members");
            DropIndex("dbo.Participants", new[] { "Event_Id" });
            DropIndex("dbo.Tracks", new[] { "Member_Id" });
            DropIndex("dbo.Tracks", new[] { "Leader_Id" });
            DropIndex("dbo.Committees", new[] { "Member_Id" });
            DropIndex("dbo.Committees", new[] { "Track_Id" });
            DropIndex("dbo.Committees", new[] { "Leader_Id" });
            DropIndex("dbo.Members", new[] { "Event_Id" });
            DropIndex("dbo.Members", new[] { "Track_Id1" });
            DropIndex("dbo.Members", new[] { "Track_Id" });
            DropIndex("dbo.Members", new[] { "Committee_Id" });
            DropIndex("dbo.Events", new[] { "Leader_Id" });
            DropTable("dbo.Partners");
            DropTable("dbo.Participants");
            DropTable("dbo.Tracks");
            DropTable("dbo.Committees");
            DropTable("dbo.Members");
            DropTable("dbo.Events");
        }
    }
}
