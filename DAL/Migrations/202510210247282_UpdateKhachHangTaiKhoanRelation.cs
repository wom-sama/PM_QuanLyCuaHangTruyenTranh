namespace PM_QuanLyCuaHangTruyenTranh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateKhachHangTaiKhoanRelation : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TaiKhoans", "MaKH");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TaiKhoans", "MaKH", c => c.String(maxLength: 20, unicode: false));
        }
    }
}
