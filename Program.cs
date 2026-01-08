//LINQ-ÖVNINGAR

// Vi börjar med att skapa en lista med användare som innehåller 1000 slumpmässigt genererade användare.
// Vi kommer använda denna lista för att utföra LINQ-övningar på dem.
// Titta i User.cs för att se hur User-klassen är uppbyggd och vilka properties den har.

List<User> allUsers = User.GetRandomListOfUsers(10000);


// FILTERING

// 1a. Använd Where() för att sortera ut alla användare i listan som kommer från exempelvis "Sweden".

var userInSweden = allUsers.Where( user=> user.Country == "Sweden").ToList();


// 1b. Skriv ut dem i konsolen med allUsers.Foreach(). Fortsätt skriva ut resultatet på liknande säät
// i kommande övningar också.

//userInSweden.ForEach(user=> Console.WriteLine(user.FullName + " Country är :"+ user.Country));

// 2. Använd Where() för att hitta alla användare vars efternamn börjar på "S".
var userNameStartWithS =allUsers.Where(n => n.LastName.StartsWith("S")).ToList();

//userNameStartWithS.ForEach( n => Console.WriteLine(n.LastName));

// 2b. Bland dem, använd Where() för att hitta alla användare som loggat in den senaste veckan. Skriv ut dem i konsolen.
var userInLastWeek = allUsers.Where(LastWeek => LastWeek.LastLogin >= DateTime.Now.AddDays(-7)).ToList();

userInLastWeek.ForEach(LastWeek =>Console.WriteLine("Användare name: " + LastWeek.FullName + " som har loggat in "+ LastWeek.LastLogin));



// SORTING

// 3. Ta ut alla användare över 65 år och använd OrderBy() för att sortera användarna i listan efter deras förnamn.
// Tänk på hur du kan räkna ut åldern med hjälp av DateOfBirth.

// 4. Använd OrderByDescending() och FirstOrDefault() för att hitta den användare som har mest DataStored.

// 5. Använd OrderBy() och ThenBy() för att sortera användare efter land och sedan efter efternamn.


// PROJECTION:

// 6. Använd Select() för att skapa en ny lista innehållandes bara användarnas email.

// 7. Använd Select() för att skapa en lista av anonyma objekt med FirstName och Email.
// LITE EXTRA KLURIG KANSKE! Hoppa över om du inte vet vad som menas. (Vad är ens anonyma objekt liksom?)

// 8. Använd Where() och Select() för att få en lista med e-postadresser från användare som har lagrat mer än 5000 MB.


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


// 22. Använd Select() och Aggregate() för att sammanfoga alla användares fullständiga namn till en enda sträng.


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
//Använd dig av så mkt LINQ som möjligt, ex empelvis GroupBy(), Select(), OrderByDescending() och FirstOrDefault().


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