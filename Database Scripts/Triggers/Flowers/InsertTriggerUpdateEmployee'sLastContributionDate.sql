/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2017 (14.0.1000)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Target Database Engine Type : Standalone SQL Server
*/

USE [Knowledge_Garden_H]
GO

/****** Object:  Trigger [dbo].[InsertTriggerNotifyAllEmployees]    Script Date: 8/7/2019 2:19:35 PM ******/
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
