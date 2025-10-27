namespace PM.GUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class XoaBanQuyen : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BanQuyens", "MaSach", "dbo.Saches");
            DropIndex("dbo.BanQuyens", new[] { "MaSach" });
            DropTable("dbo.BanQuyens");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BanQuyens",
                c => new
                    {
                        MaBanQuyen = c.String(nullable: false, maxLength: 20, unicode: false),
                        MaSach = c.String(maxLength: 20, unicode: false),
                        NgayCap = c.DateTime(nullable: false),
                        NgayHetHan = c.DateTime(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.MaBanQuyen);
            
            CreateIndex("dbo.BanQuyens", "MaSach");
            AddForeignKey("dbo.BanQuyens", "MaSach", "dbo.Saches", "MaSach");
        }
    }
}
