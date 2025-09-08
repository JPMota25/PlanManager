using Microsoft.AspNetCore.Authorization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public sealed class PermissionAttribute : AuthorizeAttribute
{
    private const string Prefix = "action:";

    public string Key { get; }

    public PermissionAttribute(string permissionKey)
    {
        if (string.IsNullOrWhiteSpace(permissionKey))
            throw new ArgumentException("permissionKey cant be null.", nameof(permissionKey));

        Key = permissionKey.Trim();
        Policy = Prefix + Key; // ex.: "perm:tscontrol.person.edit"
    }
}