namespace NewsSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedLikeTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Likes", name: "User_Id", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.Likes", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
            DropColumn("dbo.Likes", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Likes", "UserId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Likes", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Likes", name: "ApplicationUser_Id", newName: "User_Id");
        }
    }
}
