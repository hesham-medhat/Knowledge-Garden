-- ================================================
-- Template generated from Template Explorer using:
-- Create Trigger (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- See additional Create Trigger templates for more
-- examples of different Trigger statements.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

USE Knowledge_Garden_H;
GO
-- =============================================
-- Author:		Hesham Medhat
-- Create date: 8/8/2019
-- Description:	Create an insert trigger to notify all employees with the introduction of a new Flower
-- =============================================
ALTER TRIGGER InsertTriggerNotifyAllEmployees
   ON  dbo.Flowers
   FOR INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    INSERT INTO dbo.Notifications(FlowerId, EmployeeUsername)
	SELECT Id, Username
	FROM INSERTED
	CROSS JOIN dbo.Employees;

	-- Delete owner's notification
	DELETE FROM dbo.Notifications
	WHERE FlowerId = (SELECT Id from INSERTED) AND
	EmployeeUsername = (SELECT OwnerUsername FROM INSERTED);

END
GO
