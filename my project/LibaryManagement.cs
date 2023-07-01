using System;
using System.Collections.Generic;

// Book class to represent a book
class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsBorrowed { get; set; }

    public Book(int bookId, string title, string author)
    {
        BookId = bookId;
        Title = title;
        Author = author;
        IsBorrowed = false;
    }
}

// Member class to represent a library member
class Member
{
    public int MemberId { get; set; }
    public string Name { get; set; }

    public Member(int memberId, string name)
    {
        MemberId = memberId;
        Name = name;
    }
}

// Library class to manage books, members, and transactions
class Library
{
    private List<Book> books;
    private List<Member> members;
    private List<(Book, Member)> transactions;

    public Library()
    {
        books = new List<Book>();
        members = new List<Member>();
        transactions = new List<(Book, Member)>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void AddMember(Member member)
    {
        members.Add(member);
    }

    public void BorrowBook(int bookId, int memberId)
    {
        Book book = books.Find(b => b.BookId == bookId);
        Member member = members.Find(m => m.MemberId == memberId);

        if (book == null)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        if (member == null)
        {
            Console.WriteLine("Member not found.");
            return;
        }

        if (book.IsBorrowed)
        {
            Console.WriteLine("Book is already borrowed.");
            return;
        }

        book.IsBorrowed = true;
        transactions.Add((book, member));

        Console.WriteLine("Book borrowed successfully.");
    }

    public void ReturnBook(int bookId)
    {
        (Book, Member) transaction = transactions.Find(t => t.Item1.BookId == bookId);

        if (transaction.Item1 == null)
        {
            Console.WriteLine("Book not found or not borrowed.");
            return;
        }

        transaction.Item1.IsBorrowed = false;
        transactions.Remove(transaction);

        Console.WriteLine("Book returned successfully.");
    }

    public void DisplayBooks()
    {
        Console.WriteLine("Books in the library:");
        foreach (Book book in books)
        {
            Console.WriteLine($"Book ID: {book.BookId}, Title: {book.Title}, Author: {book.Author}, Is Borrowed: {(book.IsBorrowed ? "Yes" : "No")}");
        }
    }

    public void DisplayMembers()
    {
        Console.WriteLine("Library members:");
        foreach (Member member in members)
        {
            Console.WriteLine($"Member ID: {member.MemberId}, Name: {member.Name}");
        }
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        // Create a library object
        Library library = new Library();

        // Add books to the library
        library.AddBook(new Book(1, "Book 1", "Author 1"));
        library.AddBook(new Book(2, "Book 2", "Author 2"));
        library.AddBook(new Book(3, "Book 3", "Author 3"));

        // Add members to the library
        library.AddMember(new Member(1, "Member 1"));
        library.AddMember(new Member(2, "Member 2"));
        library.AddMember(new Member(3, "Member 3"));

        // Display books and members
        library.DisplayBooks();
        library.DisplayMembers();

        // Borrow a book
        library.BorrowBook(1, 1);

        // Display books after borrowing
        library.DisplayBooks();

        // Return a book
        library.ReturnBook(1);

        // Display books after returning
        library.DisplayBooks();
    }
}
