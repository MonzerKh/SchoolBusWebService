using ModelsLayer.DataLayer.Core;

using System.Collections.Generic;


namespace ModelsLayer.DataLayer.Tables.Permissions
{
    public enum UserType
    {
        Admin,
        User,
        Guardin,
        Student
    }

    public class SystemUser : BaseTable
    {
        public string Full_Name { get; set; }
        public string Phone_Number { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string ImagePath  { get; set; }
        public byte[] ImageIcon { get; set; }
        public UserType UserType { get; set; }

        public ICollection<School> Schools { get; set; }
        public ICollection<Sys_UserSystem_Role> Sys_UserSystem_Roles { get; set; }
        public ICollection<BusCompany> BusCompanies { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Guardian> Guardians { get; set; }
        public ICollection<Supervisor> Supervisors { get; set; }
        public ICollection<Driver> Drivers { get; set; }
    }
}
