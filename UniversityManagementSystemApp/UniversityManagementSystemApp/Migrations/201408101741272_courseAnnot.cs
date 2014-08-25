namespace UniversityManagementSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseAnnot : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Code", c => c.String(nullable: false, maxLength: 63));
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 127));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String());
            AlterColumn("dbo.Courses", "Code", c => c.String());
        }
    }
}
