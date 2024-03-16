// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

// Check to see if the database exists.
//using (PubContext context = new PubContext())
//{
//    context.Database.EnsureCreated();
//}

PubContext _context = new PubContext();

//QueryFilters();
//FindIt();

//AddSomeMoreAuthors();
//SkipAndTakeAuthors();

//SortAuthors();

QueryAggregate();

void QueryAggregate()
{
    var author = _context.Authors.OrderByDescending(a => a.FirstName)
        .FirstOrDefault(a => a.LastName == "Lerman");

    // Doesn't work, have to order first before using lastordefault!
    //var auth = _context.Authors.LastOrDefault(a => a.LastName == "Lerman");
}

// DbSet.Find(keyvalue) example, finding the ID=2 result.
void FindIt()
{
    var authorIdTwo = _context.Authors.Find(2);
}

void AddSomeMoreAuthors()
{
    _context.Authors.Add(new Author { FirstName = "Rhoda", LastName = "Lerman" });
    _context.Authors.Add(new Author { FirstName = "Don", LastName = "Jones" });
    _context.Authors.Add(new Author { FirstName = "Jim", LastName = "Christopher" });
    _context.Authors.Add(new Author { FirstName = "Stephen", LastName = "Haunts" });
    _context.SaveChanges();
}

// Skip and Take example.
void SkipAndTakeAuthors()
{
    var groupSize = 2;
    for (int i = 0; i < 5; i++)
    {
        var authors = _context.Authors.Skip(groupSize * i).Take(groupSize).ToList();
        Console.WriteLine($"Group {i}:");
        foreach (var author in authors)
        {
            Console.WriteLine($" {author.FirstName} {author.LastName}");
        }
    } 
}

// OrderBy, ThenBy, OrderByDescending & ThenByDescending examples.
void SortAuthors()
{
    var authorsByLastName = _context.Authors
        .OrderBy(a => a.LastName)
        .ThenBy(a => a.FirstName).ToList();
    authorsByLastName.ForEach(a => Console.WriteLine(a.LastName + ", " + a.FirstName));

    var authorsDescending = _context.Authors
        .OrderByDescending(a => a.LastName)
        .ThenByDescending(a => a.FirstName).ToList();
        Console.WriteLine("** Descending Last and First **");
    authorsByLastName.ForEach(a => Console.WriteLine(a.LastName + ", " + a.FirstName));

    var combined = _context.Authors
        .Where(a => a.LastName == "Lerman")
        .OrderByDescending(a => a.FirstName).ToList();
    authorsByLastName.ForEach(a => Console.WriteLine(a.LastName + ", " + a.FirstName));
}

void QueryFilters()
{
    // Passing a parameter to where condition.
    //var name = "Josie";
    //var authors = _context.Authors.Where(s => s.FirstName == name).ToList();

    // Like command
    //var authors = _context.Authors
    //    .Where(a => EF.Functions.Like(a.LastName, "L%")).ToList();

    // Like command with variable
    var filter = "L%";
    var authors = _context.Authors
        .Where(a => EF.Functions.Like(a.LastName, filter)).ToList();
}

GetAuthors();
//AddAuthor();
////GetAuthors();
//AddAuthorWithBook();
//GetAuthorsWithBooks();

void AddAuthorWithBook()
{
    var author = new Author { FirstName = "Julie", LastName = "Lerman" };
    author.Books.Add(new Book
    {
        Title = "Programming Entity Framework",
        PublishDate = new DateTime(2009, 1, 1)
    });
    author.Books.Add(new Book
    {
        Title = "Programming Entity Framework 2nd Ed",
        PublishDate = new DateTime(2010, 8, 1)
    });
    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}

void GetAuthorsWithBooks()
{
    using var context = new PubContext();
    var authors = context.Authors.Include(a => a.Books).ToList();
    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
        foreach (var book in author.Books)
        {
            Console.WriteLine("*" + book.Title);
        }
    }
}

void AddAuthor()
{
    var author = new Author { FirstName = "Josie", LastName = "Newf" };
    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}

void GetAuthors()
{
    using var context = new PubContext();

    // Execution: Smarter to get results first!
    var authors = context.Authors.ToList();
    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}