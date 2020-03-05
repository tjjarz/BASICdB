namespace BasicDb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                    })
                .PrimaryKey(t => t.CharId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.UserId);
            
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
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .ForeignKey("dbo.Character", t => t.Character_CharId)
                .Index(t => t.UserId)
                .Index(t => t.Character_CharId);
            
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
                "dbo.Media",
                c => new
                    {
                        MediaId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Medium = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Character_CharId = c.Int(),
                    })
                .PrimaryKey(t => t.MediaId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .ForeignKey("dbo.Character", t => t.Character_CharId)
                .Index(t => t.UserId)
                .Index(t => t.Character_CharId);
            
            CreateTable(
                "dbo.CharItem",
                c => new
                    {
                        CharItemId = c.Int(nullable: false, identity: true),
                        CharId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CharItemId)
                .ForeignKey("dbo.Character", t => t.CharId, cascadeDelete: true)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.CharId)
                .Index(t => t.ItemId);
            
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
            DropForeignKey("dbo.CharMedia", "MediaId", "dbo.Media");
            DropForeignKey("dbo.CharMedia", "CharId", "dbo.Character");
            DropForeignKey("dbo.CharItem", "ItemId", "dbo.Item");
            DropForeignKey("dbo.CharItem", "CharId", "dbo.Character");
            DropForeignKey("dbo.Character", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.Media", "Character_CharId", "dbo.Character");
            DropForeignKey("dbo.Media", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.Item", "Character_CharId", "dbo.Character");
            DropForeignKey("dbo.Item", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.CharMedia", new[] { "MediaId" });
            DropIndex("dbo.CharMedia", new[] { "CharId" });
            DropIndex("dbo.CharItem", new[] { "ItemId" });
            DropIndex("dbo.CharItem", new[] { "CharId" });
            DropIndex("dbo.Media", new[] { "Character_CharId" });
            DropIndex("dbo.Media", new[] { "UserId" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Item", new[] { "Character_CharId" });
            DropIndex("dbo.Item", new[] { "UserId" });
            DropIndex("dbo.Character", new[] { "UserId" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.CharMedia");
            DropTable("dbo.CharItem");
            DropTable("dbo.Media");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Item");
            DropTable("dbo.Character");
        }
    }
}
