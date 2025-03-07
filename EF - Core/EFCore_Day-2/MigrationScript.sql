IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Customers] (
    [CustId] int NOT NULL IDENTITY,
    [CustName] nvarchar(max) NOT NULL,
    [OrderId] int NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([CustId])
);

CREATE TABLE [Products] (
    [ProductId] int NOT NULL IDENTITY,
    [ProductName] nvarchar(max) NOT NULL,
    [Price] int NOT NULL,
    [OrderId] int NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([ProductId])
);

CREATE TABLE [Orders] (
    [OrderId] int NOT NULL IDENTITY,
    [CustId] int NULL,
    [customerCustId] int NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderId]),
    CONSTRAINT [FK_Orders_Customers_customerCustId] FOREIGN KEY ([customerCustId]) REFERENCES [Customers] ([CustId]) ON DELETE CASCADE
);

CREATE TABLE [OrderProduct] (
    [ordersOrderId] int NOT NULL,
    [productsProductId] int NOT NULL,
    CONSTRAINT [PK_OrderProduct] PRIMARY KEY ([ordersOrderId], [productsProductId]),
    CONSTRAINT [FK_OrderProduct_Orders_ordersOrderId] FOREIGN KEY ([ordersOrderId]) REFERENCES [Orders] ([OrderId]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrderProduct_Products_productsProductId] FOREIGN KEY ([productsProductId]) REFERENCES [Products] ([ProductId]) ON DELETE CASCADE
);

CREATE INDEX [IX_OrderProduct_productsProductId] ON [OrderProduct] ([productsProductId]);

CREATE INDEX [IX_Orders_customerCustId] ON [Orders] ([customerCustId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250307082924_Initial_Migration', N'9.0.2');

DECLARE @var sysname;
SELECT @var = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'Item');
IF @var IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var + '];');
ALTER TABLE [Orders] DROP COLUMN [Item];

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250307084935_Column_Changed', N'9.0.2');

COMMIT;
GO

