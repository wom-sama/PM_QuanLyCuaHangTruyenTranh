namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_LuotBan_To_Sach : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Saches", "LuotBan", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Saches", "LuotBan");
        }
    }
}
