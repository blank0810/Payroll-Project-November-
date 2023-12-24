Select employeefname, employeelname, nameofschool, datehired, employeecontactnumber, employeejobdesc from tbl_employee join tbl_department on tbl_employee.departmentid = 
tbl_department.departmentid join tbl_userrole on tbl_employee.roleid = tbl_userrole.roleid join tbl_appointmentform on tbl_employee.employeeid = tbl_appointmentform.employeeid 
where tbl_department.departmentId = 1 and  rolename = 'Department Head'

SELECT tbl_employee.employeeId, employeePassword, employeeFname, employeeLname, employeeMname, employeeJobDesc, employeeContactNumber, employeeSex, employeeCivilStatus, nationality, 
employeeBirth, employeeEmailAddress, barangay, municipality, province, zipCode, educationalAttainment, course, nameOfSchool, schoolAddress, departmentName, dateHired, dateRetired, 
employmentStatus, employeePicture, employeeSignature, tbl_employee.isActive, roleName, salaryRateDescription, amount, payrollScheduleDescription, morningShiftTime, afternoonShiftTime 
FROM tbl_employee JOIN tbl_department ON tbl_employee.departmentId = tbl_department.departmentId JOIN tbl_educationalAttainment 
ON tbl_employee.educationalAttainmentId = tbl_educationalAttainment.educationalAttainmentId JOIN tbl_userRole ON tbl_employee.roleId = tbl_userRole.roleId 
JOIN tbl_appointmentForm ON tbl_employee.employeeId = tbl_appointmentForm.employeeId JOIN tbl_salaryRateValue 
ON tbl_appointmentForm.salaryRateValueId = tbl_salaryRateValue.salaryRateValueId JOIN tbl_salaryRate on tbl_salaryRateValue.salaryRateId = tbl_salaryRate.salaryRateId
JOIN tbl_payrollSched ON tbl_appointmentForm.payrollSchedId = tbl_payrollSched.payrollSchedId 
JOIN tbl_employmentStatus ON tbl_appointmentForm.employmentStatusId = tbl_employmentStatus.employmentStatusId WHERE tbl_employee.employeeId = 1;

select * from tbl_department
delete from tbl_department
where departmentId = 2

SELECT 
    CONVERT(TIME, DATEADD(SECOND, SUM(DATEDIFF(SECOND, '00:00:00', totalHoursWorked)), '00:00:00')) AS totalHoursWorked
FROM tbl_timeLog
WHERE YEAR(dateLog) = '2023' AND MONTH(dateLog) = '11';

ALTER TABLE tbl_timeLog
ADD totalHoursWorked INT not null;
select * from tbl_employee
select * from tbl_appointmentFormBenefitsDetails
select * from tbl_benefitsContributions

SELECT
    detailsId,
    tbl_benefits.benefitsId,
    benefits,
    isBenefitActive,
    SUM(personalShareValue + employerShareValue) AS benefitValue
FROM
    tbl_appointmentFormBenefitsDetails
JOIN
    tbl_appointmentForm ON tbl_appointmentForm.appointmentFormId = tbl_appointmentFormBenefitsDetails.appointmentFormId
JOIN
    tbl_benefits ON tbl_benefits.benefitsId = tbl_appointmentFormBenefitsDetails.benefitsId
WHERE
    employeeid = 1
GROUP BY
    detailsId, tbl_benefits.benefitsId, benefits, isBenefitActive;

select * from tbl_benefitsFormula

delete from tbl_benefitsFormula
where benefitFormulaId = 2

select * from tbl_generalFormula
select * from tbl_benefits
select * from tbl_benefitsContributions
select * from tbl_benefitsFormula
select * from tbl_appointmentFormBenefitsDetails
select * from tbl_mandatedBenefits

select salaryratedescription from tbl_salaryrate where salaryratedescription not like '%custom%'
select * from tbl_salaryRate

insert into tbl_salaryRate (salaryratedescription, salaryGradeNumber, salaryRateSchedule)
values
	('Salary Grade 29', 29, 'Monthly'),
	('Salary Grade 30', 30, 'Monthly'),
	('Salary Grade 31', 31, 'Monthly'),
	('Salary Grade 32', 32, 'Monthly'),
	('Salary Grade 33', 33, 'Monthly');

update tbl_appointmentFormBenefitsDetails
set personalShareValue = null, employerShareValue = null
where detailsId != 3

