namespace LasFiszkas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntToStringID : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sets", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sets", "UserId", c => c.Int(nullable: false));
        }
    }
}
