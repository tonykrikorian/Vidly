namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypeData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.MembershipTypes (Id,SignUpFee,DurationinMonths,DiscountRate) VALUES(1,0,0,0)");
            Sql("INSERT INTO dbo.MembershipTypes (Id,SignUpFee,DurationinMonths,DiscountRate) VALUES(2,30,1,10)");
            Sql("INSERT INTO dbo.MembershipTypes (Id,SignUpFee,DurationinMonths,DiscountRate) VALUES(3,90,3,15)");
            Sql("INSERT INTO dbo.MembershipTypes (Id,SignUpFee,DurationinMonths,DiscountRate) VALUES(4,300,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
