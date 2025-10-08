namespace PM_QuanLyCuaHangTruyenTranh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        MaAdmin = c.String(nullable: false, maxLength: 20, unicode: false),
                        TenDangNhap = c.String(nullable: false, maxLength: 50, unicode: false),
                        MatKhau = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.MaAdmin);
            
            CreateTable(
                "dbo.Khaches",
                c => new
                    {
                        MaKhach = c.String(nullable: false, maxLength: 20, unicode: false),
                        TenDangNhap = c.String(nullable: false, maxLength: 50, unicode: false),
                        MatKhau = c.String(nullable: false, maxLength: 255, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.MaKhach);
            
            CreateTable(
                "dbo.NhanViens",
                c => new
                    {
                        MaNV = c.String(nullable: false, maxLength: 20, unicode: false),
                        TenDangNhap = c.String(nullable: false, maxLength: 50, unicode: false),
                        MatKhau = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.MaNV);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NhanViens");
            DropTable("dbo.Khaches");
            DropTable("dbo.Admins");
        }
    }
}