update tbl_benefitsFormula
set formulaExpression = '(([personalSharePercentage] + [employerSharePercentage]) * [monthlySalary]) / 100'
where benefitFormulaId = 5

insert into tbl_benefitsFormula (benefitsId, formulaDescription, formulaExpression)
values
	(1, 'Witholding Tax Formula', '(([basicAnnualSalary] - [amountExcess]) * [percentageToBeDeducted]) / 100 + [amountToBeDeducted]')

select isPercentage, personalShareValue, employerShareValue, sum(personalShareValue + employerShareValue) as benefitValue from tbl_benefitsContributions join tbl_benefits on tbl_benefitsContributions.benefitsId = 
tbl_benefits.benefitsId where benefits = 'SSS' and isBenefitContributionActive = 1 group by isPercentage, personalShareValue, employerShareValue

select * from tbl_benefitsFormula where benefitsId = 6


select benefits, employmentStatus from tbl_mandatedBenefits join tbl_benefits on tbl_benefits.benefitsId = tbl_mandatedBenefits.benefitsId
join tbl_employmentStatus on tbl_mandatedBenefits.employmentStatusId = tbl_employmentStatus.employmentStatusId
where employmentStatusDescription = 'Regular'

SELECT benefits
FROM tbl_mandatedBenefits mb
join tbl_benefits on mb.benefitsId = tbl_benefits.benefitsId
WHERE NOT EXISTS (
    SELECT 1
    FROM tbl_appointmentFormBenefitsDetails ab
    WHERE mb.benefitsId = ab.benefitsId
)
AND mb.employmentStatusId = (
    SELECT employmentStatusId
    FROM tbl_appointmentForm
    WHERE employeeid = 4
);

SELECT DISTINCT mb.benefitsId, tbl_benefits.benefits
FROM tbl_mandatedBenefits mb
JOIN tbl_benefits ON mb.benefitsId = tbl_benefits.benefitsId
WHERE mb.employmentStatusId = (SELECT TOP 1 employmentStatusId FROM tbl_appointmentForm WHERE employeeid = 1) -- Specify the desired employeeId
AND NOT EXISTS (
    SELECT 1
    FROM tbl_appointmentFormBenefitsDetails ab
    WHERE ab.benefitsId = mb.benefitsId
);

SELECT DISTINCT mb.benefitsId, tb.benefits
FROM tbl_mandatedBenefits mb
JOIN tbl_benefits tb ON mb.benefitsId = tb.benefitsId
LEFT JOIN tbl_appointmentFormBenefitsDetails ab ON mb.benefitsId = ab.benefitsId
AND ab.appointmentFormId = (SELECT appointmentFormId FROM tbl_appointmentForm WHERE employeeid = 4) -- Specify the desired employeeId
WHERE mb.employmentStatusId = (SELECT TOP 1 employmentStatusId FROM tbl_appointmentForm WHERE employeeid = 4) -- Specify the desired employeeId
AND ab.benefitsId IS NULL;

SELECT benefits
FROM tbl_mandatedBenefits mb
JOIN tbl_benefits b ON mb.benefitsId = b.benefitsId
JOIN tbl_employmentStatus es ON mb.employmentStatusId = es.employmentStatusId
LEFT JOIN tbl_appointmentFormBenefitsDetails ab ON mb.benefitsId = ab.benefitsId
LEFT JOIN tbl_appointmentForm af ON af.appointmentFormId = ab.appointmentFormId
WHERE af.employeeId = 4 -- Specify the desired employeeId
AND af.appointmentFormId IS NULL
AND mb.employmentStatusId = af.employmentStatusId;


select benefits from tbl_appointmentFormBenefitsDetails join tbl_benefits on tbl_appointmentFormBenefitsDetails.benefitsId = tbl_benefits.benefitsId
select * from tbl_appointmentForm

SELECT benefits FROM tbl_mandatedBenefits mb join tbl_benefits on mb.benefitsId = tbl_benefits.benefitsId WHERE NOT EXISTS (SELECT 1 FROM tbl_appointmentFormBenefitsDetails ab 
WHERE mb.benefitsId = ab.benefitsId) AND ( mb.employmentStatusId = (SELECT employmentStatusId FROM tbl_appointmentForm WHERE employeeid = 4) or 
mb.employmentStatusId = (select employmentStatusId from tbl_employmentStatus where employmentStatus = 'Regular'));

