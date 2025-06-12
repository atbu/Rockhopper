namespace Rockhopper.Git.Models;

public class Repository
{
    public string Path { get; set; }
    public Branch[]? Branches { get; set; }

    public Repository(string path)
    {
        Path = path;
    }
}