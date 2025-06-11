using System.IO;

namespace Rockhopper.Git;

public class RepositoryHelper
{
    public static bool DoesGitRepositoryExist(string path)
    {
        return Directory.Exists($"{path}\\.git");
    }

    public static string? GetHEAD(string repositoryPath)
    {
        string? line;
        try
        {
            StreamReader sr = new StreamReader($"{repositoryPath}\\.git\\HEAD");
            line = sr.ReadLine();
            if (line != null)
            {
                return line;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: {e.Message}");
        }

        return null;
    }

    public static string? GetCheckedOutBranch(string repositoryPath)
    {
        return GetHEAD(repositoryPath)?.Replace("ref: refs/heads/", "");
    }
}