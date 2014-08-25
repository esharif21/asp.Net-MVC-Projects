namespace UniversityManagementSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teacherAnnot : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "Name", c => c.String(nullable: false, maxLength: 63));
            AlterColumn("dbo.Teachers", "Email", c => c.String(nullable: false, maxLength: 127));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "Email", c => c.String());
            AlterColumn("dbo.Teachers", "Name", c => c.String());
        }
    }
}