select bc.benefitsId, isPercentage, employerShareValue, personalShareValue, sum(personalShareValue + employerShareValue) as totalValue from tbl_benefitsContributions bc
join tbl_benefits b on b.benefitsId = bc.benefitsId 
where bc.benefitsId = (select benefitsId from tbl_benefits where benefits = 'SSS') and isBenefitContributionActive = 1 group by bc.benefitsId, isPercentage, personalShareValue, 
employerShareValue

select * from tbl_benefits

SELECT benefits
FROM tbl_mandatedBenefits mb
JOIN tbl_benefits ON mb.benefitsId = tbl_benefits.benefitsId
WHERE NOT EXISTS (
    SELECT 1
    FROM tbl_appointmentFormBenefitsDetails ab
    WHERE mb.benefitsId = ab.benefitsId
)
AND mb.employmentStatusId = (
    SELECT employmentStatusId
    FROM tbl_appointmentForm
    WHERE employeeid = 4
);

ALTER TABLE tbl_salaryRate
ADD salaryRateSchedule varchar(200) NOT NULL DEFAULT 'Monthly';

update tbl_salaryRate
set salaryRateSchedule = 'Monthly'

select * from tbl_employmentStatusAccess
select * from tbl_department
delete from tbl_department where departmentId = 4
select * from tbl_userRole
select * from tbl_mandatedBenefits
select * from tbl_appointmentForm
select * from tbl_employmentStatusAccess
select * from tbl_userRole
select * from tbl_bonus

select isPercentage, benefits from tbl_mandatedBenefits join tbl_benefits on tbl_mandatedBenefits.benefitsId = tbl_benefits.benefitsId 
join tbl_employmentStatus on tbl_employmentStatus.employmentStatusId = tbl_mandatedBenefits.employmentStatusId
left join tbl_benefitsContributions on tbl_mandatedBenefits.benefitsId = tbl_benefitsContributions.benefitsId and isBenefitContributionActive = 1
where employmentStatus = 'Regular' and isMandated = 1

SELECT isPercentage, benefits
FROM tbl_mandatedBenefits
JOIN tbl_benefits ON tbl_mandatedBenefits.benefitsId = tbl_benefits.benefitsId
JOIN tbl_employmentStatus ON tbl_employmentStatus.employmentStatusId = tbl_mandatedBenefits.employmentStatusId
LEFT JOIN tbl_benefitsContributions ON tbl_mandatedBenefits.benefitsId = tbl_benefitsContributions.benefitsid AND isBenefitContributionActive = 1
WHERE employmentStatus = 'Regular' AND isMandated = 1;


select * from tbl_mandatedBenefits
select * from tbl_benefitsContributions
select * from tbl_contractLength

insert into tbl_contractLength (employmentStatusId, numberOfMonths, numberOfYears)
values (2, 6, 0);

insert into tbl_employmentStatusAccess (employmentStatusId, roleId)
values (2, 5)

update tbl_contractLength
set numberOfYears = null

select * from tbl_benefits

select * from tbl_userRole

select * from tbl_employee

insert into tbl_employmentStatusAccess (employmentStatusId, roleId)
values (1, 2)

select * from tbl_salaryRate
select * from tbl_employee
delete from tbl_salaryRate
where salaryRateId = 34

select * from tbl_userRole
select * from tbl_department

select * from tbl_employmentStatusAccess
select * from tbl_department

select roleName from tbl_employmentStatusAccess
join tbl_department on tbl_employmentStatusAccess.departmentId = tbl_department.departmentId
join tbl_userRole on tbl_employmentStatusAccess.roleId = tbl_userRole.roleId
join tbl_employmentStatus on tbl_employmentStatusAccess.employmentStatusId = tbl_employmentStatus.employmentStatusId
where employmentStatus = 'Regular' and departmentName = 'Commison On Audit'

select roleName from tbl_employmentStatusAccess 
join tbl_userRole on tbl_userRole.roleId = tbl_employmentStatusAccess.roleId 
join tbl_department on tbl_department.departmentId = tbl_employmentStatusAccess.departmentId 
join tbl_employmentStatus on tbl_employmentStatus.employmentStatusId = tbl_employmentStatusAccess.employmentStatusId 
where employmentStatus = 'Job Order' and tbl_department.departmentName = 'Mayor''s Office'

