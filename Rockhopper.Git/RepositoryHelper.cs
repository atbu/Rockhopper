using System.IO;

namespace Rockhopper.Git;

public class RepositoryHelper
{
    public static bool DoesGitRepositoryExist(string path)
    {
        return Directory.Exists($"{path}\\.git");
    }
}