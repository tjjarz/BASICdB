namespace BasicDb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Character",
                c => new
                    {
                        CharId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ShortDescription = c.String(nullable: false),
                        Description = c.String(),
                        UserId = c.String(maxLength: 128),
                        Character_CharId = c.Int(),
                        CharItem_CharItemID = c.Int(),
                        CharMedia_CharMediaID = c.Int(),
                    })
                .PrimaryKey(t => t.CharId)
                .ForeignKey("dbo.Character", t => t.Character_CharId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .ForeignKey("dbo.CharItem", t => t.CharItem_CharItemID)
                .ForeignKey("dbo.CharMedia", t => t.CharMedia_CharMediaID)
                .Index(t => t.UserId)
                .Index(t => t.Character_CharId)
                .Index(t => t.CharItem_CharItemID)
                .Index(t => t.CharMedia_CharMediaID);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Character_CharId = c.Int(),
                        CharItem_CharItemID = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .ForeignKey("dbo.Character", t => t.Character_CharId)
                .ForeignKey("dbo.CharItem", t => t.CharItem_CharItemID)
                .Index(t => t.UserId)
                .Index(t => t.Character_CharId)
                .Index(t => t.CharItem_CharItemID);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.CharItem",
                c => new
                    {
                        CharItemID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CharItemID);
            
            CreateTable(
                "dbo.CharMedia",
                c => new
                    {
                        CharMediaID = c.Int(nullable: false, identity: true),
                        CharMedia_CharMediaID = c.Int(),
                    })
                .PrimaryKey(t => t.CharMediaID)
                .ForeignKey("dbo.CharMedia", t => t.CharMedia_CharMediaID)
                .Index(t => t.CharMedia_CharMediaID);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        MediaId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Medium = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MediaId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Media", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.CharMedia", "CharMedia_CharMediaID", "dbo.CharMedia");
            DropForeignKey("dbo.Character", "CharMedia_CharMediaID", "dbo.CharMedia");
            DropForeignKey("dbo.Item", "CharItem_CharItemID", "dbo.CharItem");
            DropForeignKey("dbo.Character", "CharItem_CharItemID", "dbo.CharItem");
            DropForeignKey("dbo.Character", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.Character", "Character_CharId", "dbo.Character");
            DropForeignKey("dbo.Item", "Character_CharId", "dbo.Character");
            DropForeignKey("dbo.Item", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.Media", new[] { "UserId" });
            DropIndex("dbo.CharMedia", new[] { "CharMedia_CharMediaID" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Item", new[] { "CharItem_CharItemID" });
            DropIndex("dbo.Item", new[] { "Character_CharId" });
            DropIndex("dbo.Item", new[] { "UserId" });
            DropIndex("dbo.Character", new[] { "CharMedia_CharMediaID" });
            DropIndex("dbo.Character", new[] { "CharItem_CharItemID" });
            DropIndex("dbo.Character", new[] { "Character_CharId" });
            DropIndex("dbo.Character", new[] { "UserId" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Media");
            DropTable("dbo.CharMedia");
            DropTable("dbo.CharItem");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Item");
            DropTable("dbo.Character");
        }
    }
}
