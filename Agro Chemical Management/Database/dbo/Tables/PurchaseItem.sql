CREATE TABLE [dbo].[PurchaseItem] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [PurchaseID]  INT            NOT NULL,
    [ProductCode] INT            NOT NULL,
    [Quantity]    INT            NOT NULL,
    [Price]       NUMERIC (8, 2) NOT NULL,
    [TaxAmount]   NUMERIC (8, 2) NOT NULL,
    [Total]       NUMERIC (8, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PurchaseItem_ToProduct] FOREIGN KEY ([ProductCode]) REFERENCES [dbo].[Product] ([ProductCode]),
    CONSTRAINT [FK_PurchaseItem_ToPurchase] FOREIGN KEY ([PurchaseID]) REFERENCES [dbo].[Purchase] ([PurchaseId])
);