select salaryRateDescription, salaryRateStepDescription, amount from tbl_salaryRateValue 
join tbl_salaryRate on tbl_salaryRate.salaryRateId = tbl_salaryRateValue.salaryRateId 
left join tbl_salaryRateStep on tbl_salaryRateStep.stepId = tbl_salaryRateValue.stepId where salaryRateValueId = 300

select * from tbl_salaryRateValue
update tbl_salaryRateValue
set trancheId = 4, yearEffective = 2023 where salaryRateValueId = 300

SELECT amount FROM tbl_salaryRateValue sv 
JOIN tbl_salaryRate sr ON sv.salaryRateId = sr.salaryRateId 
LEFT JOIN tbl_salaryRateStep st ON st.stepId = sv.stepId 
LEFT JOIN tbl_salaryRateTranche srt ON srt.trancheId = sv.trancheId 
WHERE sr.salaryRateId = 35 AND (null IS NULL OR sv.stepId = 1) AND srt.isTrancheUsed = 1;

select amount from tbl_salaryRateValue
join tbl_salaryRate on tbl_salaryRateValue.salaryRateId = tbl_salaryRate.salaryRateId
left join tbl_salaryRateStep on tbl_salaryRateValue.stepId = tbl_salaryRateStep.stepId
left join tbl_salaryRateTranche on tbl_salaryRateValue.trancheId = tbl_salaryRateTranche.trancheId
where tbl_salaryRate.salaryRateId = 35 and tbl_salaryRateValue.stepId is null and isTrancheUsed = 1

select * from tbl_employee
select * from tbl_deductionDetails
select * from tbl_appointmentFormBenefitsDetails
delete from tbl_appointmentFormBenefitsDetails where appointmentFormId = 6

select * from tbl_employeeLeaveCredits
select * from tbl_payrollSched
select * from tbl_employmentStatus
select * from tbl_leaveType
delete from tbl_employeeLeaveCredits
where employeeLeaveCreditsId = 16

select * from tbl_employeePassSlipHours

select roleName from tbl_employmentStatusAccess
join tbl_department on tbl_employmentStatusAccess.departmentId = tbl_department.departmentId
join tbl_userRole on tbl_employmentStatusAccess.roleId = tbl_userRole.roleId
where roleName != 'Employee' and tbl_department.departmentId = 5

create table tbl_employmentSalaryScheduleAvailable
(
	scheduleId int not null identity(1,1) primary key,
	employmentStatusId int not null,
	payrollSchedId int not null
	constraint fk_tbl_employmentStatusSchedule foreign key (employmentStatusId)
	references tbl_employmentStatus (employmentStatusId),
	constraint fk_tbl_payrollScheduleEmployment foreign key (payrollSchedId)
	references tbl_payrollSched (payrollSchedId)
	on update cascade
)

insert into tbl_employmentSalaryScheduleAvailable (employmentStatusId, payrollSchedId)
values (1, 1),
		(1, 2),
		(2, 2)

select * from tbl_payrollSched
select * from tbl_employmentStatus
select * from tbl_employee
select * from tbl_payrollForm
select * from tbl_appointmentFormBenefitsDetails
select * from tbl_appointmentForm
select * from tbl_earningsList
select * from tbl_deductionDetails
select * from tbl_allowanceList
select * from tbl_payrollSched
select * from tbl_employeeAllowance
select * from tbl_listOfWorkingDays
select * from tbl_payrollTransactionLog
select * from tbl_systemLogs
select * from tbl_leave

select concat(employeeFname, ' ', employeeLname) as employeeName, employmentStatus, pf.dateCreated, payrollStartingDate, payrollEndingDate, salaryRateDescription, salaryRateValue, totalEarnings, 
totalDeduction, netamount, createdBy, isCertifyByOfficeHead, certifiedByOfficeHeadName, certifiedByOfficeHeadDate, isApproveByMayor, approvedByMayorName, approvedByMayorDate, isCertifiedByTreasurer, 
certifiedByTreasurerName, certifiedByTreasurerDate, isReleased, releasedDate, statusDescription from tbl_payrollForm pf
join tbl_employee e on e.employeeId = pf.employeeId
join tbl_status s on s.statusId = pf.statusId
join tbl_appointmentForm af on e.employeeId = af.employeeid
join tbl_employmentStatus es on es.employmentStatusId = af.employmentStatusId
where pf.payrollId = 4

select * from tbl_payrollForm
select * from tbl_earningsList
select * from tbl_deductionDetails

delete from tbl_payrollForm
delete from tbl_earningsList
delete from tbl_deductionDetails


