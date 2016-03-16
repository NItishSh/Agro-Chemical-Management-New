CREATE TABLE [dbo].[SaleItem] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [SaleId]      INT            NOT NULL,
    [ProductCode] INT            NOT NULL,
    [Quantity]    INT            NOT NULL,
    [Price]       NUMERIC (8, 2) NOT NULL,
    [TaxAmount]   NUMERIC (8, 2) NOT NULL,
    [Total]       NUMERIC (8, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SaleItem_ToProduct] FOREIGN KEY ([ProductCode]) REFERENCES [dbo].[Product] ([ProductCode]),
    CONSTRAINT [FK_SaleItem_ToSale] FOREIGN KEY ([SaleId]) REFERENCES [dbo].[Sale] ([SaleId])
);

