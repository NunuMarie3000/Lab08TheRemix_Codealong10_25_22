namespace Lab08TheRemix.Classes
{
  public class Book
  {
    public string Title { get; set; }
    public Author Author { get; set; }
    public int NumberOfPages { get; set; }
    public int BookNumber { get; set; }
    public Book(string title, string firstName, string lastName, int pages)
    {
      Title = title;
      Author = new Author(firstName, lastName);
      NumberOfPages = pages;
    }
  }
}