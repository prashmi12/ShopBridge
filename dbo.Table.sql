CREATE TABLE [dbo].[Product](  
    [ProductId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,  
    [ProductName] [nvarchar](100) NOT NULL,  
    [ProductDescription] [nvarchar] (100) NULL,  
    [Price] [decimal] NOT NULL) 
