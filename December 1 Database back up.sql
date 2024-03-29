USE [master]
GO
/****** Object:  Database [payrollProject]    Script Date: 01/12/2023 7:53:54 pm ******/
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
/****** Object:  Table [dbo].[tbl_appointmentForm]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_appointmentForm](
	[appointmentFormId] [int] IDENTITY(1,1) NOT NULL,
	[employeeid] [int] NOT NULL,
	[salaryRateValueId] [int] NOT NULL,
	[salaryRateValueNextStepIncrement] [date] NOT NULL,
	[dateCreated] [date] NOT NULL,
	[dateHired] [date] NOT NULL,
	[dateRetired] [datetime] NULL,
	[employmentStatusId] [int] NOT NULL,
	[morningShiftTime] [varchar](200) NULL,
	[afternoonShiftTime] [varchar](200) NULL,
	[payrollSchedId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[appointmentFormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_appointmentFormBenefitsDetails]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_appointmentFormBenefitsDetails](
	[detailsId] [int] IDENTITY(1,1) NOT NULL,
	[appointmentFormId] [int] NOT NULL,
	[benefitsId] [int] NOT NULL,
	[isBenefitActive] [bit] NOT NULL,
	[personalShareValue] [decimal](10, 2) NULL,
	[employerShareValue] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[detailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_benefits]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_benefits](
	[benefitsId] [int] IDENTITY(1,1) NOT NULL,
	[benefits] [varchar](100) NOT NULL,
	[benefitsDescription] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[benefitsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_benefitsContributions]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_benefitsContributions](
	[benefitContributionsId] [int] IDENTITY(1,1) NOT NULL,
	[benefitsId] [int] NOT NULL,
	[isBenefitContributionActive] [bit] NOT NULL,
	[isPercentage] [bit] NOT NULL,
	[personalShareValue] [decimal](10, 2) NOT NULL,
	[employerShareValue] [decimal](10, 2) NOT NULL,
	[benefitContributionEffectiveFromYear] [int] NOT NULL,
	[benefitContributionEffectiveToYear] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[benefitContributionsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_benefitsFormula]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_benefitsFormula](
	[benefitFormulaId] [int] IDENTITY(1,1) NOT NULL,
	[benefitsId] [int] NOT NULL,
	[formulaDescription] [varchar](200) NOT NULL,
	[formulaExpression] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[benefitFormulaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_bonus]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_bonus](
	[bonusId] [int] IDENTITY(1,1) NOT NULL,
	[employeeId] [int] NOT NULL,
	[bonusName] [varchar](300) NOT NULL,
	[isBonusActive] [bit] NOT NULL,
	[bonusValue] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[bonusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_calendarEvent]    Script Date: 01/12/2023 7:53:54 pm ******/
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
/****** Object:  Table [dbo].[tbl_contractLength]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_contractLength](
	[contractLengthId] [int] IDENTITY(1,1) NOT NULL,
	[employmentStatusId] [int] NOT NULL,
	[numberOfMonths] [int] NULL,
	[numberOfYears] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[contractLengthId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_deductionDetails]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_deductionDetails](
	[deductionId] [int] IDENTITY(1,1) NOT NULL,
	[payrollId] [int] NOT NULL,
	[timeLogId] [int] NULL,
	[detailsId] [int] NULL,
	[deductionDescription] [varchar](200) NOT NULL,
	[deductionAmount] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[deductionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_department]    Script Date: 01/12/2023 7:53:54 pm ******/
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
/****** Object:  Table [dbo].[tbl_earningsList]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_earningsList](
	[earningsListId] [int] IDENTITY(1,1) NOT NULL,
	[payrollId] [int] NOT NULL,
	[bonusId] [int] NULL,
	[earningsDescription] [varchar](200) NOT NULL,
	[earningsAmount] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[earningsListId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_educationalAttainment]    Script Date: 01/12/2023 7:53:54 pm ******/
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
/****** Object:  Table [dbo].[tbl_employee]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_employee](
	[employeeId] [int] IDENTITY(0,1) NOT NULL,
	[employeePassword] [varchar](max) NOT NULL,
	[isActive] [bit] NOT NULL,
	[employeeFname] [varchar](300) NOT NULL,
	[employeeLname] [varchar](300) NOT NULL,
	[employeeMname] [varchar](300) NULL,
	[nationality] [varchar](100) NOT NULL,
	[barangay] [varchar](100) NOT NULL,
	[municipality] [varchar](100) NOT NULL,
	[province] [varchar](100) NOT NULL,
	[zipCode] [varchar](100) NULL,
	[employeeBirth] [datetime] NOT NULL,
	[employeeCivilStatus] [varchar](100) NOT NULL,
	[employeeSex] [varchar](100) NOT NULL,
	[employeeContactNumber] [varchar](100) NOT NULL,
	[employeeEmailAddress] [varchar](100) NULL,
	[educationalAttainmentId] [int] NOT NULL,
	[nameOfSchool] [varchar](300) NOT NULL,
	[course] [varchar](300) NOT NULL,
	[schoolAddress] [varchar](300) NOT NULL,
	[departmentId] [int] NOT NULL,
	[employeeJobDesc] [varchar](300) NOT NULL,
	[roleId] [int] NOT NULL,
	[employeePicture] [varchar](300) NOT NULL,
	[employeeSignature] [varchar](300) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[employeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_employeeDataLogChanges]    Script Date: 01/12/2023 7:53:54 pm ******/
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
/****** Object:  Table [dbo].[tbl_employeeLeaveCredits]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_employeeLeaveCredits](
	[employeeLeaveCreditsId] [int] IDENTITY(1,1) NOT NULL,
	[employeeId] [int] NOT NULL,
	[typeId] [int] NOT NULL,
	[numberOfCredits] [decimal](10, 2) NOT NULL,
	[leaveCreditYear] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[employeeLeaveCreditsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_employeePassSlipHours]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_employeePassSlipHours](
	[employeeSlipHoursId] [int] IDENTITY(1,1) NOT NULL,
	[employeeId] [int] NOT NULL,
	[month] [int] NOT NULL,
	[year] [int] NOT NULL,
	[numberOfHours] [time](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[employeeSlipHoursId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_employmentStatus]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_employmentStatus](
	[employmentStatusId] [int] IDENTITY(1,1) NOT NULL,
	[employmentStatus] [varchar](100) NOT NULL,
	[employmentStatusDescription] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[employmentStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_employmentStatusAccess]    Script Date: 01/12/2023 7:53:54 pm ******/
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
/****** Object:  Table [dbo].[tbl_eventLog]    Script Date: 01/12/2023 7:53:54 pm ******/
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
/****** Object:  Table [dbo].[tbl_formLog]    Script Date: 01/12/2023 7:53:54 pm ******/
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
/****** Object:  Table [dbo].[tbl_formsDefaultDaysFiling]    Script Date: 01/12/2023 7:53:54 pm ******/
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
/****** Object:  Table [dbo].[tbl_formType]    Script Date: 01/12/2023 7:53:54 pm ******/
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
/****** Object:  Table [dbo].[tbl_generalFormula]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_generalFormula](
	[generalFormulaId] [int] IDENTITY(1,1) NOT NULL,
	[generalFormulaTitle] [varchar](100) NOT NULL,
	[generalFormulaDescription] [varchar](200) NOT NULL,
	[generalFormulaExpression] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[generalFormulaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_leave]    Script Date: 01/12/2023 7:53:54 pm ******/
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
	[leaveDetails] [varchar](300) NOT NULL,
	[createdBy] [varchar](200) NOT NULL,
	[dateCreated] [date] NOT NULL,
	[isRecommended] [bit] NULL,
	[recommendedBy] [varchar](200) NULL,
	[dateRecommended] [date] NULL,
	[isCertified] [bit] NULL,
	[certifiedBy] [varchar](200) NULL,
	[certificationDate] [date] NULL,
	[isApproved] [bit] NULL,
	[approvedBy] [varchar](200) NULL,
	[approvedDate] [date] NULL,
	[withPay] [bit] NULL,
	[statusId] [int] NULL,
	[disapproveReason] [varchar](300) NULL,
	[approvednumberday] [int] NULL,
	[numberOfDays] [int] NOT NULL,
	[leaveStartDate] [date] NOT NULL,
	[leaveEndDate] [date] NOT NULL,
	[creditsUsed] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[leaveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_leaveDefaultCredits]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_leaveDefaultCredits](
	[leaveDefaultCreditsId] [int] IDENTITY(1,1) NOT NULL,
	[typeId] [int] NOT NULL,
	[numberOfCredits] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[leaveDefaultCreditsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_leaveType]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_leaveType](
	[typeId] [int] IDENTITY(1,1) NOT NULL,
	[leaveType] [varchar](200) NOT NULL,
	[leaveDescription] [varchar](300) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[typeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_listOfWorkingDays]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_listOfWorkingDays](
	[workingDaysListId] [int] IDENTITY(1,1) NOT NULL,
	[payrollId] [int] NOT NULL,
	[timeLogId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[workingDaysListId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_mandatedBenefits]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_mandatedBenefits](
	[mandatedBenefitsId] [int] IDENTITY(1,1) NOT NULL,
	[employmentStatusId] [int] NOT NULL,
	[benefitsId] [int] NOT NULL,
	[isMandated] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[mandatedBenefitsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_passSlip]    Script Date: 01/12/2023 7:53:54 pm ******/
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
	[slipCreatedBy] [varchar](200) NULL,
	[formId] [int] NOT NULL,
	[isApproved] [bit] NULL,
	[approvedBy] [varchar](200) NULL,
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
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_payrollForm]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_payrollForm](
	[payrollId] [int] IDENTITY(1,1) NOT NULL,
	[payrollFormId] [int] NOT NULL,
	[employeeId] [int] NOT NULL,
	[dateCreated] [date] NOT NULL,
	[payrollStartingDate] [date] NOT NULL,
	[payrollEndingDate] [date] NOT NULL,
	[salaryRateDescription] [varchar](200) NOT NULL,
	[salaryRateValue] [decimal](10, 2) NOT NULL,
	[totalEarnings] [decimal](10, 2) NOT NULL,
	[totalDeduction] [decimal](10, 2) NOT NULL,
	[createdBy] [varchar](100) NOT NULL,
	[isCertifyByOficeHead] [bit] NULL,
	[certifiedyByOfficeHeadName] [varchar](100) NULL,
	[certifedByOfficeHeadDate] [date] NULL,
	[isApproveByMayor] [bit] NULL,
	[approvedByMayorName] [varchar](100) NULL,
	[approvedByMayorDate] [date] NULL,
	[isCertifiedByTreasurer] [bit] NULL,
	[certifiedByTreasurerName] [varchar](200) NULL,
	[certifiedByTreasurerDate] [date] NULL,
	[isReleased] [bit] NULL,
	[releasedDate] [date] NULL,
	[statusId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[payrollId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_payrollSched]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_payrollSched](
	[payrollSchedId] [int] IDENTITY(1,1) NOT NULL,
	[payrollScheduleDescription] [varchar](200) NOT NULL,
	[payrollScheduleNumberOfDays] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[payrollSchedId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_payrollTransactionLog]    Script Date: 01/12/2023 7:53:54 pm ******/
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
/****** Object:  Table [dbo].[tbl_salaryRate]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_salaryRate](
	[salaryRateId] [int] IDENTITY(1,1) NOT NULL,
	[salaryratedescription] [varchar](300) NOT NULL,
	[salaryGradeNumber] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[salaryRateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_salaryRateStep]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_salaryRateStep](
	[stepId] [int] IDENTITY(1,1) NOT NULL,
	[salaryRateStepDescription] [varchar](300) NOT NULL,
	[stepNumber] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[stepId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_salaryRateTranche]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_salaryRateTranche](
	[trancheId] [int] IDENTITY(1,1) NOT NULL,
	[salaryRateTrancheDescription] [varchar](300) NOT NULL,
	[trancheNumber] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[trancheId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_salaryRateValue]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_salaryRateValue](
	[salaryRateValueId] [int] IDENTITY(1,1) NOT NULL,
	[salaryRateId] [int] NOT NULL,
	[stepId] [int] NULL,
	[trancheId] [int] NULL,
	[amount] [decimal](10, 2) NOT NULL,
	[yearEffective] [int] NULL,
	[isActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[salaryRateValueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_specialPrivilege]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_specialPrivilege](
	[specialPrivilegeId] [int] IDENTITY(1,1) NOT NULL,
	[sppecialPrivilegeLogDate] [date] NOT NULL,
	[applicationNumber] [int] NULL,
	[slipControlNumber] [int] NULL,
	[orderControlNumber] [int] NULL,
	[specialPrivilegeDescription] [varchar](200) NOT NULL,
	[specialPrivilegeRemarks] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[specialPrivilegeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_status]    Script Date: 01/12/2023 7:53:54 pm ******/
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
/****** Object:  Table [dbo].[tbl_systemLogs]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_systemLogs](
	[systemLogId] [int] IDENTITY(1,1) NOT NULL,
	[systemLogDate] [date] NOT NULL,
	[systemLogDescription] [varchar](300) NOT NULL,
	[logCaption] [varchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[systemLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_timeLog]    Script Date: 01/12/2023 7:53:54 pm ******/
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
	[totalHoursWorked] [time](7) NULL,
	[specialPrivilegeId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[timelogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_travelOrder]    Script Date: 01/12/2023 7:53:54 pm ******/
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
	[departureTime] [datetime] NULL,
	[returnTime] [datetime] NULL,
	[destination] [varchar](200) NOT NULL,
	[purpose] [varchar](300) NOT NULL,
	[remarks] [varchar](300) NOT NULL,
	[statusId] [int] NOT NULL,
	[isApproved] [bit] NULL,
	[approvedBy] [varchar](200) NULL,
	[approvedDate] [date] NULL,
	[formId] [int] NOT NULL,
	[isNoted] [bit] NULL,
	[notedBy] [varchar](200) NULL,
	[notedDate] [date] NULL,
	[createdBy] [varchar](200) NULL,
	[createdDate] [date] NULL,
	[deniedReason] [varchar](300) NULL,
PRIMARY KEY CLUSTERED 
(
	[travelOrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_userRole]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_userRole](
	[roleId] [int] IDENTITY(0,1) NOT NULL,
	[roleName] [varchar](255) NOT NULL,
	[roleDescription] [varchar](300) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_witholdingTaxRates]    Script Date: 01/12/2023 7:53:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_witholdingTaxRates](
	[taxRateId] [int] IDENTITY(1,1) NOT NULL,
	[isTaxRateActive] [bit] NOT NULL,
	[taxRateDescription] [varchar](200) NOT NULL,
	[fromAnnualSalaryValue] [decimal](10, 2) NOT NULL,
	[toAnnualSalaryValue] [decimal](10, 2) NULL,
	[percentageToBeDeducted] [decimal](10, 2) NOT NULL,
	[amountToBeDeducted] [decimal](10, 2) NOT NULL,
	[amountExcess] [decimal](10, 2) NOT NULL,
	[taxRateEffectiveFromYear] [int] NOT NULL,
	[taxRateEffectiveToYear] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[taxRateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_appointmentForm] ON 

INSERT [dbo].[tbl_appointmentForm] ([appointmentFormId], [employeeid], [salaryRateValueId], [salaryRateValueNextStepIncrement], [dateCreated], [dateHired], [dateRetired], [employmentStatusId], [morningShiftTime], [afternoonShiftTime], [payrollSchedId]) VALUES (1, 1, 73, CAST(N'2026-12-01' AS Date), CAST(N'2023-12-01' AS Date), CAST(N'2023-12-01' AS Date), CAST(N'2053-12-01T00:00:00.000' AS DateTime), 1, N'8:00 AM - 12:00 AM', N'1:00 PM - 5:00 PM', 1)
SET IDENTITY_INSERT [dbo].[tbl_appointmentForm] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_appointmentFormBenefitsDetails] ON 

INSERT [dbo].[tbl_appointmentFormBenefitsDetails] ([detailsId], [appointmentFormId], [benefitsId], [isBenefitActive], [personalShareValue], [employerShareValue]) VALUES (2, 1, 1, 1, NULL, NULL)
INSERT [dbo].[tbl_appointmentFormBenefitsDetails] ([detailsId], [appointmentFormId], [benefitsId], [isBenefitActive], [personalShareValue], [employerShareValue]) VALUES (3, 1, 2, 1, CAST(500.00 AS Decimal(10, 2)), CAST(500.00 AS Decimal(10, 2)))
INSERT [dbo].[tbl_appointmentFormBenefitsDetails] ([detailsId], [appointmentFormId], [benefitsId], [isBenefitActive], [personalShareValue], [employerShareValue]) VALUES (4, 1, 4, 1, CAST(463.52 AS Decimal(10, 2)), CAST(463.52 AS Decimal(10, 2)))
INSERT [dbo].[tbl_appointmentFormBenefitsDetails] ([detailsId], [appointmentFormId], [benefitsId], [isBenefitActive], [personalShareValue], [employerShareValue]) VALUES (5, 1, 5, 1, CAST(2781.12 AS Decimal(10, 2)), CAST(2085.84 AS Decimal(10, 2)))
INSERT [dbo].[tbl_appointmentFormBenefitsDetails] ([detailsId], [appointmentFormId], [benefitsId], [isBenefitActive], [personalShareValue], [employerShareValue]) VALUES (6, 1, 6, 1, CAST(1042.92 AS Decimal(10, 2)), CAST(2201.72 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[tbl_appointmentFormBenefitsDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_benefits] ON 

INSERT [dbo].[tbl_benefits] ([benefitsId], [benefits], [benefitsDescription]) VALUES (1, N'Witholding Tax', N'Tax deduction from the employee''s basic annual salary.')
INSERT [dbo].[tbl_benefits] ([benefitsId], [benefits], [benefitsDescription]) VALUES (2, N'Pag-IBIG Fund', N'Housing fund for employees, employers, and self-employed individuals, providing affordable housing and short-term financing.')
INSERT [dbo].[tbl_benefits] ([benefitsId], [benefits], [benefitsDescription]) VALUES (3, N'Pag-IBIG MP2 Savings', N'Voluntary savings program offered by Pag-IBIG Fund.')
INSERT [dbo].[tbl_benefits] ([benefitsId], [benefits], [benefitsDescription]) VALUES (4, N'PhilHealth', N'Government agency implementing the national health insurance program in the Philippines.')
INSERT [dbo].[tbl_benefits] ([benefitsId], [benefits], [benefitsDescription]) VALUES (5, N'GSIS', N'Government Service Insurance System providing various social insurance benefits to government employees.')
INSERT [dbo].[tbl_benefits] ([benefitsId], [benefits], [benefitsDescription]) VALUES (6, N'SSS', N'Social Security System offering insurance benefits such as sickness, maternity, disability, retirement, and death benefits for private sector employees and 
	self-employed individuals.')
SET IDENTITY_INSERT [dbo].[tbl_benefits] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_benefitsContributions] ON 

INSERT [dbo].[tbl_benefitsContributions] ([benefitContributionsId], [benefitsId], [isBenefitContributionActive], [isPercentage], [personalShareValue], [employerShareValue], [benefitContributionEffectiveFromYear], [benefitContributionEffectiveToYear]) VALUES (1, 2, 1, 0, CAST(100.00 AS Decimal(10, 2)), CAST(100.00 AS Decimal(10, 2)), 2023, NULL)
INSERT [dbo].[tbl_benefitsContributions] ([benefitContributionsId], [benefitsId], [isBenefitContributionActive], [isPercentage], [personalShareValue], [employerShareValue], [benefitContributionEffectiveFromYear], [benefitContributionEffectiveToYear]) VALUES (2, 3, 1, 0, CAST(500.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 2023, NULL)
INSERT [dbo].[tbl_benefitsContributions] ([benefitContributionsId], [benefitsId], [isBenefitContributionActive], [isPercentage], [personalShareValue], [employerShareValue], [benefitContributionEffectiveFromYear], [benefitContributionEffectiveToYear]) VALUES (3, 4, 1, 1, CAST(2.00 AS Decimal(10, 2)), CAST(2.00 AS Decimal(10, 2)), 2023, 2023)
INSERT [dbo].[tbl_benefitsContributions] ([benefitContributionsId], [benefitsId], [isBenefitContributionActive], [isPercentage], [personalShareValue], [employerShareValue], [benefitContributionEffectiveFromYear], [benefitContributionEffectiveToYear]) VALUES (4, 4, 0, 1, CAST(2.50 AS Decimal(10, 2)), CAST(2.50 AS Decimal(10, 2)), 2024, 2025)
INSERT [dbo].[tbl_benefitsContributions] ([benefitContributionsId], [benefitsId], [isBenefitContributionActive], [isPercentage], [personalShareValue], [employerShareValue], [benefitContributionEffectiveFromYear], [benefitContributionEffectiveToYear]) VALUES (5, 5, 1, 1, CAST(9.00 AS Decimal(10, 2)), CAST(12.00 AS Decimal(10, 2)), 2023, NULL)
INSERT [dbo].[tbl_benefitsContributions] ([benefitContributionsId], [benefitsId], [isBenefitContributionActive], [isPercentage], [personalShareValue], [employerShareValue], [benefitContributionEffectiveFromYear], [benefitContributionEffectiveToYear]) VALUES (6, 6, 1, 1, CAST(4.50 AS Decimal(10, 2)), CAST(9.50 AS Decimal(10, 2)), 2023, 2024)
INSERT [dbo].[tbl_benefitsContributions] ([benefitContributionsId], [benefitsId], [isBenefitContributionActive], [isPercentage], [personalShareValue], [employerShareValue], [benefitContributionEffectiveFromYear], [benefitContributionEffectiveToYear]) VALUES (7, 6, 0, 1, CAST(5.00 AS Decimal(10, 2)), CAST(10.00 AS Decimal(10, 2)), 2025, NULL)
SET IDENTITY_INSERT [dbo].[tbl_benefitsContributions] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_benefitsFormula] ON 

INSERT [dbo].[tbl_benefitsFormula] ([benefitFormulaId], [benefitsId], [formulaDescription], [formulaExpression]) VALUES (1, 2, N'Calculate Pag-IBIG Fund Deduction', N'[monthlySalary] - [totalPagIbigAmount]')
INSERT [dbo].[tbl_benefitsFormula] ([benefitFormulaId], [benefitsId], [formulaDescription], [formulaExpression]) VALUES (2, 3, N'Calculate Pag-IBIG MP2 Deduction', N'[monthlySalary] - [totalPagIbigMP2Amount]')
INSERT [dbo].[tbl_benefitsFormula] ([benefitFormulaId], [benefitsId], [formulaDescription], [formulaExpression]) VALUES (3, 4, N'Compute PhilHealth Contribution Deduction', N'[monthlySalary] - [totalPhilHealthAmount]')
INSERT [dbo].[tbl_benefitsFormula] ([benefitFormulaId], [benefitsId], [formulaDescription], [formulaExpression]) VALUES (4, 5, N'Compute GSIS Contribution Deduction', N'[monthlySalary] - [totalGSISAmount]')
INSERT [dbo].[tbl_benefitsFormula] ([benefitFormulaId], [benefitsId], [formulaDescription], [formulaExpression]) VALUES (5, 6, N'Compute SSS Contribution Deduction', N'[monthlySalary] - [totalSSSAmount]')
SET IDENTITY_INSERT [dbo].[tbl_benefitsFormula] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_department] ON 

INSERT [dbo].[tbl_department] ([departmentId], [departmentName], [departmentInitial], [departmentLogo]) VALUES (1, N'Human Resources Office', N'HR Office', N'1104982.png')
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

INSERT [dbo].[tbl_employee] ([employeeId], [employeePassword], [isActive], [employeeFname], [employeeLname], [employeeMname], [nationality], [barangay], [municipality], [province], [zipCode], [employeeBirth], [employeeCivilStatus], [employeeSex], [employeeContactNumber], [employeeEmailAddress], [educationalAttainmentId], [nameOfSchool], [course], [schoolAddress], [departmentId], [employeeJobDesc], [roleId], [employeePicture], [employeeSignature]) VALUES (1, N'1', 1, N'Ryan Sy', N'Santos', N'Agsunta', N'Filipino', N'Tubigan', N'Initao', N'Misamis Oriental', N'9022', CAST(N'2000-08-01T00:00:00.000' AS DateTime), N'Single', N'Male', N'09050346101', N'personnel@gmail.com', 1, N'MSU Naawan', N'Bs Human Resource', N'Region X Misamis Oriental Naawan', 1, N'Developer', 3, N'RyanSySantosAgsunta.jpg', N'Ryan SySantos.jpg')
SET IDENTITY_INSERT [dbo].[tbl_employee] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_employeeDataLogChanges] ON 

INSERT [dbo].[tbl_employeeDataLogChanges] ([logId], [employeeId], [dateLog], [logDescription], [logCaption]) VALUES (1, 1, CAST(N'2023-11-30' AS Date), N'Recorded the addition of a new employee to the database.', N'New Employee Added')
SET IDENTITY_INSERT [dbo].[tbl_employeeDataLogChanges] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_employeeLeaveCredits] ON 

INSERT [dbo].[tbl_employeeLeaveCredits] ([employeeLeaveCreditsId], [employeeId], [typeId], [numberOfCredits], [leaveCreditYear]) VALUES (1, 1, 1, CAST(15.00 AS Decimal(10, 2)), 2023)
INSERT [dbo].[tbl_employeeLeaveCredits] ([employeeLeaveCreditsId], [employeeId], [typeId], [numberOfCredits], [leaveCreditYear]) VALUES (2, 1, 2, CAST(15.00 AS Decimal(10, 2)), 2023)
SET IDENTITY_INSERT [dbo].[tbl_employeeLeaveCredits] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_employeePassSlipHours] ON 

INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [month], [year], [numberOfHours]) VALUES (1, 1, 1, 2023, CAST(N'04:00:00' AS Time))
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [month], [year], [numberOfHours]) VALUES (2, 1, 2, 2023, CAST(N'04:00:00' AS Time))
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [month], [year], [numberOfHours]) VALUES (3, 1, 3, 2023, CAST(N'04:00:00' AS Time))
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [month], [year], [numberOfHours]) VALUES (4, 1, 4, 2023, CAST(N'04:00:00' AS Time))
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [month], [year], [numberOfHours]) VALUES (5, 1, 5, 2023, CAST(N'04:00:00' AS Time))
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [month], [year], [numberOfHours]) VALUES (6, 1, 6, 2023, CAST(N'04:00:00' AS Time))
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [month], [year], [numberOfHours]) VALUES (7, 1, 7, 2023, CAST(N'04:00:00' AS Time))
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [month], [year], [numberOfHours]) VALUES (8, 1, 8, 2023, CAST(N'04:00:00' AS Time))
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [month], [year], [numberOfHours]) VALUES (9, 1, 9, 2023, CAST(N'04:00:00' AS Time))
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [month], [year], [numberOfHours]) VALUES (10, 1, 10, 2023, CAST(N'04:00:00' AS Time))
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [month], [year], [numberOfHours]) VALUES (11, 1, 11, 2023, CAST(N'04:00:00' AS Time))
INSERT [dbo].[tbl_employeePassSlipHours] ([employeeSlipHoursId], [employeeId], [month], [year], [numberOfHours]) VALUES (12, 1, 12, 2023, CAST(N'04:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[tbl_employeePassSlipHours] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_employmentStatus] ON 

INSERT [dbo].[tbl_employmentStatus] ([employmentStatusId], [employmentStatus], [employmentStatusDescription]) VALUES (1, N'Regular', N'Permanent employment status granted to employees without a fixed-term contract.')
INSERT [dbo].[tbl_employmentStatus] ([employmentStatusId], [employmentStatus], [employmentStatusDescription]) VALUES (2, N'Job Order', N'Temporary employment status assigned to employees with a fixed 6-month contract.')
SET IDENTITY_INSERT [dbo].[tbl_employmentStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_employmentStatusAccess] ON 

INSERT [dbo].[tbl_employmentStatusAccess] ([statusAccessId], [employmentStatusId], [roleId]) VALUES (1, 1, 5)
INSERT [dbo].[tbl_employmentStatusAccess] ([statusAccessId], [employmentStatusId], [roleId]) VALUES (2, 1, 4)
INSERT [dbo].[tbl_employmentStatusAccess] ([statusAccessId], [employmentStatusId], [roleId]) VALUES (3, 1, 3)
SET IDENTITY_INSERT [dbo].[tbl_employmentStatusAccess] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_formType] ON 

INSERT [dbo].[tbl_formType] ([formId], [formName]) VALUES (1, N'Payroll Form')
INSERT [dbo].[tbl_formType] ([formId], [formName]) VALUES (2, N'Application for Leave')
INSERT [dbo].[tbl_formType] ([formId], [formName]) VALUES (3, N'Pass Slip')
INSERT [dbo].[tbl_formType] ([formId], [formName]) VALUES (4, N'Travel Order')
SET IDENTITY_INSERT [dbo].[tbl_formType] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_generalFormula] ON 

