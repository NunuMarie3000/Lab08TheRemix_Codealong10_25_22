using Lab08TheRemix.Classes;

namespace Lab08TheRemix
{
  class Program
  {
    private static readonly Library newLibrary = new Library();
    private static readonly Backpack<Book> newBackpack = new Backpack<Book>();
    static void Main(string[] args)
    {
      // Test();
      UserInterface();
    }
    // static void Test()
    // {
    //   Library myLibrary = new Library();
    //   myLibrary.Add("Jazz", "Toni", "Morrison", 372);
    //   myLibrary.Add("Children of Blood and Bone", "Tomi", "Adeyemi", 538);
    //   myLibrary.Add("Children of Virtue and Vengeance", "Tomi", "Adeyemi", 476);

    //   myLibrary.Borrow("Jazz");
    //   Backpack<Book> myBackpack = new Backpack<Book>();
    //   myBackpack.Pack(new Book("Jazz", "Toni", "Morrison", 372));
    //   myBackpack.Unpack(0);
    //   myLibrary.Return(new Book("Jazz", "Toni", "Morrison", 372));

    //   Console.WriteLine("This is in my library");
    //   foreach(Book book in myLibrary)
    //     Console.WriteLine(book.Title);

    //   Console.WriteLine("This is in my backpack");
    //   foreach(Book book in myBackpack)
    //     Console.WriteLine(book.Title);

    //   Console.WriteLine("This is how many books are in my library");
    //   Console.WriteLine(myLibrary.Count);
    // }

    static void UserInterface()
    {
      while(true)
      {
        Console.WriteLine("Welcome to the lending library!");
        Console.WriteLine("Pick an option");

        // all options
        Console.WriteLine("1. View All Books");
        Console.WriteLine("2. Add New Book");
        Console.WriteLine("3. Borrow a book");
        Console.WriteLine("4. Return a book");
        Console.WriteLine("5. View Bookbag");
        Console.WriteLine("6. Exit");

        // answer
        string answer = Console.ReadLine();
        switch (answer)
        {
          case "1":
            Console.Clear();
            Console.WriteLine("Library\n==============");
            ViewAllBooks();
            break;
          case "2":
            Console.Clear();
            Console.WriteLine("Add new Book\n==============");
            AddANewBook();
            break;
          case "3":
            Console.Clear();
            Console.WriteLine("Borrow a book and add to bookbag\n==============");
            BorrowABook();
            break;
          case "4":
            Console.Clear();
            Console.WriteLine("Return a Book\n==============");
            ReturnABook();
            break;
          case "5":
            Console.Clear();
            Console.WriteLine("View Bookbag\n==============");
            ViewBookbag();
            break;
          case "6":
            Exit();
            return;
          default:
            break;
        }
      }
    }

    static void ViewAllBooks()
    {
      foreach(Book book in newLibrary)
        Console.WriteLine(book.Title);
    }
    static void AddANewBook()
    {
      Console.WriteLine("Book title: ");
      string title = Console.ReadLine();
      Console.WriteLine("Author first name: ");
      string fname = Console.ReadLine();
      Console.WriteLine("Author last name: ");
      string lname = Console.ReadLine();
      Console.WriteLine("Number of pages: ");
      int pages = Convert.ToInt32(Console.ReadLine());

      newLibrary.Add(title, fname, lname, pages);
      Console.WriteLine($"{title} added to the library");
    }
    static void BorrowABook()
    {
      Console.WriteLine("What book would you like to borrow?");
      string title = Console.ReadLine();
      Book bookToBorrow = newLibrary.Borrow(title);
      Console.WriteLine($"{title} borrowed from the library. Index number {newBackpack.GetEnumerator()}");
      newBackpack.Pack(bookToBorrow);
    }
    static void ReturnABook()
    {
      Console.WriteLine("What book are you returning?");
      string title = Console.ReadLine();
      Console.WriteLine("Author first name: ");
      string fname = Console.ReadLine();
      Console.WriteLine("Author last name: ");
      string lname = Console.ReadLine();
      Console.WriteLine("Number of pages: ");
      int pages = Convert.ToInt32(Console.ReadLine());

      newLibrary.Return(new Book(title, fname, lname, pages));
      // Book bookToReturn = newBackpack.Unpack();
      // newLibrary.Return(bookToReturn);

      Console.WriteLine($"{title} removed from backpack and returned to the library");
    }
    static void ViewBookbag()
    {
      Console.WriteLine("Items in your bookbag: ");
      foreach(var item in newBackpack)
        Console.WriteLine(item.Title);
    }

    static void Exit()
    {
      Console.WriteLine("Thanks for coming to the library! Have a good day");
    }

  }
}
