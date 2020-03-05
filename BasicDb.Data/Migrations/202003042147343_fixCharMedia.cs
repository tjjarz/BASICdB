namespace BasicDb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixCharMedia : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Media", new[] { "CharMedia_CharMediaID" });
            DropColumn("dbo.Media", "MediaId");
            RenameColumn(table: "dbo.Media", name: "CharMedia_CharMediaID", newName: "MediaId");
            DropPrimaryKey("dbo.Media");
            AlterColumn("dbo.Media", "MediaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Media", "MediaId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Media", "MediaId");
            CreateIndex("dbo.Media", "MediaId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Media", new[] { "MediaId" });
            DropPrimaryKey("dbo.Media");
            AlterColumn("dbo.Media", "MediaId", c => c.Int());
            AlterColumn("dbo.Media", "MediaId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Media", "MediaId");
            RenameColumn(table: "dbo.Media", name: "MediaId", newName: "CharMedia_CharMediaID");
            AddColumn("dbo.Media", "MediaId", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Media", "CharMedia_CharMediaID");
        }
    }
}
