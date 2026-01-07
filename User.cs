class User
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string FullName => $"{FirstName} {LastName}";
    public DateTime DateOfBirth { get; set; }
    public DateTime LastLogin { get; set; }
    public string Country { get; set; } = "";
    public int DataStored { get; set; } //Syftar till mängden data användaren har lagrat i MB i en tänkt onlinetjänst.
    public string Email { get; set; } = "";

    public static List<User> GetRandomListOfUsers(int amount = 100)
    {
        List<User> users = new();

        for (int i = 0; i < amount; i++)
        {
            users.Add(new User()
            {
                FirstName = Faker.Name.First(),
                LastName = Faker.Name.Last(),
                DateOfBirth = Faker.Identification.DateOfBirth(),
                Country = Faker.Address.Country(),
                DataStored = Faker.RandomNumber.Next(100, 9999999),
                Email = Faker.Internet.Email(),
                LastLogin = DateTime.Now - TimeSpan.FromDays(Faker.RandomNumber.Next(1, 365))
            });
        }

        return users;
    }
}