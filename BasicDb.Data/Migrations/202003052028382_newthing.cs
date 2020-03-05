namespace BasicDb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newthing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "Character_CharId", c => c.Int());
            AddColumn("dbo.Media", "Character_CharId", c => c.Int());
            CreateIndex("dbo.Item", "Character_CharId");
            CreateIndex("dbo.Media", "Character_CharId");
            AddForeignKey("dbo.Item", "Character_CharId", "dbo.Character", "CharId");
            AddForeignKey("dbo.Media", "Character_CharId", "dbo.Character", "CharId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Media", "Character_CharId", "dbo.Character");
            DropForeignKey("dbo.Item", "Character_CharId", "dbo.Character");
            DropIndex("dbo.Media", new[] { "Character_CharId" });
            DropIndex("dbo.Item", new[] { "Character_CharId" });
            DropColumn("dbo.Media", "Character_CharId");
            DropColumn("dbo.Item", "Character_CharId");
        }
    }
}
