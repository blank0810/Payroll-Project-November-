select * from tbl_benefits

delete from tbl_benefits

INSERT INTO tbl_benefits (benefits, benefitsDescription)
VALUES
    ('Witholding Tax', 'Tax deduction from the employee''s basic annual salary.'),
    ('Pag-IBIG Fund', 'Housing fund for employees, employers, and self-employed individuals, providing affordable housing and short-term financing.'),
    ('Pag-IBIG MP2 Savings', 'Voluntary savings program offered by Pag-IBIG Fund.'),
    ('PhilHealth', 'Government agency implementing the national health insurance program in the Philippines.'),
    ('GSIS', 'Government Service Insurance System providing various social insurance benefits to government employees.'),
    ('SSS', 'Social Security System offering insurance benefits such as sickness, maternity, disability, retirement, and death benefits for private sector employees and 
	self-employed individuals.')

INSERT INTO tbl_benefitsContributions (benefitsId, isBenefitContributionActive, isPercentage, personalShareValue, employerShareValue, benefitContributionEffectiveFromYear, benefitContributionEffectiveToYear)
values
	(2, 1, 0, 100, 100, 2023, null),
	(3, 1, 0, 500, 0, 2023, null),
	(4, 1, 1, 2, 2, 2023, 2023),
	(4, 0, 1, 2.5, 2.5, 2024, 2025),
	(5, 1, 1, 9, 12, 2023, null),
	(6, 1, 1, 4.5, 9.5, 2023, 2024),
	(6, 0, 1, 5, 10, 2025, null)s

ALTER TABLE tbl_appointmentFormBenefitsDetails
ALTER COLUMN personalShareValue DECIMAL(10, 2) NULL;

ALTER TABLE tbl_appointmentFormBenefitsDetails
ALTER COLUMN employerShareValue DECIMAL(10, 2) NULL;

INSERT INTO tbl_benefitsFormula (benefitsId, formulaDescription, formulaExpression)
VALUES
    (2, 'Calculate Pag-IBIG Fund Deduction', '[monthlySalary] - [totalPagIbigAmount]'),
    (3, 'Calculate Pag-IBIG MP2 Deduction', '[monthlySalary] - [totalPagIbigMP2Amount]'),
    (4, 'Compute PhilHealth Contribution Deduction', '[monthlySalary] - [totalPhilHealthAmount]'),
    (5, 'Compute GSIS Contribution Deduction', '[monthlySalary] - [totalGSISAmount]'),
    (6, 'Compute SSS Contribution Deduction', '[monthlySalary] - [totalSSSAmount]');


alter table tbl_contractLength
add constraint fk_tbl_employmentStatusLength foreign key (employmentStatusId)
references tbl_employmentStatus (employmentStatusId)
on update cascade

insert into tbl_department (departmentName, departmentInitial, departmentLogo)
values
	('Human Resources Office', 'HR Office', '1104982.png')

INSERT [dbo].[tbl_educationalAttainment] ([educationalAttainment]) VALUES ('Doctor''s Degree')
INSERT [dbo].[tbl_educationalAttainment] ([educationalAttainment]) VALUES ('Master''s Degree')
INSERT [dbo].[tbl_educationalAttainment] ([educationalAttainment]) VALUES ('Bachelor''s Degree')
INSERT [dbo].[tbl_educationalAttainment] ([educationalAttainment]) VALUES ('College Undergraduate')
INSERT [dbo].[tbl_educationalAttainment] ([educationalAttainment]) VALUES ('Senior High School Graduate')
INSERT [dbo].[tbl_educationalAttainment] ([educationalAttainment]) VALUES ('Senior High School Level')
INSERT [dbo].[tbl_educationalAttainment] ([educationalAttainment]) VALUES ('Junior High School Graduate')
INSERT [dbo].[tbl_educationalAttainment] ([educationalAttainment]) VALUES ('Junior High School Level')
INSERT [dbo].[tbl_educationalAttainment] ([educationalAttainment]) VALUES ('Elementrary Graduate')
INSERT [dbo].[tbl_educationalAttainment] ([educationalAttainment]) VALUES ('Elementary Level')

select * from tbl_educationalAttainment

-- System Administrator: User responsible for direct system interaction and administration.
INSERT INTO [dbo].[tbl_userRole] ([roleName], [roleDescription]) VALUES ('System Administrator', 'User responsible for overseeing and administrating direct interactions with the system.');

-- Mayor: User account for the Municipal Mayor, holding administrative responsibilities.
INSERT INTO [dbo].[tbl_userRole] ([roleName], [roleDescription]) VALUES ('Mayor', 'User account designated for the Municipal Mayor, encompassing administrative duties and decision-making.');

-- Personnel: Account used by the Human Resources Officer to manage personnel-related tasks.
INSERT INTO [dbo].[tbl_userRole] ([roleName], [roleDescription]) VALUES ('Personnel', 'User account specifically utilized by the Human Resources Officer to handle personnel-related tasks.');

-- Department Head: User account for respective office heads, managing departmental affairs.
INSERT INTO [dbo].[tbl_userRole] ([roleName], [roleDescription]) VALUES ('Department Head', 'User account assigned to department heads, responsible for overseeing and managing affairs within their respective offices.');

-- Employee: User account for all employees, facilitating daily tasks and access to relevant information.
INSERT INTO [dbo].[tbl_userRole] ([roleName], [roleDescription]) VALUES ('Employee', 'User account designated for all employees, providing access to necessary tools and information for their daily tasks.');

DBCC CHECKIDENT ('[tbl_userRole]', RESEED, 0);
DBCC CHECKIDENT ('[tbl_userRole]', NORESEED);
select * from tbl_userRole
select * from tbl_employee
delete from tbl_userRole

insert into tbl_userRole (roleName, roleDescription)
values
	('System Administrator', 'User responsible for overseeing and administrating direct interactions with the system.')

INSERT [dbo].[tbl_employee] ([employeePassword], [employeeFname], [employeeLname], [employeeMname], [employeeBirth], [employeeCivilStatus], [employeeSex], [employeeContactNumber], [employeeEmailAddress], [educationalAttainmentId], [nameOfSchool], [course], [schoolAddress], [departmentId], [employeeJobDesc], [roleId], [employeePicture], [employeeSignature], [nationality], [barangay], [municipality], [province], [zipCode], [isActive]) 
VALUES (N'1', N'Ryan Sy', N'Santos', N'Agsunta', CAST(N'2000-08-01T00:00:00.000' AS DateTime), N'Single', N'Male', N'09050346101', N'personnel@gmail.com', 1, N'MSU Naawan', N'Bs Human Resource', N'Region X Misamis Oriental Naawan', 1, N'Developer', 2, N'RyanSySantosAgsunta.jpg', N'Ryan SySantos.jpg', N'Filipino', N'Tubigan', N'Initao', N'Misamis Oriental', N'9022', 1)

INSERT INTO tbl_employeeDataLogChanges (employeeId, dateLog, logDescription, logCaption)
VALUES
	(1, GETDATE(), 'Recorded the addition of a new employee to the database.', 'New Employee Added');

insert into tbl_leaveType (leaveType, leaveDescription)
values
	('Sick Leave', 'Type of leave to avail if the employee have an illness/sickness.'),
	('Vacation Leave', 'Type of leave to avail if the employee wants to do a vacation.')

select * from tbl_leaveType

insert into tbl_employeeLeaveCredits (employeeId, typeId, numberOfCredits, leaveCreditYear)
values
	(1, 1, 15, 2023),
	(1, 2, 15, 2023)

insert into tbl_employeePassSlipHours (employeeId, month, year, numberOfHours)
values
	(1, 1, 2023, CAST(N'04:00:00' AS Time)),
	(1, 2, 2023, CAST(N'04:00:00' AS Time)),
	(1, 3, 2023, CAST(N'04:00:00' AS Time)),
	(1, 4, 2023, CAST(N'04:00:00' AS Time)),
	(1, 5, 2023, CAST(N'04:00:00' AS Time)),
	(1, 6, 2023, CAST(N'04:00:00' AS Time)),
	(1, 7, 2023, CAST(N'04:00:00' AS Time)),
	(1, 8, 2023, CAST(N'04:00:00' AS Time)),
	(1, 9, 2023, CAST(N'04:00:00' AS Time)),
	(1, 10, 2023, CAST(N'04:00:00' AS Time)),
	(1, 11, 2023, CAST(N'04:00:00' AS Time)),
	(1, 12, 2023, CAST(N'04:00:00' AS Time))

INSERT INTO tbl_employmentStatus (employmentStatus, employmentStatusDescription)
VALUES
	('Regular', 'Permanent employment status granted to employees without a fixed-term contract.'),
	('Job Order', 'Temporary employment status assigned to employees with a fixed 6-month contract.');

select * from tbl_userRole
select * from tbl_employee
update tbl_employee
set roleId = 3

insert into tbl_employmentStatusAccess (employmentStatusId, roleId)
values
	(1, 5),
	(1, 4),
	(1, 3)

insert into tbl_formType (formName)
values
	('Payroll Form'),
	('Application for Leave'),
	('Pass Slip'),
	('Travel Order')

insert into tbl_leaveDefaultCredits (typeId, numberOfCredits)
values
	(1, 15),
	(2, 15)

select * from tbl_benefits
select * from tbl_benefits

insert into tbl_mandatedBenefits (employmentStatusId, benefitsId, isMandated)
values
	(1, 1, 1),
	(1, 2, 1),
	(1, 3, 0),
	(1, 4, 1),
	(1, 5, 1),
	(1, 6, 0),
	(2, 3, 0)

INSERT INTO tbl_salaryRate (salaryratedescription, salaryGradeNumber)
VALUES
    ('Salary Grade 1', 1),
    ('Salary Grade 2', 2),
    ('Salary Grade 3', 3),
    ('Salary Grade 4', 4),
    ('Salary Grade 5', 5),
    ('Salary Grade 6', 6),
    ('Salary Grade 7', 7),
    ('Salary Grade 8', 8),
    ('Salary Grade 9', 9),
    ('Salary Grade 10', 10),
    ('Salary Grade 11', 11),
    ('Salary Grade 12', 12),
    ('Salary Grade 13', 13),
    ('Salary Grade 14', 14),
    ('Salary Grade 15', 15),
    ('Salary Grade 16', 16),
    ('Salary Grade 17', 17),
    ('Salary Grade 18', 18),
    ('Salary Grade 19', 19),
    ('Salary Grade 20', 20),
    ('Salary Grade 21', 21),
    ('Salary Grade 22', 22),
    ('Salary Grade 23', 23),
    ('Salary Grade 24', 24),
    ('Salary Grade 25', 25),
    ('Salary Grade 26', 26),
    ('Salary Grade 27', 27),
    ('Salary Grade 28', 28);

INSERT INTO tbl_salaryRateStep (salaryRateStepDescription, stepNumber)
VALUES
    ('Step 1', 1),
    ('Step 2', 2),
    ('Step 3', 3),
    ('Step 4', 4),
    ('Step 5', 5),
    ('Step 6', 6),
    ('Step 7', 7),
    ('Step 8', 8);

INSERT INTO tbl_salaryRateTranche (salaryRateTrancheDescription, trancheNumber)
VALUES
    ('1st Tranche', 1),
    ('2nd Tranche', 2),
    ('3rd Tranche', 3),
    ('4th Tranche', 4);

select * from tbl_salaryRateTranche
alter table tbl_salaryRateValue
drop column salaryRateSchedule

INSERT INTO tbl_salaryRateValue (salaryRateId, stepId, trancheId, amount, yearEffective, isActive)
VALUES
    (1, 1, 4, 13000, 2023, 1),
    (1, 2, 4, 13109, 2023, 1),
    (1, 3, 4, 13219, 2023, 1),
    (1, 4, 4, 13329, 2023, 1),
    (1, 5, 4, 13441, 2023, 1),
    (1, 6, 4, 13553, 2023, 1),
    (1, 7, 4, 13666, 2023, 1),
    (1, 8, 4, 13780, 2023, 1),
    (2, 1, 4, 13819, 2023, 1),
    (2, 2, 4, 13925, 2023, 1),
    (2, 3, 4, 14032, 2023, 1),
    (2, 4, 4, 14140, 2023, 1),
    (2, 5, 4, 14248, 2023, 1),
    (2, 6, 4, 14357, 2023, 1),
    (2, 7, 4, 14468, 2023, 1),
    (2, 8, 4, 14578, 2023, 1),
    (3, 1, 4, 14678, 2023, 1),
    (3, 2, 4, 14792, 2023, 1),
    (3, 3, 4, 14905, 2023, 1),
    (3, 4, 4, 15020, 2023, 1),
    (3, 5, 4, 15136, 2023, 1),
    (3, 6, 4, 15251, 2023, 1),
    (3, 7, 4, 15369, 2023, 1),
    (3, 8, 4, 15486, 2023, 1),
    (4, 1, 4, 15586, 2023, 1),
    (4, 2, 4, 15706, 2023, 1),
    (4, 3, 4, 15827, 2023, 1),
    (4, 4, 4, 15948, 2023, 1),
    (4, 5, 4, 16071, 2023, 1),
    (4, 6, 4, 16193, 2023, 1),
    (4, 7, 4, 16318, 2023, 1),
    (4, 8, 4, 16443, 2023, 1),
    (5, 1, 4, 16543, 2023, 1),
    (5, 2, 4, 16671, 2023, 1),
    (5, 3, 4, 16799, 2023, 1),
    (5, 4, 4, 16928, 2023, 1),
    (5, 5, 4, 17057, 2023, 1),
    (5, 6, 4, 17189, 2023, 1),
    (5, 7, 4, 17321, 2023, 1),
    (5, 8, 4, 17453, 2023, 1),
	(6, 1, 4, 17553, 2023, 1),
    (6, 2, 4, 17688, 2023, 1),
    (6, 3, 4, 17824, 2023, 1),
    (6, 4, 4, 17962, 2023, 1),
    (6, 5, 4, 18100, 2023, 1),
    (6, 6, 4, 18238, 2023, 1),
    (6, 7, 4, 18379, 2023, 1),
    (6, 8, 4, 18520, 2023, 1),
	(7, 1, 4, 18620, 2023, 1),
    (7, 2, 4, 18763, 2023, 1),
    (7, 3, 4, 18907, 2023, 1),
    (7, 4, 4, 19053, 2023, 1),
    (7, 5, 4, 19198, 2023, 1),
    (7, 6, 4, 19346, 2023, 1),
    (7, 7, 4, 19494, 2023, 1),
    (7, 8, 4, 19644, 2023, 1),
	(8, 1, 4, 19744, 2023, 1),
    (8, 2, 4, 19923, 2023, 1),
    (8, 3, 4, 20104, 2023, 1),
    (8, 4, 4, 20285, 2023, 1),
    (8, 5, 4, 20468, 2023, 1),
    (8, 6, 4, 20653, 2023, 1),
    (8, 7, 4, 20840, 2023, 1),
    (8, 8, 4, 21029, 2023, 1),
	(9, 1, 4, 21129, 2023, 1),
    (9, 2, 4, 21304, 2023, 1),
    (9, 3, 4, 21483, 2023, 1),
    (9, 4, 4, 21663, 2023, 1),
    (9, 5, 4, 21844, 2023, 1),
    (9, 6, 4, 22026, 2023, 1),
    (9, 7, 4, 22210, 2023, 1),
    (9, 8, 4, 22396, 2023, 1),
	(10, 1, 4, 23176, 2023, 1),
    (10, 2, 4, 23370, 2023, 1),
    (10, 3, 4, 23565, 2023, 1),
    (10, 4, 4, 23762, 2023, 1),
    (10, 5, 4, 23961, 2023, 1),
    (10, 6, 4, 24161, 2023, 1),
    (10, 7, 4, 24363, 2023, 1),
    (10, 8, 4, 24567, 2023, 1),
	(11, 1, 4, 27000, 2023, 1),
    (11, 2, 4, 27284, 2023, 1),
    (11, 3, 4, 27573, 2023, 1),
    (11, 4, 4, 27865, 2023, 1),
    (11, 5, 4, 28161, 2023, 1),
    (11, 6, 4, 28462, 2023, 1),
    (11, 7, 4, 28766, 2023, 1),
    (11, 8, 4, 29075, 2023, 1),
	(12, 1, 4, 29165, 2023, 1),
    (12, 2, 4, 29449, 2023, 1),
    (12, 3, 4, 29737, 2023, 1),
    (12, 4, 4, 30028, 2023, 1),
    (12, 5, 4, 30323, 2023, 1),
    (12, 6, 4, 30662, 2023, 1),
    (12, 7, 4, 30924, 2023, 1),
    (12, 8, 4, 31230, 2023, 1),
	(13, 1, 4, 31320, 2023, 1),
    (13, 2, 4, 31633, 2023, 1),
    (13, 3, 4, 31949, 2023, 1),
    (13, 4, 4, 32269, 2023, 1),
    (13, 5, 4, 32594, 2023, 1),
    (13, 6, 4, 32922, 2023, 1),
    (13, 7, 4, 33254, 2023, 1),
    (13, 8, 4, 33591, 2023, 1),
	(14, 1, 4, 33843, 2023, 1),
    (14, 2, 4, 34187, 2023, 1),
    (14, 3, 4, 34535, 2023, 1),
    (14, 4, 4, 34888, 2023, 1),
    (14, 5, 4, 35244, 2023, 1),
    (14, 6, 4, 35605, 2023, 1),
    (14, 7, 4, 35971, 2023, 1),
    (14, 8, 4, 36341, 2023, 1),
	(15, 1, 4, 36619, 2023, 1),
    (15, 2, 4, 36997, 2023, 1),
    (15, 3, 4, 37380, 2023, 1),
    (15, 4, 4, 37768, 2023, 1),
    (15, 5, 4, 38160, 2023, 1),
    (15, 6, 4, 38557, 2023, 1),
    (15, 7, 4, 38959, 2023, 1),
    (15, 8, 4, 39367, 2023, 1),
	(16, 1, 4, 39672, 2023, 1),
    (16, 2, 4, 40088, 2023, 1),
    (16, 3, 4, 40509, 2023, 1),
    (16, 4, 4, 40935, 2023, 1),
    (16, 5, 4, 41367, 2023, 1),
    (16, 6, 4, 41804, 2023, 1),
    (16, 7, 4, 42247, 2023, 1),
    (16, 8, 4, 42694, 2023, 1),
	(17, 1, 4, 43030, 2023, 1),
    (17, 2, 4, 43488, 2023, 1),
    (17, 3, 4, 43951, 2023, 1),
    (17, 4, 4, 44420, 2023, 1),
    (17, 5, 4, 44895, 2023, 1),
    (17, 6, 4, 45376, 2023, 1),
    (17, 7, 4, 45862, 2023, 1),
    (17, 8, 4, 46355, 2023, 1),
	(18, 1, 4, 46725, 2023, 1),
    (18, 2, 4, 47228, 2023, 1),
    (18, 3, 4, 47738, 2023, 1),
    (18, 4, 4, 48253, 2023, 1),
    (18, 5, 4, 48776, 2023, 1),
    (18, 6, 4, 49305, 2023, 1),
    (18, 7, 4, 49840, 2023, 1),
    (18, 8, 4, 50382, 2023, 1),
	(19, 1, 4, 51357, 2023, 1),
    (19, 2, 4, 52096, 2023, 1),
    (19, 3, 4, 52847, 2023, 1),
    (19, 4, 4, 53610, 2023, 1),
    (19, 5, 4, 54386, 2023, 1),
    (19, 6, 4, 55174, 2023, 1),
    (19, 7, 4, 55976, 2023, 1),
    (19, 8, 4, 56790, 2023, 1),
	(20, 1, 4, 57347, 2023, 1),
    (20, 2, 4, 58181, 2023, 1),
    (20, 3, 4, 59030, 2023, 1),
    (20, 4, 4, 59892, 2023, 1),
    (20, 5, 4, 60769, 2023, 1),
    (20, 6, 4, 61660, 2023, 1),
    (20, 7, 4, 62565, 2023, 1),
    (20, 8, 4, 63485, 2023, 1),
	(21, 1, 4, 63997, 2023, 1),
    (21, 2, 4, 64940, 2023, 1),
    (21, 3, 4, 65899, 2023, 1),
    (21, 4, 4, 66873, 2023, 1),
    (21, 5, 4, 67864, 2023, 1),
    (21, 6, 4, 68870, 2023, 1),
    (21, 7, 4, 69893, 2023, 1),
    (21, 8, 4, 70933, 2023, 1),
	(22, 1, 4, 71511, 2023, 1),
    (22, 2, 4, 72577, 2023, 1),
    (22, 3, 4, 73661, 2023, 1),
    (22, 4, 4, 74762, 2023, 1),
    (22, 5, 4, 75881, 2023, 1),
    (22, 6, 4, 77019, 2023, 1),
    (22, 7, 4, 78175, 2023, 1),
    (22, 8, 4, 79349, 2023, 1),
	(23, 1, 4, 80003, 2023, 1),
    (23, 2, 4, 81207, 2023, 1),
    (23, 3, 4, 82432, 2023, 1),
    (23, 4, 4, 83683, 2023, 1),
    (23, 5, 4, 85049, 2023, 1),
    (23, 6, 4, 86437, 2023, 1),
    (23, 7, 4, 87847, 2023, 1),
    (23, 8, 4, 89281, 2023, 1),
	(24, 1, 4, 90078, 2023, 1),
    (24, 2, 4, 91548, 2023, 1),
    (24, 3, 4, 93043, 2023, 1),
    (24, 4, 4, 94562, 2023, 1),
    (24, 5, 4, 96105, 2023, 1),
    (24, 6, 4, 97674, 2023, 1),
    (24, 7, 4, 99268, 2023, 1),
    (24, 8, 4, 100888, 2023, 1),
	(25, 1, 4, 102690, 2023, 1),
    (25, 2, 4, 104366, 2023, 1),
    (25, 3, 4, 106069, 2023, 1),
    (25, 4, 4, 107800, 2023, 1),
    (25, 5, 4, 109560, 2023, 1),
    (25, 6, 4, 111348, 2023, 1),
    (25, 7, 4, 113166, 2023, 1),
    (25, 8, 4, 115012, 2023, 1),
	(26, 1, 4, 116040, 2023, 1),
    (26, 2, 4, 117933, 2023, 1),
    (26, 3, 4, 119858, 2023, 1),
    (26, 4, 4, 121814, 2023, 1),
    (26, 5, 4, 123803, 2023, 1),
    (26, 6, 4, 125823, 2023, 1),
    (26, 7, 4, 127876, 2023, 1),
    (26, 8, 4, 129964, 2023, 1),
	(27, 1, 4, 131124, 2023, 1),
    (27, 2, 4, 133264, 2023, 1),
    (27, 3, 4, 135440, 2023, 1),
    (27, 4, 4, 137650, 2023, 1),
    (27, 5, 4, 139897, 2023, 1),
    (27, 6, 4, 142180, 2023, 1),
    (27, 7, 4, 144501, 2023, 1),
    (27, 8, 4, 146859, 2023, 1),
	(28, 1, 4, 148171, 2023, 1),
    (28, 2, 4, 150589, 2023, 1),
    (28, 3, 4, 153047, 2023, 1),
    (28, 4, 4, 155545, 2023, 1),
    (28, 5, 4, 158083, 2023, 1),
    (28, 6, 4, 160664, 2023, 1),
    (28, 7, 4, 163286, 2023, 1),
    (28, 8, 4, 165951, 2023, 1);

INSERT INTO tbl_salaryRateValue (salaryRateId, stepId, trancheId, amount, yearEffective, isActive)
VALUES
    (29, 1, 4, 167432, 2023, 1),
    (29, 2, 4, 170166, 2023, 1),
    (29, 3, 4, 172943, 2023, 1),
    (29, 4, 4, 175766, 2023, 1),
    (29, 5, 4, 178634, 2023, 1),
    (29, 6, 4, 181550, 2023, 1),
    (29, 7, 4, 184513, 2023, 1),
    (29, 8, 4, 187525, 2023, 1),
    (30, 1, 4, 189199, 2023, 1),
    (30, 2, 4, 192286, 2023, 1),
    (30, 3, 4, 195425, 2023, 1),
    (30, 4, 4, 198615, 2023, 1),
    (30, 5, 4, 201856, 2023, 1),
    (30, 6, 4, 205151, 2023, 1),
    (30, 7, 4, 208499, 2023, 1),
    (30, 8, 4, 211902, 2023, 1),
    (31, 1, 4, 278434, 2023, 1),
    (31, 2, 4, 283872, 2023, 1),
    (31, 3, 4, 289416, 2023, 1),
    (31, 4, 4, 295069, 2023, 1),
    (31, 5, 4, 300833, 2023, 1),
    (31, 6, 4, 306708, 2023, 1),
    (31, 7, 4, 312699, 2023, 1),
    (31, 8, 4, 318806, 2023, 1),
    (32, 1, 4, 331954, 2023, 1),
    (32, 2, 4, 338649, 2023, 1),
    (32, 3, 4, 345478, 2023, 1),
    (32, 4, 4, 352445, 2023, 1),
    (32, 5, 4, 359553, 2023, 1),
    (32, 6, 4, 366804, 2023, 1),
    (32, 7, 4, 374202, 2023, 1),
    (32, 8, 4, 381748, 2023, 1),
    (33, 1, 4, 419144, 2023, 1),
    (33, 2, 4, 431718, 2023, 1),
    (33, 3, 4, 0, 2023, 1),
    (33, 4, 4, 0, 2023, 1),
    (33, 5, 4, 0, 2023, 1),
    (33, 6, 4, 0, 2023, 1),
    (33, 7, 4, 0, 2023, 1),
    (33, 8, 4, 0, 2023, 1);

SELECT
    sr.salaryratedescription,
    MAX(CASE WHEN sv.stepId = 1 THEN sv.amount END) AS Step1,
    MAX(CASE WHEN sv.stepId = 2 THEN sv.amount END) AS Step2,
    MAX(CASE WHEN sv.stepId = 3 THEN sv.amount END) AS Step3,
    MAX(CASE WHEN sv.stepId = 4 THEN sv.amount END) AS Step4,
    MAX(CASE WHEN sv.stepId = 5 THEN sv.amount END) AS Step5,
    MAX(CASE WHEN sv.stepId = 6 THEN sv.amount END) AS Step6,
    MAX(CASE WHEN sv.stepId = 7 THEN sv.amount END) AS Step7,
    MAX(CASE WHEN sv.stepId = 8 THEN sv.amount END) AS Step8
FROM tbl_salaryRateValue sv
JOIN tbl_salaryRate sr ON sv.salaryRateId = sr.salaryRateId
JOIN tbl_salaryRateTranche st ON sv.trancheId = st.trancheId
WHERE st.trancheNumber = 4 AND sv.yearEffective = 2023 AND sv.isActive = 1
GROUP BY sr.salaryratedescription, sr.salaryGradeNumber
ORDER BY sr.salaryGradeNumber;

select * from tbl_salaryRateTranche
select * from tbl_salaryRateValue

update tbl_salaryRateValue
set trancheId = null
where salaryRateValueId = 300

alter table tbl_salaryRateTranche
add isTrancheUsed bit not null default 1
update tbl_salaryRateTranche
set isTrancheUsed = 1 where trancheId = 4

select * from tbl_salaryRate

SELECT amount FROM tbl_salaryRateValue sv JOIN tbl_salaryRate sr ON sv.salaryRateId = sr.salaryRateId 
JOIN tbl_salaryRateStep st ON st.stepId = sv.stepId 
JOIN tbl_salaryRateTranche srt ON srt.trancheId = sv.trancheId 
WHERE sr.salaryRateId = 22 
AND st.stepNumber = 1 
AND srt.isTrancheUsed = 1

select salaryRateId from tbl_salaryRate where salaryRateDescription = 'Salary Grade 22'

select salaryRateValueId from tbl_salaryRateValue where amount = 71511

SELECT salaryRateValueId, amount
FROM tbl_salaryRateValue
GROUP BY salaryRateValueId, amount
HAVING COUNT(DISTINCT amount) > 1;

SELECT salaryRateValueId, amount
FROM tbl_salaryRateValue
WHERE amount IN (
    SELECT amount
    FROM tbl_salaryRateValue
    GROUP BY amount
    HAVING COUNT(amount) > 1
);

SELECT sv.salaryRateValueId, sv.amount, sv.salaryRateId
FROM tbl_salaryRateValue sv
WHERE sv.amount IN (
    SELECT amount
    FROM tbl_salaryRateValue
    GROUP BY amount
    HAVING COUNT(amount) > 1
)
AND sv.salaryRateId NOT IN (
    SELECT salaryRateId
    FROM tbl_salaryRateValue
    WHERE amount IN (
        SELECT amount
        FROM tbl_salaryRateValue
        GROUP BY amount
        HAVING COUNT(amount) > 1
    )
    GROUP BY salaryRateId
    HAVING COUNT(DISTINCT amount) = 1
);

SELECT COUNT(*) AS custom_Count FROM tbl_salaryRate WHERE salaryratedescription like '%Custom%'

update tbl_salaryRateTranche
set isTrancheUsed = 0
where trancheId != 4

select * from tbl_salaryRateTranche

create table tbl_payrollSched
(
	payrollSchedId int not null identity(1,1) primary key,
	payrollScheduleDescription varchar(200) not null,
	payrollScheduleNumberOfDays int not null
)

drop table tbl_payrollSched

insert into tbl_payrollSched (payrollScheduleDescription, payrollScheduleNumberOfDays)
values
	('Monthly', 23),
	('Semi-Monthly', 11)

alter table tbl_salaryRateValue
add isActive bit not null

select * from tbl_status

insert into tbl_status (statusDescription)
values
	('Approved'),
	('Pending'),
	('Denied'),
	('Approved but On Hold'),
	('Approved waiting to be released'),
	('Released and Paid');


create table tbl_listOfWorkingDays
(
	workingDaysListId int identity(1,1) not null primary key,
	payrollId int not null,
	timeLogId int not null unique
	constraint fk_tbl_payrollWorkingDaysList foreign key (payrollId)
	references tbl_payrollForm (payrollId)
	on update cascade,
	constraint fk_tbl_timeLog foreign key (timeLogId)
	references tbl_timeLog (timeLogId)
	on update cascade
)
alter table tbl_witholdingTaxRates
alter column toAnnualSalaryValue decimal(10,2) null

select * from tbl_userRole
select * from tbl_witholdingTaxRates

INSERT INTO tbl_witholdingTaxRates (
    isTaxRateActive,
    taxRateDescription,
    fromAnnualSalaryValue,
    toAnnualSalaryValue,
    percentageToBeDeducted,
    amountToBeDeducted,
    amountExcess, 
    taxRateEffectiveFromYear,
    taxRateEffectiveToYear
)
VALUES 
    (1, '0% Tax Rate for Annual Salary up to 250,000', 0, 250000, 0, 0, 0, 2023, null),
    (1, '15% Tax Rate for Annual Salary Above 250,000 to 400,000 (Excess over 250,000)', 250001, 400000, 15, 0, 250000, 2023, null),
    (1, '20% Tax Rate for Annual Salary Above 400,000 to 800,000 (Excess over 400,000) with a fixed deduction of 22,500', 400001, 800000, 20, 22500, 400000, 2023, null),
    (1, '25% Tax Rate for Annual Salary Above 800,000 to 2,000,000 (Excess over 800,000) with a fixed deduction of 102,500', 800001, 2000000, 25, 102500, 800000, 2023, null),
    (1, '30% Tax Rate for Annual Salary Above 2,000,000 to 8,000,000 (Excess over 2,000,000) with a fixed deduction of 402,500', 2000001, 8000000, 30, 402500, 200000, 2023, null),
    (1, '35% Tax Rate for Annual Salary Above 8,000,000 with a fixed deduction of 2,202,500', 8000001, null, 35, 2202500, 8000000, 2023, null);

SELECT taxRateDescription, percentageToBeDeducted, amountToBeDeducted, amountExcess
FROM tbl_witholdingTaxRates
WHERE isTaxRateActive = 1
  AND 1331138.08 BETWEEN fromAnnualSalaryValue AND COALESCE(toAnnualSalaryValue, 9999999999)
  AND taxRateEffectiveFromYear <= 2023
  AND (taxRateEffectiveToYear IS NULL OR taxRateEffectiveToYear >= 2023)
ORDER BY fromAnnualSalaryValue;

select * from tbl_employee
select * from tbl_appointmentForm
select * from tbl_appointmentFormBenefitsDetails
select * from tbl_timeLog
select max(employeeId) from tbl_employee
SELECT SCOPE_IDENTITY() from tbl_employee AS LastInsertedEmployeeId;
SELECT IDENT_CURRENT('tbl_employee')
delete from tbl_employee
where employeeId = 4

update tbl_employee
set employeeSignature = 'RyanSySantosAgsunta.jpg'
where employeeId = 1

insert into tbl_timeLog (employeeId, dateLog, morningStatus, afternoonStatus)
values (4, GETDATE(), 'Just Got Hired', 'Just Got Hired')

SELECT
    sr.salaryratedescription,
    MAX(CASE WHEN sv.stepId = 1 THEN sv.amount END) AS Step1,
    MAX(CASE WHEN sv.stepId = 2 THEN sv.amount END) AS Step2,
    MAX(CASE WHEN sv.stepId = 3 THEN sv.amount END) AS Step3,
    MAX(CASE WHEN sv.stepId = 4 THEN sv.amount END) AS Step4,
    MAX(CASE WHEN sv.stepId = 5 THEN sv.amount END) AS Step5,
    MAX(CASE WHEN sv.stepId = 6 THEN sv.amount END) AS Step6,
    MAX(CASE WHEN sv.stepId = 7 THEN sv.amount END) AS Step7,
    MAX(CASE WHEN sv.stepId = 8 THEN sv.amount END) AS Step8
FROM tbl_salaryRateValue sv
JOIN tbl_salaryRate sr ON sv.salaryRateId = sr.salaryRateId
JOIN tbl_salaryRateTranche st ON sv.trancheId = st.trancheId
WHERE st.trancheNumber = 4 AND sv.yearEffective = 2023 AND sv.isActive = 1
GROUP BY sr.salaryratedescription, sr.salaryGradeNumber, sv.salaryRateValueId
ORDER BY sr.salaryGradeNumber;

select * from tbl_appointmentForm
select * from tbl_employmentStatus
select * from tbl_payrollSched
select * from tbl_benefitsFormula
select * from tbl_mandatedBenefits
select * from tbl_benefitsContributions
select * from tbl_benefits
select * from tbl_appointmentFormBenefitsDetails
select * from tbl_witholdingTaxRates

23176
4.50
9.50

insert into tbl_appointmentForm (employeeid, salaryRateValueId, salaryRateValueNextStepIncrement, dateCreated, dateHired, dateRetired, employmentStatusId, morningShiftTime, 
afternoonShiftTime, payrollSchedId)
values
	(1, 73, 'December 01, 2026', 'December 01, 2023', 'December 01, 2023', 'December 01, 2053', 1, '8:00 AM - 12:00 AM', '1:00 PM - 5:00 PM', 1);

insert into tbl_appointmentFormBenefitsDetails(appointmentFormId, benefitsId, isBenefitActive, personalShareValue, employerShareValue)
values
	(1, 1, 1, null, null),
	(1, 2, 1, 500, 500),
	(1, 4, 1, 463.52, 463.52),
	(1, 5, 1, 2781.12, 2085.84),
	(1, 6, 1, 1042.92, 2201.72)


INSERT INTO tbl_generalFormula (
    generalFormulaTitle, 
    generalFormulaDescription, 
    generalFormulaExpression
)
VALUES
    ('Percentage Conversion', 'Calculates a specific amount by converting from a percentage of the given salary value.', '([salaryValue] * [percentageNumber]) / 100'),
    ('Converting Monthly to Annual Salary', 'Converts the monthly salary to an annual salary value.', '[monthlySalary] * [numberOfMonthsInAYear]'),
    ('Tax Value Per Month', 'Determines the monthly tax amount based on the total annual tax.', '[totalTax] / [numberOfMonthsInAYear]'),
    ('Withholding Tax Formula', 'Computes the withholding tax amount using a specified tax rate.', '(([basicAnnualSalary] - [amountExcess]) * [percentageToBeDeducted]) / 100 + [amountToBeDeducted]'),
    ('Getting the Basic Annual Salary', 'Obtains the total annual salary by subtracting total annual deductions from the total annual salary value.', '[totalAnnualSalary] - [totalAnnualDeductions]'),
    ('Annual Value Deductions', 'Calculates the total annual value of deductions, considering both personal and employer shares.', '([personalShareValue] + [employerShareValue]) * [numberOfMonthsInAYear]');

select * from tbl_generalFormula
select * from tbl_witholdingTaxRates
update tbl_generalFormula
set generalFormulaExpression = '[totalValue] * [numberOfMonthsInAYear]'
where generalFormulaId = 6

select * from tbl_benefitsFormula
select * from tbl_appointmentForm
select * from tbl_appointmentFormBenefitsDetails
delete from tbl_appointmentFormBenefitsDetails
where detailsId = 13

select isMandated from tbl_mandatedBenefits where benefitsId = (select benefitsId from tbl_appointmentFormBenefitsDetails where detailsId = 2)

update tbl_appointmentFormBenefitsDetails
set employerShareValue = null
where detailsId = 18

SELECT benefits, mb.benefitsId FROM tbl_mandatedBenefits mb join tbl_benefits on mb.benefitsId = tbl_benefits.benefitsId 
WHERE NOT EXISTS (SELECT 1 FROM tbl_appointmentFormBenefitsDetails ab WHERE mb.benefitsId = ab.benefitsId) 
AND (mb.employmentStatusId = (SELECT employmentStatusId FROM tbl_appointmentForm WHERE employeeid = 4) 
or mb.employmentStatusId = (select employmentStatusId from tbl_employmentStatus where employmentStatus = 'Regular'))

select * from tbl_salaryRateStep

select * from tbl_employmentStatusAccess

insert into tbl_employmentStatusAccess (employmentStatusId, roleId, departmentId)
values (2, 4, 5)

delete from tbl_employmentStatusAccess where statusAccessId = 5
update tbl_employmentStatusAccess
set employmentStatusId = 1 where statusAccessId = 12

select roleName from tbl_employmentStatusAccess
join tbl_userRole on tbl_userRole.roleId = tbl_employmentStatusAccess.roleId
join tbl_department on tbl_department.departmentId = tbl_employmentStatusAccess.departmentId
join tbl_employmentStatus on tbl_employmentStatus.employmentStatusId = tbl_employmentStatusAccess.employmentStatusId
where employmentStatus = 'Regular' and tbl_department.departmentId = 1

select count(*) from tbl_employee 
join tbl_userRole on tbl_employee.roleId = tbl_userRole.roleId 
join tbl_department on tbl_employee.departmentId = tbl_department.departmentId 
where roleName = 'Personnel' and departmentName = 'Human Resources Office'

SELECT tbl_employee.employeeId, employeePassword, employeeFname, employeeLname, employeeMname, employeeJobDesc, employeeContactNumber, employeeSex, employeeCivilStatus, nationality, 
employeeBirth, employeeEmailAddress, barangay, municipality, province, zipCode, educationalAttainment, course, nameOfSchool, schoolAddress, departmentName, dateHired, dateRetired, 
employmentStatus, employeePicture, employeeSignature, tbl_employee.isActive, roleName, amount, tbl_appointmentForm.salaryRateValueId, payrollScheduleDescription, morningShiftTime, afternoonShiftTime 
FROM tbl_employee 
JOIN tbl_department ON tbl_employee.departmentId = tbl_department.departmentId 
JOIN tbl_educationalAttainment ON tbl_employee.educationalAttainmentId = tbl_educationalAttainment.educationalAttainmentId 
JOIN tbl_userRole ON tbl_employee.roleId = tbl_userRole.roleId 
JOIN tbl_appointmentForm ON tbl_employee.employeeId = tbl_appointmentForm.employeeId 
JOIN tbl_salaryRateValue ON tbl_appointmentForm.salaryRateValueId = tbl_salaryRateValue.salaryRateValueId 
JOIN tbl_salaryRate on tbl_salaryRateValue.salaryRateId = tbl_salaryRate.salaryRateId 
JOIN tbl_payrollSched ON tbl_appointmentForm.payrollSchedId = tbl_payrollSched.payrollSchedId 
JOIN tbl_employmentStatus ON tbl_appointmentForm.employmentStatusId = tbl_employmentStatus.employmentStatusId WHERE tbl_employee.employeeId = 1

create table tbl_companyDetails
(
	companyDetailsId int not null primary key identity(1,1),
	companyName varchar(100) not null,
	companyAddress varchar(100) not null
)

INSERT INTO tbl_companyDetails (companyName, companyAddress)
VALUES ('Local Government Unit of Initao', 'Jampason, Initao, Misamis Oriental 9022');

select timeLogId, dateLog, morningIn, morningOut, morningStatus, afternoonIn, afternoonOut, afternoonStatus, totalHoursWorked, specialPrivilegeDescription from tbl_timeLog 
left join tbl_specialPrivilege on tbl_timeLog.specialPrivilegeId = tbl_specialPrivilege.specialPrivilegeId 
where employeeId = 4 and dateLog = '11/1/2023'

select * from tbl_timeLog
select * from tbl_department
select * from tbl_userRole
select * from tbl_leave

alter table tbl_leave
drop column dateCreated

select count(*) from tbl_employee 
join tbl_userRole on tbl_employee.roleId = tbl_userRole.roleId 
join tbl_department on tbl_employee.departmentId = tbl_department.departmentId 
where roleName = 'Employee' and departmentName = 'Mayor''s Office' and roleName != 'Employee'

create table tbl_logType
(
	logTypeId int not null identity(1,1) primary key,
	logTypeDescription varchar(100) not null
)

create table tbl_timePeriod
(
	timePeriodId int primary key identity(1,1) not null,
	timePeriodDescription varchar(100) not null
)

create table tbl_timeStatus
(
	timeStatusId int not null identity(1,1) primary key,
	timeStatusDescription varchar(100) not null,
	logTypeId int not null,
	timePeriodId int not null,
	fromTime time not null,
	toTime time not null
	constraint fk_tbl_logTypeStatus foreign key (logTypeId)
	references tbl_logType (logTypeId),
	constraint fk_tbl_timePeriodStatus foreign key (timePeriodId)
	references tbl_timePeriod (timePeriodId)
	on update cascade
)

insert into tbl_logType (logTypeDescription)
values ('In'),
('Out')

insert into tbl_timePeriod (timePeriodDescription)
values
	('A.M'),
	('P.M')

insert into tbl_timeStatus (timeStatusDescription, logTypeId, timePeriodId, fromTime, toTime)
values
	('On Time', 1, 1, '00:00:00', '8:00:00'),
	('On Time', 2, 1, '12:00:00', '12:29:00'),
	('On Time', 1, 2, '12:30:00', '13:00:00'),
	('On Time', 2, 2, '17:00:00', '18:00:00'),
	('Late', 1, 1, '08:01:00', '11:59:00'),
	('Late', 1, 2, '13:01:00', '16:59:00'),
	('Undertime', 2, 1, '08:01:00', '11:59:00'),
	('Undertime', 2, 2, '13:01:00', '04:59:00')

select * from tbl_specialPrivilege
select * from tbl_timeLog

alter table tbl_timeLog
add logTypeId int not null
constraint fk_tbl_timeLogLogType foreign key (logTypeId)
references tbl_logType (logTypeId)
on update cascade

select * from tbl_specialPrivilege
select * from tbl_employee

select * from tbl_timeLog

insert into tbl_timeLog (employeeId, dateLog, timeLog, timePeriodId, logTypeId)
values
	(4, 'November 1, 2023', '8:00 AM', 1, 1),
	(4, 'November 1, 2023', '12:01 PM', 1, 2),
	(4, 'November 1, 2023', '12:40 PM', 2, 1),
	(4, 'November 1, 2023', '5:00 PM', 2, 2)

SELECT
    dateLog,
    employeeId, specialPrivilegeDescription,
    MAX(CASE WHEN timePeriodId = 1 AND logTypeId = 1 THEN timeLog END) AS MorninIn,
    MAX(CASE WHEN timePeriodId = 1 AND logTypeId = 2 THEN timeLog END) AS MorningOut,
    MAX(CASE WHEN timePeriodId = 2 AND logTypeId = 1 THEN timeLog END) AS AfternoonIn,
    MAX(CASE WHEN timePeriodId = 2 AND logTypeId = 2 THEN timeLog END) AS AfternoonOut
FROM
    tbl_timeLog
LEFT JOIN tbl_specialPrivilege on tbl_specialPrivilege.specialPrivilegeId = tbl_timeLog.specialPrivilegeId
WHERE
    employeeId = 4
    AND dateLog = 'November 1, 2023'
GROUP BY
    dateLog,
    employeeId,
	specialPrivilegeDescription;

select * from tbl_timeLog

create table tbl_lateRecord
(
	lateRecordId int not null identity(1,1) primary key,
	timeLogId int not null,
	numberOfMinutes int not null
	constraint fk_tbl_lateLogs foreign key (timeLogId)
	references tbl_timeLog (timeLogId)
	on update cascade
)

create table tbl_overtimeRecord
(
	overtimeRecordId int not null identity(1,1) primary key,
	timeLogId int not null,
	numberOfMinutes int not null
	constraint fk_tbl_overtimeLogs foreign key (timeLogId)
	references tbl_timeLog (timeLogId)
	on update cascade
)

create table tbl_undertimeRecord
(
	undertimeRecordId int not null identity(1,1) primary key,
	timeLogId int not null,
	numberOfMinutes int not null
	constraint fk_tbl_undertimeLogs foreign key (timeLogId)
	references tbl_timeLog (timeLogId)
	on update cascade
)

select sum(numberOfMinutes) from tbl_lateRecord
join tbl_timeLog on tbl_lateRecord.timeLogId = tbl_timeLog.timelogId
where month(dateLog) = 11 and dateLog < GetDate()

select count(*) as leaveCount from tbl_specialPrivilege
join tbl_timeLog on tbl_timeLog.specialPrivilegeId = tbl_specialPrivilege.specialPrivilegeId
where MONTH(dateLog) = 11 and dateLog < GETDATE() and applicationNumber is not null

select * from tbl_specialPrivilege
select * from tbl_timeLog
delete from tbl_timeLog
where employeeId = 1

SELECT
    dateLog,
    employeeId,
    specialPrivilegeDescription, sum(lr.numberOfMinutes) as lateMinutes, sum(ur.numberOfMinutes) as undertimeMinutes, sum(otr.numberOfMinutes) as overtimeMinutes,
    MAX(CASE WHEN timePeriodId = 1 AND logTypeId = 1 THEN timeLog END) AS MorningIn,
    MAX(CASE WHEN timePeriodId = 1 AND logTypeId = 2 THEN timeLog END) AS MorningOut,
    MAX(CASE WHEN timePeriodId = 2 AND logTypeId = 1 THEN timeLog END) AS AfternoonIn,
    MAX(CASE WHEN timePeriodId = 2 AND logTypeId = 2 THEN timeLog END) AS AfternoonOut,
    MAX(CASE WHEN timePeriodId = 1 AND logTypeId = 1 THEN tbl_timeLog.timelogId END) AS MorningInLogId,
    MAX(CASE WHEN timePeriodId = 1 AND logTypeId = 2 THEN tbl_timeLog.timelogId END) AS MorningOutLogId,
    MAX(CASE WHEN timePeriodId = 2 AND logTypeId = 1 THEN tbl_timeLog.timelogId END) AS AfternoonInLogId,
    MAX(CASE WHEN timePeriodId = 2 AND logTypeId = 2 THEN tbl_timeLog.timelogId END) AS AfternoonOutLogId
FROM
    tbl_timeLog
LEFT JOIN tbl_specialPrivilege ON tbl_specialPrivilege.specialPrivilegeId = tbl_timeLog.specialPrivilegeId
LEFT JOIN tbl_lateRecord lr on lr.timeLogId = tbl_timeLog.timeLogId
LEFT JOIN tbl_overtimeRecord otr on otr.timeLogId = tbl_timeLog.timeLogId
LEFT JOIN tbl_undertimeRecord ur on ur.timeLogId = tbl_timeLog.timeLogId
WHERE
    employeeId = 4
    AND dateLog = 'November 1, 2023'
GROUP BY
    dateLog,
    employeeId,
    specialPrivilegeDescription,
	lr.numberOfMinutes,
	ur.numberOfMinutes,
	otr.numberOfMinutes;

select roleName from tbl_employmentStatusAccess 
join tbl_department on tbl_employmentStatusAccess.departmentId = tbl_department.departmentId 
join tbl_userRole on tbl_employmentStatusAccess.roleId = tbl_userRole.roleId 
where roleName != 'Employee' and tbl_department.departmentId = 3

select * from tbl_department
select * from tbl_userRole
select * from tbl_employmentStatusAccess
select * from tbl_employmentStatusAccess where roleId != 5 and departmentId = 1

insert into tbl_employmentStatusAccess (employmentStatusId, roleId, departmentId)
values (1, 2, 3)

delete from tbl_employmentStatusAccess
where roleId = 1