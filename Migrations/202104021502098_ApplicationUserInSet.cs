namespace LasFiszkas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUserInSet : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Sets", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Sets", "UserId");
            RenameColumn(table: "dbo.Sets", name: "ApplicationUser_Id", newName: "UserId");
            AlterColumn("dbo.Sets", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Sets", "UserId");
            DropColumn("dbo.Sets", "User_NickName");
            DropColumn("dbo.Sets", "User_ProfileImageFIle");
            DropColumn("dbo.Sets", "User_Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sets", "User_Email", c => c.String());
            AddColumn("dbo.Sets", "User_ProfileImageFIle", c => c.Binary());
            AddColumn("dbo.Sets", "User_NickName", c => c.String(maxLength: 20));
            DropIndex("dbo.Sets", new[] { "UserId" });
            AlterColumn("dbo.Sets", "UserId", c => c.String());
            RenameColumn(table: "dbo.Sets", name: "UserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Sets", "UserId", c => c.String());
            CreateIndex("dbo.Sets", "ApplicationUser_Id");
        }
    }
}
