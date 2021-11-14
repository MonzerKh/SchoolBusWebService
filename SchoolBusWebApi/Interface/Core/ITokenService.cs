using ModelsLayer.DataLayer.Tables.Permissions;

namespace SchoolBusWebApi.Interface
{
    public interface ITokenService
    {
        string CreateToken(SystemUser user);
    }
}
