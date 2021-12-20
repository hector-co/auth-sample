namespace Shared.Auth
{
    public interface ISessionInfo
    {
        bool IsAuthenticated { get; }
        IEnumerable<string> Roles { get; }
        string UserId { get; }
        string UserName { get; }
        string Name { get; }
        string LastName { get; }
        string FullName { get; }
        string Email { get; }
        bool HasRole(string role);
        bool HasAdministratorRole();
    }
}