namespace UniversityManagementSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotAllocClassRoom : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AllocateClassRooms", "StartTime", c => c.String(nullable: false));
            AlterColumn("dbo.AllocateClassRooms", "EndTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AllocateClassRooms", "EndTime", c => c.String());
            AlterColumn("dbo.AllocateClassRooms", "StartTime", c => c.String());
        }
    }
}
