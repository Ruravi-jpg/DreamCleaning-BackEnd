namespace DC.WebApi.Api.Services
{
    public class CleanNames
    {
        /// <summary>
        /// This functions converts the fist letter of the passed string to upper and the rest to lower
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string CleanName(string name)
        {
            return String.Concat(name[0].ToString().ToUpper(), name.Substring(1).ToLower());
        }
    }
}
