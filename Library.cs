using System;

namespace ConsoleApp1
{
  class Library
  {
    private int CurrentBookCount = 0;
    private int CurrentMemberCount = 0;
    private const int MaxBooks = 100;
    private const int MaxMembers = 100;
    private readonly Book[] Books = new Book[MaxBooks];
    private readonly Member[] Members = new Member[MaxMembers];

    public void AddBook(Book book)
    {
      if (CurrentBookCount >= MaxBooks)
      {
        Console.WriteLine("Library is full");
        return;
      }

      Books[CurrentBookCount] = book;
      Console.WriteLine($"Book '{book.Title}' added successfully.");
      CurrentBookCount++;
    }

    public void RegisterMember(Member member)
    {
      if (CurrentMemberCount >= MaxMembers)
      {
        Console.WriteLine("Library is full");
        return;
      }

      // Check if the member is already registered
      if (IsMemberRegistered(member.GetMemberID()))
      {
        Console.WriteLine($"Member with ID {member.GetMemberID()} is already registered.");
        return;
      }

      Members[CurrentMemberCount] = member;
      CurrentMemberCount++;
      Console.WriteLine($"Member '{member.Name}' registered successfully.");
    }

    // Method to check if a member is already registered
    private bool IsMemberRegistered(int memberId)
    {
      for (int i = 0; i < CurrentMemberCount; i++)
      {
        if (Members[i].GetMemberID() == memberId)
        {
          return true;
        }
      }
      return false;
    }

    public void CheckoutBook(int memberId, string isbn)
    {
      Book? book = GetBookByISBN(isbn);
      if (book != null)
      {
        Member? member = GetMemberByID(memberId);
        if (member != null)
        {
          member.CheckoutBook(book);
        }
        else
        {
          Console.WriteLine($"Member with ID {memberId} not found.");
        }
      }
      else
      {
        Console.WriteLine($"Book with ISBN {isbn} not found.");
      }
    }

    public Book? GetBookByISBN(string isbn)
    {
      foreach (Book book in Books)
      {
        if (book != null && book.GetISBN() == isbn)
        {
          return book;
        }
      }
      return null;
    }

    public void PrintCheckedOutBooks(int memberId)
    {
      Member? member = GetMemberByID(memberId);
      if (member != null)
      {
        member.PrintCheckedOutBooks();
      }
      else
      {
        Console.WriteLine($"Member with ID {memberId} not found.");
      }
    }

    public void ReturnBook(int memberId, string isbn)
    {
      Book? book = GetBookByISBN(isbn);
      if (book != null)
      {
        Member? member = GetMemberByID(memberId);
        if (member != null)
        {
          member.ReturnBook(book);
        }
        else
        {
          Console.WriteLine($"Member with ID {memberId} not found.");
        }
      }
      else
      {
        Console.WriteLine($"Book with ISBN {isbn} not found.");
      }
    }

    // Method to get a member by their ID
    private Member? GetMemberByID(int memberId)
    {
      foreach (Member member in Members)
      {
        if (member != null && member.GetMemberID() == memberId)
        {
          return member;
        }
      }
      return null;
    }
  }
}
