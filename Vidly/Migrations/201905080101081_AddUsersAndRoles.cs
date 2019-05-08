namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsersAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0d3bddca-e0ad-49d2-bdfe-bfd28cf4a422', N'tony.krikorian@outlook.com', 0, N'AO46RqfSiqbl1vXWvQvoceC2u1mCtR9MMAB+kiNzLbfEcjjXMLa5MbK0KXXK1uMhmA==', N'7dc2c2f1-9a5b-4d04-8379-18914fcc732c', NULL, 0, 0, NULL, 1, 0, N'tony.krikorian@outlook.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f1974427-e93a-482e-bd31-fc94600c64bd', N'admin@vidly.com', 0, N'AEOBmR1tFelwFSMsXLNroEogFit8ZjWkpNxzuxkgYiA5AyinwRxNEqojW5mp9Ch3dA==', N'3cb60600-0192-4c8a-9116-532f4b3d5562', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'61a37398-581a-4bf3-8762-e8980229251e', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f1974427-e93a-482e-bd31-fc94600c64bd', N'61a37398-581a-4bf3-8762-e8980229251e')

                
                ");
        }
        
        public override void Down()
        {
        }
    }
}
