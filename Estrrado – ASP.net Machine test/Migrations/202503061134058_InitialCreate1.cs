﻿namespace Estrrado___ASP.net_Machine_test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Username", c => c.String());
            AddColumn("dbo.Students", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Password");
            DropColumn("dbo.Students", "Username");
        }
    }
}
