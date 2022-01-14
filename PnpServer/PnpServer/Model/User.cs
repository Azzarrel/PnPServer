namespace PnpServer.Model
{
    public class User
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public string Guid { get; set; }

        public User()
        {

        }

        public User(int iD, string name, string password, string guid)
        {
            ID = iD;
            Name = name;
            Password = password;
            Guid = guid;
        }


    }
}
