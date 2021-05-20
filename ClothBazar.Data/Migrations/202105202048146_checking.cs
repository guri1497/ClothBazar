namespace ClothBazar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checking : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "ImageURL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "ImageURL", c => c.String());
        }
    }
}
