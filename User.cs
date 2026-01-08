class User
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string FullName => $"{FirstName} {LastName}";
    public DateOnly DateOfBirth { get; set; }

    public int Age
    {
        get
        {
            DateTime today = DateTime.Now;
            int age = today.Year - DateOfBirth.Year - (today.DayOfYear < DateOfBirth.DayOfYear ? 1 : 0);
            return age;
        }
    }

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
                DateOfBirth = new DateOnly(
                    Faker.RandomNumber.Next(1960, 2001),
                    Faker.RandomNumber.Next(1, 12),
                    Faker.RandomNumber.Next(1, 28)
                ),
                Country = Faker.Address.Country(),
                DataStored = Faker.RandomNumber.Next(100, 9999999),
                Email = Faker.Internet.Email(),
                LastLogin = DateTime.Now - TimeSpan.FromDays(Faker.RandomNumber.Next(1, 365),
                                                             Faker.RandomNumber.Next(0, 24),
                                                             Faker.RandomNumber.Next(0, 60),
                                                             Faker.RandomNumber.Next(0, 60))
            });
        }

        return users;
    }
}