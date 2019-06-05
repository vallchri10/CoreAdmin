using System.Data;
using System.Data.SqlClient;

namespace CoreAdmin.Data.Utilities
{
    public static class SQLParameters
    {
        public static SqlParameter CustomerID = new SqlParameter("@CustomerID", SqlDbType.NVarChar);
        public static SqlParameter FirstName = new SqlParameter("@FirstName", SqlDbType.NVarChar);
        public static SqlParameter LastName = new SqlParameter("@LastName", SqlDbType.NVarChar);
        public static SqlParameter DateOfBirth = new SqlParameter("@DateOfBirth", SqlDbType.Date);
        public static SqlParameter Address = new SqlParameter("@Address", SqlDbType.NVarChar);
        public static SqlParameter City = new SqlParameter("@City", SqlDbType.NVarChar);
        public static SqlParameter State = new SqlParameter("@State", SqlDbType.NVarChar);
        public static SqlParameter ZipCode = new SqlParameter("@ZipCode", SqlDbType.NVarChar);
        public static SqlParameter ReturnCode = new SqlParameter("@ReturnCode", SqlDbType.Int)
        {
            Direction = ParameterDirection.Output
        };

        public static SqlParameter UserID = new SqlParameter("@UserID", SqlDbType.NVarChar);
        public static SqlParameter UserRole = new SqlParameter("@UserRole", SqlDbType.NVarChar);
        public static SqlParameter Username = new SqlParameter("@Username", SqlDbType.NVarChar);

        public static SqlParameter PasswordHash = new SqlParameter("@PasswordHash", SqlDbType.Binary);
        public static SqlParameter PasswordSalt = new SqlParameter("@PasswordSalt", SqlDbType.Binary);
    }
}