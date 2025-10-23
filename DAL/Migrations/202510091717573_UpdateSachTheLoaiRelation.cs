namespace PM.GUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSachTheLoaiRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Saches", "MaTheLoai", "dbo.TheLoais");
            DropIndex("dbo.Saches", new[] { "MaTheLoai" });
            CreateTable(
                "dbo.TheLoaiSaches",
                c => new
                    {
                        TheLoai_MaTheLoai = c.String(nullable: false, maxLength: 128),
                        Sach_MaSach = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.TheLoai_MaTheLoai, t.Sach_MaSach })
                .ForeignKey("dbo.TheLoais", t => t.TheLoai_MaTheLoai, cascadeDelete: true)
                .ForeignKey("dbo.Saches", t => t.Sach_MaSach, cascadeDelete: true)
                .Index(t => t.TheLoai_MaTheLoai)
                .Index(t => t.Sach_MaSach);
            
            DropColumn("dbo.Saches", "MaTheLoai");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Saches", "MaTheLoai", c => c.String(maxLength: 128));
            DropForeignKey("dbo.TheLoaiSaches", "Sach_MaSach", "dbo.Saches");
            DropForeignKey("dbo.TheLoaiSaches", "TheLoai_MaTheLoai", "dbo.TheLoais");
            DropIndex("dbo.TheLoaiSaches", new[] { "Sach_MaSach" });
            DropIndex("dbo.TheLoaiSaches", new[] { "TheLoai_MaTheLoai" });
            DropTable("dbo.TheLoaiSaches");
            CreateIndex("dbo.Saches", "MaTheLoai");
            AddForeignKey("dbo.Saches", "MaTheLoai", "dbo.TheLoais", "MaTheLoai");
        }
    }
}
