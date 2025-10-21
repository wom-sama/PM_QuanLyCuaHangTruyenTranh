namespace PM_QuanLyCuaHangTruyenTranh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePasswordFieldLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "MatKhau", c => c.String(nullable: false, maxLength: 255, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "MatKhau", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
    }
}
