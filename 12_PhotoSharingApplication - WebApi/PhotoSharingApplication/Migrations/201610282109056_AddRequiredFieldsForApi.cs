namespace PhotoSharingApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredFieldsForApi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Photos", "PhotoFile", c => c.Binary(nullable: false));
            AlterColumn("dbo.Photos", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Photos", "UserName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Photos", "UserName", c => c.String());
            AlterColumn("dbo.Photos", "Description", c => c.String());
            AlterColumn("dbo.Photos", "PhotoFile", c => c.Binary());
        }
    }
}
