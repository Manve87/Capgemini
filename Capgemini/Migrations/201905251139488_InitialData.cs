namespace Capgemini.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialData : DbMigration
    {
        public override void Up()


        {
            for (int i = 1;i <15; i++ )
            {
                Sql($"INSERT INTO Tasks (taskName) VALUES ('Task {i}') ");
            }
            for (int i = 1; i <= 3; i++)
            {
                Sql($"INSERT INTO Users (userName) VALUES ('User {i}') ");
            }

            

        }

        public override void Down()
        {
        }
    }
}
