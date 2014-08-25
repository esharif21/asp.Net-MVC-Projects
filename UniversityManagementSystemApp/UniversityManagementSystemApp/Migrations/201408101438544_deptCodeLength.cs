namespace UniversityManagementSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deptCodeLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "Code", c => c.String(nullable: false, maxLength: 31));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "Code", c => c.String(nullable: false));
        }
    }
}
