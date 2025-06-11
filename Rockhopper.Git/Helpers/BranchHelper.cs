using Rockhopper.Git.Models;

namespace Rockhopper.Git.Helpers;

public class BranchHelper
{
    public static Branch[] GetBranches(string repositoryPath)
    {
        string[] heads = Directory.GetFiles($"{repositoryPath}\\.git\\refs\\heads");

        List<Branch> branches = new List<Branch>();
        foreach (string head in heads)
        {
            Branch branch = new Branch(Path.GetFileNameWithoutExtension(head));
            branches.Add(branch);
        }

        return branches.ToArray();
    }
}