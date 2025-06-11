namespace Rockhopper.Git.Helpers;

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
                return line.Replace("ref: refs/heads/", "");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: {e.Message}");
        }

        return null;
    }
}