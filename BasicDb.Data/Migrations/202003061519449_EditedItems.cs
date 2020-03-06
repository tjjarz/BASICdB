namespace BasicDb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditedItems : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Item", name: "UserId", newName: "AddedBy");
            RenameIndex(table: "dbo.Item", name: "IX_UserId", newName: "IX_AddedBy");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Item", name: "IX_AddedBy", newName: "IX_UserId");
            RenameColumn(table: "dbo.Item", name: "AddedBy", newName: "UserId");
        }
    }
}
