CREATE TABLE [dbo].[Sale] (
    [SaleId]          INT             IDENTITY (1, 1) NOT NULL,
    [CustomerName]    NVARCHAR (100)  NOT NULL,
    [CustomerAddress] NVARCHAR (200)  NOT NULL,
    [SaleDate]        DATETIME        NOT NULL,
    [TotalSaleValue]  NUMERIC (10, 2) NOT NULL,
    [SaleType]        BIT             NOT NULL,
    [Operator]        NVARCHAR (50)   NOT NULL,
    PRIMARY KEY CLUSTERED ([SaleId] ASC)
);