alter table tbl_deductionDetails
drop column timeLogId

select departmentName, count(*) as requestCount from tbl_payrollForm pf
join tbl_employee e on pf.employeeId = e.employeeId
join tbl_department d on e.departmentId = d.departmentId
where (pf.isCertifyByOfficeHead is null and pf.isApproveByMayor is null) or (pf.isCertifyByOfficeHead is null and pf.isApproveByMayor is null and departmentName = 'Commison On Audit')
group by departmentName



select concat(employeeFname, ' ', employeeLname) as employeeName, payrollId, employeePicture, departmentName, netAmount from tbl_payrollForm pf
join tbl_employee e on pf.employeeId = e.employeeId
join tbl_department d on d.departmentId = e.departmentId
where departmentName = 'Commison on Audit' 

SELECT 
    CONCAT(e.employeeFname, ' ', e.employeeLname) AS employeeName,
    pf.payrollFormId,
    pf.netAmount,
    pf.totalDeduction,
    pf.totalEarnings,
    pf.dateCreated,
    e.employeeId,
	e.employeeJobDesc
FROM 
    tbl_payrollForm pf
    JOIN tbl_employee e ON pf.employeeId = e.employeeId
    JOIN tbl_department d ON d.departmentId = e.departmentId
WHERE 
    d.departmentName = 'Commison on Audit' and pf.isApproveByMayor is null and pf.isCertifyByOfficeHead is null

SELECT 
    SUM(totalDeduction) as totalDeduction,
	SUM(totalEarnings) as totalEarnings,
	SUM(netAmount) as totalNetAmount,
	COUNT(*) as requestCount
FROM 
    tbl_payrollForm pf
    JOIN tbl_employee e ON pf.employeeId = e.employeeId
    JOIN tbl_department d ON d.departmentId = e.departmentId
WHERE 
    d.departmentName = 'Commison on Audit' and pf.isApproveByMayor is null and pf.isCertifyByOfficeHead is null

update tbl_payrollForm 
set isCertifyByOfficeHead = null, certifiedByOfficeHeadName = null, certifiedByOfficeHeadDate = null
where payrollId = 5

update tbl_payrollForm
set isApproveByMayor = 1, approvedByMayorName = '', approvedByMayorDate = '', statusId = (select statusId from tbl_status where statusDescription = @description)
where payrollFormId = @id


alter table tbl_deductionDetails
add detailsId int not null
constraint fk_tbl_deductionDetails foreign key (detailsId)
references tbl_appointmentFormBenefitsDetails (detailsId)

select count(*) from tbl_deductionDetails
join tbl_payrollForm on tbl_deductionDetails.payrollId = tbl_payrollForm.payrollId
where MONTH(dateCreated) = 11 and detailsId = 1

alter table tbl_leave


insert into tbl_employeeAllowance (allowanceListId, employeeId)

select specifiedDay from tbl_employmentSalaryScheduleAvailable
join tbl_payrollSched on tbl_employmentSalaryScheduleAvailable.payrollSchedId = tbl_payrollSched.payrollSchedId
join tbl_employmentStatus on tbl_employmentStatus.employmentStatusId = tbl_employmentSalaryScheduleAvailable.employmentStatusId
where employmentStatus = 'Regular'

alter table tbl_payrollForm
add netAmount decimal(10,2) not null


select * from tbl_specialPrivilege
select * from tbl_timeLog
select * from tbl_listOfWorkingDays

alter table tbl_deductionDetails
add personalShare decimal(10, 2) not null

IF EXISTS (
    SELECT 1
    FROM tbl_timeLog t
    WHERE t.timelogId IN (
        SELECT timeLogId 
        FROM tbl_timeLog 
        WHERE dateLog >= 'December 1, 2023' AND dateLog <= 'December 31, 2023'
    )
    AND EXISTS (
        SELECT 1
        FROM tbl_listOfWorkingDays l
        WHERE l.timeLogId = t.timelogId
    )
)
BEGIN
    -- This means there are matching records in tbl_listOfWorkingDays
    PRINT 'There are records in tbl_listOfWorkingDays for the specified date range.';
END
ELSE
BEGIN
    -- No matching records in tbl_listOfWorkingDays
    PRINT 'No records in tbl_listOfWorkingDays for the specified date range.';
END


EXEC sp_rename 
   @objname = 'tbl_payrollForm.isCertifyByOficeHead', 
   @newname = 'isCertifyByOfficeHead', 
   @objtype = 'COLUMN';


