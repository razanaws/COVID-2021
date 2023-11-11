namespace Project.Models
{
    static class Account
    {
        public static string fname;
        public static string lname;
        public static string email;
        public static string id;
        public static string age;

        public static void SetData(string fname1, string lname1, string email1, string id1, string age1)
        {
            fname = fname1;
            lname = lname1;
            email = email1;
            id = id1;
            age = age1;
        }
        public static string GetId()
        {
            return id;
        }
    }
}
