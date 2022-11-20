
namespace Domain
{
    public class DatabaseOptions
    {
#if DEBUG
        public const string DatabaseConnectionString = @"Data Source=localhost;Initial Catalog=PostMkaerDataBase;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
#endif

#if RELESE
        public const string DatabaseConnectionString = @"";
#endif

    }
}
