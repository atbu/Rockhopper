namespace Rockhopper.Git.Models;

public class Branch
{
    public string Name { get; set; }

    public Branch(string name)
    {
        Name = name;
    }
}