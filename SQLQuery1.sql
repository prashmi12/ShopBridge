CREATE TABLE [dbo].[Product](  
    [ProductId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,  
    [ProductName] [nvarchar](100) NOT NULL,  
    [ProductDescription] [varchar] NOT NULL,  
    [Price] [int] NOT NULL) 