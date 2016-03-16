CREATE TABLE [dbo].[Party] (
    [PartyCode]     INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (100) NOT NULL,
    [Address]       NVARCHAR (200) NOT NULL,
    [ContactNumber] NVARCHAR (50)  NOT NULL,
    [TinNumber]     NVARCHAR (50)  NULL,
    [Description]   NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([PartyCode] ASC)
);

