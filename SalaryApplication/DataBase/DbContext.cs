using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;

namespace SalaryApplication.DataBase
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() :
            base(new SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = "HRDataBase.db3", ForeignKeys = true }.ConnectionString
            }, true)
        { }

        public void Create()
        {
            CreateEmployeeTable();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            CreateCompanyTable();
            CreateEmployeeTable();
        }


        public void CreateCompanyTable()
        {
            using (SQLiteConnection conn = new SQLiteConnection("data source = HRDataBase.db3"))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    string query = @"Create table if not exists 
                                    [Company] 
                                    (
                                    [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                                    [NAME] NVARCHAR (2048) NULL
                                    )";

                    conn.Open();
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CreateEmployeeTable()
        {
            using (SQLiteConnection conn = new SQLiteConnection("data source = HRDataBase.db3"))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    string query = @"Create table if not exists 
                                    [Employe] 
                                    (
                                    [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
                                    [FirstName] NVARCHAR (40) NULL,
                                    [LastName] NVARCHAR (40) NULL,
                                    [MiddleName] NVARCHAR (40) NULL,
                                    [EmployeeType] INTEGER NOT NULL,
                                    [EnrollmentDate] DATE,                              
                                    [CompanyId] INTEGER NOT NULL,
                                    FOREIGN KEY (CompanyId) REFERENCES Company(Id)
                                    
                                    )";

                    conn.Open();
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //public void CreateTableEmployeeTypes()
        //{
        //    using (SQLiteConnection conn = new SQLiteConnection("data source = HRDatabase.db3"))
        //    {
        //        using (SQLiteCommand cmd = new SQLiteCommand(conn))
        //        {
        //            string query = @"Create table if not exists 
        //                            [EmployeeTypes] 
        //                            (
        //                            [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
        //                            [EmployeeId] INTEGER NOT NULL,
        //                            [Salary] DOUBLE NULL,                 
        //                            FOREIGN KEY (EmployeeId) REFERENCES Employe(Id)
        //                            )";

        //            conn.Open();
        //            cmd.CommandText = query;
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}

        public DbSet<Employe> EmployeDb { get; set; }
        public DbSet<Company> CompanyDb { get; set; }

        //public DbSet<EmployeeTypes> EmployeeTypesDb { get; set; }


    }
}
