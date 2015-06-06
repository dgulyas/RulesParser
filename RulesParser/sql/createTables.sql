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

IF OBJECT_ID('dbo.SubSection', 'U') IS NOT NULL
	DROP TABLE dbo.SubSection


--Token: X.
--A single digit followed by a period
CREATE TABLE Section
(
sectionID INT IDENTITY(1,1) PRIMARY KEY,
sectionNumber INT NOT NULL,
sectionName VARCHAR(100) NOT NULL
)

--Token: XYY.
--The X is the Section number
--The YY is the subsection number
CREATE TABLE SubSection
(
subSectionID INT IDENTITY(1,1) PRIMARY KEY,
sectionID INT NOT NULL,
subSectionNumber INT NOT NULL,
subSectionName VARCHAR(100) NOT NULL,
CONSTRAINT FK_SubSection_Section FOREIGN KEY (sectionID)
	REFERENCES dbo.Section (sectionID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)

--Token: XYY.Z.
--XYY. is the sub section it belongs to
--Z is the MainRule number
CREATE TABLE MainRule
(
mainRuleID INT IDENTITY(1,1) PRIMARY KEY,
subSectionID INT NOT NULL,
mainRuleNumber INT NOT NULL,
ruleText VARCHAR(2000),
CONSTRAINT FK_MainRule_SubSection FOREIGN KEY (subSectionID)
	REFERENCES dbo.SubSection (subSectionID)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)

--Token: XYY.Zw
--XYY.Z is the Main rule it belongs to
--w is the sub rules letter
CREATE TABLE SubRule
(
subRuleID INT IDENTITY(1,1) PRIMARY KEY,
mainRuleId INT NOT NULL,
subRuleLetter VARCHAR(2) NOT NULL,
ruleText VARCHAR(2000),
CONSTRAINT FK_SubRule_MainRule FOREIGN KEY (mainRuleId)
	REFERENCES dbo.MainRule (mainRuleId)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)

--an example that comes after a main rule
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

--an example that comes after a sub rule
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