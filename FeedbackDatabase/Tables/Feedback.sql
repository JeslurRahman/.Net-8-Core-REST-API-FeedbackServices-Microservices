CREATE TABLE [dbo].[Feedbacks]
(
	[Id]			INT NOT NULL IDENTITY(1,1),
	[Subject]		VARCHAR(100) NULL,
	[Message]		VARCHAR(MAX) NULL,
	[Rating]		INT NOT NULL, --rating from 1,2,3,4,5
	[CreatedBy]		VARCHAR(50) NOT NULL DEFAULT 'System',
	[CreatedDate]	DATETIME2 NOT NULL DEFAULT getdate()
	CONSTRAINT PK_FeedbacksId PRIMARY KEY CLUSTERED (Id ASC)
)
