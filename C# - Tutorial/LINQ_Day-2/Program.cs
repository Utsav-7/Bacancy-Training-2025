using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Day_2
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            List<Book> bookList1 = Book.GetBookList1();
            List<Book> bookList2 = Book.GetBookList2();
            List<BorrowRecord> borrowRecordList = new BorrowRecord().GetBorrowRecords();
            MethodSyntax methodSyntax = new MethodSyntax();
            QuerySyntax querySyntax = new QuerySyntax();

            // 1. List all books and their corresponding borrow records, even if a book has never been borrowed.
            // 3. Modify the first query so that all books appear, even if no one has borrowed them.
            querySyntax.ListWithBookBorrowRecords(bookList1, borrowRecordList);
            methodSyntax.ListWithBookBorrowRecords(bookList1, borrowRecordList);
            Console.WriteLine("--------------------------------------------------------------------");

            // 2. Generate a dataset that pairs each book with every borrow record, regardless of any existing relationship.
            querySyntax.GenerateDatasetWithPairs(bookList1, borrowRecordList);
            methodSyntax.GenerateDatasetWithPairs(bookList1, borrowRecordList);
            Console.WriteLine("--------------------------------------------------------------------");

            // 4. Retrieve a list of books that have been borrowed, displaying each book’s title along with the name of the borrower. Books that have never been borrowed should not appear in the output.
            querySyntax.ModifyBookList(bookList1, borrowRecordList);
            methodSyntax.ModifyBookList(bookList1, borrowRecordList);
            Console.WriteLine("--------------------------------------------------------------------");

            // 5. Categorize all borrow records by book title, displaying the total number of times each book has been borrowed.
            querySyntax.CountTotalNumberOfBorrowedBooks(bookList1, borrowRecordList);
            methodSyntax.CountTotalNumberOfBorrowedBooks(bookList1, borrowRecordList);
            Console.WriteLine("--------------------------------------------------------------------");

            // 6. List all books that have been borrowed at least 3 times, using a nested LINQ query.
            querySyntax.BookListBorrowMoreThan3(bookList1, borrowRecordList);
            methodSyntax.BookListBorrowedMoreThen3(bookList1, borrowRecordList);
            Console.WriteLine("--------------------------------------------------------------------");

            // 7. Retrieve a list of unique genres available in the book collection.
            methodSyntax.UniqueGenreBookList(bookList1);
            Console.WriteLine("--------------------------------------------------------------------");

            // 8. Combine two book collections (from different libraries), ensuring there are no duplicate books.
            querySyntax.CombineUniqueCollection(bookList1, bookList2);
            methodSyntax.CombineUniqueCollection(bookList1, bookList2);
            Console.WriteLine("--------------------------------------------------------------------");

            // 9. Identify books that appear in both collections.
            querySyntax.GetSameBooksInBothCollections(bookList1, bookList2);
            methodSyntax.GetSameBooksInBothCollections(bookList1, bookList2);
            Console.WriteLine("--------------------------------------------------------------------");

            // 10. Find books that exist in one collection but not in the other.
            methodSyntax.GetDifferentBooksInBothCollections(bookList1, bookList2);
            Console.WriteLine("--------------------------------------------------------------------");

            // 11. Convert the query to execute immediately and compare the differences.
            querySyntax.DifferenceBetweenImmediateAndDeffered(bookList1);
            methodSyntax.DifferenceBetweenImmediateAndDeffered(bookList1);
            Console.WriteLine("--------------------------------------------------------------------");
        }
    }
}