INSERT [dbo].[tbl_generalFormula] ([generalFormulaId], [generalFormulaTitle], [generalFormulaDescription], [generalFormulaExpression]) VALUES (1, N'Percentage Conversion', N'Calculates a specific amount by converting from a percentage of the given salary value.', N'([salaryValue] * [percentageNumber]) / 100')
INSERT [dbo].[tbl_generalFormula] ([generalFormulaId], [generalFormulaTitle], [generalFormulaDescription], [generalFormulaExpression]) VALUES (2, N'Converting Monthly to Annual Salary', N'Converts the monthly salary to an annual salary value.', N'[monthlySalary] * [numberOfMonthsInAYear]')
INSERT [dbo].[tbl_generalFormula] ([generalFormulaId], [generalFormulaTitle], [generalFormulaDescription], [generalFormulaExpression]) VALUES (3, N'Tax Value Per Month', N'Determines the monthly tax amount based on the total annual tax.', N'[totalTax] / [numberOfMonthsInAYear]')
INSERT [dbo].[tbl_generalFormula] ([generalFormulaId], [generalFormulaTitle], [generalFormulaDescription], [generalFormulaExpression]) VALUES (4, N'Withholding Tax Formula', N'Computes the withholding tax amount using a specified tax rate.', N'(([basicAnnualSalary] - [amountExcess]) * [percentageToBeDeducted]) / 100 + [amountToBeDeducted]')
INSERT [dbo].[tbl_generalFormula] ([generalFormulaId], [generalFormulaTitle], [generalFormulaDescription], [generalFormulaExpression]) VALUES (5, N'Getting the Basic Annual Salary', N'Obtains the total annual salary by subtracting total annual deductions from the total annual salary value.', N'[totalAnnualSalary] - [totalAnnualDeductions]')
INSERT [dbo].[tbl_generalFormula] ([generalFormulaId], [generalFormulaTitle], [generalFormulaDescription], [generalFormulaExpression]) VALUES (6, N'Annual Value Deductions', N'Calculates the total annual value of deductions, considering both personal and employer shares.', N'([personalShareValue] + [employerShareValue]) * [numberOfMonthsInAYear]')
SET IDENTITY_INSERT [dbo].[tbl_generalFormula] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_leaveDefaultCredits] ON 

