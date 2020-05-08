-- create Contacts table
CREATE TABLE [dbo].[Contacts](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[Address] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- populate Conatcts table with data
declare @idx int = 0

while @idx <= 1000
begin
	insert into Contacts values ('Address ' + cast(@idx as varchar(50)))
	set @idx = @idx + 1
end
GO

