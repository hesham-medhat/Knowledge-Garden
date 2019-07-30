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
-- =============================================
-- Author:		Hesham Medhat
-- Create date: 30/7/2019
-- Description:	Create an insert trigger to update owner Employee's LastContributionTime
-- =============================================
CREATE TRIGGER InsertAndUpdateTriggerUpdateEmployeeLastContributionTime
   ON  dbo.Flowers
   AFTER INSERT, UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    UPDATE dbo.Employees
	SET LastContributionTime = CURRENT_TIMESTAMP
	WHERE Username = (SELECT OwnerUsername FROM INSERTED);

END
GO