namespace ClothBazar.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class configurationAdded : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Configs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Configs",
                c => new
                    {
                        Key = c.String(nullable: false, maxLength: 128),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Key);
            
        }
    }
}
