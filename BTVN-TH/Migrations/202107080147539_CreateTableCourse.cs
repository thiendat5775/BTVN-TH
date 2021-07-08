namespace BTVN_TH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LectureId = c.String(nullable: false, maxLength: 128),
                        Place = c.String(nullable: false, maxLength: 255),
                        DateTime = c.DateTime(nullable: false),
                        CatelogyId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.LectureId, cascadeDelete: true)
                .Index(t => t.LectureId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "LectureId", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "LectureId" });
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
        }
    }
}
