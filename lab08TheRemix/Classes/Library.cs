using System;
using System.Collections;
using System.Collections.Generic;

using Lab08TheRemix.Interfaces;

namespace Lab08TheRemix.Classes
{
  class Library : ILibrary
  {
    // ILibrary implements Add(), Borrow(), Return(), as well as IReadOnlyCollection<T>
    // which implements: int Count { get; } // returns number of elements in the collection
    // IReadOnlyCollection<Book>
    //     Gets the number of elements in the collection.
    // Returns:   The number of elements in the collection.
    // It implements IEnumerable<T>, IEnumerable
    public int Count { get; set; } = 0;// included b/c IReadOnlyCollection requests it, count number of items in collection

    public IEnumerator<Book> GetEnumerator()
    {
      foreach(Book book in LibraryStorage.Values)
        yield return book;
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    // i need to be able to enumerate through Library storage, to iterate through Book objects
    private Dictionary<string, Book> LibraryStorage = new Dictionary<string, Book>();
    
    // is available whenever we use dictionary, property
    // public int Count = LibraryStorage.Count;

    public void Add(string title, string firstName, string lastName, int numberOfPages)
    {
      // create new Book
      Book newBook = new Book(title, firstName, lastName, numberOfPages);
      // add book to library storage
      LibraryStorage.Add(title.ToLower(), newBook);
      Count++;
    }

    public Book Borrow(string title)
    {
      if(LibraryStorage.ContainsKey(title.ToLower()))
      {
        Book bookToBorrow = LibraryStorage[title.ToLower()];
        LibraryStorage.Remove(title.ToLower());
        Count--;
        return bookToBorrow;
      }
      else return null;
    }

    public void Return(Book book)
    {
      LibraryStorage.Add(book.Title.ToLower(), book);
      Count++;
    }    
  }
}