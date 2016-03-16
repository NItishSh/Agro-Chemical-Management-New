CREATE TABLE [dbo].[Purchase] (
    [PurchaseId]         INT             IDENTITY (1, 1) NOT NULL,
    [InvoiceNumber]      NVARCHAR (50)   NOT NULL,
    [PurchaseDate]       DATETIME        NOT NULL,
    [PartyCode]          INT             NOT NULL,
    [TotalPurchaseValue] NUMERIC (10, 2) NOT NULL,
    [BillType]           BIT             NOT NULL,
    [Opertator]          NVARCHAR (50)   NOT NULL,
    PRIMARY KEY CLUSTERED ([PurchaseId] ASC),
    CONSTRAINT [FK_Purchase_ToParty] FOREIGN KEY ([PartyCode]) REFERENCES [dbo].[Party] ([PartyCode])
);

