namespace UniversityManagementSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRoomAllocate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllocateClassRooms",
                c => new
                    {
                        AllocateClassRoomId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        DayId = c.Int(nullable: false),
                        StartTime = c.String(),
                        EndTime = c.String(),
                    })
                .PrimaryKey(t => t.AllocateClassRoomId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: false)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: false)
                .ForeignKey("dbo.Days", t => t.DayId, cascadeDelete: false)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: false)
                .Index(t => t.DepartmentId)
                .Index(t => t.CourseId)
                .Index(t => t.RoomId)
                .Index(t => t.DayId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AllocateClassRooms", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.AllocateClassRooms", "DayId", "dbo.Days");
            DropForeignKey("dbo.AllocateClassRooms", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.AllocateClassRooms", "CourseId", "dbo.Courses");
            DropIndex("dbo.AllocateClassRooms", new[] { "DayId" });
            DropIndex("dbo.AllocateClassRooms", new[] { "RoomId" });
            DropIndex("dbo.AllocateClassRooms", new[] { "CourseId" });
            DropIndex("dbo.AllocateClassRooms", new[] { "DepartmentId" });
            DropTable("dbo.AllocateClassRooms");
        }
    }
}
