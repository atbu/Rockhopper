namespace Rockhopper.Git.Models;

public class Repository
{
    public string Path { get; set; }
    public string RootFolderName { get; set; }
    public string HEAD { get; set; }
    public Branch[] Branches { get; set; }

    public Repository(string path)
    {
        Path = path;
        RootFolderName = System.IO.Path.GetDirectoryName(path) ?? string.Empty;
        HEAD = "";
        Branches = [];
    }
}