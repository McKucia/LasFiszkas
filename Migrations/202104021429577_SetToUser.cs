namespace LasFiszkas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sets", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Sets", "User_NickName", c => c.String(maxLength: 20));
            AddColumn("dbo.Sets", "User_ProfileImageFIle", c => c.Binary());
            AddColumn("dbo.Sets", "User_Email", c => c.String());
            AddColumn("dbo.Sets", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Sets", "ApplicationUser_Id");
            AddForeignKey("dbo.Sets", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sets", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Sets", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Sets", "ApplicationUser_Id");
            DropColumn("dbo.Sets", "User_Email");
            DropColumn("dbo.Sets", "User_ProfileImageFIle");
            DropColumn("dbo.Sets", "User_NickName");
            DropColumn("dbo.Sets", "UserId");
        }
    }
}
