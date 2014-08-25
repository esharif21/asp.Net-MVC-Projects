namespace UniversityManagementSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teacherCourseAssign : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeacherCourseAssigns",
                c => new
                    {
                        TeacherCourseAssignId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherCourseAssignId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: false)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: false)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: false)
                .Index(t => t.DepartmentId)
                .Index(t => t.TeacherId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherCourseAssigns", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeacherCourseAssigns", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.TeacherCourseAssigns", "CourseId", "dbo.Courses");
            DropIndex("dbo.TeacherCourseAssigns", new[] { "CourseId" });
            DropIndex("dbo.TeacherCourseAssigns", new[] { "TeacherId" });
            DropIndex("dbo.TeacherCourseAssigns", new[] { "DepartmentId" });
            DropTable("dbo.TeacherCourseAssigns");
        }
    }
}
