using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Day_2
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }

        public static List<Book> bookList1 = new List<Book>();
        public static List<Book> bookList2 = new List<Book>();

        public Book() { }
        public Book(int bookId, string title, string genre)
        {
            BookId = bookId;
            Title = title;
            Genre = genre;
        }

        public static void Library1()
        {
            bookList1.Add(new Book(1, "Atomic Habit","Self-Help"));
            bookList1.Add(new Book(2, "The Alchemist", "Fiction"));
            bookList1.Add(new Book(3, "The Lean Startup", "Business"));
            bookList1.Add(new Book(4, "The 7 Habits of Highly Effective People", "Self-Help"));
            bookList1.Add(new Book(5, "The Subtle Art of Not Giving a F*ck", "Self-Help"));
            bookList1.Add(new Book(6, "The Da Vinci Code", "Fiction"));
            bookList1.Add(new Book(7, "Wings of Fire", "Autobiography"));
            bookList1.Add(new Book(8, "Rich Dad Poor Dad", "Business"));
            bookList1.Add(new Book(9, "Thinking, Fast and Slow", "Psychology"));
            bookList1.Add(new Book(10, "To Kill a Mockingbird", "Fiction"));
            bookList1.Add(new Book(11, "Sapiens: A Brief History of Humankind", "History"));
            bookList1.Add(new Book(12, "The Power of Habit", "Self-Help"));
            bookList1.Add(new Book(13, "Zero to One", "Business"));
            bookList1.Add(new Book(14, "The Catcher in the Rye", "Fiction"));
            bookList1.Add(new Book(15, "Man's Search for Meaning", "Philosophy"));
        }

        public static void Library2()
        {
            // Repeated Books from bookList1
            bookList2.Add(new Book(1, "Atomic Habit", "Self-Help"));
            bookList2.Add(new Book(2, "The 7 Habits of Highly Effective People", "Self-Help"));
            bookList2.Add(new Book(3, "The Da Vinci Code", "Fiction"));
            bookList2.Add(new Book(4, "Thinking, Fast and Slow", "Psychology"));
            bookList2.Add(new Book(5, "Zero to One", "Business"));
            bookList2.Add(new Book(6, "Meditations", "Philosophy"));
            bookList2.Add(new Book(7, "The Art of War", "Strategy"));
            bookList2.Add(new Book(8, "1984", "Dystopian"));
            bookList2.Add(new Book(9, "Brave New World", "Dystopian"));
            bookList2.Add(new Book(10, "The Hobbit", "Fantasy"));
            bookList2.Add(new Book(11, "A Brief History of Time", "Science"));
            bookList2.Add(new Book(12, "Crime and Punishment", "Classic"));
            bookList2.Add(new Book(13, "The Great Gatsby", "Classic"));
            bookList2.Add(new Book(14, "Harry Potter and the Sorcerer's Stone", "Fantasy"));
            bookList2.Add(new Book(15, "The Road", "Post-Apocalyptic"));
        }

        public static List<Book> GetBookList1()
        {
            Book.Library1();
            return bookList1;
        }

        public static List<Book> GetBookList2()
        {
            Book.Library2();
            return bookList2;
        }
    }
}
