namespace MovieBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) 
                    VALUES (N'a43eb9ff-703a-4deb-825b-7c6e89f1d277', N'admin@MovieBase.com', 0, N'AIxi93hYbc67wBrrpIvAvQ6f+G2bLnqy5P2VE7Pu7zZ4EMYA+XtJYeEPe+yjdyEPSA==', N'f0b4e295-ebb6-4a9c-bfb4-61bf4c508f84', NULL, 0, 0, NULL, 1, 0, N'admin@MovieBase.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) 
                    VALUES (N'd8cd1083-26ee-4a47-b234-739b9cb4ba33', N'guest@MovieBase.com', 0, N'AGGoJ82dMKi2DfswoO64gT4c2oiglfEm5NsTj0QcjEPtDlLwwCi38LXWu8GMxtHVWg==', N'6a6e338b-a020-4886-88d8-25f9533b2277', NULL, 0, 0, NULL, 1, 0, N'guest@MovieBase.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) 
                    VALUES (N'2afc0fdb-fa9b-4ac9-9243-d6d0b4a45a9c', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) 
                    VALUES (N'a43eb9ff-703a-4deb-825b-7c6e89f1d277', N'2afc0fdb-fa9b-4ac9-9243-d6d0b4a45a9c')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
