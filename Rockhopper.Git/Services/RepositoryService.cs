using System.Management.Automation;
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

    public Branch[] GetBranches(Repository repository)
    {
        string[] heads = Directory.GetFiles($"{repository.Path}\\.git\\refs\\heads");
        List<Branch> branches = new List<Branch>();
        foreach (var head in heads)
        {
            Branch branch = new Branch(repository, Path.GetFileNameWithoutExtension(head));
            branches.Add(branch);
        }
        return branches.ToArray();
    }
    
    public bool CheckOutBranch(Repository repository, string branchName)
    {
        using (PowerShell powerShell = PowerShell.Create())
        {
            powerShell.AddScript($"cd {repository.Path}");
            powerShell.AddScript($"git checkout {branchName}");

            powerShell.Invoke();
        }
        
        // Check whether branch has actually been checked out
        return GetHEAD(repository) == branchName;
    }
}