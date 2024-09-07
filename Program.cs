using System;

namespace ConsoleApp1
{
  class Program
  {
    static void Main(string[] args)
    {
      Book book1 = new("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565");
      Book book2 = new("To Kill a Mockingbird", "Harper Lee", "9780061120084");
      Book book3 = new("1984", "George Orwell", "9780451524935");
      Book book4 = new("Animal Farm", "George Orwell", "9780451526345");

      Member member1 = new("John Doe", 0);
      Member member2 = new("Jane Smith", 1);
      Member member3 = new("Alice Johnson", 10);

      Library library = new();

      library.AddBook(book1);
      library.AddBook(book2);
      library.AddBook(book3);
      library.AddBook(book4);

      library.RegisterMember(member3);
      library.RegisterMember(member3);

      library.CheckoutBook(10, "9780743273565");
      library.CheckoutBook(10, "9780061120084");
      library.CheckoutBook(10, "9780451524935");
      
      library.ReturnBook(10, "9780743273565");

      library.CheckoutBook(10, "9780451526345");

      Console.ReadLine();
    }
  }
}
