namespace Village_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Residents",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        fatherName = c.String(),
                        Gender = c.String(),
                        bornInVillage = c.Boolean(nullable: false),
                        yearOfBirth = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Residents");
        }
    }
}
