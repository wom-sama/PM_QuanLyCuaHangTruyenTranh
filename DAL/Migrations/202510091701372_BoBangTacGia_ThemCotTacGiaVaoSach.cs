namespace PM.GUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoBangTacGia_ThemCotTacGiaVaoSach : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Saches", "MaTacGia", "dbo.TacGias");
            DropIndex("dbo.Saches", new[] { "MaTacGia" });
            AddColumn("dbo.Saches", "TacGia", c => c.String());
            DropColumn("dbo.Saches", "MaTacGia");
            DropTable("dbo.TacGias");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TacGias",
                c => new
                    {
                        MaTacGia = c.String(nullable: false, maxLength: 128),
                        ButDanh = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaTacGia);
            
            AddColumn("dbo.Saches", "MaTacGia", c => c.String(maxLength: 128));
            DropColumn("dbo.Saches", "TacGia");
            CreateIndex("dbo.Saches", "MaTacGia");
            AddForeignKey("dbo.Saches", "MaTacGia", "dbo.TacGias", "MaTacGia");
        }
    }
}
