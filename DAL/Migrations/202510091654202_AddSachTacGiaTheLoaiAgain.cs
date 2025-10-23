namespace PM.GUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSachTacGiaTheLoaiAgain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Saches",
                c => new
                    {
                        MaSach = c.String(nullable: false, maxLength: 128),
                        TenSach = c.String(nullable: false, maxLength: 100),
                        SoTrang = c.Int(nullable: false),
                        GioiThieu = c.String(),
                        BiaSach = c.String(),
                        MaTacGia = c.String(maxLength: 128),
                        MaTheLoai = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaSach)
                .ForeignKey("dbo.TacGias", t => t.MaTacGia)
                .ForeignKey("dbo.TheLoais", t => t.MaTheLoai)
                .Index(t => t.MaTacGia)
                .Index(t => t.MaTheLoai);
            
            CreateTable(
                "dbo.TacGias",
                c => new
                    {
                        MaTacGia = c.String(nullable: false, maxLength: 128),
                        ButDanh = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaTacGia);
            
            CreateTable(
                "dbo.TheLoais",
                c => new
                    {
                        MaTheLoai = c.String(nullable: false, maxLength: 128),
                        TenTheLoai = c.String(nullable: false),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.MaTheLoai);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Saches", "MaTheLoai", "dbo.TheLoais");
            DropForeignKey("dbo.Saches", "MaTacGia", "dbo.TacGias");
            DropIndex("dbo.Saches", new[] { "MaTheLoai" });
            DropIndex("dbo.Saches", new[] { "MaTacGia" });
            DropTable("dbo.TheLoais");
            DropTable("dbo.TacGias");
            DropTable("dbo.Saches");
        }
    }
}
