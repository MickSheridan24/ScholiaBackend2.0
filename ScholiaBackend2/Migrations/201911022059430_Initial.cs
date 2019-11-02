namespace ScholiaBackend2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "GutenbergId", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "Body", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Body");
            DropColumn("dbo.Books", "GutenbergId");
        }
    }
}
