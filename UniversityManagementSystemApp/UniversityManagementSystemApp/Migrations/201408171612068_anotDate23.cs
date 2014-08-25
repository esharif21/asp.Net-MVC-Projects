namespace UniversityManagementSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotDate23 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AllocateClassRooms", "StartTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AllocateClassRooms", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}
