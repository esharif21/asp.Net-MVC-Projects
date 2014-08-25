namespace UniversityManagementSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDay : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        DayId = c.Int(nullable: false, identity: true),
                        TimeDay = c.String(),
                    })
                .PrimaryKey(t => t.DayId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Days");
        }
    }
}
