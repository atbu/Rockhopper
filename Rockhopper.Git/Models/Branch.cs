namespace Rockhopper.Git.Models;

public class Branch
{
    public Repository Repository { get; set; }
    public string Name { get; set; }

    public Branch(Repository repository, string name)
    {
        Repository = repository;
        Name = name;
    }
}