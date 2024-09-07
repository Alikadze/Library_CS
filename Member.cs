using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
  class Member(string name, int memberID)
    {
        public string Name { get; private set; } = name;
        public int MemberID { get; private set; } = memberID;
        private const int MaxBooks = 3;
    private readonly List<Book> CheckedOutBooks = new List<Book>();

        public int GetMemberID()
    {
      return MemberID;
    }

    public void CheckoutBook(Book book)
    {
      if (CheckedOutBooks.Count >= MaxBooks)
      {
        Console.WriteLine($"{Name} has reached the maximum number of checked out books ({MaxBooks}).");
        return;
      }
      if (book.GetIsCheckedOut())
      {
        Console.WriteLine($"The book '{book.GetTitle()}' is already checked out.");
        return;
      }

      book.Checkout();
      CheckedOutBooks.Add(book);
      Console.WriteLine($"✓ '{book.GetTitle()}' has been successfully checked out by {Name}.");
    }

    public void ReturnBook(Book book)
    {
      if (CheckedOutBooks.Remove(book))
      {
        book.ReturnBook();
        Console.WriteLine($"✓ '{book.GetTitle()}' has been successfully returned by {Name}.");
      }
      else
      {
        Console.WriteLine($"✗ '{book.GetTitle()}' was not found in {Name}'s checked out books.");
      }
    }

    public void PrintCheckedOutBooks()
    {
      Console.WriteLine($"----- Books Checked Out by {Name} (ID: {MemberID}) -----");
      if (CheckedOutBooks.Count == 0)
      {
        Console.WriteLine("No books currently checked out.");
      }
      else
      {
        foreach (Book book in CheckedOutBooks)
        {
          book.PrintBook();
        }
      }
      Console.WriteLine("---------------------------------------------------------");
    }
  }
}
