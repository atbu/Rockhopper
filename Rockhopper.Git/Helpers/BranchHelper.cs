using Rockhopper.Git.Models;

namespace Rockhopper.Git.Helpers;

public class BranchHelper
{
    public static Branch[] GetBranches(Repository repository)
    {
        string[] heads = Directory.GetFiles($"{repository.Path}\\.git\\refs\\heads");

        List<Branch> branches = new List<Branch>();
        foreach (string head in heads)
        {
            Branch branch = new Branch(repository, Path.GetFileNameWithoutExtension(head));
            branches.Add(branch);
        }

        return branches.ToArray();
    }
}