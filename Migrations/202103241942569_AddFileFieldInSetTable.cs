namespace LasFiszkas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileFieldInSetTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sets", "ImageFIle", c => c.Binary());
            DropColumn("dbo.Sets", "IconFilename");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sets", "IconFilename", c => c.String());
            DropColumn("dbo.Sets", "ImageFIle");
        }
    }
}
