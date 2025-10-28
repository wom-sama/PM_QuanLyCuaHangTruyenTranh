namespace PM.GUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNgaySinhAnhDaiDien : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KhachHangs", "AnhDaiDien", c => c.Binary());
            AddColumn("dbo.KhachHangs", "NgaySinh", c => c.DateTime(nullable: false));
            AddColumn("dbo.NhanViens", "AnhDaiDien", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NhanViens", "AnhDaiDien");
            DropColumn("dbo.KhachHangs", "NgaySinh");
            DropColumn("dbo.KhachHangs", "AnhDaiDien");
        }
    }
}
