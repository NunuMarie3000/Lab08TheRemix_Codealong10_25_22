using System.Collections;
using Lab08TheRemix.Classes;

namespace Lab08TheRemix.Interfaces
{
  public interface ILibrary : IReadOnlyCollection<Book>
  // IReadOnlyCollection<Book>
  //     Gets the number of elements in the collection.
  // Returns:   The number of elements in the collection.
  // It implements IEnumerable<T>, IEnumerable
  {
    /// <summary>
    /// Add a Book to the library.
    /// </summary>
    void Add(string title, string firstName, string lastName, int numberOfPages);

    /// <summary>
    /// Remove a Book from the library with the given title.
    /// </summary>
    /// <returns>The Book, or null if not found.</returns>
    Book Borrow(string title);

    /// <summary>
    /// Return a Book to the library.
    /// </summary>
    void Return(Book book);
  }
}