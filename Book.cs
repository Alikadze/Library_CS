using System;

namespace ConsoleApp1
{
  class Book
  {
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    private bool IsCheckedOut { get; set; }

    public Book(string title, string author, string isbn)
    {
      Title = title;
      Author = author;
      ISBN = isbn;
      IsCheckedOut = false;
    }

    public string GetTitle()
    {
      return Title;
    }

    public bool GetIsCheckedOut()
    {
      return IsCheckedOut;
    }

    public void Checkout()
    {
      IsCheckedOut = true;
    }

    public void ReturnBook()
    {
      IsCheckedOut = false;
    }

    public string GetISBN()
    {
      return ISBN;
    }

    public void PrintBook()
    {
      Console.WriteLine($"Title: {Title}");
      Console.WriteLine($"Author: {Author}");
      Console.WriteLine($"ISBN: {ISBN}");
      Console.WriteLine($"Status: {(IsCheckedOut ? "Checked Out" : "Available")}");
      Console.WriteLine("---------------------------------------------------------");
    }
  }
}
