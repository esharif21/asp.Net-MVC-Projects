namespace UniversityManagementSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRoomStatusField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "RoomStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "RoomStatus");
        }
    }
}
