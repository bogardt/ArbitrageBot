using BinanceWebSocketApi.Abstractions;

namespace BinanceWebSocketApi.Utils;

public class FileSystem : IFileSystem
{
    public string GetCurrentDirectory() => Directory.GetCurrentDirectory();

    public string GetDirectoryName(string path)
    {
        if (string.IsNullOrEmpty(path))
            throw new ArgumentNullException(nameof(path));
        var dir = Path.GetDirectoryName(path);
        if (string.IsNullOrEmpty(dir))
            throw new DirectoryNotFoundException();
        return dir;
    }

    public bool DirectoryExists(string path) => Directory.Exists(path);

    public DirectoryInfo CreateDirectory(string path) => Directory.CreateDirectory(path);

    public FileInfo[] GetFiles(string path, string searchPattern)
    {
        var directoryInfo = new DirectoryInfo(path);
        return directoryInfo.GetFiles(searchPattern);
    }

    public string GetSolutionPath()
    {
        var currentDirectory = GetCurrentDirectory();

        var directoryInfo = new DirectoryInfo(currentDirectory);

        while (directoryInfo != null && !GetFiles(directoryInfo.FullName, "*.sln").Any())
            directoryInfo = directoryInfo.Parent;

        return directoryInfo?.FullName;
    }
}
