namespace AppNet.EFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModifyBy = c.Int(nullable: false),
                        ModifyOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreateOn = c.DateTime(nullable: false),
                        Name = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModifyBy = c.Int(nullable: false),
                        ModifyOn = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreateOn = c.DateTime(nullable: false),
                        Name = c.String(),
                        SurName = c.String(),
                        EmailAddress = c.String(),
                        Password = c.String(),
                        LastLoginDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
    }
}
