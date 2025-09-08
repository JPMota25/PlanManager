namespace PlanManager.Domain.Entities.Utils;

public class SystemConfiguration
{
    private void SetEachPlanHasAKey(bool eachPlanPermissionHasAKey)
    {
        EachPlanPermissionHasAKey = eachPlanPermissionHasAKey;
    }
    public bool EachPlanPermissionHasAKey { get; private set; }

    private void SetPlanPermissionTokenExpirationInDays(int planPermissionTokenExpirationInDays)
    {
        PlanPermissionTokenExpirationInDays = planPermissionTokenExpirationInDays;
    }
    public int PlanPermissionTokenExpirationInDays { get; private set; }
}