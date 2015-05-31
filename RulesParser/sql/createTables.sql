USE mtgRules

IF OBJECT_ID('dbo.SubRuleExample', 'U') IS NOT NULL
	DROP TABLE dbo.SubRuleExample

IF OBJECT_ID('dbo.MainRuleExample', 'U') IS NOT NULL
	DROP TABLE dbo.MainRuleExample

IF OBJECT_ID('dbo.SubRule', 'U') IS NOT NULL
	DROP TABLE dbo.SubRule

IF OBJECT_ID('dbo.MainRule', 'U') IS NOT NULL
	DROP TABLE dbo.MainRule

IF OBJECT_ID('dbo.Section', 'U') IS NOT NULL
	DROP TABLE dbo.Section

CREATE TABLE Section
(
sectionID INT IDENTITY(1,1) PRIMARY KEY,
sectionNumber INT NOT NULL,
sectionName INT NOT NULL
)

CREATE TABLE MainRule
(
mainRuleID INT IDENTITY(1,1) PRIMARY KEY,
sectionID INT NOT NULL,
mainRuleNumber INT NOT NULL,
ruleText VARCHAR(2000),
CONSTRAINT FK_MainRule_Section FOREIGN KEY (sectionID)
	REFERENCES dbo.Section (sectionID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)

CREATE TABLE SubRule
(
subRuleID INT IDENTITY(1,1) PRIMARY KEY,
mainRuleId INT NOT NULL,
subRuleLetter INT NOT NULL,
ruleText VARCHAR(2000),
CONSTRAINT FK_SubRule_MainRule FOREIGN KEY (mainRuleId)
	REFERENCES dbo.MainRule (mainRuleId)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)

CREATE TABLE MainRuleExample
(
mainRuleExampleID INT IDENTITY(1,1) PRIMARY KEY,
mainRuleId INT NOT NULL,
exampleText VARCHAR(2000),
CONSTRAINT FK_MainRuleExample_MainRule FOREIGN KEY (mainRuleId)
	REFERENCES dbo.MainRule (mainRuleId)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)

CREATE TABLE SubRuleExample
(
subRuleExampleID INT IDENTITY(1,1) PRIMARY KEY,
subRuleId INT NOT NULL,
exampleText VARCHAR(2000),
CONSTRAINT FK_SubRuleExample_SubRule FOREIGN KEY (subRuleId)
	REFERENCES dbo.SubRule (subRuleId)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)