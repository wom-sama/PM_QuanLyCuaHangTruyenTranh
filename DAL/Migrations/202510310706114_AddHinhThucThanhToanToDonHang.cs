namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHinhThucThanhToanToDonHang : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonHangs", "HinhThucThanhToan", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonHangs", "HinhThucThanhToan");
        }
    }
}
