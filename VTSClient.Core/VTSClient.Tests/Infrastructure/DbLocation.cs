using System.IO;
using PCLStorage;
using VTSClient.DAL.Infrastructure.Interfaces;

namespace VTSClient.Tests.Infrastructure
{
    public class DbLocation : IDbLocation
    {
        public string GetDatabasePath(string fileName)
        {
            var path = Path.Combine(FileSystem.Current.LocalStorage.Path, fileName);

            return path;
        }
    }
}