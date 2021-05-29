namespace ClothBazar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class configurationAdded1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Configurations",
                c => new
                    {
                        Key = c.String(nullable: false, maxLength: 128),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Key);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Configurations");
        }
    }
}
