using System.Data;
using System.Data.SqlClient;

namespace CorePractice.Data
{
    public static class SQLParameters
    {
        public static SqlParameter CustomerID = new SqlParameter("@CustomerID", SqlDbType.NVarChar);
        public static SqlParameter FirstName = new SqlParameter("@FirstName", SqlDbType.NVarChar);
        public static SqlParameter LastName = new SqlParameter("@LastName", SqlDbType.NVarChar);
        public static SqlParameter DateOfBirth = new SqlParameter("@DateOfBirth", SqlDbType.DateTime2);
        public static SqlParameter Address = new SqlParameter("@Address", SqlDbType.NVarChar);

        public static SqlParameter ReturnCode = new SqlParameter("@ReturnCode", SqlDbType.Int)
        {
            Direction = ParameterDirection.Output
        };
    }
}