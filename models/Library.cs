using System;

namespace library2
{
  public class Library
  {
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Id { get; private set; }

    public Library()
    {
      Id = Guid.NewGuid().ToString();
    }

    public Library(string title, string description, decimal price)
    {
      Title = title;
      Description = description;
      Price =  price;
      Id = Guid.NewGuid().ToString();
    }
  }
}