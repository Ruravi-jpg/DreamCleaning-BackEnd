namespace DC.WebApi.Common
{
    public class DCException : Exception
    {

        public int Code { get; set; }

        public DCException(int code, string msg) : base(msg)
        {
            Code = code;
        }

        public static void ThrowCannotCreateEntityDuplicatedData()
        {
            throw new DCException(8010, "Cannot create or update. There is another record with the same data");
        }

        public static void ThrowCannotCreateEntityDuplicatedUsername()
        {
            throw new DCException(9010, "Cannot create user, that username already exists");
        }

        public static void ThrowCannotCreateUser()
        {
            throw new DCException(5010, "Cannot create user based on your credentials");
        }

        public static void ThrowCannotEditUser()
        {
            throw new DCException(5020, "Cannot update user based on your credentials");
        }
    }
}
