using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Day_2
{
    public class MethodSyntax
    {
        public void ListWithBookBorrowRecords(List<Book> bookList, List<BorrowRecord> borrowRecords)
        {
            // Left Join
            var leftJoin = bookList.GroupJoin(borrowRecords,
                                    bl => bl.BookId,
                                    br => br.BookId,
                                    (bl, br) => new
                                    {
                                        BookTitle = bl.Title,
                                        Borrower = br.DefaultIfEmpty(),
                                    })
                                    .SelectMany(
                                        brleft => brleft.Borrower,
                                        (bl, brLeft) => new
                                        {
                                            BookTitle = bl.BookTitle,
                                            Borrower = brLeft?.BorrowerName ?? "No Borrower",
                                        }
                                    );

            foreach (var item in leftJoin)
            {
                Console.WriteLine($"Borrower: {item.Borrower} | Book Title: {item.BookTitle}");
            }
        }

        public void ModifyBookList(List<Book> bookList, List<BorrowRecord> borrowRecords)
        {
            // Inner Join
            var fullList = bookList.Join(borrowRecords,
                           bl => bl.BookId,
                           br => br.BookId,
                           (bl, br) => new
                           {
                               bl.BookId,
                               bl.Title,
                               bl.Genre,
                               br.BorrowerName,
                               br.BorrowDate
                           });

            foreach (var item in fullList)
            {
                Console.WriteLine($"BookId: {item.BookId} | Title: {item.Title} | Genre: {item.Genre} | Borrower: {item.BorrowerName} | Borrow Date: {item.BorrowDate}");
            }
        }

        public void CountTotalNumberOfBorrowedBooks(List<Book> bookList, List<BorrowRecord> borrowRecords)
        {
            // Perform Left Join and Group by BookId
            var totalBorrowed = bookList.GroupJoin(borrowRecords,
                                bl => bl.BookId,
                                br => br.BookId,
                                (bl, br) => new
                                {
                                    bl.Title,
                                    BorrowCount = br.Count()
                                });
            foreach (var item in totalBorrowed)
            {
                Console.WriteLine($"Book Title: {item.Title} | Borrow Count: {item.BorrowCount}");
            }
        }

        public void BookListBorrowedMoreThen3(List<Book> bookList, List<BorrowRecord> borrowRecords)
        {
            var specificList = borrowRecords
                               .GroupBy(b => b.BookId)
                               .Where(g => g.Count() >= 3)
                               .Join(bookList,
                                      g => g.Key,
                                      book => book.BookId,
                                      (g, book) => book.Title)
                               .ToList();

            foreach (var item in specificList)
            {
                Console.WriteLine($"Book Title: {item}");
            }
        }

        public void GenerateDatasetWithPairs(List<Book> bookList, List<BorrowRecord> borrowRecords)
        {
            // Cross Join
            var fullList = bookList.SelectMany(
                            br => borrowRecords,
                            (br, borrow) => new
                            {
                                BookTitle = br.Title,
                                Borrower = borrow.BorrowerName,
                                BorrowDate = borrow.BorrowDate
                            });

            foreach (var item in fullList)
            {
                Console.WriteLine($"Book Title: {item.BookTitle} | Borrower: {item.Borrower} | Borrow Date: {item.BorrowDate}");
            }
        }

        public void UniqueGenreBookList(List<Book> bookList)
        {
            var uniqueList = bookList.Select(b => b.Genre).Distinct();

            foreach (var item in uniqueList)
            {
                Console.WriteLine($"Genre: {item}");
            }
        }

        public void CombineUniqueCollection(List<Book> bookList1, List<Book> bookList2)
        {
            var combinedList = bookList1.Union(bookList2).DistinctBy(genre => genre.Genre).DistinctBy(Title => Title.Title);

            foreach (var item in combinedList)
            {
                Console.WriteLine($" Title: {item.Title}");
            }
        }

        public void GetSameBooksInBothCollections(List<Book> bookList1, List<Book> bookList2)
        {
            var sameBooks = bookList1.Intersect(bookList2);

            foreach (var item in sameBooks)
            {
                Console.WriteLine($" Title: {item.Title}");
            }
        }

        public void GetDifferentBooksInBothCollections(List<Book> bookList1, List<Book> bookList2)
        {
            // A - B
            var differentBooks1 = bookList1.Except(bookList2);
            // B - A
            var differentBooks2 = bookList2.Except(bookList1);

            Console.WriteLine("---- Books in BookList1 but not in BookList2 ----");
            foreach (var item in differentBooks1)
            {
                Console.WriteLine($" Title: {item.Title}");
            }

            Console.WriteLine("---- Books in BookList2 but not in BookList1 ----");
            foreach (var item in differentBooks2)
            {
                Console.WriteLine($" Title: {item.Title}");
            }
        }

        public void DifferenceBetweenImmediateAndDeffered(List<Book> bookList)
        {
            var immediate = bookList.Select(b => b.Title).ToList();
            var deffered = bookList.Select(b => b.Title);

            Console.WriteLine("---- Immediate Execution ----");
            // Add a new book to the list
            immediate.Add(new Book(101, "My Book", "Fiction").Title);

            foreach (var item in immediate)
            {
                Console.WriteLine($" Title: {item}");
            }

            Console.WriteLine("---- Deffered Execution ----");
            foreach (var item in deffered)
            {
                Console.WriteLine($" Title: {item}");
            }
        }
    }
}
