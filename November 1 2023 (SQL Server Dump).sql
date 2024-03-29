USE [master]
GO
/****** Object:  Database [payrollProject]    Script Date: 01/11/2023 9:05:28 pm ******/
CREATE DATABASE [payrollProject]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'payrollProject', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\payrollProject.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'payrollProject_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\payrollProject_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [payrollProject] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [payrollProject].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [payrollProject] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [payrollProject] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [payrollProject] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [payrollProject] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [payrollProject] SET ARITHABORT OFF 
GO
ALTER DATABASE [payrollProject] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [payrollProject] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [payrollProject] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [payrollProject] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [payrollProject] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [payrollProject] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [payrollProject] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [payrollProject] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [payrollProject] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [payrollProject] SET  ENABLE_BROKER 
GO
ALTER DATABASE [payrollProject] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [payrollProject] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [payrollProject] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [payrollProject] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [payrollProject] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [payrollProject] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [payrollProject] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [payrollProject] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [payrollProject] SET  MULTI_USER 
GO
ALTER DATABASE [payrollProject] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [payrollProject] SET DB_CHAINING OFF 
GO
ALTER DATABASE [payrollProject] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [payrollProject] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [payrollProject] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [payrollProject] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'payrollProject', N'ON'
GO
ALTER DATABASE [payrollProject] SET QUERY_STORE = OFF
GO
USE [payrollProject]
GO
/****** Object:  Table [dbo].[tbl_appointmentForm]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_appointmentForm](
	[appointmentFormId] [int] IDENTITY(1,1) NOT NULL,
	[employeeid] [int] NOT NULL,
	[salaryRateId] [int] NOT NULL,
	[dateCreated] [date] NOT NULL,
	[dateHired] [date] NOT NULL,
	[dateRetired] [datetime] NULL,
	[employmentStatusId] [int] NOT NULL,
	[payrollschedid] [int] NULL,
	[morningShiftTime] [varchar](200) NULL,
	[afternoonShiftTime] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[appointmentFormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_appointmentFormBenefitsDetails]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_appointmentFormBenefitsDetails](
	[detailsId] [int] IDENTITY(1,1) NOT NULL,
	[appointmentFormId] [int] NOT NULL,
	[benefitsId] [int] NOT NULL,
	[benefitsValue] [int] NULL,
	[benefitsPercentageDeduction] [int] NULL,
	[benefitStatus] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[detailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_benefits]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_benefits](
	[benefitsId] [int] IDENTITY(1,1) NOT NULL,
	[benefits] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[benefitsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_bonus]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_bonus](
	[bonusId] [int] IDENTITY(1,1) NOT NULL,
	[employeeId] [int] NOT NULL,
	[bonusName] [varchar](300) NOT NULL,
	[bonusStatus] [varchar](300) NOT NULL,
	[bonusValue] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[bonusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_calendarEvent]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_calendarEvent](
	[eventId] [int] IDENTITY(1,1) NOT NULL,
	[eventDateAdded] [date] NOT NULL,
	[eventName] [varchar](100) NOT NULL,
	[eventDescription] [varchar](max) NULL,
	[memorandumNumber] [varchar](max) NOT NULL,
	[eventAddedBy] [varchar](300) NULL,
	[eventEndDate] [datetime] NULL,
	[eventStartDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[eventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_contractLength]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_contractLength](
	[contractLenthId] [int] IDENTITY(1,1) NOT NULL,
	[employmentStatusId] [int] NOT NULL,
	[numberOfMonths] [int] NULL,
	[numberOfYears] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[contractLenthId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_deductionDetails]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_deductionDetails](
	[deductionId] [int] IDENTITY(1,1) NOT NULL,
	[payrollId] [int] NOT NULL,
	[detailsId] [int] NULL,
	[penaltyId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[deductionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_department]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_department](
	[departmentId] [int] IDENTITY(1,1) NOT NULL,
	[departmentName] [varchar](255) NOT NULL,
	[departmentInitial] [varchar](50) NULL,
	[departmentLogo] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[departmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_earningsList]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_earningsList](
	[earningsListId] [int] IDENTITY(1,1) NOT NULL,
	[timeLogId] [int] NOT NULL,
	[payrollId] [int] NOT NULL,
	[bonusId] [int] NOT NULL,
	[workingDaysId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[earningsListId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_educationalAttainment]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_educationalAttainment](
	[educationalAttainmentId] [int] IDENTITY(1,1) NOT NULL,
	[educationalAttainment] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[educationalAttainmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_employee]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_employee](
	[employeeId] [int] IDENTITY(0,1) NOT NULL,
	[employeePassword] [varchar](max) NOT NULL,
	[employeeFname] [varchar](max) NOT NULL,
	[employeeLname] [varchar](max) NOT NULL,
	[employeeMname] [varchar](max) NULL,
	[employeeBirth] [datetime] NOT NULL,
	[employeeCivilStatus] [varchar](100) NOT NULL,
	[employeeSex] [varchar](100) NOT NULL,
	[employeeContactNumber] [varchar](100) NULL,
	[employeeEmailAddress] [varchar](100) NULL,
	[educationalAttainmentId] [int] NOT NULL,
	[nameOfSchool] [varchar](300) NOT NULL,
	[course] [varchar](300) NOT NULL,
	[schoolAddress] [varchar](300) NOT NULL,
	[departmentId] [int] NOT NULL,
	[employeeJobDesc] [varchar](300) NOT NULL,
	[roleId] [int] NOT NULL,
	[employeePicture] [varchar](max) NOT NULL,
	[employeeSignature] [varchar](max) NOT NULL,
	[nationality] [varchar](100) NULL,
	[barangay] [varchar](100) NULL,
	[municipality] [varchar](100) NULL,
	[province] [varchar](100) NULL,
	[zipCode] [varchar](100) NULL,
	[isActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[employeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_employeeDataLogChanges]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_employeeDataLogChanges](
	[logId] [int] IDENTITY(1,1) NOT NULL,
	[employeeId] [int] NOT NULL,
	[dateLog] [date] NOT NULL,
	[logDescription] [varchar](255) NOT NULL,
	[logCaption] [varchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[logId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_employeeLeaveCredits]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_employeeLeaveCredits](
	[employeeLeaveCreditsId] [int] IDENTITY(1,1) NOT NULL,
	[employeeId] [int] NOT NULL,
	[typeId] [int] NOT NULL,
	[numberOfCredits] [float] NOT NULL,
	[leaveCreditYear] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[employeeLeaveCreditsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_employeePassSlipHours]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_employeePassSlipHours](
	[employeeSlipHoursId] [int] IDENTITY(1,1) NOT NULL,
	[employeeId] [int] NOT NULL,
	[numberOfHours] [int] NOT NULL,
	[month] [int] NOT NULL,
	[year] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[employeeSlipHoursId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_employmentStatus]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_employmentStatus](
	[employmentStatusId] [int] IDENTITY(1,1) NOT NULL,
	[employmentStatus] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[employmentStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_employmentStatusAccess]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_employmentStatusAccess](
	[statusAccessId] [int] IDENTITY(1,1) NOT NULL,
	[employmentStatusId] [int] NOT NULL,
	[roleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[statusAccessId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_eventLog]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_eventLog](
	[logId] [int] IDENTITY(1,1) NOT NULL,
	[eventId] [int] NOT NULL,
	[logDescription] [varchar](300) NULL,
	[logDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[logId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_formLog]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_formLog](
	[logId] [int] IDENTITY(1,1) NOT NULL,
	[logDate] [date] NOT NULL,
	[logDescription] [varchar](300) NOT NULL,
	[leaveId] [int] NULL,
	[travelOrderId] [int] NULL,
	[slipId] [int] NULL,
	[formid] [int] NULL,
	[logCaption] [varchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[logId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_formsDefaultDaysFiling]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_formsDefaultDaysFiling](
	[dayFilingId] [int] IDENTITY(1,1) NOT NULL,
	[formId] [int] NOT NULL,
	[numberOfDays] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[dayFilingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_formType]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_formType](
	[formId] [int] IDENTITY(1,1) NOT NULL,
	[formName] [varchar](300) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[formId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_leave]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_leave](
	[leaveId] [int] IDENTITY(1,1) NOT NULL,
	[applicationNumber] [int] NOT NULL,
	[employeeId] [int] NOT NULL,
	[dateFile] [date] NOT NULL,
	[typeId] [int] NOT NULL,
	[formId] [int] NOT NULL,
	[leaveDetails] [varchar](max) NOT NULL,
	[isRecommended] [bit] NULL,
	[recommendedBy] [varchar](max) NULL,
	[dateRecommended] [date] NULL,
	[isCertified] [bit] NULL,
	[certifiedBy] [varchar](max) NULL,
	[certificationDate] [date] NULL,
	[isApproved] [bit] NULL,
	[approvedBy] [varchar](max) NULL,
	[approvedDate] [date] NULL,
	[withPay] [bit] NULL,
	[statusId] [int] NULL,
	[disapproveReason] [varchar](300) NULL,
	[approvednumberday] [int] NULL,
	[numberOfDays] [int] NOT NULL,
	[leaveStartDate] [date] NOT NULL,
	[leaveEndDate] [date] NOT NULL,
	[creditsUsed] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[leaveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_leaveDefaultCredits]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_leaveDefaultCredits](
	[leaveDefaultCreditsId] [int] IDENTITY(1,1) NOT NULL,
	[typeId] [int] NOT NULL,
	[numberOfCredits] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[leaveDefaultCreditsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_leaveType]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_leaveType](
	[typeId] [int] IDENTITY(1,1) NOT NULL,
	[leaveType] [varchar](300) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[typeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_mandatedBenefits]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_mandatedBenefits](
	[mandatedBenefitsId] [int] IDENTITY(1,1) NOT NULL,
	[employmentStatusId] [int] NOT NULL,
	[benefitsId] [int] NOT NULL,
	[isMandated] [bit] NOT NULL,
	[isPercentage] [bit] NOT NULL,
	[personalShareValue] [int] NULL,
	[employerShareValue] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[mandatedBenefitsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_passSlip]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_passSlip](
	[slipId] [int] IDENTITY(1,1) NOT NULL,
	[slipControlNumber] [int] NOT NULL,
	[employeeId] [int] NOT NULL,
	[dateFile] [date] NOT NULL,
	[slipDate] [date] NOT NULL,
	[slipDestination] [varchar](300) NOT NULL,
	[slipCreatedBy] [varchar](max) NULL,
	[formId] [int] NOT NULL,
	[isApproved] [bit] NULL,
	[approvedBy] [varchar](max) NULL,
	[approvedDate] [date] NULL,
	[statusId] [int] NOT NULL,
	[isNoted] [bit] NULL,
	[slipNotedBy] [varchar](300) NULL,
	[slipNotedDate] [datetime] NULL,
	[deniedReason] [varchar](300) NULL,
	[slipStartingTime] [datetime] NOT NULL,
	[slipEndingTime] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[slipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_payrollForm]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_payrollForm](
	[payrollId] [int] IDENTITY(1,1) NOT NULL,
	[payrollFormId] [int] NOT NULL,
	[employeeId] [int] NOT NULL,
	[dateCreated] [date] NOT NULL,
	[totalEarnings] [int] NOT NULL,
	[totalDeductions] [int] NOT NULL,
	[createdBy] [varchar](300) NOT NULL,
	[isCertified] [bit] NULL,
	[dateCertified] [date] NULL,
	[certifiedBy] [varchar](300) NULL,
	[isApproved] [bit] NULL,
	[approvedDate] [date] NULL,
	[approvedBy] [varchar](300) NULL,
	[isPaymentCertified] [bit] NULL,
	[paymentCertifiedDate] [date] NULL,
	[paymentCertifiedBy] [varchar](300) NULL,
	[isReleased] [bit] NULL,
	[payrollReleaseDate] [date] NULL,
	[statusIdentifier] [int] NOT NULL,
	[statusId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[payrollId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_payrollSched]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_payrollSched](
	[payrollSchedId] [int] IDENTITY(1,1) NOT NULL,
	[payrollSched] [int] NOT NULL,
	[payrollScheduleDescription] [varchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[payrollSchedId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_payrollTransactionLog]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_payrollTransactionLog](
	[transactionLogId] [int] IDENTITY(1,1) NOT NULL,
	[logDate] [date] NOT NULL,
	[payrollId] [int] NOT NULL,
	[logDescription] [varchar](300) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[transactionLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_penalty]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_penalty](
	[penaltyId] [int] IDENTITY(1,1) NOT NULL,
	[timeLogId] [int] NOT NULL,
	[penaltyValue] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[penaltyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_salaryRate]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_salaryRate](
	[salaryRateId] [int] IDENTITY(1,1) NOT NULL,
	[salaryValue] [int] NOT NULL,
	[salaryratedescription] [varchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[salaryRateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_status]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_status](
	[statusId] [int] IDENTITY(1,1) NOT NULL,
	[statusDescription] [varchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[statusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_systemLogs]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_systemLogs](
	[systemLogId] [int] IDENTITY(1,1) NOT NULL,
	[systemLogDate] [date] NOT NULL,
	[systemLogDescription] [varchar](max) NOT NULL,
	[logCaption] [varchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[systemLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_timeDesignation]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_timeDesignation](
	[timeDesignationId] [int] IDENTITY(1,1) NOT NULL,
	[timeDesignation] [time](7) NOT NULL,
	[timeDesignationDescription] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[timeDesignationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_timeEvent]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_timeEvent](
	[timeEventId] [int] IDENTITY(1,1) NOT NULL,
	[timeEvent] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[timeEventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_timeLog]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_timeLog](
	[timelogId] [int] IDENTITY(1,1) NOT NULL,
	[employeeId] [int] NOT NULL,
	[dateLog] [datetime] NOT NULL,
	[morningIn] [datetime] NULL,
	[morningOut] [datetime] NULL,
	[morningStatus] [varchar](200) NULL,
	[afternoonIn] [datetime] NULL,
	[afternoonOut] [datetime] NULL,
	[afternoonStatus] [varchar](200) NULL,
	[totalHoursWorked] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[timelogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_timeStatus]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_timeStatus](
	[timeStatusId] [int] IDENTITY(1,1) NOT NULL,
	[timeStatusDescription] [varchar](300) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[timeStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_travelOrder]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_travelOrder](
	[travelOrderId] [int] IDENTITY(1,1) NOT NULL,
	[orderControlNumber] [int] NOT NULL,
	[employeeId] [int] NOT NULL,
	[dateFiled] [date] NOT NULL,
	[dateDeparture] [date] NOT NULL,
	[departureTime] [time](7) NOT NULL,
	[returnTime] [time](7) NOT NULL,
	[destination] [varchar](100) NOT NULL,
	[purpose] [varchar](max) NOT NULL,
	[remarks] [varchar](max) NOT NULL,
	[statusId] [int] NOT NULL,
	[isApproved] [bit] NULL,
	[approvedBy] [varchar](max) NULL,
	[approvedDate] [date] NULL,
	[formId] [int] NOT NULL,
	[isNoted] [bit] NULL,
	[notedBy] [varchar](300) NULL,
	[notedDate] [date] NULL,
	[createdBy] [varchar](300) NULL,
	[createdDate] [date] NULL,
	[deniedReason] [varchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[travelOrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_userRole]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_userRole](
	[roleId] [int] IDENTITY(0,1) NOT NULL,
	[roleName] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_workingDaysRate]    Script Date: 01/11/2023 9:05:28 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_workingDaysRate](
	[workingDaysId] [int] IDENTITY(1,1) NOT NULL,
	[timeLogId] [int] NOT NULL,
	[hourNumber] [int] NOT NULL,
	[totalValue] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[workingDaysId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_appointmentForm] ON 

INSERT [dbo].[tbl_appointmentForm] ([appointmentFormId], [employeeid], [salaryRateId], [dateCreated], [dateHired], [dateRetired], [employmentStatusId], [payrollschedid], [morningShiftTime], [afternoonShiftTime]) VALUES (1, 1, 2, CAST(N'2023-05-06' AS Date), CAST(N'1998-07-08' AS Date), CAST(N'2023-09-16T00:00:00.000' AS DateTime), 1, 1, N'8:00 AM - 12:00 PM', N'1:00 PM - 5:00 PM')
INSERT [dbo].[tbl_appointmentForm] ([appointmentFormId], [employeeid], [salaryRateId], [dateCreated], [dateHired], [dateRetired], [employmentStatusId], [payrollschedid], [morningShiftTime], [afternoonShiftTime]) VALUES (2, 2, 2, CAST(N'2023-08-28' AS Date), CAST(N'2023-08-28' AS Date), CAST(N'2023-09-01T00:00:00.000' AS DateTime), 1, 2, NULL, NULL)
INSERT [dbo].[tbl_appointmentForm] ([appointmentFormId], [employeeid], [salaryRateId], [dateCreated], [dateHired], [dateRetired], [employmentStatusId], [payrollschedid], [morningShiftTime], [afternoonShiftTime]) VALUES (3, 3, 2, CAST(N'2023-09-09' AS Date), CAST(N'2023-09-09' AS Date), CAST(N'2023-10-11T00:00:00.000' AS DateTime), 1, 1, N'8:00 AM - 12:00 PM', N'1:00 PM - 5:00 PM')
INSERT [dbo].[tbl_appointmentForm] ([appointmentFormId], [employeeid], [salaryRateId], [dateCreated], [dateHired], [dateRetired], [employmentStatusId], [payrollschedid], [morningShiftTime], [afternoonShiftTime]) VALUES (4, 4, 3, CAST(N'2023-09-16' AS Date), CAST(N'2023-09-16' AS Date), NULL, 1, 1, N'8:00 AM - 12:00 PM', N'1:00 PM - 5:00 PM')
SET IDENTITY_INSERT [dbo].[tbl_appointmentForm] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_appointmentFormBenefitsDetails] ON 

INSERT [dbo].[tbl_appointmentFormBenefitsDetails] ([detailsId], [appointmentFormId], [benefitsId], [benefitsValue], [benefitsPercentageDeduction], [benefitStatus]) VALUES (2, 1, 1, 500, NULL, N'Active')
INSERT [dbo].[tbl_appointmentFormBenefitsDetails] ([detailsId], [appointmentFormId], [benefitsId], [benefitsValue], [benefitsPercentageDeduction], [benefitStatus]) VALUES (3, 2, 1, 500, NULL, N'Active')
INSERT [dbo].[tbl_appointmentFormBenefitsDetails] ([detailsId], [appointmentFormId], [benefitsId], [benefitsValue], [benefitsPercentageDeduction], [benefitStatus]) VALUES (4, 1, 2, 500, NULL, N'Active')
INSERT [dbo].[tbl_appointmentFormBenefitsDetails] ([detailsId], [appointmentFormId], [benefitsId], [benefitsValue], [benefitsPercentageDeduction], [benefitStatus]) VALUES (5, 1, 3, 500, NULL, N'Active')
INSERT [dbo].[tbl_appointmentFormBenefitsDetails] ([detailsId], [appointmentFormId], [benefitsId], [benefitsValue], [benefitsPercentageDeduction], [benefitStatus]) VALUES (7, 4, 5, 42, NULL, N'Active')
INSERT [dbo].[tbl_appointmentFormBenefitsDetails] ([detailsId], [appointmentFormId], [benefitsId], [benefitsValue], [benefitsPercentageDeduction], [benefitStatus]) VALUES (8, 4, 2, 200, NULL, N'Active')
INSERT [dbo].[tbl_appointmentFormBenefitsDetails] ([detailsId], [appointmentFormId], [benefitsId], [benefitsValue], [benefitsPercentageDeduction], [benefitStatus]) VALUES (9, 4, 3, 8, NULL, N'Active')
INSERT [dbo].[tbl_appointmentFormBenefitsDetails] ([detailsId], [appointmentFormId], [benefitsId], [benefitsValue], [benefitsPercentageDeduction], [benefitStatus]) VALUES (15, 1, 5, 21, NULL, N'Active')
SET IDENTITY_INSERT [dbo].[tbl_appointmentFormBenefitsDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_benefits] ON 

INSERT [dbo].[tbl_benefits] ([benefitsId], [benefits]) VALUES (1, N'SSS')
INSERT [dbo].[tbl_benefits] ([benefitsId], [benefits]) VALUES (2, N'Pag-ibig')
INSERT [dbo].[tbl_benefits] ([benefitsId], [benefits]) VALUES (3, N'Philhealth')
INSERT [dbo].[tbl_benefits] ([benefitsId], [benefits]) VALUES (5, N'GSIS')
INSERT [dbo].[tbl_benefits] ([benefitsId], [benefits]) VALUES (6, N'Witholding Tax')
INSERT [dbo].[tbl_benefits] ([benefitsId], [benefits]) VALUES (7, N'MP2 Savings')
SET IDENTITY_INSERT [dbo].[tbl_benefits] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_calendarEvent] ON 

INSERT [dbo].[tbl_calendarEvent] ([eventId], [eventDateAdded], [eventName], [eventDescription], [memorandumNumber], [eventAddedBy], [eventEndDate], [eventStartDate]) VALUES (8, CAST(N'2023-08-07' AS Date), N'Party', N'After work Party', N'12231', N'Ryan Santos', CAST(N'2023-08-07T17:00:00.000' AS DateTime), CAST(N'2023-08-07T08:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_calendarEvent] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_contractLength] ON 

INSERT [dbo].[tbl_contractLength] ([contractLenthId], [employmentStatusId], [numberOfMonths], [numberOfYears]) VALUES (1, 2, 6, NULL)
SET IDENTITY_INSERT [dbo].[tbl_contractLength] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_department] ON 

INSERT [dbo].[tbl_department] ([departmentId], [departmentName], [departmentInitial], [departmentLogo]) VALUES (1, N'Human Resources Office', N'HR', N'C:\Users\azuce\OneDrive\Desktop\Capstone Files\Capstone Project\Payroll Project 2\Payroll_Project2\Payroll_Project2\Image\Department Logo\1104982.png')
INSERT [dbo].[tbl_department] ([departmentId], [departmentName], [departmentInitial], [departmentLogo]) VALUES (2, N'Mayor Office', N'HR', N'C:\Users\azuce\OneDrive\Desktop\Capstone Files\Capstone Project\Payroll Project 2\Payroll_Project2\Payroll_Project2\Image\Department Logo\1104982.png')
INSERT [dbo].[tbl_department] ([departmentId], [departmentName], [departmentInitial], [departmentLogo]) VALUES (3, N'Accounting Office', N'Not Applicable', N'C:\Users\azuce\OneDrive\Desktop\Capstone Files\Capstone Project\Payroll Project 2\Payroll_Project2\Payroll_Project2\Image\Department Logo\Accounting Office')
INSERT [dbo].[tbl_department] ([departmentId], [departmentName], [departmentInitial], [departmentLogo]) VALUES (4, N'Vice Mayor Office', N'VM OFFICE', N'C:\Users\azuce\OneDrive\Desktop\Capstone Files\Capstone Project\finalPayrollProject-master\Payroll_Project2\Image\Department Logo\Vice Mayor Office.jpg')
SET IDENTITY_INSERT [dbo].[tbl_department] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_educationalAttainment] ON 

INSERT [dbo].[tbl_educationalAttainment] ([educationalAttainmentId], [educationalAttainment]) VALUES (1, N'Doctor''s Degree')
INSERT [dbo].[tbl_educationalAttainment] ([educationalAttainmentId], [educationalAttainment]) VALUES (2, N'Master''s Degree')
INSERT [dbo].[tbl_educationalAttainment] ([educationalAttainmentId], [educationalAttainment]) VALUES (3, N'Bachelor''s Degree')
INSERT [dbo].[tbl_educationalAttainment] ([educationalAttainmentId], [educationalAttainment]) VALUES (4, N'College Undergraduate')
INSERT [dbo].[tbl_educationalAttainment] ([educationalAttainmentId], [educationalAttainment]) VALUES (5, N'Senior High School Graduate')
INSERT [dbo].[tbl_educationalAttainment] ([educationalAttainmentId], [educationalAttainment]) VALUES (6, N'Senior High School Level')
INSERT [dbo].[tbl_educationalAttainment] ([educationalAttainmentId], [educationalAttainment]) VALUES (7, N'Junior High School Graduate')
INSERT [dbo].[tbl_educationalAttainment] ([educationalAttainmentId], [educationalAttainment]) VALUES (8, N'Junior High School Level')
INSERT [dbo].[tbl_educationalAttainment] ([educationalAttainmentId], [educationalAttainment]) VALUES (9, N'Elementrary Graduate')
INSERT [dbo].[tbl_educationalAttainment] ([educationalAttainmentId], [educationalAttainment]) VALUES (10, N'Elementary Level')
SET IDENTITY_INSERT [dbo].[tbl_educationalAttainment] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_employee] ON 

INSERT [dbo].[tbl_employee] ([employeeId], [employeePassword], [employeeFname], [employeeLname], [employeeMname], [employeeBirth], [employeeCivilStatus], [employeeSex], [employeeContactNumber], [employeeEmailAddress], [educationalAttainmentId], [nameOfSchool], [course], [schoolAddress], [departmentId], [employeeJobDesc], [roleId], [employeePicture], [employeeSignature], [nationality], [barangay], [municipality], [province], [zipCode], [isActive]) VALUES (1, N'1', N'Ryan Sy', N'Santos', N'Agsunta', CAST(N'2000-08-01T00:00:00.000' AS DateTime), N'Single', N'Male', N'09050346101', N'personnel@gmail.com', 1, N'MSU Naawan', N'Bs Human Resource', N'Region X Misamis Oriental Naawan', 1, N'Developer', 2, N'C:\Users\azuce\Desktop\Capstone Files\Capstone Project\finalPayrollProject-master\Payroll_Project2\Image\User Images\Ryan SySantosAgsunta.jpg', N'C:\Users\azuce\Desktop\Capstone Files\Capstone Project\finalPayrollProject-master\Payroll_Project2\Image\User Signatures\Ryan SySantos.jpg', N'Filipino', N'Tubigan', N'Initao', N'Misamis Oriental', N'9022', 1)
INSERT [dbo].[tbl_employee] ([employeeId], [employeePassword], [employeeFname], [employeeLname], [employeeMname], [employeeBirth], [employeeCivilStatus], [employeeSex], [employeeContactNumber], [employeeEmailAddress], [educationalAttainmentId], [nameOfSchool], [course], [schoolAddress], [departmentId], [employeeJobDesc], [roleId], [employeePicture], [employeeSignature], [nationality], [barangay], [municipality], [province], [zipCode], [isActive]) VALUES (2, N'samanthaalburo', N'Lyka Mae', N'Alburo', N'Padayao', CAST(N'2000-02-01T00:00:00.000' AS DateTime), N'Single', N'Female', N'1888271', N'sam@gmail.com', 8, N'Tubigan Elem. School', N'N/A', N'Tubigan Initao', 1, N'Secretary', 4, N'C:\Users\azuce\OneDrive\Desktop\Capstone Files\Capstone Project\finalPayrollProject-master\Payroll_Project2\Image\User Images\Lyka MaeAlburoPadayao.jpg', N'C:\Users\azuce\OneDrive\Desktop\Capstone Files\Capstone Project\finalPayrollProject-master\Payroll_Project2\Image\User Signatures\Lyka MaeAlburo.jpg', N'Filipino', N'Tubigan', N'Initao', N'Misamis Oriental', N'9022', 1)
INSERT [dbo].[tbl_employee] ([employeeId], [employeePassword], [employeeFname], [employeeLname], [employeeMname], [employeeBirth], [employeeCivilStatus], [employeeSex], [employeeContactNumber], [employeeEmailAddress], [educationalAttainmentId], [nameOfSchool], [course], [schoolAddress], [departmentId], [employeeJobDesc], [roleId], [employeePicture], [employeeSignature], [nationality], [barangay], [municipality], [province], [zipCode], [isActive]) VALUES (3, N'3', N'Trisha Jane', N'Bangcong', N'Andaya', CAST(N'2000-10-29T00:00:00.000' AS DateTime), N'Married', N'Female', N'0975260924', N'trishajane@gmail.com', 8, N'Lugait High School', N'N/A', N'Lugait', 1, N'Secretary', 3, N'C:\Users\azuce\OneDrive\Desktop\Capstone Files\Capstone Project\finalPayrollProject-master\Payroll_Project2\Image\User Images\Trisha JaneBangcongAndaya.jpg', N'C:\Users\azuce\OneDrive\Desktop\Capstone Files\Capstone Project\finalPayrollProject-master\Payroll_Project2\Image\User Signatures\Trisha JaneBangcongAndaya.jpg', N'Fil-Am', N'Upper Talacogon', N'Lugait', N'Mis. Or.', N'9025', 1)
INSERT [dbo].[tbl_employee] ([employeeId], [employeePassword], [employeeFname], [employeeLname], [employeeMname], [employeeBirth], [employeeCivilStatus], [employeeSex], [employeeContactNumber], [employeeEmailAddress], [educationalAttainmentId], [nameOfSchool], [course], [schoolAddress], [departmentId], [employeeJobDesc], [roleId], [employeePicture], [employeeSignature], [nationality], [barangay], [municipality], [province], [zipCode], [isActive]) VALUES (4, N'4', N'Riza Mae', N'Nevesaga', N'Fajardo', CAST(N'2000-02-01T00:00:00.000' AS DateTime), N'Married', N'Female', N'1', N'rizamae@gmail.com', 7, N'Libertad National High School', N'N/A', N'Poblacion Libertad', 1, N'Secretary', 4, N'C:\Users\azuce\Desktop\Capstone Files\Capstone Project\finalPayrollProject-master\Payroll_Project2\Image\User Images\Riza MaeNevesagaFajardo.jpg', N'C:\Users\azuce\Desktop\Capstone Files\Capstone Project\finalPayrollProject-master\Payroll_Project2\Image\User Signatures\Riza MaeNevesagaFajardo.jpg', N'Filipino', N'Poblacion', N'Libertad', N'Misamis Oriental', N'9021', 1)
SET IDENTITY_INSERT [dbo].[tbl_employee] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_employeeDataLogChanges] ON 

INSERT [dbo].[tbl_employeeDataLogChanges] ([logId], [employeeId], [dateLog], [logDescription], [logCaption]) VALUES (1, 2, CAST(N'2023-08-28' AS Date), N'The personnel Ryan Santos added Samantha Alburo as a new employee. Date and time added is Monday, 28 August 2023 11:56 am', N'New Employee Added')
INSERT [dbo].[tbl_employeeDataLogChanges] ([logId], [employeeId], [dateLog], [logDescription], [logCaption]) VALUES (2, 2, CAST(N'2023-08-30' AS Date), N'Personal details updated by Ryan Santos. Date and time of update: Wednesday, 30 August 2023 2:20 pm', N'Employee Data Update')
INSERT [dbo].[tbl_employeeDataLogChanges] ([logId], [employeeId], [dateLog], [logDescription], [logCaption]) VALUES (3, 2, CAST(N'2023-08-30' AS Date), N'Personal details updated by Ryan Santos. Date and time of update: Wednesday, 30 August 2023 2:21 pm', N'Employee Data Update')
INSERT [dbo].[tbl_employeeDataLogChanges] ([logId], [employeeId], [dateLog], [logDescription], [logCaption]) VALUES (4, 2, CAST(N'2023-08-30' AS Date), N'Personal details updated by Ryan Santos. Date and time of update: Wednesday, 30 August 2023 2:21 pm', N'Employee Data Update')
INSERT [dbo].[tbl_employeeDataLogChanges] ([logId], [employeeId], [dateLog], [logDescription], [logCaption]) VALUES (5, 2, CAST(N'2023-08-30' AS Date), N'Personal details updated by Ryan Santos. Date and time of update: Wednesday, 30 August 2023 2:25 pm', N'Employee Data Update')
INSERT [dbo].[tbl_employeeDataLogChanges] ([logId], [employeeId], [dateLog], [logDescription], [logCaption]) VALUES (6, 1, CAST(N'2023-08-30' AS Date), N'Personal details updated by Ryan Sy Santos. Date and time of update: Wednesday, 30 August 2023 6:31 pm', N'Employee Data Update')
INSERT [dbo].[tbl_employeeDataLogChanges] ([logId], [employeeId], [dateLog], [logDescription], [logCaption]) VALUES (7, 1, CAST(N'2023-08-31' AS Date), N'Personal details updated by Ryan Sy Santos. Date and time of update: Thursday, 31 August 2023 8:25 pm', N'Employee Data Update')
INSERT [dbo].[tbl_employeeDataLogChanges] ([logId], [employeeId], [dateLog], [logDescription], [logCaption]) VALUES (8, 1, CAST(N'2023-08-31' AS Date), N'Personal details updated by Ryan Sy Santos. Date and time of update: Thursday, 31 August 2023 8:25 pm', N'Employee Data Update')
INSERT [dbo].[tbl_employeeDataLogChanges] ([logId], [employeeId], [dateLog], [logDescription], [logCaption]) VALUES (9, 1, CAST(N'2023-09-01' AS Date), N'Personal details updated by Ryan Sy Santos. Date and time of update: Friday, 1 September 2023 10:06 am', N'Employee Data Update')
INSERT [dbo].[tbl_employeeDataLogChanges] ([logId], [employeeId], [dateLog], [logDescription], [logCaption]) VALUES (10, 2, CAST(N'2023-09-01' AS Date), N'Personal details updated by Ryan Sy Santos. Date and time of update: Friday, 1 September 2023 10:06 am', N'Employee Data Update')
INSERT [dbo].[tbl_employeeDataLogChanges] ([logId], [employeeId], [dateLog], [logDescription], [logCaption]) VALUES (11, 2, CAST(N'2023-09-01' AS Date), N'Personal details updated by Ryan Sy Santos. Date and time of update: Friday, 1 September 2023 10:27 am', N'Employee Data Update')
INSERT [dbo].[tbl_employeeDataLogChanges] ([logId], [employeeId], [dateLog], [logDescription], [logCaption]) VALUES (12, 3, CAST(N'2023-09-09' AS Date), N'The personnel Ryan Sy Santos added Trisha Jane Bangcong as a new employee. Date and time added is Saturday, 9 September 2023 4:07 pm', N'New Employee Added')
INSERT [dbo].[tbl_employeeDataLogChanges] ([logId], [employeeId], [dateLog], [logDescription], [logCaption]) VALUES (13, 1, CAST(N'2023-09-16' AS Date), N'Personal details updated by Ryan Sy Santos. Date and time of update: Saturday, 16 September 2023 11:37 am', N'Employee Data Update')
INSERT [dbo].[tbl_employeeDataLogChanges] ([logId], [employeeId], [dateLog], [logDescription], [logCaption]) VALUES (14, 4, CAST(N'2023-09-16' AS Date), N'The personnel Ryan Sy Santos added Riza Mae Nevesaga as a new employee. Date and time added is Saturday, 16 September 2023 1:54 pm', N'New Employee Added')
INSERT [dbo].[tbl_employeeDataLogChanges] ([logId], [employeeId], [dateLog], [logDescription], [logCaption]) VALUES (15, 3, CAST(N'2023-10-11' AS Date), N'Personal details updated by Ryan Sy Santos. Date and time of update: Wednesday, 11 October 2023 2:00 am', N'Employee Data Update')
INSERT [dbo].[tbl_employeeDataLogChanges] ([logId], [employeeId], [dateLog], [logDescription], [logCaption]) VALUES (16, 3, CAST(N'2023-10-11' AS Date), N'Personal details updated by Ryan Sy Santos. Date and time of update: Wednesday, 11 October 2023 2:15 am', N'Employee Data Update')
INSERT [dbo].[tbl_employeeDataLogChanges] ([logId], [employeeId], [dateLog], [logDescription], [logCaption]) VALUES (17, 1, CAST(N'2023-10-24' AS Date), N'Personal details updated by Ryan Sy Santos. Date and time of update: Tuesday, 24 October 2023 10:15 am', N'Employee Data Update')
SET IDENTITY_INSERT [dbo].[tbl_employeeDataLogChanges] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_employeeLeaveCredits] ON 

INSERT [dbo].[tbl_employeeLeaveCredits] ([employeeLeaveCreditsId], [employeeId], [typeId], [numberOfCredits], [leaveCreditYear]) VALUES (1, 1, 1, 30, 2023)
INSERT [dbo].[tbl_employeeLeaveCredits] ([employeeLeaveCreditsId], [employeeId], [typeId], [numberOfCredits], [leaveCreditYear]) VALUES (2, 1, 2, 30, 2023)
INSERT [dbo].[tbl_employeeLeaveCredits] ([employeeLeaveCreditsId], [employeeId], [typeId], [numberOfCredits], [leaveCreditYear]) VALUES (3, 2, 1, 30, 2023)
INSERT [dbo].[tbl_employeeLeaveCredits] ([employeeLeaveCreditsId], [employeeId], [typeId], [numberOfCredits], [leaveCreditYear]) VALUES (4, 2, 2, 30, 2023)
INSERT [dbo].[tbl_employeeLeaveCredits] ([employeeLeaveCreditsId], [employeeId], [typeId], [numberOfCredits], [leaveCreditYear]) VALUES (5, 3, 1, 30, 2023)
INSERT [dbo].[tbl_employeeLeaveCredits] ([employeeLeaveCreditsId], [employeeId], [typeId], [numberOfCredits], [leaveCreditYear]) VALUES (6, 3, 2, 30, 2023)
INSERT [dbo].[tbl_employeeLeaveCredits] ([employeeLeaveCreditsId], [employeeId], [typeId], [numberOfCredits], [leaveCreditYear]) VALUES (7, 4, 1, 30, 2023)
INSERT [dbo].[tbl_employeeLeaveCredits] ([employeeLeaveCreditsId], [employeeId], [typeId], [numberOfCredits], [leaveCreditYear]) VALUES (8, 4, 2, 30, 2023)
SET IDENTITY_INSERT [dbo].[tbl_employeeLeaveCredits] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_employeePassSlipHours] ON 

INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (1, 1, 4, 1, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (2, 2, 4, 1, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (3, 3, 4, 1, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (4, 4, 4, 1, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (5, 1, 4, 2, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (6, 2, 4, 2, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (7, 3, 4, 2, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (8, 4, 4, 2, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (9, 1, 4, 3, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (10, 2, 4, 3, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (11, 3, 4, 3, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (12, 4, 4, 3, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (13, 1, 4, 4, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (14, 2, 4, 4, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (15, 3, 4, 4, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (16, 4, 4, 4, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (17, 1, 4, 5, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (18, 2, 4, 5, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (19, 3, 4, 5, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (20, 4, 4, 5, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (21, 1, 4, 6, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (22, 2, 4, 6, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (23, 3, 4, 6, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (24, 4, 4, 6, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (25, 1, 4, 7, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (26, 2, 4, 7, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (27, 3, 4, 7, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (28, 4, 4, 7, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (29, 1, 4, 8, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (30, 2, 4, 8, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (31, 3, 4, 8, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (32, 4, 4, 8, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (33, 1, 4, 9, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (34, 2, 4, 9, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (35, 3, 4, 9, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (36, 4, 4, 9, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (37, 1, 4, 10, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (38, 2, 4, 10, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (39, 3, 4, 10, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (40, 4, 4, 10, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (41, 1, 4, 11, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (42, 2, 4, 11, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (43, 3, 4, 11, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (44, 4, 4, 11, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (45, 1, 4, 12, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (46, 2, 4, 12, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (47, 3, 4, 12, 2023)
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [numberOfHours], [month], [year]) VALUES (48, 4, 4, 12, 2023)
SET IDENTITY_INSERT [dbo].[tbl_employeePassSlipHours] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_employmentStatus] ON 

INSERT [dbo].[tbl_employmentStatus] ([employmentStatusId], [employmentStatus]) VALUES (1, N'Regular')
INSERT [dbo].[tbl_employmentStatus] ([employmentStatusId], [employmentStatus]) VALUES (2, N'Job Order')
SET IDENTITY_INSERT [dbo].[tbl_employmentStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_employmentStatusAccess] ON 

INSERT [dbo].[tbl_employmentStatusAccess] ([statusAccessId], [employmentStatusId], [roleId]) VALUES (1, 1, 1)
INSERT [dbo].[tbl_employmentStatusAccess] ([statusAccessId], [employmentStatusId], [roleId]) VALUES (2, 1, 0)
INSERT [dbo].[tbl_employmentStatusAccess] ([statusAccessId], [employmentStatusId], [roleId]) VALUES (3, 1, 2)
INSERT [dbo].[tbl_employmentStatusAccess] ([statusAccessId], [employmentStatusId], [roleId]) VALUES (5, 1, 3)
INSERT [dbo].[tbl_employmentStatusAccess] ([statusAccessId], [employmentStatusId], [roleId]) VALUES (6, 1, 4)
INSERT [dbo].[tbl_employmentStatusAccess] ([statusAccessId], [employmentStatusId], [roleId]) VALUES (7, 2, 4)
SET IDENTITY_INSERT [dbo].[tbl_employmentStatusAccess] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_formLog] ON 

INSERT [dbo].[tbl_formLog] ([logId], [logDate], [logDescription], [leaveId], [travelOrderId], [slipId], [formid], [logCaption]) VALUES (1, CAST(N'2023-10-23' AS Date), N'Leave Request Submitted:||Employee ID who Submitted:  ( ID: 1 )||Submission Date and Time: Monday, 23 October 2023 6:02 pm', 2, NULL, NULL, NULL, N'Application for Leave Request Submission')
INSERT [dbo].[tbl_formLog] ([logId], [logDate], [logDescription], [leaveId], [travelOrderId], [slipId], [formid], [logCaption]) VALUES (2, CAST(N'2023-10-24' AS Date), N'Human Resource Officer who Certified the Request: Ryan Sy Santos ( ID: 1 )||Employee: Ryan Sy Santos (Employee ID: 1 )||Leave Application Number: 1||Certification Date and Time: Tuesday, 24 October 2023 7:48 pm', 2, NULL, NULL, NULL, N'Certification by Human Resource Office for the Application for Leave')
SET IDENTITY_INSERT [dbo].[tbl_formLog] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_formType] ON 

INSERT [dbo].[tbl_formType] ([formId], [formName]) VALUES (1, N'Travel Order')
INSERT [dbo].[tbl_formType] ([formId], [formName]) VALUES (2, N'Application for Leave')
INSERT [dbo].[tbl_formType] ([formId], [formName]) VALUES (3, N'Pass Slip')
INSERT [dbo].[tbl_formType] ([formId], [formName]) VALUES (4, N'Appointment Form')
SET IDENTITY_INSERT [dbo].[tbl_formType] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_leave] ON 

INSERT [dbo].[tbl_leave] ([leaveId], [applicationNumber], [employeeId], [dateFile], [typeId], [formId], [leaveDetails], [isRecommended], [recommendedBy], [dateRecommended], [isCertified], [certifiedBy], [certificationDate], [isApproved], [approvedBy], [approvedDate], [withPay], [statusId], [disapproveReason], [approvednumberday], [numberOfDays], [leaveStartDate], [leaveEndDate], [creditsUsed]) VALUES (2, 1, 1, CAST(N'2023-10-23' AS Date), 1, 2, N'Check up', 1, N'Ryan Sy Santos', CAST(N'2023-10-24' AS Date), 1, N'Ryan Sy Santos', CAST(N'2023-10-24' AS Date), NULL, NULL, NULL, NULL, 2, NULL, NULL, 1, CAST(N'2023-10-24' AS Date), CAST(N'2023-10-25' AS Date), 1)
SET IDENTITY_INSERT [dbo].[tbl_leave] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_leaveDefaultCredits] ON 

INSERT [dbo].[tbl_leaveDefaultCredits] ([leaveDefaultCreditsId], [typeId], [numberOfCredits]) VALUES (1, 1, 30)
INSERT [dbo].[tbl_leaveDefaultCredits] ([leaveDefaultCreditsId], [typeId], [numberOfCredits]) VALUES (2, 2, 30)
SET IDENTITY_INSERT [dbo].[tbl_leaveDefaultCredits] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_leaveType] ON 

INSERT [dbo].[tbl_leaveType] ([typeId], [leaveType]) VALUES (1, N'Sick Leave')
INSERT [dbo].[tbl_leaveType] ([typeId], [leaveType]) VALUES (2, N'Voluntary Leave')
SET IDENTITY_INSERT [dbo].[tbl_leaveType] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_mandatedBenefits] ON 

INSERT [dbo].[tbl_mandatedBenefits] ([mandatedBenefitsId], [employmentStatusId], [benefitsId], [isMandated], [isPercentage], [personalShareValue], [employerShareValue]) VALUES (1, 1, 2, 1, 0, 100, 100)
INSERT [dbo].[tbl_mandatedBenefits] ([mandatedBenefitsId], [employmentStatusId], [benefitsId], [isMandated], [isPercentage], [personalShareValue], [employerShareValue]) VALUES (2, 1, 3, 1, 1, 2, 2)
INSERT [dbo].[tbl_mandatedBenefits] ([mandatedBenefitsId], [employmentStatusId], [benefitsId], [isMandated], [isPercentage], [personalShareValue], [employerShareValue]) VALUES (3, 1, 5, 1, 1, 9, 12)
INSERT [dbo].[tbl_mandatedBenefits] ([mandatedBenefitsId], [employmentStatusId], [benefitsId], [isMandated], [isPercentage], [personalShareValue], [employerShareValue]) VALUES (4, 1, 7, 0, 0, 500, 0)
SET IDENTITY_INSERT [dbo].[tbl_mandatedBenefits] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_payrollSched] ON 

INSERT [dbo].[tbl_payrollSched] ([payrollSchedId], [payrollSched], [payrollScheduleDescription]) VALUES (1, 30, N'Monthly')
INSERT [dbo].[tbl_payrollSched] ([payrollSchedId], [payrollSched], [payrollScheduleDescription]) VALUES (2, 15, N'15 days')
SET IDENTITY_INSERT [dbo].[tbl_payrollSched] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_salaryRate] ON 

INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryValue], [salaryratedescription]) VALUES (2, 100, N'Salary Grade 1')
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryValue], [salaryratedescription]) VALUES (3, 200, N'Salary Grade 2')
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryValue], [salaryratedescription]) VALUES (4, 200, N'Salary Grade 3')
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryValue], [salaryratedescription]) VALUES (17, 80005, N'Custom1')
SET IDENTITY_INSERT [dbo].[tbl_salaryRate] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_status] ON 

INSERT [dbo].[tbl_status] ([statusId], [statusDescription]) VALUES (1, N'Approved')
INSERT [dbo].[tbl_status] ([statusId], [statusDescription]) VALUES (2, N'Pending')
INSERT [dbo].[tbl_status] ([statusId], [statusDescription]) VALUES (3, N'Denied')
SET IDENTITY_INSERT [dbo].[tbl_status] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_systemLogs] ON 

INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (1, CAST(N'2023-08-23' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (2, CAST(N'2023-08-23' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (3, CAST(N'2023-08-23' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (4, CAST(N'2023-08-23' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (5, CAST(N'2023-08-23' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (6, CAST(N'2023-08-23' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (7, CAST(N'2023-08-23' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (8, CAST(N'2023-08-23' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (9, CAST(N'2023-08-23' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (10, CAST(N'2023-08-23' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (11, CAST(N'2023-08-23' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (12, CAST(N'2023-08-23' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (13, CAST(N'2023-08-23' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (14, CAST(N'2023-08-23' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (15, CAST(N'2023-08-23' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (16, CAST(N'2023-08-23' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (17, CAST(N'2023-08-24' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (18, CAST(N'2023-08-25' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (19, CAST(N'2023-08-25' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (20, CAST(N'2023-08-27' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (21, CAST(N'2023-08-28' AS Date), N'The personnel Ryan Santos added Samantha Alburo as a new employee. Date and time added is Monday, 28 August 2023 11:56 am', N'New Employee Added')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (22, CAST(N'2023-08-30' AS Date), N'Employee Ryan Santos has updated the data of Lyka Mae Alburo. Date and time of update: Wednesday, 30 August 2023 2:20 pm', N'Employee Data Update')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (23, CAST(N'2023-08-30' AS Date), N'Employee Ryan Santos has updated the data of Lyka Mae Alburo. Date and time of update: Wednesday, 30 August 2023 2:21 pm', N'Employee Data Update')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (24, CAST(N'2023-08-30' AS Date), N'Employee Ryan Santos has updated the data of Lyka Mae Alburo. Date and time of update: Wednesday, 30 August 2023 2:21 pm', N'Employee Data Update')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (25, CAST(N'2023-08-30' AS Date), N'Employee Ryan Santos has updated the data of Lyka Mae Alburo. Date and time of update: Wednesday, 30 August 2023 2:25 pm', N'Employee Data Update')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (26, CAST(N'2023-08-30' AS Date), N'Employee Ryan Sy Santos has updated the data of Ryan Sy Santos. Date and time of update: Wednesday, 30 August 2023 6:31 pm', N'Employee Data Update')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (27, CAST(N'2023-08-31' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (28, CAST(N'2023-08-31' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (29, CAST(N'2023-08-31' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (30, CAST(N'2023-08-31' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (31, CAST(N'2023-08-31' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (32, CAST(N'2023-08-31' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (33, CAST(N'2023-08-31' AS Date), N'Employee Ryan Sy Santos has updated the data of Ryan Sy Santos. Date and time of update: Thursday, 31 August 2023 8:25 pm', N'Employee Data Update')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (34, CAST(N'2023-08-31' AS Date), N'Employee Ryan Sy Santos has updated the data of Ryan Sy Santos. Date and time of update: Thursday, 31 August 2023 8:25 pm', N'Employee Data Update')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (35, CAST(N'2023-09-01' AS Date), N'Employee Ryan Sy Santos has updated the data of Ryan Sy Santos. Date and time of update: Friday, 1 September 2023 10:06 am', N'Employee Data Update')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (36, CAST(N'2023-09-01' AS Date), N'Employee Ryan Sy Santos has updated the data of Lyka Mae Alburo. Date and time of update: Friday, 1 September 2023 10:06 am', N'Employee Data Update')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (37, CAST(N'2023-09-01' AS Date), N'Employee Ryan Sy Santos has updated the data of Lyka Mae Alburo. Date and time of update: Friday, 1 September 2023 10:27 am', N'Employee Data Update')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (38, CAST(N'2023-09-02' AS Date), N'A new department has been added: ||Personnel Name: Ryan Sy Santos||Department Name: Vice Mayor Office||Date and Time Added: Saturday, 2 September 2023 9:47 am', N'Department Addition')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (39, CAST(N'2023-09-03' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (40, CAST(N'2023-09-03' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (41, CAST(N'2023-09-03' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (42, CAST(N'2023-09-03' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 1.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (43, CAST(N'2023-09-03' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 2.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (44, CAST(N'2023-09-03' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 2.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (45, CAST(N'2023-09-03' AS Date), N'User 1 has made additions or modifications to Daily Time Record (DTR) logs. Employee ID: 2.', N'User Activity: Addition and Modification of Daily Time Record (DTR) Logs')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (46, CAST(N'2023-09-09' AS Date), N'The personnel Ryan Sy Santos added Trisha Jane Bangcong as a new employee. Date and time added is Saturday, 9 September 2023 4:07 pm', N'New Employee Added')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (47, CAST(N'2023-09-16' AS Date), N'Employee Ryan Sy Santos has updated the data of Ryan Sy Santos. Date and time of update: Saturday, 16 September 2023 11:37 am', N'Employee Data Update')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (48, CAST(N'2023-09-16' AS Date), N'The personnel Ryan Sy Santos added Riza Mae Nevesaga as a new employee. Date and time added is Saturday, 16 September 2023 1:54 pm', N'New Employee Added')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (49, CAST(N'2023-10-11' AS Date), N'Employee Ryan Sy Santos has updated the data of Trisha Jane Bangcong. Date and time of update: Wednesday, 11 October 2023 2:00 am', N'Employee Data Update')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (50, CAST(N'2023-10-11' AS Date), N'Employee Ryan Sy Santos has updated the data of Trisha Jane Bangcong. Date and time of update: Wednesday, 11 October 2023 2:15 am', N'Employee Data Update')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (51, CAST(N'2023-10-23' AS Date), N'Leave Request Submitted:||Employee ID Wwho Submitted the request: (Employee ID: 1 )||Submission Date and Time: Monday, 23 October 2023 6:02 pm', N'Application for Leave Request Submission')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (52, CAST(N'2023-10-24' AS Date), N'Employee Ryan Sy Santos has updated the data of Ryan Sy Santos. Date and time of update: Tuesday, 24 October 2023 10:15 am', N'Employee Data Update')
INSERT [dbo].[tbl_systemLogs] ([systemLogId], [systemLogDate], [systemLogDescription], [logCaption]) VALUES (53, CAST(N'2023-10-24' AS Date), N'Human Resource Officer who Certified: Ryan Sy Santos( ID: 1 )||Employee: Ryan Sy Santos (Employee ID: 1 )||Submission Date and Time: Tuesday, 24 October 2023 7:48 pm', N'Certification by Human Resource Office for the Application for Leave')
SET IDENTITY_INSERT [dbo].[tbl_systemLogs] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_timeDesignation] ON 

INSERT [dbo].[tbl_timeDesignation] ([timeDesignationId], [timeDesignation], [timeDesignationDescription]) VALUES (1, CAST(N'08:00:00' AS Time), N'Morning In')
INSERT [dbo].[tbl_timeDesignation] ([timeDesignationId], [timeDesignation], [timeDesignationDescription]) VALUES (2, CAST(N'12:00:00' AS Time), N'Morning Out')
INSERT [dbo].[tbl_timeDesignation] ([timeDesignationId], [timeDesignation], [timeDesignationDescription]) VALUES (3, CAST(N'13:00:00' AS Time), N'Afternoon In')
INSERT [dbo].[tbl_timeDesignation] ([timeDesignationId], [timeDesignation], [timeDesignationDescription]) VALUES (4, CAST(N'17:00:00' AS Time), N'Afternoon Out')
SET IDENTITY_INSERT [dbo].[tbl_timeDesignation] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_timeEvent] ON 

INSERT [dbo].[tbl_timeEvent] ([timeEventId], [timeEvent]) VALUES (1, N'Morning In')
INSERT [dbo].[tbl_timeEvent] ([timeEventId], [timeEvent]) VALUES (2, N'Morning Out')
INSERT [dbo].[tbl_timeEvent] ([timeEventId], [timeEvent]) VALUES (3, N'Afternoon In')
INSERT [dbo].[tbl_timeEvent] ([timeEventId], [timeEvent]) VALUES (4, N'Afternoon Out')
INSERT [dbo].[tbl_timeEvent] ([timeEventId], [timeEvent]) VALUES (7, N'Application for Leave')
INSERT [dbo].[tbl_timeEvent] ([timeEventId], [timeEvent]) VALUES (8, N'Travel Order')
INSERT [dbo].[tbl_timeEvent] ([timeEventId], [timeEvent]) VALUES (9, N'Pass Slip')
INSERT [dbo].[tbl_timeEvent] ([timeEventId], [timeEvent]) VALUES (10, N'Others')
INSERT [dbo].[tbl_timeEvent] ([timeEventId], [timeEvent]) VALUES (11, N'Local Event')
INSERT [dbo].[tbl_timeEvent] ([timeEventId], [timeEvent]) VALUES (12, N'Just Got Hired')
SET IDENTITY_INSERT [dbo].[tbl_timeEvent] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_timeLog] ON 

INSERT [dbo].[tbl_timeLog] ([timelogId], [employeeId], [dateLog], [morningIn], [morningOut], [morningStatus], [afternoonIn], [afternoonOut], [afternoonStatus], [totalHoursWorked]) VALUES (2, 1, CAST(N'2023-08-16T00:00:00.000' AS DateTime), NULL, NULL, N'Just Got Hired', NULL, NULL, N'Just Got Hired', NULL)
INSERT [dbo].[tbl_timeLog] ([timelogId], [employeeId], [dateLog], [morningIn], [morningOut], [morningStatus], [afternoonIn], [afternoonOut], [afternoonStatus], [totalHoursWorked]) VALUES (18, 1, CAST(N'2023-08-01T00:00:00.000' AS DateTime), CAST(N'2023-08-01T08:00:00.000' AS DateTime), CAST(N'2023-08-01T12:00:00.000' AS DateTime), N'On Time', CAST(N'2023-08-01T15:30:00.000' AS DateTime), CAST(N'2023-08-01T17:00:00.000' AS DateTime), N'Late', 5)
INSERT [dbo].[tbl_timeLog] ([timelogId], [employeeId], [dateLog], [morningIn], [morningOut], [morningStatus], [afternoonIn], [afternoonOut], [afternoonStatus], [totalHoursWorked]) VALUES (19, 2, CAST(N'2023-08-28T00:00:00.000' AS DateTime), NULL, NULL, N'Just Got Hired', NULL, NULL, N'Just Got Hired', NULL)
INSERT [dbo].[tbl_timeLog] ([timelogId], [employeeId], [dateLog], [morningIn], [morningOut], [morningStatus], [afternoonIn], [afternoonOut], [afternoonStatus], [totalHoursWorked]) VALUES (20, 1, CAST(N'2023-09-01T00:00:00.000' AS DateTime), CAST(N'2023-09-01T08:00:00.000' AS DateTime), CAST(N'2023-09-01T12:00:00.000' AS DateTime), N'On Time', CAST(N'2023-09-01T12:30:00.000' AS DateTime), CAST(N'2023-09-01T17:00:00.000' AS DateTime), N'On Time', 8)
INSERT [dbo].[tbl_timeLog] ([timelogId], [employeeId], [dateLog], [morningIn], [morningOut], [morningStatus], [afternoonIn], [afternoonOut], [afternoonStatus], [totalHoursWorked]) VALUES (21, 1, CAST(N'2023-09-04T00:00:00.000' AS DateTime), CAST(N'2023-09-04T09:00:00.000' AS DateTime), CAST(N'2023-09-04T12:00:00.000' AS DateTime), N'Late', CAST(N'2023-09-04T13:00:00.000' AS DateTime), CAST(N'2023-09-04T17:00:00.000' AS DateTime), N'On Time', 7)
INSERT [dbo].[tbl_timeLog] ([timelogId], [employeeId], [dateLog], [morningIn], [morningOut], [morningStatus], [afternoonIn], [afternoonOut], [afternoonStatus], [totalHoursWorked]) VALUES (22, 2, CAST(N'2023-09-01T00:00:00.000' AS DateTime), CAST(N'2023-09-01T08:00:00.000' AS DateTime), CAST(N'2023-09-01T11:00:00.000' AS DateTime), N'Undertime', CAST(N'2023-09-01T12:00:00.000' AS DateTime), CAST(N'2023-09-01T17:00:00.000' AS DateTime), N'On Time', 7)
INSERT [dbo].[tbl_timeLog] ([timelogId], [employeeId], [dateLog], [morningIn], [morningOut], [morningStatus], [afternoonIn], [afternoonOut], [afternoonStatus], [totalHoursWorked]) VALUES (23, 3, CAST(N'2023-09-09T00:00:00.000' AS DateTime), NULL, NULL, N'Just Got Hired', NULL, NULL, N'Just Got Hired', NULL)
INSERT [dbo].[tbl_timeLog] ([timelogId], [employeeId], [dateLog], [morningIn], [morningOut], [morningStatus], [afternoonIn], [afternoonOut], [afternoonStatus], [totalHoursWorked]) VALUES (24, 4, CAST(N'2023-09-16T00:00:00.000' AS DateTime), NULL, NULL, N'Just Got Hired', NULL, NULL, N'Just Got Hired', NULL)
SET IDENTITY_INSERT [dbo].[tbl_timeLog] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_timeStatus] ON 

INSERT [dbo].[tbl_timeStatus] ([timeStatusId], [timeStatusDescription]) VALUES (1, N'Absent')
INSERT [dbo].[tbl_timeStatus] ([timeStatusId], [timeStatusDescription]) VALUES (2, N'Late')
INSERT [dbo].[tbl_timeStatus] ([timeStatusId], [timeStatusDescription]) VALUES (3, N'Overtime')
INSERT [dbo].[tbl_timeStatus] ([timeStatusId], [timeStatusDescription]) VALUES (4, N'Undertime')
INSERT [dbo].[tbl_timeStatus] ([timeStatusId], [timeStatusDescription]) VALUES (5, N'On Time')
INSERT [dbo].[tbl_timeStatus] ([timeStatusId], [timeStatusDescription]) VALUES (6, N'On Leave')
INSERT [dbo].[tbl_timeStatus] ([timeStatusId], [timeStatusDescription]) VALUES (7, N'Pass Slip')
INSERT [dbo].[tbl_timeStatus] ([timeStatusId], [timeStatusDescription]) VALUES (8, N'Travel Order')
INSERT [dbo].[tbl_timeStatus] ([timeStatusId], [timeStatusDescription]) VALUES (9, N'Just Hired')
SET IDENTITY_INSERT [dbo].[tbl_timeStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_userRole] ON 

INSERT [dbo].[tbl_userRole] ([roleId], [roleName]) VALUES (0, N'System Administrator')
INSERT [dbo].[tbl_userRole] ([roleId], [roleName]) VALUES (1, N'Mayor')
INSERT [dbo].[tbl_userRole] ([roleId], [roleName]) VALUES (2, N'Personnel')
INSERT [dbo].[tbl_userRole] ([roleId], [roleName]) VALUES (3, N'Department Head')
INSERT [dbo].[tbl_userRole] ([roleId], [roleName]) VALUES (4, N'Employee')
SET IDENTITY_INSERT [dbo].[tbl_userRole] OFF
GO
/****** Object:  Index [unique_penaltyId]    Script Date: 01/11/2023 9:05:28 pm ******/
ALTER TABLE [dbo].[tbl_deductionDetails] ADD  CONSTRAINT [unique_penaltyId] UNIQUE NONCLUSTERED 
(
	[penaltyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__tbl_earn__B06ECBE8B7719F81]    Script Date: 01/11/2023 9:05:28 pm ******/
ALTER TABLE [dbo].[tbl_earningsList] ADD UNIQUE NONCLUSTERED 
(
	[workingDaysId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__tbl_leav__769912DB9F60B9A7]    Script Date: 01/11/2023 9:05:28 pm ******/
ALTER TABLE [dbo].[tbl_leave] ADD UNIQUE NONCLUSTERED 
(
	[applicationNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__tbl_pass__42AF11D836E229BE]    Script Date: 01/11/2023 9:05:28 pm ******/
ALTER TABLE [dbo].[tbl_passSlip] ADD UNIQUE NONCLUSTERED 
(
	[slipControlNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__tbl_payr__F7CD850802B4B54D]    Script Date: 01/11/2023 9:05:28 pm ******/
ALTER TABLE [dbo].[tbl_payrollForm] ADD UNIQUE NONCLUSTERED 
(
	[payrollFormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [unique_timeLog]    Script Date: 01/11/2023 9:05:28 pm ******/
ALTER TABLE [dbo].[tbl_penalty] ADD  CONSTRAINT [unique_timeLog] UNIQUE NONCLUSTERED 
(
	[timeLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__tbl_trav__95A1B95F3A2EB555]    Script Date: 01/11/2023 9:05:28 pm ******/
ALTER TABLE [dbo].[tbl_travelOrder] ADD UNIQUE NONCLUSTERED 
(
	[orderControlNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__tbl_work__6AAA14F6C6620195]    Script Date: 01/11/2023 9:05:28 pm ******/
ALTER TABLE [dbo].[tbl_workingDaysRate] ADD UNIQUE NONCLUSTERED 
(
	[timeLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_appointmentForm]  WITH CHECK ADD  CONSTRAINT [fk_tbl_appointmentFormSalaryRateId] FOREIGN KEY([salaryRateId])
REFERENCES [dbo].[tbl_salaryRate] ([salaryRateId])
GO
ALTER TABLE [dbo].[tbl_appointmentForm] CHECK CONSTRAINT [fk_tbl_appointmentFormSalaryRateId]
GO
ALTER TABLE [dbo].[tbl_appointmentForm]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employeeEmployment] FOREIGN KEY([employmentStatusId])
REFERENCES [dbo].[tbl_employmentStatus] ([employmentStatusId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_appointmentForm] CHECK CONSTRAINT [fk_tbl_employeeEmployment]
GO
ALTER TABLE [dbo].[tbl_appointmentForm]  WITH CHECK ADD  CONSTRAINT [fk_tbl_payrollSchedule] FOREIGN KEY([payrollschedid])
REFERENCES [dbo].[tbl_payrollSched] ([payrollSchedId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_appointmentForm] CHECK CONSTRAINT [fk_tbl_payrollSchedule]
GO
ALTER TABLE [dbo].[tbl_appointmentForm]  WITH CHECK ADD  CONSTRAINT [tbl_employee_appointmentformEmployee] FOREIGN KEY([employeeid])
REFERENCES [dbo].[tbl_employee] ([employeeId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_appointmentForm] CHECK CONSTRAINT [tbl_employee_appointmentformEmployee]
GO
ALTER TABLE [dbo].[tbl_appointmentFormBenefitsDetails]  WITH CHECK ADD  CONSTRAINT [fk_tbl_appointmentForm] FOREIGN KEY([appointmentFormId])
REFERENCES [dbo].[tbl_appointmentForm] ([appointmentFormId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_appointmentFormBenefitsDetails] CHECK CONSTRAINT [fk_tbl_appointmentForm]
GO
ALTER TABLE [dbo].[tbl_appointmentFormBenefitsDetails]  WITH CHECK ADD  CONSTRAINT [fk_tbl_benefits] FOREIGN KEY([benefitsId])
REFERENCES [dbo].[tbl_benefits] ([benefitsId])
GO
ALTER TABLE [dbo].[tbl_appointmentFormBenefitsDetails] CHECK CONSTRAINT [fk_tbl_benefits]
GO
ALTER TABLE [dbo].[tbl_bonus]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employeeId] FOREIGN KEY([employeeId])
REFERENCES [dbo].[tbl_employee] ([employeeId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_bonus] CHECK CONSTRAINT [fk_tbl_employeeId]
GO
ALTER TABLE [dbo].[tbl_deductionDetails]  WITH CHECK ADD  CONSTRAINT [fk_tbl_payrollBenefits] FOREIGN KEY([detailsId])
REFERENCES [dbo].[tbl_appointmentFormBenefitsDetails] ([detailsId])
GO
ALTER TABLE [dbo].[tbl_deductionDetails] CHECK CONSTRAINT [fk_tbl_payrollBenefits]
GO
ALTER TABLE [dbo].[tbl_deductionDetails]  WITH CHECK ADD  CONSTRAINT [tbl_payrollPenalty] FOREIGN KEY([penaltyId])
REFERENCES [dbo].[tbl_penalty] ([penaltyId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_deductionDetails] CHECK CONSTRAINT [tbl_payrollPenalty]
GO
ALTER TABLE [dbo].[tbl_earningsList]  WITH CHECK ADD  CONSTRAINT [fk_tbl_earningsBonus] FOREIGN KEY([bonusId])
REFERENCES [dbo].[tbl_bonus] ([bonusId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_earningsList] CHECK CONSTRAINT [fk_tbl_earningsBonus]
GO
ALTER TABLE [dbo].[tbl_earningsList]  WITH CHECK ADD  CONSTRAINT [fk_tbl_earningsPayroll] FOREIGN KEY([payrollId])
REFERENCES [dbo].[tbl_payrollForm] ([payrollId])
GO
ALTER TABLE [dbo].[tbl_earningsList] CHECK CONSTRAINT [fk_tbl_earningsPayroll]
GO
ALTER TABLE [dbo].[tbl_employee]  WITH CHECK ADD  CONSTRAINT [fk_tbl_department] FOREIGN KEY([departmentId])
REFERENCES [dbo].[tbl_department] ([departmentId])
GO
ALTER TABLE [dbo].[tbl_employee] CHECK CONSTRAINT [fk_tbl_department]
GO
ALTER TABLE [dbo].[tbl_employee]  WITH CHECK ADD  CONSTRAINT [fk_tbl_educationalAttainment] FOREIGN KEY([educationalAttainmentId])
REFERENCES [dbo].[tbl_educationalAttainment] ([educationalAttainmentId])
GO
ALTER TABLE [dbo].[tbl_employee] CHECK CONSTRAINT [fk_tbl_educationalAttainment]
GO
ALTER TABLE [dbo].[tbl_employee]  WITH CHECK ADD  CONSTRAINT [fk_tbl_userRole] FOREIGN KEY([roleId])
REFERENCES [dbo].[tbl_userRole] ([roleId])
GO
ALTER TABLE [dbo].[tbl_employee] CHECK CONSTRAINT [fk_tbl_userRole]
GO
ALTER TABLE [dbo].[tbl_employeeDataLogChanges]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employeeChanges] FOREIGN KEY([employeeId])
REFERENCES [dbo].[tbl_employee] ([employeeId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_employeeDataLogChanges] CHECK CONSTRAINT [fk_tbl_employeeChanges]
GO
ALTER TABLE [dbo].[tbl_employeeLeaveCredits]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employeeLeaveCredits] FOREIGN KEY([employeeId])
REFERENCES [dbo].[tbl_employee] ([employeeId])
GO
ALTER TABLE [dbo].[tbl_employeeLeaveCredits] CHECK CONSTRAINT [fk_tbl_employeeLeaveCredits]
GO
ALTER TABLE [dbo].[tbl_employeeLeaveCredits]  WITH CHECK ADD  CONSTRAINT [fk_tbl_leaveTypeEmployeeCredits] FOREIGN KEY([typeId])
REFERENCES [dbo].[tbl_leaveType] ([typeId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_employeeLeaveCredits] CHECK CONSTRAINT [fk_tbl_leaveTypeEmployeeCredits]
GO
ALTER TABLE [dbo].[tbl_employeePassSlipHours]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employeeIdSlipHours] FOREIGN KEY([employeeId])
REFERENCES [dbo].[tbl_employee] ([employeeId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_employeePassSlipHours] CHECK CONSTRAINT [fk_tbl_employeeIdSlipHours]
GO
ALTER TABLE [dbo].[tbl_employmentStatusAccess]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employmentStatusAccess] FOREIGN KEY([employmentStatusId])
REFERENCES [dbo].[tbl_employmentStatus] ([employmentStatusId])
GO
ALTER TABLE [dbo].[tbl_employmentStatusAccess] CHECK CONSTRAINT [fk_tbl_employmentStatusAccess]
GO
ALTER TABLE [dbo].[tbl_employmentStatusAccess]  WITH CHECK ADD  CONSTRAINT [fk_tbl_roleAccess] FOREIGN KEY([roleId])
REFERENCES [dbo].[tbl_userRole] ([roleId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_employmentStatusAccess] CHECK CONSTRAINT [fk_tbl_roleAccess]
GO
ALTER TABLE [dbo].[tbl_eventLog]  WITH CHECK ADD  CONSTRAINT [fk_tbl_calendarEventLog] FOREIGN KEY([eventId])
REFERENCES [dbo].[tbl_calendarEvent] ([eventId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_eventLog] CHECK CONSTRAINT [fk_tbl_calendarEventLog]
GO
ALTER TABLE [dbo].[tbl_formLog]  WITH CHECK ADD  CONSTRAINT [fk_tbl_formLogType] FOREIGN KEY([formid])
REFERENCES [dbo].[tbl_formType] ([formId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_formLog] CHECK CONSTRAINT [fk_tbl_formLogType]
GO
ALTER TABLE [dbo].[tbl_formLog]  WITH CHECK ADD  CONSTRAINT [fk_tbl_leaveForm] FOREIGN KEY([leaveId])
REFERENCES [dbo].[tbl_leave] ([leaveId])
GO
ALTER TABLE [dbo].[tbl_formLog] CHECK CONSTRAINT [fk_tbl_leaveForm]
GO
ALTER TABLE [dbo].[tbl_formLog]  WITH CHECK ADD  CONSTRAINT [fk_tbl_passSlipForm] FOREIGN KEY([slipId])
REFERENCES [dbo].[tbl_passSlip] ([slipId])
GO
ALTER TABLE [dbo].[tbl_formLog] CHECK CONSTRAINT [fk_tbl_passSlipForm]
GO
ALTER TABLE [dbo].[tbl_formLog]  WITH CHECK ADD  CONSTRAINT [fk_tbl_travelForm] FOREIGN KEY([travelOrderId])
REFERENCES [dbo].[tbl_travelOrder] ([travelOrderId])
GO
ALTER TABLE [dbo].[tbl_formLog] CHECK CONSTRAINT [fk_tbl_travelForm]
GO
ALTER TABLE [dbo].[tbl_formsDefaultDaysFiling]  WITH CHECK ADD  CONSTRAINT [fk_tblFormType_numberOfDays] FOREIGN KEY([formId])
REFERENCES [dbo].[tbl_formType] ([formId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_formsDefaultDaysFiling] CHECK CONSTRAINT [fk_tblFormType_numberOfDays]
GO
ALTER TABLE [dbo].[tbl_leave]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employee_leaveTable] FOREIGN KEY([employeeId])
REFERENCES [dbo].[tbl_employee] ([employeeId])
GO
ALTER TABLE [dbo].[tbl_leave] CHECK CONSTRAINT [fk_tbl_employee_leaveTable]
GO
ALTER TABLE [dbo].[tbl_leave]  WITH CHECK ADD  CONSTRAINT [fk_tbl_leaveFormType] FOREIGN KEY([formId])
REFERENCES [dbo].[tbl_formType] ([formId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_leave] CHECK CONSTRAINT [fk_tbl_leaveFormType]
GO
ALTER TABLE [dbo].[tbl_leave]  WITH CHECK ADD  CONSTRAINT [fk_tbl_leavetype] FOREIGN KEY([typeId])
REFERENCES [dbo].[tbl_leaveType] ([typeId])
GO
ALTER TABLE [dbo].[tbl_leave] CHECK CONSTRAINT [fk_tbl_leavetype]
GO
ALTER TABLE [dbo].[tbl_leave]  WITH CHECK ADD  CONSTRAINT [fk_tbl_tatus] FOREIGN KEY([statusId])
REFERENCES [dbo].[tbl_status] ([statusId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_leave] CHECK CONSTRAINT [fk_tbl_tatus]
GO
ALTER TABLE [dbo].[tbl_leaveDefaultCredits]  WITH CHECK ADD  CONSTRAINT [fk_tbl_leaveTypeCredits] FOREIGN KEY([typeId])
REFERENCES [dbo].[tbl_leaveType] ([typeId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_leaveDefaultCredits] CHECK CONSTRAINT [fk_tbl_leaveTypeCredits]
GO
ALTER TABLE [dbo].[tbl_passSlip]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employeeSlip] FOREIGN KEY([employeeId])
REFERENCES [dbo].[tbl_employee] ([employeeId])
GO
ALTER TABLE [dbo].[tbl_passSlip] CHECK CONSTRAINT [fk_tbl_employeeSlip]
GO
ALTER TABLE [dbo].[tbl_passSlip]  WITH CHECK ADD  CONSTRAINT [fk_tbl_formType] FOREIGN KEY([formId])
REFERENCES [dbo].[tbl_formType] ([formId])
GO
ALTER TABLE [dbo].[tbl_passSlip] CHECK CONSTRAINT [fk_tbl_formType]
GO
ALTER TABLE [dbo].[tbl_passSlip]  WITH CHECK ADD  CONSTRAINT [fk_tbl_passStatus] FOREIGN KEY([statusId])
REFERENCES [dbo].[tbl_status] ([statusId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_passSlip] CHECK CONSTRAINT [fk_tbl_passStatus]
GO
ALTER TABLE [dbo].[tbl_payrollForm]  WITH CHECK ADD  CONSTRAINT [fk_tbl_payrollEmployee] FOREIGN KEY([employeeId])
REFERENCES [dbo].[tbl_employee] ([employeeId])
GO
ALTER TABLE [dbo].[tbl_payrollForm] CHECK CONSTRAINT [fk_tbl_payrollEmployee]
GO
ALTER TABLE [dbo].[tbl_payrollForm]  WITH CHECK ADD  CONSTRAINT [fk_tbl_payrollStatus] FOREIGN KEY([statusId])
REFERENCES [dbo].[tbl_status] ([statusId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_payrollForm] CHECK CONSTRAINT [fk_tbl_payrollStatus]
GO
ALTER TABLE [dbo].[tbl_penalty]  WITH CHECK ADD  CONSTRAINT [fk_tbl_penalty] FOREIGN KEY([timeLogId])
REFERENCES [dbo].[tbl_timeLog] ([timelogId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_penalty] CHECK CONSTRAINT [fk_tbl_penalty]
GO
ALTER TABLE [dbo].[tbl_timeLog]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employee] FOREIGN KEY([employeeId])
REFERENCES [dbo].[tbl_employee] ([employeeId])
GO
ALTER TABLE [dbo].[tbl_timeLog] CHECK CONSTRAINT [fk_tbl_employee]
GO
ALTER TABLE [dbo].[tbl_travelOrder]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employeeTravelOrder] FOREIGN KEY([employeeId])
REFERENCES [dbo].[tbl_employee] ([employeeId])
GO
ALTER TABLE [dbo].[tbl_travelOrder] CHECK CONSTRAINT [fk_tbl_employeeTravelOrder]
GO
ALTER TABLE [dbo].[tbl_travelOrder]  WITH CHECK ADD  CONSTRAINT [fk_tbl_formTypeTravelOrder] FOREIGN KEY([formId])
REFERENCES [dbo].[tbl_formType] ([formId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_travelOrder] CHECK CONSTRAINT [fk_tbl_formTypeTravelOrder]
GO
ALTER TABLE [dbo].[tbl_travelOrder]  WITH CHECK ADD  CONSTRAINT [fk_tbl_statusTravelOrder] FOREIGN KEY([statusId])
REFERENCES [dbo].[tbl_status] ([statusId])
GO
ALTER TABLE [dbo].[tbl_travelOrder] CHECK CONSTRAINT [fk_tbl_statusTravelOrder]
GO
ALTER TABLE [dbo].[tbl_workingDaysRate]  WITH CHECK ADD  CONSTRAINT [fk_tbl_workingTimeLog] FOREIGN KEY([timeLogId])
REFERENCES [dbo].[tbl_timeLog] ([timelogId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_workingDaysRate] CHECK CONSTRAINT [fk_tbl_workingTimeLog]
GO
USE [master]
GO
ALTER DATABASE [payrollProject] SET  READ_WRITE 
GO
