namespace LasFiszkas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fish",
                c => new
                    {
                        FishId = c.Int(nullable: false, identity: true),
                        FishInnerId = c.Int(nullable: false),
                        SetId = c.Int(nullable: false),
                        EspContent = c.String(nullable: false, maxLength: 35),
                        PlContent = c.String(nullable: false, maxLength: 35),
                    })
                .PrimaryKey(t => t.FishId)
                .ForeignKey("dbo.Sets", t => t.SetId, cascadeDelete: true)
                .Index(t => t.SetId);
            
            CreateTable(
                "dbo.Sets",
                c => new
                    {
                        SetId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Description = c.String(maxLength: 60),
                        IconFilename = c.String(),
                    })
                .PrimaryKey(t => t.SetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fish", "SetId", "dbo.Sets");
            DropIndex("dbo.Fish", new[] { "SetId" });
            DropTable("dbo.Sets");
            DropTable("dbo.Fish");
        }
    }
}
