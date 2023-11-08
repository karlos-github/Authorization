using AuthorizationStudio9.Model;

namespace AuthorizationStudio9.Repository
{
    public interface IUserRoleRepository
    {
        IEnumerable<UserRole> GetAllUserRoles();
        void InsertNewUserRole(UserRole userRole);
        void UpdateUserRole(UserRole userRole);
        void DeleteUserRole(int id);
    }
}
