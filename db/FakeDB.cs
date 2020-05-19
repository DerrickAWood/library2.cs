using System.Collections.Generic;

namespace library2
{
  public static class FakeDB
  {
    public static List<Library> Librarys = new List<Library>()
    {
      new Library("this book 1", "good read", 5.00m),
      new Library("this book 2", "really good read", 6.00m),
      new Library("this book 3", "super good read", 7.00m)
    };
  }
}