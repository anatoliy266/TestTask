--CREATE TABLE [dbo].[INTERVIEW]
--(
--	[Id] INT NOT NULL PRIMARY KEY identity(1, 1),
--	[FIO] varchar(max),
--	[PHONE_NUMBER] varchar(max),
--	[POSITION] varchar(max),
--	[EMPLOYEE] varchar(max),
--	[EMPLOYEE_POSITION] varchar(max),
--	[DATE] datetime,
--	[TEST_TASK_END_DATE] datetime
--)


CREATE TABLE [dbo].[EMPLOYEES]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1, 1),
	[FIO] varchar(max),
	[POSITION] varchar(max),
)

CREATE TABLE [dbo].[POSITIONS]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1, 1),
	[FIO] varchar(max),
	[POSITION] varchar(max),
)
