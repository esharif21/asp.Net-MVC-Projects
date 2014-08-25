namespace UniversityManagementSystemApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGradeLetter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GradeLetters",
                c => new
                    {
                        GradeLetterId = c.Int(nullable: false, identity: true),
                        Grade = c.String(),
                    })
                .PrimaryKey(t => t.GradeLetterId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GradeLetters");
        }
    }
}
