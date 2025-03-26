USE utsavdb;

-- Create View of student records
CREATE VIEW StudentRecords AS
SELECT * FROM Student AS s
JOIN Marks AS m 
ON s.id = m.student_id;

SELECT * FROM StudentRecords;

CREATE VIEW StudentRecords2 AS
SELECT s.id, s.name, s.class, s.city, m.subject, m.marks FROM Student AS s
JOIN Marks AS m 
ON s.id = m.student_id;

SELECT * FROM StudentRecords2;

CREATE VIEW LocStudentRecords AS
SELECT s.id, s.name, s.class, s.city, m.subject, m.marks 
FROM Student AS s
JOIN Marks AS m 
ON s.id = m.student_id
WHERE s.city = 'ahemdabad';

-- Alter view
ALTER VIEW LocStudentRecords AS
SELECT s.id, s.name, s.class, s.city, m.subject, m.marks 
FROM Student AS s
JOIN Marks AS m 
ON s.id = m.student_id
WHERE s.city = 'surat';

SELECT * FROM LocStudentRecords;

-- drop view 
DROP VIEW StudentRecords;
DROP VIEW StudentRecords2;
DROP VIEW AhmStudentRecords;

