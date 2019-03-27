namespace CalumBSUAttempt2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserToGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genres", "User", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Genres", "User");
        }
    }
}
