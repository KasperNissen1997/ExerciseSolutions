using System.Configuration;

namespace ModelPersistence.Persistence
{
    public abstract class Repository
    {
        // protected string connectionString = ConfigurationManager.ConnectionStrings["DatabaseServerInstance"].ConnectionString;
        protected string connectionString = "Server=10.56.8.36; Database=DB_2023_36; User Id=STUDENT_36; Password=OPENDB_36";

        protected abstract void Load();
        protected abstract void Save();
    }
}
