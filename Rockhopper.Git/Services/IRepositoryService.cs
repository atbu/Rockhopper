using Rockhopper.Git.Models;

namespace Rockhopper.Git.Services;

public interface IRepositoryService
{
    string GetHEAD(Repository repository);
    Branch[] GetBranches(Repository repository);
    bool CheckOutBranch(Repository repository, string branchName);
}