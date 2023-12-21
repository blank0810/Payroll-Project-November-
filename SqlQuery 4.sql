SELECT 
    tbl_employee.employeeid,
    CONCAT(employeeFname, ' ', employeeLname) AS employeeName,
    employeePicture,
    departmentName
FROM 
    tbl_timeLog
JOIN 
    tbl_employee ON tbl_timeLog.employeeId = tbl_employee.employeeId
JOIN 
    tbl_department ON tbl_department.departmentId = tbl_employee.departmentId
WHERE 
    dateLog >= 'November 1, 2023' AND dateLog <= 'November 30, 2023'
    AND tbl_employee.employeeId NOT IN (
        SELECT employeeId 
        FROM tbl_payrollForm 
        WHERE 
            statusId = 2 
            AND payrollStartingDate = 'November 1, 2023'
            AND payrollEndingDate = 'November 30, 2023'
    )
GROUP BY 
    tbl_employee.employeeid, employeeFname, employeeLname,
    employeePicture, departmentName;

SELECT 
    CONCAT(e.employeeFname, ' ', e.employeeLname) AS employeeName,
    pf.payrollFormId,
    e.employeePicture,
    d.departmentName,
    pf.netAmount,
	pf.totalDeduction,
	pf.totalEarnings,
	pf.dateCreated,
	e.employeeId
FROM 
    tbl_payrollForm pf
    JOIN tbl_employee e ON pf.employeeId = e.employeeId
    JOIN tbl_department d ON d.departmentId = e.departmentId
WHERE 
    d.departmentName = 'Commison On Audit' and pf.isApproveByMayor is null and pf.isCertifyByOficeHead is null