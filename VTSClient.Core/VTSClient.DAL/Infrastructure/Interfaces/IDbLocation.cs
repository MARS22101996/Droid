namespace VTSClient.DAL.Infrastructure.Interfaces
{
    public interface IDbLocation
    {
        string GetDatabasePath(string filename);
    }
}
