using System.Collections;
using Lab08TheRemix.Interfaces;

namespace Lab08TheRemix.Classes
{
  public class Backpack<T> : IBag<T>
  {
    private List<T> BackpackStorage = new List<T>();
    public void Pack(T item)
    {
      BackpackStorage.Add(item);
    }
    public T Unpack(int index)
    {
      T itemToBeUnpacked = BackpackStorage[index];
      BackpackStorage.Remove(itemToBeUnpacked);
      // or
      // BackpackStorage.RemoveAt(index);
      return itemToBeUnpacked;
    }

    public IEnumerator<T> GetEnumerator()
    {
      foreach(T item in BackpackStorage)
        yield return item;
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }
}