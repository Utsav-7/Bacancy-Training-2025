INSERT INTO identity_table (name) VALUES ('PQR');
INSERT INTO identity_table (name) VALUES ('GEY');

SELECT * FROM identity_table;

INSERT INTO Cust_table_NEW (date_time) VALUES (GETDATE());
SELECT * FROM Cust_table_NEW;


SELECT SCOPE_IDENTITY();
SELECT @@IDENTITY