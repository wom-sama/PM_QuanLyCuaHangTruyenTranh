namespace PM.GUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SuaLuuAnh : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Saches", "BiaSach");
            AddColumn("dbo.Saches", "BiaSach", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Saches", "BiaSach", c => c.String());
        }
    }
}