ALTER TABLE tbl_payrollSched
ALTER COLUMN scheduleFormula VARCHAR(100) NOT NULL;

update tbl_payrollSched
set scheduleFormula = '[monthlySalary] / [2]' where payrollSchedId = 2

select * from tbl_employee
select * from tbl_timeLog

insert into tbl_timeLog (employeeId, dateLog, morningIn, morningOut, morningStatus, afternoonIn, afternoonOut, afternoonStatus, totalHoursWorked)
values (4, GetDate(), )

DECLARE @startDate DATE = '2023-11-01';
DECLARE @endDate DATE = '2023-11-30';
DECLARE @employeeId INT = 4;

WHILE @startDate <= @endDate
BEGIN
    INSERT INTO tbl_timeLog (employeeId, dateLog, morningIn, morningOut, morningStatus, afternoonIn, afternoonOut, afternoonStatus, totalHoursWorked)
    VALUES (
        @employeeId,
        @startDate,
        CAST(@startDate AS DATETIME) + '08:00:00', -- Morning In
        CAST(@startDate AS DATETIME) + '12:00:00', -- Morning Out
        'On Time', -- Morning Status
        CAST(@startDate AS DATETIME) + '13:00:00', -- Afternoon In
        CAST(@startDate AS DATETIME) + '17:00:00', -- Afternoon Out
        'On Time', -- Afternoon Status
        8 -- Total Hours Worked
    );

    SET @startDate = DATEADD(DAY, 1, @startDate);
END;

select scheduleFormula from tbl_payrollSched where payrollScheduleDescription = 'Monthly'

update tbl_payrollSched
set scheduleFormula = '[monthlySalary] / 2'
where payrollSchedId = 2

alter table tbl_allowanceList
add allowanceDescription varchar(100) not null default 'Personnel Economic Relief Allowance'

create table tbl_employeeAllowanceAccess
(
	employeeAllowanceId int not null identity(1,1) primary key,
	allowanceListId int not null,
	employmentStatusId int not null
	constraint fk_tbl_allowanceAccess foreign key (allowanceListId)
	references tbl_allowanceList (allowanceListId),
	constraint fk_tbl_employmentAllowance foreign key (employmentStatusId)
	references tbl_employmentStatus (employmentStatusId)
	on update cascade
)

insert into tbl_employeeAllowanceAccess (allowanceListId, employmentStatusId)
values (1,1)

select * from tbl_employeeAllowance
select * from tbl_employeeAllowanceAccess
select * from tbl_allowanceList

insert into tbl_employeeAllowance (employeeId, allowanceListId, allowanceValue, isAllowanceEnforced)
values (4, 1, 2000, 1)

select allowanceName, allowanceValue from tbl_employeeAllowance 
join tbl_allowanceList on tbl_employeeAllowance.allowanceListId = tbl_allowanceList.allowanceListId 
join tbl_employee on tbl_employee.employeeId = tbl_employeeAllowance.employeeId 
where tbl_employee.employeeId = 4 and isAllowanceEnforced = 1

alter table tbl_allowanceList
add allowanceMinimumValue decimal(10,2) not null default 2000

select tbl_allowanceList.allowanceListId, allowanceMinimumValue, allowanceName from tbl_employeeAllowanceAccess
join tbl_allowanceList on tbl_employeeAllowanceAccess.allowanceListId = tbl_allowanceList.allowanceListId
join tbl_employmentStatus on tbl_employeeAllowanceAccess.employmentStatusId = tbl_employmentStatus.employmentStatusId
where employmentStatus = 'Regular'

alter table tbl_timeLog
drop column totalHoursWorked

select * from tbl_timeLog
select * from tbl_appointmentForm
select * from tbl_overtimeRecord

select sum(numberOfMinutes) from tbl_undertimeRecord 
join tbl_timeLog on tbl_undertimeRecord.timeLogId = tbl_timeLog.timeLogId 
where month(dateLog) = 11 and dateLog < GETDATE() and employeeId = 4

SELECT timeStatusDescription
FROM tbl_timeStatus
WHERE timePeriodId = (select timePeriodId from tbl_timeLog where timelogId = 66)
  AND logTypeId = (select logTypeId from tbl_timeLog where timelogId = 66)
  AND CAST((select timeLog from tbl_timeLog where timelogId = 66) AS TIME) BETWEEN fromTime AND toTime;
