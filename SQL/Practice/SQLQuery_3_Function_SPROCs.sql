----------------------------------------------------------------------------
-- System Functions

SELECT UPPER('utsav') AS upperCase;
SELECT LOWER('UtSaV') AS lowerCase;
SELECT LEN('UTsav') AS stringLen;
									   
SELECT GETDATE() AS Today;
SELECT YEAR(GETDATE()) AS currentYear;

SELECT COUNT(*) FROM Student;
SELECT MAX(marks) AS maxMark FROM Marks;
SELECT AVG(marks) AS aveMark FROM Marks;

SELECT USER_NAME(); 
SELECT @@SERVERNAME;

----------------------------------------------------------------------------
-- (Scaler Functions) User defined functions 

CREATE FUNCTION TotalMarks ()
RETURNS INT
AS 
BEGIN
	DECLARE @tmarks INT;
	SELECT @tmarks = SUM(marks) FROM Marks;
	RETURN @tmarks;
END;

SELECT dbo.TotalMarks() AS [Total Marks];

DROP FUNCTION TotalMarks;


CREATE FUNCTION GetStudentCount()
RETURNS INT
AS
BEGIN
    DECLARE @count INT;
    SELECT @count = COUNT(*) FROM Student;
    RETURN @count;
END;

SELECT dbo.GetStudentCount() AS [Total Students];

DROP FUNCTION GetStudentCount;

CREATE FUNCTION GetSquare(@val INT)
RETURNS INT
AS 
BEGIN 
	DECLARE @ans INT;
	SELECT @ans = @val * @val;
	RETURN @ans;
END;

SELECT dbo.GetSquare(5) AS [Ans in Square];

-- (Table Valued functions) User defined function

CREATE FUNCTION GetAhmedabadStudents()
RETURNS TABLE
AS
RETURN
(
    SELECT * FROM Student WHERE city = 'ahemdabad'
);

SELECT * FROM dbo.GetAhmedabadStudents();

DROP FUNCTION GetAhmedabadStudents;
	
----------------------------------------------------------------------------
-- Stored Procedures
CREATE PROCEDURE AddStudent
    @id INT,
    @name VARCHAR(50),
    @age INT,
    @class INT,
    @city VARCHAR(50)
AS
BEGIN
    INSERT INTO Student (id, name, age, class, city) 
    VALUES (@id, @name, @age, @class, @city);
END;

EXEC AddStudent 12, 'Ramesh', 15, 8, 'Vadodara';

SELECT * FROM Student;

DROP PROCEDURE dbo.AddStudent;

CREATE PROCEDURE AddMark
	@student_id INT,
	@subject VARCHAR(50),
	@marks INT
AS
BEGIN
	INSERT INTO Marks (student_id, subject, marks)
	VALUES (@student_id, @subject, @marks);
END;

EXEC AddMark 1, 'Chemistry', 90;

SELECT * FROM Marks;

DROP PROCEDURE dbo.AddMark;