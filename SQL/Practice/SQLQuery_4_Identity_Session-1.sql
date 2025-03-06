CREATE TABLE identity_table(
	id INT IDENTITY(1,1),
	name VARCHAR(50)
);

INSERT INTO identity_table (name) VALUES ('Abc');
INSERT INTO identity_table (name) VALUES ('def');
INSERT INTO identity_table (name) VALUES ('efg');

SELECT * FROM identity_table;

SELECT SCOPE_IDENTITY();
SELECT @@IDENTITY;

CREATE TABLE Cust_table(
	id INT IDENTITY,
	date_time DATETIME
);

INSERT INTO Cust_table VALUES (GETDATE());

SELECT * FROM Cust_table;

CREATE TRIGGER tr_InsertCustDetails 
ON identity_table
AFTER INSERT 
AS 
BEGIN
	INSERT INTO Cust_table VALUES (GETDATE());
END;

SELECT * FROM Cust_table;

INSERT INTO identity_table (name) VALUES ('YRU');

SELECT SCOPE_IDENTITY();
SELECT @@IDENTITY;

DROP TRIGGER tr_InsertCustDetails;


CREATE TABLE Cust_table_NEW(
	id INT IDENTITY,
	date_time DATETIME
);

INSERT INTO Cust_table_NEW (date_time) VALUES (GETDATE());
SELECT * FROM Cust_table_NEW;

SELECT @@IDENTITY;
SELECT SCOPE_IDENTITY();