INSERT [dbo].[tbl_leaveDefaultCredits] ([leaveDefaultCreditsId], [typeId], [numberOfCredits]) VALUES (1, 1, CAST(15.00 AS Decimal(10, 2)))
INSERT [dbo].[tbl_leaveDefaultCredits] ([leaveDefaultCreditsId], [typeId], [numberOfCredits]) VALUES (2, 2, CAST(15.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[tbl_leaveDefaultCredits] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_leaveType] ON 

INSERT [dbo].[tbl_leaveType] ([typeId], [leaveType], [leaveDescription]) VALUES (1, N'Sick Leave', N'Type of leave to avail if the employee have an illness/sickness.')
INSERT [dbo].[tbl_leaveType] ([typeId], [leaveType], [leaveDescription]) VALUES (2, N'Vacation Leave', N'Type of leave to avail if the employee wants to do a vacation.')
SET IDENTITY_INSERT [dbo].[tbl_leaveType] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_mandatedBenefits] ON 

INSERT [dbo].[tbl_mandatedBenefits] ([mandatedBenefitsId], [employmentStatusId], [benefitsId], [isMandated]) VALUES (1, 1, 1, 1)
INSERT [dbo].[tbl_mandatedBenefits] ([mandatedBenefitsId], [employmentStatusId], [benefitsId], [isMandated]) VALUES (2, 1, 2, 1)
INSERT [dbo].[tbl_mandatedBenefits] ([mandatedBenefitsId], [employmentStatusId], [benefitsId], [isMandated]) VALUES (3, 1, 3, 0)
INSERT [dbo].[tbl_mandatedBenefits] ([mandatedBenefitsId], [employmentStatusId], [benefitsId], [isMandated]) VALUES (4, 1, 4, 1)
INSERT [dbo].[tbl_mandatedBenefits] ([mandatedBenefitsId], [employmentStatusId], [benefitsId], [isMandated]) VALUES (5, 1, 5, 1)
INSERT [dbo].[tbl_mandatedBenefits] ([mandatedBenefitsId], [employmentStatusId], [benefitsId], [isMandated]) VALUES (6, 1, 6, 0)
INSERT [dbo].[tbl_mandatedBenefits] ([mandatedBenefitsId], [employmentStatusId], [benefitsId], [isMandated]) VALUES (7, 2, 3, 0)
SET IDENTITY_INSERT [dbo].[tbl_mandatedBenefits] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_payrollSched] ON 

INSERT [dbo].[tbl_payrollSched] ([payrollSchedId], [payrollScheduleDescription], [payrollScheduleNumberOfDays]) VALUES (1, N'Monthly', 23)
INSERT [dbo].[tbl_payrollSched] ([payrollSchedId], [payrollScheduleDescription], [payrollScheduleNumberOfDays]) VALUES (2, N'Semi-Monthly', 11)
SET IDENTITY_INSERT [dbo].[tbl_payrollSched] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_salaryRate] ON 

INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (1, N'Salary Grade 1', 1)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (2, N'Salary Grade 2', 2)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (3, N'Salary Grade 3', 3)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (4, N'Salary Grade 4', 4)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (5, N'Salary Grade 5', 5)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (6, N'Salary Grade 6', 6)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (7, N'Salary Grade 7', 7)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (8, N'Salary Grade 8', 8)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (9, N'Salary Grade 9', 9)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (10, N'Salary Grade 10', 10)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (11, N'Salary Grade 11', 11)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (12, N'Salary Grade 12', 12)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (13, N'Salary Grade 13', 13)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (14, N'Salary Grade 14', 14)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (15, N'Salary Grade 15', 15)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (16, N'Salary Grade 16', 16)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (17, N'Salary Grade 17', 17)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (18, N'Salary Grade 18', 18)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (19, N'Salary Grade 19', 19)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (20, N'Salary Grade 20', 20)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (21, N'Salary Grade 21', 21)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (22, N'Salary Grade 22', 22)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (23, N'Salary Grade 23', 23)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (24, N'Salary Grade 24', 24)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (25, N'Salary Grade 25', 25)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (26, N'Salary Grade 26', 26)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (27, N'Salary Grade 27', 27)
INSERT [dbo].[tbl_salaryRate] ([salaryRateId], [salaryratedescription], [salaryGradeNumber]) VALUES (28, N'Salary Grade 28', 28)
SET IDENTITY_INSERT [dbo].[tbl_salaryRate] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_salaryRateStep] ON 

INSERT [dbo].[tbl_salaryRateStep] ([stepId], [salaryRateStepDescription], [stepNumber]) VALUES (1, N'Step 1', 1)
INSERT [dbo].[tbl_salaryRateStep] ([stepId], [salaryRateStepDescription], [stepNumber]) VALUES (2, N'Step 2', 2)
INSERT [dbo].[tbl_salaryRateStep] ([stepId], [salaryRateStepDescription], [stepNumber]) VALUES (3, N'Step 3', 3)
INSERT [dbo].[tbl_salaryRateStep] ([stepId], [salaryRateStepDescription], [stepNumber]) VALUES (4, N'Step 4', 4)
INSERT [dbo].[tbl_salaryRateStep] ([stepId], [salaryRateStepDescription], [stepNumber]) VALUES (5, N'Step 5', 5)
INSERT [dbo].[tbl_salaryRateStep] ([stepId], [salaryRateStepDescription], [stepNumber]) VALUES (6, N'Step 6', 6)
INSERT [dbo].[tbl_salaryRateStep] ([stepId], [salaryRateStepDescription], [stepNumber]) VALUES (7, N'Step 7', 7)
INSERT [dbo].[tbl_salaryRateStep] ([stepId], [salaryRateStepDescription], [stepNumber]) VALUES (8, N'Step 8', 8)
SET IDENTITY_INSERT [dbo].[tbl_salaryRateStep] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_salaryRateTranche] ON 

INSERT [dbo].[tbl_salaryRateTranche] ([trancheId], [salaryRateTrancheDescription], [trancheNumber]) VALUES (1, N'1st Tranche', 1)
INSERT [dbo].[tbl_salaryRateTranche] ([trancheId], [salaryRateTrancheDescription], [trancheNumber]) VALUES (2, N'2nd Tranche', 2)
INSERT [dbo].[tbl_salaryRateTranche] ([trancheId], [salaryRateTrancheDescription], [trancheNumber]) VALUES (3, N'3rd Tranche', 3)
INSERT [dbo].[tbl_salaryRateTranche] ([trancheId], [salaryRateTrancheDescription], [trancheNumber]) VALUES (4, N'4th Tranche', 4)
SET IDENTITY_INSERT [dbo].[tbl_salaryRateTranche] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_salaryRateValue] ON 

INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (1, 1, 1, 4, CAST(13000.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (2, 1, 2, 4, CAST(13109.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (3, 1, 3, 4, CAST(13219.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (4, 1, 4, 4, CAST(13329.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (5, 1, 5, 4, CAST(13441.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (6, 1, 6, 4, CAST(13553.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (7, 1, 7, 4, CAST(13666.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (8, 1, 8, 4, CAST(13780.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (9, 2, 1, 4, CAST(13819.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (10, 2, 2, 4, CAST(13925.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (11, 2, 3, 4, CAST(14032.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (12, 2, 4, 4, CAST(14140.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (13, 2, 5, 4, CAST(14248.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (14, 2, 6, 4, CAST(14357.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (15, 2, 7, 4, CAST(14468.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (16, 2, 8, 4, CAST(14578.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (17, 3, 1, 4, CAST(14678.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (18, 3, 2, 4, CAST(14792.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (19, 3, 3, 4, CAST(14905.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (20, 3, 4, 4, CAST(15020.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (21, 3, 5, 4, CAST(15136.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (22, 3, 6, 4, CAST(15251.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (23, 3, 7, 4, CAST(15369.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (24, 3, 8, 4, CAST(15486.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (25, 4, 1, 4, CAST(15586.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (26, 4, 2, 4, CAST(15706.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (27, 4, 3, 4, CAST(15827.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (28, 4, 4, 4, CAST(15948.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (29, 4, 5, 4, CAST(16071.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (30, 4, 6, 4, CAST(16193.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (31, 4, 7, 4, CAST(16318.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (32, 4, 8, 4, CAST(16443.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (33, 5, 1, 4, CAST(16543.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (34, 5, 2, 4, CAST(16671.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (35, 5, 3, 4, CAST(16799.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (36, 5, 4, 4, CAST(16928.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (37, 5, 5, 4, CAST(17057.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (38, 5, 6, 4, CAST(17189.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (39, 5, 7, 4, CAST(17321.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (40, 5, 8, 4, CAST(17453.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (41, 6, 1, 4, CAST(17553.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (42, 6, 2, 4, CAST(17688.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (43, 6, 3, 4, CAST(17824.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (44, 6, 4, 4, CAST(17962.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (45, 6, 5, 4, CAST(18100.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (46, 6, 6, 4, CAST(18238.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (47, 6, 7, 4, CAST(18379.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (48, 6, 8, 4, CAST(18520.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (49, 7, 1, 4, CAST(18620.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (50, 7, 2, 4, CAST(18763.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (51, 7, 3, 4, CAST(18907.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (52, 7, 4, 4, CAST(19053.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (53, 7, 5, 4, CAST(19198.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (54, 7, 6, 4, CAST(19346.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (55, 7, 7, 4, CAST(19494.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (56, 7, 8, 4, CAST(19644.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (57, 8, 1, 4, CAST(19744.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (58, 8, 2, 4, CAST(19923.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (59, 8, 3, 4, CAST(20104.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (60, 8, 4, 4, CAST(20285.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (61, 8, 5, 4, CAST(20468.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (62, 8, 6, 4, CAST(20653.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (63, 8, 7, 4, CAST(20840.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (64, 8, 8, 4, CAST(21029.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (65, 9, 1, 4, CAST(21129.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (66, 9, 2, 4, CAST(21304.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (67, 9, 3, 4, CAST(21483.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (68, 9, 4, 4, CAST(21663.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (69, 9, 5, 4, CAST(21844.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (70, 9, 6, 4, CAST(22026.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (71, 9, 7, 4, CAST(22210.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (72, 9, 8, 4, CAST(22396.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (73, 10, 1, 4, CAST(23176.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (74, 10, 2, 4, CAST(23370.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (75, 10, 3, 4, CAST(23565.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (76, 10, 4, 4, CAST(23762.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (77, 10, 5, 4, CAST(23961.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (78, 10, 6, 4, CAST(24161.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (79, 10, 7, 4, CAST(24363.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (80, 10, 8, 4, CAST(24567.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (81, 11, 1, 4, CAST(27000.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (82, 11, 2, 4, CAST(27284.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (83, 11, 3, 4, CAST(27573.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (84, 11, 4, 4, CAST(27865.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (85, 11, 5, 4, CAST(28161.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (86, 11, 6, 4, CAST(28462.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (87, 11, 7, 4, CAST(28766.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (88, 11, 8, 4, CAST(29075.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (89, 12, 1, 4, CAST(29165.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (90, 12, 2, 4, CAST(29449.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (91, 12, 3, 4, CAST(29737.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (92, 12, 4, 4, CAST(30028.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (93, 12, 5, 4, CAST(30323.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (94, 12, 6, 4, CAST(30662.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (95, 12, 7, 4, CAST(30924.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (96, 12, 8, 4, CAST(31230.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (97, 13, 1, 4, CAST(31320.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (98, 13, 2, 4, CAST(31633.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (99, 13, 3, 4, CAST(31949.00 AS Decimal(10, 2)), 2023, 1)
GO
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (100, 13, 4, 4, CAST(32269.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (101, 13, 5, 4, CAST(32594.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (102, 13, 6, 4, CAST(32922.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (103, 13, 7, 4, CAST(33254.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (104, 13, 8, 4, CAST(33591.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (105, 14, 1, 4, CAST(33843.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (106, 14, 2, 4, CAST(34187.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (107, 14, 3, 4, CAST(34535.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (108, 14, 4, 4, CAST(34888.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (109, 14, 5, 4, CAST(35244.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (110, 14, 6, 4, CAST(35605.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (111, 14, 7, 4, CAST(35971.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (112, 14, 8, 4, CAST(36341.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (113, 15, 1, 4, CAST(36619.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (114, 15, 2, 4, CAST(36997.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (115, 15, 3, 4, CAST(37380.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (116, 15, 4, 4, CAST(37768.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (117, 15, 5, 4, CAST(38160.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (118, 15, 6, 4, CAST(38557.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (119, 15, 7, 4, CAST(38959.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (120, 15, 8, 4, CAST(39367.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (121, 16, 1, 4, CAST(39672.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (122, 16, 2, 4, CAST(40088.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (123, 16, 3, 4, CAST(40509.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (124, 16, 4, 4, CAST(40935.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (125, 16, 5, 4, CAST(41367.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (126, 16, 6, 4, CAST(41804.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (127, 16, 7, 4, CAST(42247.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (128, 16, 8, 4, CAST(42694.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (129, 17, 1, 4, CAST(43030.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (130, 17, 2, 4, CAST(43488.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (131, 17, 3, 4, CAST(43951.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (132, 17, 4, 4, CAST(44420.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (133, 17, 5, 4, CAST(44895.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (134, 17, 6, 4, CAST(45376.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (135, 17, 7, 4, CAST(45862.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (136, 17, 8, 4, CAST(46355.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (137, 18, 1, 4, CAST(46725.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (138, 18, 2, 4, CAST(47228.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (139, 18, 3, 4, CAST(47738.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (140, 18, 4, 4, CAST(48253.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (141, 18, 5, 4, CAST(48776.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (142, 18, 6, 4, CAST(49305.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (143, 18, 7, 4, CAST(49840.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (144, 18, 8, 4, CAST(50382.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (145, 19, 1, 4, CAST(51357.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (146, 19, 2, 4, CAST(52096.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (147, 19, 3, 4, CAST(52847.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (148, 19, 4, 4, CAST(53610.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (149, 19, 5, 4, CAST(54386.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (150, 19, 6, 4, CAST(55174.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (151, 19, 7, 4, CAST(55976.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (152, 19, 8, 4, CAST(56790.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (153, 20, 1, 4, CAST(57347.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (154, 20, 2, 4, CAST(58181.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (155, 20, 3, 4, CAST(59030.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (156, 20, 4, 4, CAST(59892.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (157, 20, 5, 4, CAST(60769.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (158, 20, 6, 4, CAST(61660.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (159, 20, 7, 4, CAST(62565.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (160, 20, 8, 4, CAST(63485.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (161, 21, 1, 4, CAST(63997.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (162, 21, 2, 4, CAST(64940.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (163, 21, 3, 4, CAST(65899.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (164, 21, 4, 4, CAST(66873.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (165, 21, 5, 4, CAST(67864.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (166, 21, 6, 4, CAST(68870.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (167, 21, 7, 4, CAST(69893.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (168, 21, 8, 4, CAST(70933.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (169, 22, 1, 4, CAST(71511.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (170, 22, 2, 4, CAST(72577.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (171, 22, 3, 4, CAST(73661.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (172, 22, 4, 4, CAST(74762.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (173, 22, 5, 4, CAST(75881.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (174, 22, 6, 4, CAST(77019.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (175, 22, 7, 4, CAST(78175.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (176, 22, 8, 4, CAST(79349.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (177, 23, 1, 4, CAST(80003.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (178, 23, 2, 4, CAST(81207.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (179, 23, 3, 4, CAST(82432.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (180, 23, 4, 4, CAST(83683.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (181, 23, 5, 4, CAST(85049.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (182, 23, 6, 4, CAST(86437.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (183, 23, 7, 4, CAST(87847.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (184, 23, 8, 4, CAST(89281.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (185, 24, 1, 4, CAST(90078.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (186, 24, 2, 4, CAST(91548.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (187, 24, 3, 4, CAST(93043.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (188, 24, 4, 4, CAST(94562.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (189, 24, 5, 4, CAST(96105.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (190, 24, 6, 4, CAST(97674.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (191, 24, 7, 4, CAST(99268.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (192, 24, 8, 4, CAST(100888.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (193, 25, 1, 4, CAST(102690.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (194, 25, 2, 4, CAST(104366.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (195, 25, 3, 4, CAST(106069.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (196, 25, 4, 4, CAST(107800.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (197, 25, 5, 4, CAST(109560.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (198, 25, 6, 4, CAST(111348.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (199, 25, 7, 4, CAST(113166.00 AS Decimal(10, 2)), 2023, 1)
GO
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (200, 25, 8, 4, CAST(115012.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (201, 26, 1, 4, CAST(116040.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (202, 26, 2, 4, CAST(117933.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (203, 26, 3, 4, CAST(119858.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (204, 26, 4, 4, CAST(121814.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (205, 26, 5, 4, CAST(123803.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (206, 26, 6, 4, CAST(125823.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (207, 26, 7, 4, CAST(127876.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (208, 26, 8, 4, CAST(129964.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (209, 27, 1, 4, CAST(131124.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (210, 27, 2, 4, CAST(133264.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (211, 27, 3, 4, CAST(135440.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (212, 27, 4, 4, CAST(137650.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (213, 27, 5, 4, CAST(139897.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (214, 27, 6, 4, CAST(142180.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (215, 27, 7, 4, CAST(144501.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (216, 27, 8, 4, CAST(146859.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (217, 28, 1, 4, CAST(148171.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (218, 28, 2, 4, CAST(150589.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (219, 28, 3, 4, CAST(153047.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (220, 28, 4, 4, CAST(155545.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (221, 28, 5, 4, CAST(158083.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (222, 28, 6, 4, CAST(160664.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (223, 28, 7, 4, CAST(163286.00 AS Decimal(10, 2)), 2023, 1)
INSERT [dbo].[tbl_salaryRateValue] ([salaryRateValueId], [salaryRateId], [stepId], [trancheId], [amount], [yearEffective], [isActive]) VALUES (224, 28, 8, 4, CAST(165951.00 AS Decimal(10, 2)), 2023, 1)
SET IDENTITY_INSERT [dbo].[tbl_salaryRateValue] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_status] ON 

INSERT [dbo].[tbl_status] ([statusId], [statusDescription]) VALUES (1, N'Approved')
INSERT [dbo].[tbl_status] ([statusId], [statusDescription]) VALUES (2, N'Pending')
INSERT [dbo].[tbl_status] ([statusId], [statusDescription]) VALUES (3, N'Denied')
INSERT [dbo].[tbl_status] ([statusId], [statusDescription]) VALUES (4, N'Approved but On Hold')
INSERT [dbo].[tbl_status] ([statusId], [statusDescription]) VALUES (5, N'Approved waiting to be released')
INSERT [dbo].[tbl_status] ([statusId], [statusDescription]) VALUES (6, N'Released and Paid')
SET IDENTITY_INSERT [dbo].[tbl_status] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_userRole] ON 

INSERT [dbo].[tbl_userRole] ([roleId], [roleName], [roleDescription]) VALUES (1, N'System Administrator', N'User responsible for overseeing and administrating direct interactions with the system.')
INSERT [dbo].[tbl_userRole] ([roleId], [roleName], [roleDescription]) VALUES (2, N'Mayor', N'User account designated for the Municipal Mayor, encompassing administrative duties and decision-making.')
INSERT [dbo].[tbl_userRole] ([roleId], [roleName], [roleDescription]) VALUES (3, N'Personnel', N'User account specifically utilized by the Human Resources Officer to handle personnel-related tasks.')
INSERT [dbo].[tbl_userRole] ([roleId], [roleName], [roleDescription]) VALUES (4, N'Department Head', N'User account assigned to department heads, responsible for overseeing and managing affairs within their respective offices.')
INSERT [dbo].[tbl_userRole] ([roleId], [roleName], [roleDescription]) VALUES (5, N'Employee', N'User account designated for all employees, providing access to necessary tools and information for their daily tasks.')
SET IDENTITY_INSERT [dbo].[tbl_userRole] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_witholdingTaxRates] ON 

INSERT [dbo].[tbl_witholdingTaxRates] ([taxRateId], [isTaxRateActive], [taxRateDescription], [fromAnnualSalaryValue], [toAnnualSalaryValue], [percentageToBeDeducted], [amountToBeDeducted], [amountExcess], [taxRateEffectiveFromYear], [taxRateEffectiveToYear]) VALUES (1, 1, N'0% Tax Rate for Annual Salary up to 250,000', CAST(0.00 AS Decimal(10, 2)), CAST(250000.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), 2023, NULL)
INSERT [dbo].[tbl_witholdingTaxRates] ([taxRateId], [isTaxRateActive], [taxRateDescription], [fromAnnualSalaryValue], [toAnnualSalaryValue], [percentageToBeDeducted], [amountToBeDeducted], [amountExcess], [taxRateEffectiveFromYear], [taxRateEffectiveToYear]) VALUES (2, 1, N'15% Tax Rate for Annual Salary Above 250,000 to 400,000 (Excess over 250,000)', CAST(250001.00 AS Decimal(10, 2)), CAST(400000.00 AS Decimal(10, 2)), CAST(15.00 AS Decimal(10, 2)), CAST(0.00 AS Decimal(10, 2)), CAST(250000.00 AS Decimal(10, 2)), 2023, NULL)
INSERT [dbo].[tbl_witholdingTaxRates] ([taxRateId], [isTaxRateActive], [taxRateDescription], [fromAnnualSalaryValue], [toAnnualSalaryValue], [percentageToBeDeducted], [amountToBeDeducted], [amountExcess], [taxRateEffectiveFromYear], [taxRateEffectiveToYear]) VALUES (3, 1, N'20% Tax Rate for Annual Salary Above 400,000 to 800,000 (Excess over 400,000) with a fixed deduction of 22,500', CAST(400001.00 AS Decimal(10, 2)), CAST(800000.00 AS Decimal(10, 2)), CAST(20.00 AS Decimal(10, 2)), CAST(22500.00 AS Decimal(10, 2)), CAST(400000.00 AS Decimal(10, 2)), 2023, NULL)
INSERT [dbo].[tbl_witholdingTaxRates] ([taxRateId], [isTaxRateActive], [taxRateDescription], [fromAnnualSalaryValue], [toAnnualSalaryValue], [percentageToBeDeducted], [amountToBeDeducted], [amountExcess], [taxRateEffectiveFromYear], [taxRateEffectiveToYear]) VALUES (4, 1, N'25% Tax Rate for Annual Salary Above 800,000 to 2,000,000 (Excess over 800,000) with a fixed deduction of 102,500', CAST(800001.00 AS Decimal(10, 2)), CAST(2000000.00 AS Decimal(10, 2)), CAST(25.00 AS Decimal(10, 2)), CAST(102500.00 AS Decimal(10, 2)), CAST(800000.00 AS Decimal(10, 2)), 2023, NULL)
INSERT [dbo].[tbl_witholdingTaxRates] ([taxRateId], [isTaxRateActive], [taxRateDescription], [fromAnnualSalaryValue], [toAnnualSalaryValue], [percentageToBeDeducted], [amountToBeDeducted], [amountExcess], [taxRateEffectiveFromYear], [taxRateEffectiveToYear]) VALUES (5, 1, N'30% Tax Rate for Annual Salary Above 2,000,000 to 8,000,000 (Excess over 2,000,000) with a fixed deduction of 402,500', CAST(2000001.00 AS Decimal(10, 2)), CAST(8000000.00 AS Decimal(10, 2)), CAST(30.00 AS Decimal(10, 2)), CAST(402500.00 AS Decimal(10, 2)), CAST(200000.00 AS Decimal(10, 2)), 2023, NULL)
INSERT [dbo].[tbl_witholdingTaxRates] ([taxRateId], [isTaxRateActive], [taxRateDescription], [fromAnnualSalaryValue], [toAnnualSalaryValue], [percentageToBeDeducted], [amountToBeDeducted], [amountExcess], [taxRateEffectiveFromYear], [taxRateEffectiveToYear]) VALUES (6, 1, N'35% Tax Rate for Annual Salary Above 8,000,000 with a fixed deduction of 2,202,500', CAST(8000001.00 AS Decimal(10, 2)), NULL, CAST(35.00 AS Decimal(10, 2)), CAST(2202500.00 AS Decimal(10, 2)), CAST(8000000.00 AS Decimal(10, 2)), 2023, NULL)
SET IDENTITY_INSERT [dbo].[tbl_witholdingTaxRates] OFF
GO
/****** Object:  Index [unique_timeLogId]    Script Date: 01/12/2023 7:53:54 pm ******/
ALTER TABLE [dbo].[tbl_deductionDetails] ADD  CONSTRAINT [unique_timeLogId] UNIQUE NONCLUSTERED 
(
	[timeLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_EmployeePicture_Signature]    Script Date: 01/12/2023 7:53:54 pm ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_EmployeePicture_Signature] ON [dbo].[tbl_employee]
(
	[employeePicture] ASC,
	[employeeSignature] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__tbl_leav__769912DB92D3AF57]    Script Date: 01/12/2023 7:53:54 pm ******/
ALTER TABLE [dbo].[tbl_leave] ADD UNIQUE NONCLUSTERED 
(
	[applicationNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__tbl_list__6AAA14F6BFEA0912]    Script Date: 01/12/2023 7:53:54 pm ******/
ALTER TABLE [dbo].[tbl_listOfWorkingDays] ADD UNIQUE NONCLUSTERED 
(
	[timeLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__tbl_pass__42AF11D83AE3B6AF]    Script Date: 01/12/2023 7:53:54 pm ******/
ALTER TABLE [dbo].[tbl_passSlip] ADD UNIQUE NONCLUSTERED 
(
	[slipControlNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__tbl_payr__F7CD85083A88E344]    Script Date: 01/12/2023 7:53:54 pm ******/
ALTER TABLE [dbo].[tbl_payrollForm] ADD UNIQUE NONCLUSTERED 
(
	[payrollFormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [UQ__tbl_trav__95A1B95FF85622BB]    Script Date: 01/12/2023 7:53:54 pm ******/
ALTER TABLE [dbo].[tbl_travelOrder] ADD UNIQUE NONCLUSTERED 
(
	[orderControlNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_appointmentForm]  WITH CHECK ADD  CONSTRAINT [fk_tbl_appointmentFormSalaryRateValueId] FOREIGN KEY([salaryRateValueId])
REFERENCES [dbo].[tbl_salaryRateValue] ([salaryRateValueId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_appointmentForm] CHECK CONSTRAINT [fk_tbl_appointmentFormSalaryRateValueId]
GO
ALTER TABLE [dbo].[tbl_appointmentForm]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employee_appointmentForm] FOREIGN KEY([employeeid])
REFERENCES [dbo].[tbl_employee] ([employeeId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_appointmentForm] CHECK CONSTRAINT [fk_tbl_employee_appointmentForm]
GO
ALTER TABLE [dbo].[tbl_appointmentForm]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employment] FOREIGN KEY([employmentStatusId])
REFERENCES [dbo].[tbl_employmentStatus] ([employmentStatusId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_appointmentForm] CHECK CONSTRAINT [fk_tbl_employment]
GO
ALTER TABLE [dbo].[tbl_appointmentForm]  WITH CHECK ADD  CONSTRAINT [fk_tbl_payrollSchedule] FOREIGN KEY([payrollSchedId])
REFERENCES [dbo].[tbl_payrollSched] ([payrollSchedId])
GO
ALTER TABLE [dbo].[tbl_appointmentForm] CHECK CONSTRAINT [fk_tbl_payrollSchedule]
GO
ALTER TABLE [dbo].[tbl_appointmentFormBenefitsDetails]  WITH CHECK ADD  CONSTRAINT [fk_tbl_appointmentForm] FOREIGN KEY([appointmentFormId])
REFERENCES [dbo].[tbl_appointmentForm] ([appointmentFormId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_appointmentFormBenefitsDetails] CHECK CONSTRAINT [fk_tbl_appointmentForm]
GO
ALTER TABLE [dbo].[tbl_appointmentFormBenefitsDetails]  WITH CHECK ADD  CONSTRAINT [fk_tbl_appointmentFormBenefitsDetails_benefits] FOREIGN KEY([benefitsId])
REFERENCES [dbo].[tbl_benefits] ([benefitsId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_appointmentFormBenefitsDetails] CHECK CONSTRAINT [fk_tbl_appointmentFormBenefitsDetails_benefits]
GO
ALTER TABLE [dbo].[tbl_benefitsContributions]  WITH CHECK ADD  CONSTRAINT [fk_tbl_benefitsContributions] FOREIGN KEY([benefitsId])
REFERENCES [dbo].[tbl_benefits] ([benefitsId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_benefitsContributions] CHECK CONSTRAINT [fk_tbl_benefitsContributions]
GO
ALTER TABLE [dbo].[tbl_benefitsFormula]  WITH CHECK ADD  CONSTRAINT [fk_tbl_benefitsFormula] FOREIGN KEY([benefitsId])
REFERENCES [dbo].[tbl_benefits] ([benefitsId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_benefitsFormula] CHECK CONSTRAINT [fk_tbl_benefitsFormula]
GO
ALTER TABLE [dbo].[tbl_bonus]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employeeBonus] FOREIGN KEY([employeeId])
REFERENCES [dbo].[tbl_employee] ([employeeId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_bonus] CHECK CONSTRAINT [fk_tbl_employeeBonus]
GO
ALTER TABLE [dbo].[tbl_contractLength]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employmentStatusLength] FOREIGN KEY([employmentStatusId])
REFERENCES [dbo].[tbl_employmentStatus] ([employmentStatusId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_contractLength] CHECK CONSTRAINT [fk_tbl_employmentStatusLength]
GO
ALTER TABLE [dbo].[tbl_deductionDetails]  WITH CHECK ADD  CONSTRAINT [fk_tbl_penaltyLog] FOREIGN KEY([timeLogId])
REFERENCES [dbo].[tbl_timeLog] ([timelogId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_deductionDetails] CHECK CONSTRAINT [fk_tbl_penaltyLog]
GO
ALTER TABLE [dbo].[tbl_earningsList]  WITH CHECK ADD  CONSTRAINT [fk_tbl_earningsBonus] FOREIGN KEY([bonusId])
REFERENCES [dbo].[tbl_bonus] ([bonusId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_earningsList] CHECK CONSTRAINT [fk_tbl_earningsBonus]
GO
ALTER TABLE [dbo].[tbl_earningsList]  WITH CHECK ADD  CONSTRAINT [fk_tbl_payrollId] FOREIGN KEY([payrollId])
REFERENCES [dbo].[tbl_payrollForm] ([payrollId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_earningsList] CHECK CONSTRAINT [fk_tbl_payrollId]
GO
ALTER TABLE [dbo].[tbl_employee]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employeeDepartment] FOREIGN KEY([departmentId])
REFERENCES [dbo].[tbl_department] ([departmentId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_employee] CHECK CONSTRAINT [fk_tbl_employeeDepartment]
GO
ALTER TABLE [dbo].[tbl_employee]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employeeEducationalAttainment] FOREIGN KEY([educationalAttainmentId])
REFERENCES [dbo].[tbl_educationalAttainment] ([educationalAttainmentId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_employee] CHECK CONSTRAINT [fk_tbl_employeeEducationalAttainment]
GO
ALTER TABLE [dbo].[tbl_employee]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employeeRole] FOREIGN KEY([roleId])
REFERENCES [dbo].[tbl_userRole] ([roleId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_employee] CHECK CONSTRAINT [fk_tbl_employeeRole]
GO
ALTER TABLE [dbo].[tbl_employeeDataLogChanges]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employeeDataChanges] FOREIGN KEY([employeeId])
REFERENCES [dbo].[tbl_employee] ([employeeId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_employeeDataLogChanges] CHECK CONSTRAINT [fk_tbl_employeeDataChanges]
GO
ALTER TABLE [dbo].[tbl_employeeLeaveCredits]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employeeLeaveCredits] FOREIGN KEY([employeeId])
REFERENCES [dbo].[tbl_employee] ([employeeId])
ON UPDATE CASCADE
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
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_formLog] CHECK CONSTRAINT [fk_tbl_leaveForm]
GO
ALTER TABLE [dbo].[tbl_formLog]  WITH CHECK ADD  CONSTRAINT [fk_tbl_passSlipForm] FOREIGN KEY([slipId])
REFERENCES [dbo].[tbl_passSlip] ([slipId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_formLog] CHECK CONSTRAINT [fk_tbl_passSlipForm]
GO
ALTER TABLE [dbo].[tbl_formLog]  WITH CHECK ADD  CONSTRAINT [fk_tbl_travelForm] FOREIGN KEY([travelOrderId])
REFERENCES [dbo].[tbl_travelOrder] ([travelOrderId])
ON UPDATE CASCADE
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
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_leave] CHECK CONSTRAINT [fk_tbl_employee_leaveTable]
GO
ALTER TABLE [dbo].[tbl_leave]  WITH CHECK ADD  CONSTRAINT [fk_tbl_leaveFormType] FOREIGN KEY([formId])
REFERENCES [dbo].[tbl_formType] ([formId])
GO
ALTER TABLE [dbo].[tbl_leave] CHECK CONSTRAINT [fk_tbl_leaveFormType]
GO
ALTER TABLE [dbo].[tbl_leave]  WITH CHECK ADD  CONSTRAINT [fk_tbl_leavetype] FOREIGN KEY([typeId])
REFERENCES [dbo].[tbl_leaveType] ([typeId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_leave] CHECK CONSTRAINT [fk_tbl_leavetype]
GO
ALTER TABLE [dbo].[tbl_leave]  WITH CHECK ADD  CONSTRAINT [fk_tbl_status] FOREIGN KEY([statusId])
REFERENCES [dbo].[tbl_status] ([statusId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_leave] CHECK CONSTRAINT [fk_tbl_status]
GO
ALTER TABLE [dbo].[tbl_leaveDefaultCredits]  WITH CHECK ADD  CONSTRAINT [fk_tbl_leaveTypeCredits] FOREIGN KEY([typeId])
REFERENCES [dbo].[tbl_leaveType] ([typeId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_leaveDefaultCredits] CHECK CONSTRAINT [fk_tbl_leaveTypeCredits]
GO
ALTER TABLE [dbo].[tbl_listOfWorkingDays]  WITH CHECK ADD  CONSTRAINT [fk_tbl_payrollWorkingDaysList] FOREIGN KEY([payrollId])
REFERENCES [dbo].[tbl_payrollForm] ([payrollId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_listOfWorkingDays] CHECK CONSTRAINT [fk_tbl_payrollWorkingDaysList]
GO
ALTER TABLE [dbo].[tbl_listOfWorkingDays]  WITH CHECK ADD  CONSTRAINT [fk_tbl_timeLog] FOREIGN KEY([timeLogId])
REFERENCES [dbo].[tbl_timeLog] ([timelogId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_listOfWorkingDays] CHECK CONSTRAINT [fk_tbl_timeLog]
GO
ALTER TABLE [dbo].[tbl_passSlip]  WITH CHECK ADD  CONSTRAINT [fk_tbl_formType] FOREIGN KEY([formId])
REFERENCES [dbo].[tbl_formType] ([formId])
GO
ALTER TABLE [dbo].[tbl_passSlip] CHECK CONSTRAINT [fk_tbl_formType]
GO
ALTER TABLE [dbo].[tbl_passSlip]  WITH CHECK ADD  CONSTRAINT [fk_tbl_passSlipEmployee] FOREIGN KEY([employeeId])
REFERENCES [dbo].[tbl_employee] ([employeeId])
GO
ALTER TABLE [dbo].[tbl_passSlip] CHECK CONSTRAINT [fk_tbl_passSlipEmployee]
GO
ALTER TABLE [dbo].[tbl_passSlip]  WITH CHECK ADD  CONSTRAINT [fk_tbl_passStatus] FOREIGN KEY([statusId])
REFERENCES [dbo].[tbl_status] ([statusId])
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
ALTER TABLE [dbo].[tbl_salaryRateValue]  WITH CHECK ADD  CONSTRAINT [fk_tbl_salaryRate] FOREIGN KEY([salaryRateId])
REFERENCES [dbo].[tbl_salaryRate] ([salaryRateId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_salaryRateValue] CHECK CONSTRAINT [fk_tbl_salaryRate]
GO
ALTER TABLE [dbo].[tbl_salaryRateValue]  WITH CHECK ADD  CONSTRAINT [fk_tbl_salaryRateTranche] FOREIGN KEY([trancheId])
REFERENCES [dbo].[tbl_salaryRateTranche] ([trancheId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_salaryRateValue] CHECK CONSTRAINT [fk_tbl_salaryRateTranche]
GO
ALTER TABLE [dbo].[tbl_salaryRateValue]  WITH CHECK ADD  CONSTRAINT [fk_tbl_salaryStep] FOREIGN KEY([stepId])
REFERENCES [dbo].[tbl_salaryRateStep] ([stepId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_salaryRateValue] CHECK CONSTRAINT [fk_tbl_salaryStep]
GO
ALTER TABLE [dbo].[tbl_timeLog]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employee] FOREIGN KEY([employeeId])
REFERENCES [dbo].[tbl_employee] ([employeeId])
ON UPDATE CASCADE
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
GO
ALTER TABLE [dbo].[tbl_travelOrder] CHECK CONSTRAINT [fk_tbl_formTypeTravelOrder]
GO
ALTER TABLE [dbo].[tbl_travelOrder]  WITH CHECK ADD  CONSTRAINT [fk_tbl_statusTravelOrder] FOREIGN KEY([statusId])
REFERENCES [dbo].[tbl_status] ([statusId])
GO
ALTER TABLE [dbo].[tbl_travelOrder] CHECK CONSTRAINT [fk_tbl_statusTravelOrder]
GO
USE [master]
GO
ALTER DATABASE [payrollProject] SET  READ_WRITE 
GO
