namespace BasicDb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMedia : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CharMedia", "Media_MediaId", "dbo.Media");
            DropIndex("dbo.CharMedia", new[] { "Media_MediaId" });
            RenameColumn(table: "dbo.Item", name: "UserId", newName: "AddedBy");
            RenameIndex(table: "dbo.Item", name: "IX_UserId", newName: "IX_AddedBy");
            AddColumn("dbo.Media", "MediaType", c => c.String(nullable: false));
            DropColumn("dbo.Media", "Medium");
            DropTable("dbo.CharMedia");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CharMedia",
                c => new
                    {
                        CharMediaID = c.Int(nullable: false, identity: true),
                        Media_MediaId = c.Int(),
                    })
                .PrimaryKey(t => t.CharMediaID);
            
            AddColumn("dbo.Media", "Medium", c => c.Int(nullable: false));
            DropColumn("dbo.Media", "MediaType");
            RenameIndex(table: "dbo.Item", name: "IX_AddedBy", newName: "IX_UserId");
            RenameColumn(table: "dbo.Item", name: "AddedBy", newName: "UserId");
            CreateIndex("dbo.CharMedia", "Media_MediaId");
            AddForeignKey("dbo.CharMedia", "Media_MediaId", "dbo.Media", "MediaId");
        }
    }
}
