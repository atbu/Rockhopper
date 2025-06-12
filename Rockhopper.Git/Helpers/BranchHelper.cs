using System.Management.Automation;
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

    public static bool DoesBranchExist(Repository repository, string branchName)
    {
        Branch[] branches = GetBranches(repository);
        string[] branchNames = branches.Select(branch => branch.Name).ToArray();

        return branchNames.Contains(branchName);
    }

    public static void CheckOutBranch(Repository repository, string branchName)
    {
        using (PowerShell powerShell = PowerShell.Create())
        {
            powerShell.AddScript($"cd {repository.Path}");
            powerShell.AddScript($"git checkout {branchName}");

            powerShell.Invoke();
        }
    }
}