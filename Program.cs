//LINQ-ÖVNINGAR

// Vi börjar med att skapa en lista med användare som innehåller 1000 slumpmässigt genererade användare.
// Vi kommer använda denna lista för att utföra LINQ-övningar på dem.
// Titta i User.cs för att se hur User-klassen är uppbyggd och vilka properties den har.

List<User> allUsers = User.GetRandomListOfUsers(10000);

//Använd linq för att spara användarlistnan i en csv-fil
string csvPath = "users.csv";
var csvLines = allUsers.Select(user =>
    $"{user.FirstName},{user.LastName},{user.DateOfBirth},{user.LastLogin},{user.Country},{user.DataStored},{user.Email}"
);
File.WriteAllLines(csvPath, csvLines);

//Ladda in användare från csv-filen igen
var loadedCsvLines = File.ReadAllLines(csvPath);
List<User> usersFromCsv = loadedCsvLines.Select(line =>
{
    var parts = line.Split(',');
    return new User()
    {
        FirstName = parts[0],
        LastName = parts[1],
        DateOfBirth = DateOnly.Parse(parts[2]),
        LastLogin = DateTime.Parse(parts[3]),
        Country = parts[4],
        DataStored = int.Parse(parts[5]),
        Email = parts[6]
    };
}).ToList();

// FILTERING

// 1a. Använd Where() för att sortera ut alla användare i listan som kommer från exempelvis "Sweden".
List<User> usersFromSweden = allUsers.Where(user => user.Country == "Sweden").ToList();

// 1b. Skriv ut dem i konsolen med allUsers.Foreach(). Fortsätt skriva ut resultatet på liknande säät
// i kommande övningar också.
usersFromSweden.ForEach(user =>
    Console.WriteLine($"{user.FullName}, {user.Country}, {user.Email}")
);

// 2. Använd Where() för att hitta alla användare vars efternamn börjar på "S".
List<User> usersWithLastNameS = allUsers
    .Where(user => user.LastName.StartsWith("B"))
    .ToList();


// 2b. Använd Where() för att hitta alla användare som loggat in den senaste veckan. Skriv ut dem i konsolen.
DateTime oneWeekAgo = DateTime.Now - TimeSpan.FromDays(7);
usersWithLastNameS
    .Where(user => user.LastLogin >= oneWeekAgo)
    .ToList().ForEach(user =>
    Console.WriteLine($"{user.FullName}, Last Login: {user.LastLogin}"));


// SORTING

// 3. Ta ut alla användare över 65 år och använd OrderBy() för att sortera användarna i listan efter deras förnamn.
// Tänk på hur du kan räkna ut åldern med hjälp av DateOfBirth.
DateTime today = DateTime.Now;
allUsers
    .Where(user => user.Age > 65)
    .OrderBy(user => user.FirstName)
    .ToList().ForEach(user =>
    Console.WriteLine($"{user.FullName}, Age: {user.Age}"));



// 4. Använd OrderByDescending() och FirstOrDefault() för att hitta den användare som har mest DataStored.


// 5. Använd OrderBy() och ThenBy() för att sortera användare efter land och sedan efter efternamn.


// PROJECTION:

// 6. Använd Select() för att skapa en ny lista innehållandes bara användarnas email.


// 7. Använd Select() för att skapa en lista av anonyma objekt med FirstName och Email.
// LITE EXTRA KLURIG KANSKE! Hoppa över om du inte känner dig redo. (Vad är ens anonyma objekt liksom?)


// 8. Använd Where() och Select() för att få en lista med e-postadresser från användare som har lagrat mer än 5000 dataenheter.


// QUANTIFIERS

// 9. Använd Any() för att kontrollera om det finns någon användare från "USA".
// bool hasUsersFromUSA = SKRIV NÅTT HÄR

// 10. Använd All() för att kontrollera om alla användare har en giltig e-postadress (innehåller '@').


// 11. Använd Select() och Contains() för att kontrollera om det finns någon användare med förnamnet "Anna".
// 11b. Detta är inte jättebra rent minnes- och prestandamässigt. Varför inte tror du och vad skulle ett 
// bättre alternativ vara?


// SET OPERATIONS (Här bara med Distinct(), inte Union, Intersect eller Except)

// 12. Ta fram en lista på alla unika länder som våra användare kommer från.
// Tips: Använd först Select() för att göra en ny lista med bara länder. Använd sen Distinct().
var uniqueCountries = allUsers
    .Select(user => user.Country)
    .Distinct()
    .ToList();


// ELEMENTS

// 13. Använd FirstOrDefault() för att hitta den första användaren med ett specifikt efternamn.


// CONVERSION:

// 14. Använd ToDictionary() för att skapa en dictionary där nyckeln är användarens e-post och värdet är deras fullständiga namn.


// AGGREGERING

// 16. Använd Max() för att hitta det högsta värdet av DataStored.


// 17. Använd Min() för att hitta den lägsta åldern bland användarna


// 18. Använd Count() för att räkna hur många användare som har den lägsta åldern, kontra hur många det är som har den högsta åldern.


// 19. Använd Sum() för att beräkna den totala mängden lagrad data av alla användare.


// 20. Använd Average() för att beräkna den genomsnittliga mängden lagrad data.


// 21. Använd Aggregate() för att beräkna den totala mängden lagrad data av alla användare (int).
// Tips: Aggregate använder sig av en Func<int, int, int> där det första int är ackumulatorn och det andra är värdet från varje element i listan och den sista inten är det som returneras och blir den nya ackumulatorn.
var totalDataStored = allUsers
    .Sum(user => user.DataStored);


// 22. Använd Select() och Aggregate() för att sammanfoga alla användares fullständiga namn till en enda sträng.
var allNames = allUsers
    .Select(user => user.FullName)
    .Aggregate((current, next) => current + ", " + next);


// PARTITIONING

// 23. Använd Take() för att ta de första 10 användarna i listan.


// 24. Använd Skip() för att hoppa över de första 990 användarna i listan.


// 25. Använd TakeWhile() för att ta alla användare tills en användare med mindre än 10000 DataStored dyker upp.


// 26. Använd SkipWhile() för att hoppa över alla användare tills en användare med mindre än 10000 DataStored dyker upp.


// GROUPING

// 27. Använd GroupBy() och Count() för att räkna antalet användare per land.


// GROUPING PROJECTION SORTING  

// 28. Hur kan du ta reda på vilket land som har användare med högst totala DataStored?
//Alltså, räkna ihop den totala DataStored per land och skriv ut det land som ligger högst.
//Använd dig av så mkt LINQ som möjligt, ex Sum() och Max().  (Hint: Select() behövs också...)


// STOR DATAKÄLLA!

// 29. Använda LINQ på ännu större datakällor
// Läs in textfilen pg46.txt
// Hur kan du använda LINQ för att analysera den? Exempelvis:
// - Hur många ord finns det i texten?
// - Hur många ord börjar på bokstaven "a"?
// - Vilket är det vanligaste ordet?
// - Hur många ord är längre än 10 tecken?
// - Hur många ord är unika? (Hint: Distinct() )
// - Hur många ord förekommer mer än 10 gånger? (Hint: GroupBy() )
// - Vilka ord förekommer endast en gång?

// En annan övning: Återskapa detta med hjälp av LINQ: 
// https://lmnt.me/blog/the-most-mario-colors.html
// Börja med att skapa den grundläggande strukturen med all data, 
// Ta sedan ut de olika sorteringarna bloggen gör.