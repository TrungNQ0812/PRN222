use FUNewsManagement;

ALTER TABLE [dbo].[SystemAccount]
ADD [AccountStatus] NVARCHAR(10) NOT NULL DEFAULT 'Activate';

ALTER TABLE [dbo].[SystemAccount]
ADD CONSTRAINT CHK_AccountStatus CHECK ([AccountStatus] IN ('Activate', 'Deactivate'));