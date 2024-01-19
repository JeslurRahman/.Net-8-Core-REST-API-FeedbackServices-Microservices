BEGIN TRY
	BEGIN TRANSACTION;
		BEGIN
			PRINT 'Updating Feedbacks.Ratings';
			ALTER TABLE Feedbacks ADD CONSTRAINT UC_EntityId_Key UNIQUE (EntityId, [Key]);
		END
	COMMIT TRANSACTION;
	PRINT 'Ratings column renamed in [Feedbacks] Table '

END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION;
	PRINT 'Ratings column renamed in [Feedbacks] Table failed!'
END CATCH;
GO
--#### End [CHANGE SCRIPT] ####

--#### Start [VALIDATION] FOR table ####
IF ( 
	(SELECT character_maximum_length FROM information_schema.columns WHERE table_name = 'Feedbacks' and column_name = 'EntityId') = 50
	and 
	NOT EXISTS (SELECT 1 FROM Feedbacks WHERE Rating < 1 OR Rating > 5 )
   )
BEGIN
		PRINT 'Feedbacks column update Validation complete successfully'
END
ELSE
BEGIN
		PRINT 'Feedbacks column update Validation was not successful'
		RETURN;
END
GO
--#### End [VALIDATION] ####
