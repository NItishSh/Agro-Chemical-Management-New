CREATE TABLE [dbo].[Product] (
    [ProductCode]  INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (100) NOT NULL,
    [TAX]          NUMERIC (5, 2) NOT NULL,
    [PartyCode]    INT            NOT NULL,
    [QuantityType] NVARCHAR (50)  NULL,
    [Description]  NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([ProductCode] ASC),
    CONSTRAINT [FK_Product_ToParty] FOREIGN KEY ([PartyCode]) REFERENCES [dbo].[Party] ([PartyCode])
);

