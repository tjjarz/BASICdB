namespace BasicDb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixMediaAgain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CharMedia",
                c => new
                    {
                        CharMediaId = c.Int(nullable: false, identity: true),
                        CharId = c.Int(nullable: false),
                        MediaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CharMediaId)
                .ForeignKey("dbo.Character", t => t.CharId, cascadeDelete: true)
                .ForeignKey("dbo.Media", t => t.MediaId, cascadeDelete: true)
                .Index(t => t.CharId)
                .Index(t => t.MediaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CharMedia", "MediaId", "dbo.Media");
            DropForeignKey("dbo.CharMedia", "CharId", "dbo.Character");
            DropIndex("dbo.CharMedia", new[] { "MediaId" });
            DropIndex("dbo.CharMedia", new[] { "CharId" });
            DropTable("dbo.CharMedia");
        }
    }
}
