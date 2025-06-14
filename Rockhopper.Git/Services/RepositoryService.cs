using Rockhopper.Git.Models;

namespace Rockhopper.Git.Services;

public class RepositoryService : IRepositoryService
{
    public string GetHEAD(Repository repository)
    {
        string? line;
        try
        {
            StreamReader sr = new StreamReader($"{repository.Path}\\.git\\HEAD");
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