/* 
			SCRIPT TO BUILD SQL AZURE FUSION DB
*/

-- remove table if exists
IF OBJECT_ID('dbo.Login', 'U') IS NOT NULL
  DROP TABLE [dbo].[Login]
GO

-- create the federated scheme only for login
CREATE FEDERATION LoginFederation(IdentityHash UNIQUEIDENTIFIER RANGE)
GO

-- Connect to federation
USE FEDERATION LoginFederation (IdentityHash = '00000000-0000-0000-0000-000000000000') WITH RESET, FILTERING = OFF
GO

-- login table federated on md5 hash
CREATE TABLE [dbo].[Login](
      [IdentityHash] [uniqueidentifier] NOT NULL,
      [Identity] [nvarchar](255) NOT NULL,
	  [SystemId] [uniqueidentifier] NOT NULL,
	  [Region] [int] NOT NULL,
	  [InsertDate] [datetime] NOT NULL,
      [ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Login_PatientId] PRIMARY KEY CLUSTERED
(
      [IdentityHash] ASC,
	  [Identity] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)FEDERATED ON (IdentityHash = IdentityHash)
GO

USE FEDERATION ROOT WITH RESET
GO

-- create the scheme for the rest of the DB by region.  
CREATE FEDERATION RegionFederation(Region int RANGE)
GO

-- Connect to federation
USE FEDERATION RegionFederation (Region = 0) WITH RESET, FILTERING = OFF
GO

IF OBJECT_ID('dbo.Patient', 'U') IS NOT NULL
  DROP TABLE [dbo].[Patient]
GO

-- Top level patient table
CREATE TABLE [dbo].[Patient](
      [PatientId] [uniqueidentifier] NOT NULL,
	  [Region] [int] NOT NULL,
	  [FirstName] nvarchar(50) NOT NULL,
	  [LastName] nvarchar(50) NOT NULL,
	  [Email] nvarchar(255) NOT NULL,
	  [Phone] nvarchar(255) NOT NULL,
	  [Address1] nvarchar(50) NOT NULL,
	  [Address2] nvarchar(50) NULL,
	  [City] nvarchar(50) NULL,
	  [State] char(2) NOT NULL,
	  [ZipCode] int NOT NULL,
	  [SpatialLocation] geography NOT NULL,
	  [InsertDate] [datetime] NOT NULL,
      [ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Patient_PatientId] PRIMARY KEY CLUSTERED
(
	  [Region] ASC,
      [PatientId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)FEDERATED ON (Region = Region)
GO

CREATE NONCLUSTERED INDEX ix_Patient_FirstName ON [dbo].[Patient]
(
	[FirstName] ASC
)
GO

CREATE NONCLUSTERED INDEX ix_Patient_LastName ON [dbo].[Patient]
(
	[LastName] ASC
)
GO

IF OBJECT_ID('dbo.Doctor', 'U') IS NOT NULL
  DROP TABLE [dbo].[Doctor]
GO

-- Top level doctor table..  kept address out because it relates to the practice
CREATE TABLE [dbo].[Doctor](
      [DoctorId] [uniqueidentifier] NOT NULL,
	  [Region] [int] NOT NULL,
	  [LicenseNumber] int NOT NULL,
	  [FirstName] nvarchar(50) NOT NULL,
	  [LastName] nvarchar(50) NOT NULL,
	  [Email] nvarchar(255) NOT NULL,
	  [Phone] nvarchar(255) NOT NULL,
	  [InsertDate] [datetime] NOT NULL,
      [ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Doctor_DoctorId] PRIMARY KEY CLUSTERED
(
	  [Region] ASC,
      [DoctorId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)FEDERATED ON (Region = Region)
GO

CREATE NONCLUSTERED INDEX ix_Doctor_FirstName ON [dbo].[Doctor]
(
	[FirstName] ASC
)
GO

CREATE NONCLUSTERED INDEX ix_Doctor_LastName ON [dbo].[Doctor]
(
	[LastName] ASC
)
GO

IF OBJECT_ID('dbo.Practice', 'U') IS NOT NULL
  DROP TABLE [dbo].[Practice]
GO

-- Top level practice table.  many to many with doctors
CREATE TABLE [dbo].[Practice](
      [PracticeId] [uniqueidentifier] NOT NULL,
	  [Region] [int] NOT NULL,
	  [Name] nvarchar(50) NOT NULL,
	  [GroupNumber] nvarchar(50) NOT NULL,
	  [Email] nvarchar(255) NOT NULL,
	  [Phone] nvarchar(255) NOT NULL,
	  [Address1] nvarchar(50) NOT NULL,
	  [Address2] nvarchar(50) NULL,
	  [City] nvarchar(50) NULL,
	  [State] char(2) NOT NULL,
	  [ZipCode] int NOT NULL,
	  [SpatialLocation] geography NOT NULL,
	  [InsertDate] [datetime] NOT NULL,
      [ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Practice_PracticeId] PRIMARY KEY CLUSTERED
(
	  [Region] ASC,
      [PracticeId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)FEDERATED ON (Region = Region)
GO

CREATE NONCLUSTERED INDEX ix_Practice_Name ON [dbo].[Practice]
(
	[Name] ASC
)
GO

CREATE NONCLUSTERED INDEX ix_Practice_GroupNumber ON [dbo].[Practice]
(
	[GroupNumber] ASC
)
GO

-- many to many practice doctor
CREATE TABLE [dbo].[PracticeToDoctor](
      [PracticeId] [uniqueidentifier] NOT NULL,
	  [DoctorId] [uniqueidentifier] NOT NULL,
	  [Region] [int] NOT NULL,
	  [InsertDate] [datetime] NOT NULL,
      [ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_PracticeToDoctor_PracticeIdAndDoctorId] PRIMARY KEY CLUSTERED
(
	  [Region] ASC,
      [PracticeId] ASC,
	  [DoctorId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)FEDERATED ON (Region = Region)
GO

ALTER TABLE [dbo].[PracticeToDoctor]
ADD CONSTRAINT PracticeToDoctor_PracticeId_FK FOREIGN KEY ( Region, PracticeId ) REFERENCES [dbo].[Practice](Region, PracticeId)
GO

ALTER TABLE [dbo].[PracticeToDoctor]
ADD CONSTRAINT PracticeToDoctor_DoctorId_FK FOREIGN KEY ( Region, PracticeId ) REFERENCES [dbo].[Doctor](Region, DoctorId)
GO

-- many to many practice patient
CREATE TABLE [dbo].[PracticeToPatient](
      [PracticeId] [uniqueidentifier] NOT NULL,
	  [PatientId] [uniqueidentifier] NOT NULL,
	  [Region] [int] NOT NULL,
	  [InsertDate] [datetime] NOT NULL,
      [ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_PracticeToPatient_PracticeIdAndPatientId] PRIMARY KEY CLUSTERED
(
	  [Region] ASC,
      [PracticeId] ASC,
	  [PatientId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)FEDERATED ON (Region = Region)
GO

ALTER TABLE [dbo].[PracticeToPatient]
ADD CONSTRAINT PracticeToPatient_PracticeId_FK FOREIGN KEY ( Region, PracticeId ) REFERENCES [dbo].[Practice](Region, PracticeId)
GO

ALTER TABLE [dbo].[PracticeToPatient]
ADD CONSTRAINT PracticeToPatient_Patient_FK FOREIGN KEY ( Region, PatientId ) REFERENCES [dbo].[Patient](Region, PatientId)
GO

-- Top level diagnosis codes taken from medicare
CREATE TABLE [dbo].[Diagnosis](
      [DiagnosisId] [uniqueidentifier] NOT NULL,
	  [Region] [int] NOT NULL,
	  [Code] nvarchar(50) NOT NULL,
	  [Description] nvarchar(2048) NOT NULL,
	  [InsertDate] [datetime] NOT NULL,
      [ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Diagnosis_DiagnosisId] PRIMARY KEY CLUSTERED
(
	  [Region] ASC,
      [DiagnosisId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)FEDERATED ON (Region = Region)
GO

-- many to many patient to diagnosis
CREATE TABLE [dbo].[PatientToDiagnosis](
      [PatientId] [uniqueidentifier] NOT NULL,
	  [DiagnosisId] [uniqueidentifier] NOT NULL,
	  [Region] [int] NOT NULL,
	  [InsertDate] [datetime] NOT NULL,
      [ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_PatientToDiagnosis_PatientIdAndDiagnosisId] PRIMARY KEY CLUSTERED
(
	  [Region] ASC,
      [PatientId] ASC,
	  [DiagnosisId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)FEDERATED ON (Region = Region)
GO

ALTER TABLE [dbo].[PatientToDiagnosis]
ADD CONSTRAINT PatientToDiagnosis_PatientId_FK FOREIGN KEY ( Region, PatientId ) REFERENCES [dbo].[Patient](Region, PatientId)
GO

ALTER TABLE [dbo].[PatientToDiagnosis]
ADD CONSTRAINT PatientToDiagnosis_Diagnosis_FK FOREIGN KEY ( Region, DiagnosisId ) REFERENCES [dbo].[Diagnosis](Region, DiagnosisId)
GO

-- many to many patientdiagnosis to doctor
CREATE TABLE [dbo].[PatientDiagnosisToDoctor](
      [PatientId] [uniqueidentifier] NOT NULL,
	  [DiagnosisId] [uniqueidentifier] NOT NULL,
	  [DoctorId] [uniqueidentifier] NOT NULL,
	  [Region] [int] NOT NULL,
	  [InsertDate] [datetime] NOT NULL,
      [ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_PatientDiagnosisToDoctor_PatientIdDiagnosisIdAndDoctorId] PRIMARY KEY CLUSTERED
(
	  [Region] ASC,
      [PatientId] ASC,
	  [DiagnosisId] ASC,
	  [DoctorId] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)FEDERATED ON (Region = Region)
GO

ALTER TABLE [dbo].[PatientDiagnosisToDoctor]
ADD CONSTRAINT PatientDiagnosisToDoctor_PatientDiagnosisId_FK FOREIGN KEY ( Region, PatientId, DiagnosisId ) REFERENCES [dbo].[PatientToDiagnosis](Region, PatientId, DiagnosisId)
GO

ALTER TABLE [dbo].[PatientDiagnosisToDoctor]
ADD CONSTRAINT PatientDiagnosisToDoctor_Doctor_FK FOREIGN KEY ( Region, DoctorId ) REFERENCES [dbo].[Doctor](Region, DoctorId)
GO