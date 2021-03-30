namespace LasFiszkas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfileImageFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserData_ProfileImageFIle", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserData_ProfileImageFIle");
        }
    }
}
