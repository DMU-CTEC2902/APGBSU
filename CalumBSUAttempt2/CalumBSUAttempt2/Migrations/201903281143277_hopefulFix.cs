namespace CalumBSUAttempt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hopefulFix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiscussionInfoes",
                c => new
                    {
                        DiscussionInfoId = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        DiscussionId = c.Int(nullable: false),
                        User = c.String(),
                    })
                .PrimaryKey(t => t.DiscussionInfoId)
                .ForeignKey("dbo.Discussions", t => t.DiscussionId, cascadeDelete: true)
                .Index(t => t.DiscussionId);
            
            CreateTable(
                "dbo.Discussions",
                c => new
                    {
                        DiscussionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        User = c.String(),
                    })
                .PrimaryKey(t => t.DiscussionId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Headline = c.String(),
                        BodyText = c.String(),
                        User = c.String(),
                    })
                .PrimaryKey(t => t.NewsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiscussionInfoes", "DiscussionId", "dbo.Discussions");
            DropIndex("dbo.DiscussionInfoes", new[] { "DiscussionId" });
            DropTable("dbo.News");
            DropTable("dbo.Discussions");
            DropTable("dbo.DiscussionInfoes");
        }
    }
}
