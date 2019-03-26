namespace CalumBSUAttempt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserToEveryTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "User", c => c.String());
            AddColumn("dbo.Directors", "User", c => c.String());
            AddColumn("dbo.Films", "User", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Films", "User");
            DropColumn("dbo.Directors", "User");
            DropColumn("dbo.Actors", "User");
        }
    }
}
