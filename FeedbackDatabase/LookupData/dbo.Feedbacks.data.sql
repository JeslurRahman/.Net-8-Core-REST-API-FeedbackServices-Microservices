--Static data, That feeding to Feedbacks table

SET IDENTITY_INSERT [dbo].[Feedbacks] ON
GO

MERGE INTO [dbo].[Feedbacks] AS [Target]
USING (VALUES
(1, '.Net Core 08 Web API','xyz 01', 8,'Jeslur', getdate()),
(2, '.Net Core 07 Web API','xyz 02', 6,'Rifkhan', getdate()),
(3, '.Net Core 06 Web API','xyz 03', 9,'Risny', getdate()),
(4, '.Net Core 05 Web API','xyz 04', 5,'Limhan', getdate()),
(5, '.Net Core 04 Web API','xyz 05', 8,'Rikas', getdate())

)
AS [Source] ([Id],[Subject],[Message],[Rating],[CreatedBy],[CreatedDate])
ON [Target].[Id] = [Source].[Id]
WHEN MATCHED THEN --update matched rows
UPDATE SET
		[Subject] = [Source].[Subject],
		[Message] = [Source].[Message],
		[Rating] = [Source].[Rating],
		[CreatedBy] = [Source].[CreatedBy],
		[CreatedDate] = [Source].[CreatedDate]
WHEN NOT MATCHED BY TARGET THEN --insert new rows
INSERT ([Id],[Subject],[Message],[Rating],[CreatedBy],[CreatedDate])
VALUES ([Id],[Subject],[Message],[Rating],[CreatedBy],[CreatedDate]);

--WHEN NOT MATCHED BY SOURCE THEN --delete rows that are in the target but not the source
--DELETE;

GO
SET IDENTITY_INSERT [dbo].[Feedbacks] OFF
GO