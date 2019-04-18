namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Genres (Name) VALUES('Comedy')");
            Sql("INSERT INTO dbo.Genres (Name) VALUES('Terror')");
            Sql("INSERT INTO dbo.Genres (Name) VALUES('War')");
            Sql("INSERT INTO dbo.Genres (Name) VALUES('Drama')");
        }
        
        public override void Down()
        {
        }
    }
}
