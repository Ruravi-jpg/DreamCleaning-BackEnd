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

        public static void ThrowCannotCreateAdminUser()
        {
            throw new DCException(5030, "Cannot create admin users");
        }

        public static void ThrowCannotEditUser()
        {
            throw new DCException(5020, "Cannot update user based on your credentials");
        }

        public static void ThrowCannotCreateProperty()
        {
            throw new DCException(7030, "You can´t create a property based on your credentials");
        }

        public static void ThrowCannotEditProperty()
        {
            throw new DCException(7040, "You can´t edit a property based on your credentials");
        }

        internal static void ThrowCannotSaveImageInvalidLength()
        {
            throw new DCException(4040, "Cannot upload image, invalid data");
        }

        internal static void ThrowCannotSaveImageTooLarge()
        {
            throw new DCException(4050, "Cannot upload image, it´s too large");
        }

        internal static void ThrowCannotSaveImageInvalidExtension()
        {
            throw new DCException(4060, "Cannot upload image, invalid extension");
        }

        public static void ThrowImageNotFound()
        {
            throw new DCException(4070, "image not found");
        }
    }
}
