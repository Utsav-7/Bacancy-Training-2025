CREATE TABLE Student (
	id INT PRIMARY KEY,
	name VARCHAR(50),
	age INT,
	class INT,
	city VARCHAR(50)
);

CREATE TABLE Class (
    class_id INT PRIMARY KEY, 
    class_name VARCHAR(50) NOT NULL, 
    section CHAR(1) CHECK (section IN ('A', 'B', 'C', 'D')), 
    teacher VARCHAR(50)
);

CREATE TABLE Marks (
    mark_id INT PRIMARY KEY IDENTITY(1,1),
    student_id INT FOREIGN KEY REFERENCES Student(id), 
    subject VARCHAR(50), 
    marks INT CHECK (marks BETWEEN 0 AND 100)
);

INSERT INTO Marks (student_id, subject, marks) VALUES 
(1, 'Mathematics', 85),
(2, 'Mathematics', 75),
(3, 'Science', 80),
(4, 'Science', 70),
(5, 'English', 90),
(6, 'English', 88),
(7, 'History', 76),
(8, 'History', 85),
(9, 'Physics', 79),
(10, 'Physics', 83);

INSERT INTO Class (class_id, class_name, section, teacher) VALUES 
(5, 'Fifth Standard', 'A', 'Mr. Sharma'),
(6, 'Sixth Standard', 'B', 'Ms. Patel'),
(7, 'Seventh Standard', 'A', 'Mr. Khan'),
(10, 'Tenth Standard', 'C', 'Ms. Mehta'),
(12, 'Twelfth Standard', 'D', 'Dr. Verma');

INSERT INTO Student (id, name, age, class, city) VALUES 
(1, 'jay', 18, 12, 'ahemdabad'),
(2, 'ram', 12, 6, 'baroda'),
(3, 'mahesh', 10, 5, 'rajkot'),
(4, 'vicky', 16, 10, 'surat'),
(5, 'raju', 16, 10, 'ahemdabad'),
(6, 'shyam', 18, 12, 'baroda'),
(7, 'baburao', 9, 4, 'surat'),
(8, 'alish', 10, 5, 'rajkot'),
(9, 'het', 13, 7, 'mumbai'),
(10, 'shiv', 14, 7, 'pune'),
(11, 'raj', 10, 5, 'surat');

SELECT * FROM Student;
SELECT * FROM Class;
SELECT * FROM Marks;