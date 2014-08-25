namespace UniversityManagementSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addResultEntry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResultEntries",
                c => new
                    {
                        ResultEntryId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        GradeLetterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResultEntryId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: false)
                .ForeignKey("dbo.GradeLetters", t => t.GradeLetterId, cascadeDelete: false)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: false)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.GradeLetterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResultEntries", "StudentId", "dbo.Students");
            DropForeignKey("dbo.ResultEntries", "GradeLetterId", "dbo.GradeLetters");
            DropForeignKey("dbo.ResultEntries", "CourseId", "dbo.Courses");
            DropIndex("dbo.ResultEntries", new[] { "GradeLetterId" });
            DropIndex("dbo.ResultEntries", new[] { "CourseId" });
            DropIndex("dbo.ResultEntries", new[] { "StudentId" });
            DropTable("dbo.ResultEntries");
        }
    }
}
