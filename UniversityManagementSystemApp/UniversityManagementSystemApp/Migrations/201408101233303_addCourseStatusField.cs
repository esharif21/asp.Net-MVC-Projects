namespace UniversityManagementSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCourseStatusField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "CourseStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "CourseStatus");
        }
    }
}
