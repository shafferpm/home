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
//QueryAggregate();
//InsertAuthor();
//RetrieveAndUpdateAuthor();
//RetrieveAndUpdateMultipleAuthors();
//VariousOperations();
//CoordinatedRetrieveAndUpdateAuthor();
//DeleteAnAuthor();
//InsertMultipleAuthors();
//InsertMultipleAuthors2();
BulkAddUpdate();

void BulkAddUpdate()
{
    var newAuthors = new Author[]
    {
        new Author{ FirstName = "Tsitsi", LastName = "Dangarembga" },
        new Author{ FirstName = "Lisa", LastName = "See" },
        new Author{ FirstName = "Zhang", LastName = "Ling" },
        new Author{ FirstName = "Marilynne", LastName = "Robinson" }
    };

    _context.Authors.AddRange(newAuthors);
    var book = _context.Books.Find(2);
    book.Title = "Programming Entity Framework 2nd Edition";
    _context.SaveChanges();
}

void InsertMultipleAuthorsPassedIn(List<Author> listOfAuthors)
{
    _context.Authors.AddRange(listOfAuthors);
    _context.SaveChanges();
}

void InsertMultipleAuthors2()
{
    var authorList = new Author[]{
        new Author { FirstName = "Ruth", LastName = "Ozeki" },
        new Author { FirstName = "Sofia", LastName = "Segovia" },
        new Author { FirstName = "Ursula", LastName = "LeGuin" },
        new Author { FirstName = "Hugh", LastName = "Howey" },
        new Author { FirstName = "Isabelle", LastName = "Allende" }
    };

    _context.AddRange(authorList);
    _context.SaveChanges();
}

// AddRange example
void InsertMultipleAuthors()
{
    _context.Authors.AddRange(new Author { FirstName = "Ruth", LastName = "Ozeki" },
                              new Author { FirstName = "Sofia", LastName = "Segovia" },
                              new Author { FirstName = "Ursula", LastName = "LeGuin" },
                              new Author { FirstName = "Hugh", LastName = "Howey" },
                              new Author { FirstName = "Isabelle", LastName = "Allende"});    
    _context.SaveChanges();
}

void DeleteAnAuthor()
{
    var extraJL = _context.Authors.Find(1);
    if (extraJL != null)
    {
        _context.Authors.Remove(extraJL);   // Remove method triggers the state of the author to changed
        _context.SaveChanges();
    }
}

void CoordinatedRetrieveAndUpdateAuthor()
{
    var author = FindThatAuthor(3); // nothing is tracking the changes to the author because a using statement was used in the SaveThatAuthor method!
    if (author?.FirstName == "Julie")
    {
        author.FirstName = "Julia";
        SaveThatAuthor(author);
    }
}

void SaveThatAuthor(Author author)
{
    using var anotherShortLivedContext = new PubContext();  // This PubContext instance knows nothing about the history of the parameter author object!

    // Every field in the author object is updated, because it doesn't know about the history of the object, no changetracker.
    anotherShortLivedContext.Authors.Update(author);    // Update statement sets the state of the author object to modified.
    anotherShortLivedContext.SaveChanges();
}

Author FindThatAuthor(int authorId)
{
    using var shortLivedContext = new PubContext(); // PubContext() is shortlived, gets disposed because of the using statement.
    return shortLivedContext.Authors.Find(authorId);
}

void VariousOperations()
{
    var author = _context.Authors.Find(2); // this is currently Josie Newf
    author.LastName = "Newfoundland";
    var newauthor = new Author { LastName = "Appleman", FirstName = "Dan" };
    _context.Authors.Add(newauthor);
    _context.SaveChanges();
}

void RetrieveAndUpdateMultipleAuthors()
{
    var LermanAuthors = _context.Authors.Where(a => a.LastName == "Lehrman").ToList();
    foreach (var la in LermanAuthors)
    {
        la.LastName = "Lerman";
    }

    Console.WriteLine("Before" + _context.ChangeTracker.DebugView.ShortView);
    _context.ChangeTracker.DetectChanges();
    Console.WriteLine("After" + _context.ChangeTracker.DebugView.ShortView);

    _context.SaveChanges();
}

void RetrieveAndUpdateAuthor()
{
    var author = _context.Authors.FirstOrDefault(a => a.FirstName == "Julie" && a.LastName == "Lerman");
    if (author != null)
    {
        author.FirstName = "Julia";
        _context.SaveChanges();
    }
}

// Inserting an Author object directly using DbContext, and not declaring the object (ex. var author = _context.Authors.Add( new Author ...);
void InsertAuthor()
{
    var author = new Author { FirstName = "Frank", LastName = "Herbert" };
    _context.Authors.Add(author);
    _context.SaveChanges();
}

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

//GetAuthors();
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