using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Day_2
{
    public class BorrowRecord
    {
        public int RecordId { get; set; }
        public int BookId { get; set; }
        public string BorrowerName { get; set; }
        public DateTime BorrowDate { get; set; }

        public static List<BorrowRecord> borrowRecordList = new List<BorrowRecord>();

        public BorrowRecord() { }

        public BorrowRecord(int recordId, int bookId, string borrowerName, DateTime borrowDate)
        {
            RecordId = recordId;
            BookId = bookId;
            BorrowerName = borrowerName;
            BorrowDate = borrowDate;
        }

        public static void IntializeBorrowRecord()
        {
            borrowRecordList.Add(new BorrowRecord(1, 1, "John Doe", new DateTime(2021, 1, 1)));
            borrowRecordList.Add(new BorrowRecord(2, 2, "Jane Doe", new DateTime(2021, 1, 2)));
            borrowRecordList.Add(new BorrowRecord(3, 4, "Bob", new DateTime(2021, 1, 4)));
            borrowRecordList.Add(new BorrowRecord(4, 5, "Charlie", new DateTime(2021, 1, 5)));
            borrowRecordList.Add(new BorrowRecord(5, 2, "David", new DateTime(2021, 1, 6)));
            borrowRecordList.Add(new BorrowRecord(6, 3, "Grace", new DateTime(2021, 1, 9)));
            borrowRecordList.Add(new BorrowRecord(7, 10, "Hank", new DateTime(2021, 1, 10)));
            borrowRecordList.Add(new BorrowRecord(8, 12, "Jack", new DateTime(2021, 1, 12)));
            borrowRecordList.Add(new BorrowRecord(9, 13, "Kate", new DateTime(2021, 1, 13)));
            borrowRecordList.Add(new BorrowRecord(10, 15, "Mia", new DateTime(2021, 1, 15)));
            borrowRecordList.Add(new BorrowRecord(11, 1, "Kate", new DateTime(2021, 1, 13)));
            borrowRecordList.Add(new BorrowRecord(12, 2, "Mia", new DateTime(2021, 1, 15)));
            borrowRecordList.Add(new BorrowRecord(13, 4, "Kate", new DateTime(2021, 1, 13)));
            borrowRecordList.Add(new BorrowRecord(14, 5, "Mia", new DateTime(2021, 1, 15)));
        }

        public List<BorrowRecord> GetBorrowRecords()
        {
            BorrowRecord.IntializeBorrowRecord();
            return borrowRecordList;
        }
    }
}
