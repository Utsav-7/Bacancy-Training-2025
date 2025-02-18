using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Day_2
{
    public class QuerySyntax
    {
        public void ListWithBookBorrowRecords(List<Book> books, List<BorrowRecord> borrowRecords)
        {
            // Left Join
            var leftJoin = from book in books
                           join records in borrowRecords on book.BookId equals records.BookId into recordGroup
                           from newRecords in recordGroup.DefaultIfEmpty() // also contain if null value is present
                           select new
                           {
                               BookTitle = book.Title,
                               Borrower = newRecords?.BorrowerName ?? "No borrower",
                           };
            foreach (var record in leftJoin)
            {
                Console.WriteLine($"Book Title: {record.BookTitle} | Borrower: {record.Borrower}");
            }
        }

        public void GenerateDatasetWithPairs(List<Book> books, List<BorrowRecord> borrowRecords)
        {
            // Cross Join
            var fullRecords = from book in books
                              from record in borrowRecords
                              select new
                              {
                                  BookTitle = book.Title,
                                  BookGenre = book.Genre,
                                  Borrower = record.BorrowerName,
                              };

            foreach (var record in fullRecords)
            {
                Console.WriteLine($"Book Title: {record.BookTitle} | Book Genre: {record.BookGenre} | Borrower: {record.Borrower}");
            }
        }

        public void ModifyBookList(List<Book> books, List<BorrowRecord> borrowRecords)
        {
            // Inner Join
            var innerJoin = from book in books
                            join record in borrowRecords
                            on book.BookId equals record.BookId into newRecords
                            from record in newRecords 
                            select new
                            {
                                BookTitle = book.Title,
                                BookGenre = book.Genre,
                                Borrower = record.BorrowerName,
                                BorrowDate = record.BorrowDate,
                            };

            foreach (var record in innerJoin)
            {
                Console.WriteLine($"Book Title: {record.BookTitle} | Book Genre: {record.BookGenre} | Borrower: {record.Borrower} | Borrow Date: {record.BorrowDate}");
            }
        }

        public void CountTotalNumberOfBorrowedBooks(List<Book> books, List<BorrowRecord> borrowRecords)
        {
            var totalBorrowed = from book in books
                                join record in borrowRecords
                                on book.BookId equals record.BookId
                                group book by book.Title into bookGroup
                                select new
                                {
                                    BookTitle = bookGroup.Key,
                                    BorrowCount = bookGroup.Count(),
                                };

            foreach (var record in totalBorrowed)
            {
                Console.WriteLine($"Book Title: {record.BookTitle} | Borrow Count: {record.BorrowCount}");
            }
        }
        public void BookListBorrowMoreThan3(List<Book> books, List<BorrowRecord> borrowRecords)
        {
            var specificList = from book in books
                               join record in borrowRecords
                               on book.BookId equals record.BookId
                               group book by book.Title into bookGroup
                               where bookGroup.Count() >= 3
                               select new
                               {
                                   BookCount = bookGroup.Count(),
                                   BookTitle = bookGroup.Key,
                               };
            foreach (var item in specificList)
            {
                Console.WriteLine($"Book Title: {item.BookTitle} | Count: {item.BookCount}");
            }
        }

        public void CombineUniqueCollection(List<Book> books1, List<Book> books2)
        {
            var combinedList = (from book1 in books1
                               join book2 in books2
                               on book1.BookId equals book2.BookId
                               into bookGroup
                               select new
                               {
                                   Title = book1.Title,
                               }).Distinct();

            foreach (var book in combinedList)
            {
                Console.WriteLine($"Book Title: {book.Title}");
            }
        }

        public void GetSameBooksInBothCollections(List<Book> books1, List<Book> books2)
        {
            // Join based on Book Title
            var sameBooks = (from book1 in books1
                            join book2 in books2
                            on book1.BookId equals book2.BookId into bookList
                            select new
                            {
                                Title = book1.Title,
                            }).ToList();
            foreach(var book in sameBooks)
            {
                Console.WriteLine($"Book Title: {book.Title}");
            }
        }

        public void DifferenceBetweenImmediateAndDeffered(List<Book> books)
        {
            var immediate = (from book in books
                             select book).ToList();
            immediate.Add(new Book(101, "My New Book", "Self-Help"));

            Console.WriteLine("----- Immediate Execution -----");
            foreach (var book in immediate)
            {
                Console.WriteLine($"Book Title: {book.Title}");
            }

            var deffered = from book in books
                           select book;
            //deffered.Add(new Book(102, "My New Book 2", "Fiction")); compilation error

            Console.WriteLine("----- Deffered Execution -----");
            foreach (var book in deffered)
            {
                Console.WriteLine($"Book Title: {book.Title}");
            }
        }
    }
}
