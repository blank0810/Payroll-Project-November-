USE [master]
GO
/****** Object:  Database [payrollProject]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_allowanceList]    Script Date: 05/01/2024 6:02:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_allowanceList](
	[allowanceListId] [int] IDENTITY(1,1) NOT NULL,
	[allowanceName] [varchar](100) NOT NULL,
	[allowanceDescription] [varchar](100) NOT NULL,
	[allowanceMinimumValue] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[allowanceListId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_appointmentForm]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_appointmentFormBenefitsDetails]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_benefits]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_benefitsContributions]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_benefitsFormula]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_calendarEvent]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_companyDetails]    Script Date: 05/01/2024 6:02:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_companyDetails](
	[companyDetailsId] [int] IDENTITY(1,1) NOT NULL,
	[companyName] [varchar](100) NOT NULL,
	[companyType] [varchar](200) NOT NULL,
	[companyEmail] [varchar](200) NOT NULL,
	[companyFacebookName] [varchar](200) NOT NULL,
	[companyFacebookLink] [varchar](200) NOT NULL,
	[barangay] [varchar](200) NOT NULL,
	[municipality] [varchar](200) NOT NULL,
	[province] [varchar](200) NOT NULL,
	[zipCode] [varchar](200) NOT NULL,
	[contactNumber] [varchar](200) NOT NULL,
	[companyLogo] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[companyDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_contractLength]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_deductionDetails]    Script Date: 05/01/2024 6:02:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_deductionDetails](
	[deductionId] [int] IDENTITY(1,1) NOT NULL,
	[payrollId] [int] NOT NULL,
	[deductionDescription] [varchar](200) NOT NULL,
	[deductionAmount] [decimal](10, 2) NOT NULL,
	[detailsId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[deductionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_department]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_earningsList]    Script Date: 05/01/2024 6:02:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_earningsList](
	[earningsListId] [int] IDENTITY(1,1) NOT NULL,
	[payrollId] [int] NOT NULL,
	[earningsDescription] [varchar](200) NOT NULL,
	[earningsAmount] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[earningsListId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_educationalAttainment]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_employee]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_employeeAllowance]    Script Date: 05/01/2024 6:02:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_employeeAllowance](
	[allowanceId] [int] IDENTITY(1,1) NOT NULL,
	[allowanceListId] [int] NOT NULL,
	[employeeId] [int] NOT NULL,
	[allowanceValue] [decimal](10, 2) NOT NULL,
	[isAllowanceEnforced] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[allowanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_employeeAllowanceAccess]    Script Date: 05/01/2024 6:02:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_employeeAllowanceAccess](
	[employeeAllowanceId] [int] IDENTITY(1,1) NOT NULL,
	[allowanceListId] [int] NOT NULL,
	[employmentStatusId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[employeeAllowanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_employeeDataLogChanges]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_employeeLeaveCredits]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_employeePassSlipHours]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_employmentStatus]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_employmentStatusAccess]    Script Date: 05/01/2024 6:02:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_employmentStatusAccess](
	[statusAccessId] [int] IDENTITY(1,1) NOT NULL,
	[employmentStatusId] [int] NOT NULL,
	[roleId] [int] NOT NULL,
	[departmentId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[statusAccessId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_eventLog]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_formLog]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_formsDefaultDaysFiling]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_formType]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_generalFormula]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_lateRecord]    Script Date: 05/01/2024 6:02:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_lateRecord](
	[lateRecordId] [int] IDENTITY(1,1) NOT NULL,
	[timeLogId] [int] NOT NULL,
	[numberOfMinutes] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[lateRecordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_leave]    Script Date: 05/01/2024 6:02:28 am ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[applicationNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_leaveDefaultCredits]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_leaveType]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_listOfWorkingDays]    Script Date: 05/01/2024 6:02:28 am ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[timeLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_logType]    Script Date: 05/01/2024 6:02:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_logType](
	[logTypeId] [int] IDENTITY(1,1) NOT NULL,
	[logTypeDescription] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[logTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_mandatedBenefits]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_mayorDetails]    Script Date: 05/01/2024 6:02:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_mayorDetails](
	[mayorDetailsId] [int] IDENTITY(1,1) NOT NULL,
	[employeeId] [int] NOT NULL,
	[dateAppointed] [date] NOT NULL,
	[termStarted] [date] NOT NULL,
	[termEnded] [date] NOT NULL,
	[isTermActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[mayorDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_overtimeRecord]    Script Date: 05/01/2024 6:02:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_overtimeRecord](
	[overtimeRecordId] [int] IDENTITY(1,1) NOT NULL,
	[timeLogId] [int] NOT NULL,
	[numberOfMinutes] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[overtimeRecordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_passSlip]    Script Date: 05/01/2024 6:02:28 am ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[slipControlNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_payrollForm]    Script Date: 05/01/2024 6:02:28 am ******/
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
	[isCertifyByOfficeHead] [bit] NULL,
	[certifiedByOfficeHeadName] [varchar](100) NULL,
	[certifiedByOfficeHeadDate] [date] NULL,
	[isApproveByMayor] [bit] NULL,
	[approvedByMayorName] [varchar](100) NULL,
	[approvedByMayorDate] [date] NULL,
	[isCertifiedByTreasurer] [bit] NULL,
	[certifiedByTreasurerName] [varchar](200) NULL,
	[certifiedByTreasurerDate] [date] NULL,
	[isReleased] [bit] NULL,
	[releasedDate] [date] NULL,
	[statusId] [int] NOT NULL,
	[payslipType] [varchar](100) NOT NULL,
	[netAmount] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[payrollId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[payrollFormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_payrollSched]    Script Date: 05/01/2024 6:02:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_payrollSched](
	[payrollSchedId] [int] IDENTITY(1,1) NOT NULL,
	[payrollScheduleDescription] [varchar](200) NOT NULL,
	[scheduleFormula] [varchar](100) NOT NULL,
	[scheduleNumberOfDays] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[payrollSchedId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_payrollTransactionLog]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_salaryRate]    Script Date: 05/01/2024 6:02:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_salaryRate](
	[salaryRateId] [int] IDENTITY(1,1) NOT NULL,
	[salaryratedescription] [varchar](300) NOT NULL,
	[salaryGradeNumber] [int] NULL,
	[salaryRateSchedule] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[salaryRateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_salaryRateStep]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_salaryRateTranche]    Script Date: 05/01/2024 6:02:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_salaryRateTranche](
	[trancheId] [int] IDENTITY(1,1) NOT NULL,
	[salaryRateTrancheDescription] [varchar](300) NOT NULL,
	[trancheNumber] [int] NULL,
	[isTrancheUsed] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[trancheId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_salaryRateValue]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_specialPrivilege]    Script Date: 05/01/2024 6:02:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_specialPrivilege](
	[specialPrivilegeId] [int] IDENTITY(1,1) NOT NULL,
	[specialPrivilegeLogDate] [date] NOT NULL,
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
/****** Object:  Table [dbo].[tbl_status]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_systemLogs]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_timeLog]    Script Date: 05/01/2024 6:02:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_timeLog](
	[timelogId] [int] IDENTITY(1,1) NOT NULL,
	[employeeId] [int] NOT NULL,
	[dateLog] [date] NOT NULL,
	[specialPrivilegeId] [int] NULL,
	[timeLog] [datetime] NOT NULL,
	[timePeriodId] [int] NOT NULL,
	[logTypeId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[timelogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_timePeriod]    Script Date: 05/01/2024 6:02:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_timePeriod](
	[timePeriodId] [int] IDENTITY(1,1) NOT NULL,
	[timePeriodDescription] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[timePeriodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_timeStatus]    Script Date: 05/01/2024 6:02:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_timeStatus](
	[timeStatusId] [int] IDENTITY(1,1) NOT NULL,
	[timeStatusDescription] [varchar](100) NOT NULL,
	[logTypeId] [int] NOT NULL,
	[timePeriodId] [int] NOT NULL,
	[fromTime] [time](7) NOT NULL,
	[toTime] [time](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[timeStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_travelOrder]    Script Date: 05/01/2024 6:02:28 am ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[orderControlNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_undertimeRecord]    Script Date: 05/01/2024 6:02:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_undertimeRecord](
	[undertimeRecordId] [int] IDENTITY(1,1) NOT NULL,
	[timeLogId] [int] NOT NULL,
	[numberOfMinutes] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[undertimeRecordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_userRole]    Script Date: 05/01/2024 6:02:28 am ******/
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
/****** Object:  Table [dbo].[tbl_viceMayorDetails]    Script Date: 05/01/2024 6:02:28 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_viceMayorDetails](
	[viceMayorDetailsId] [int] IDENTITY(1,1) NOT NULL,
	[employeeId] [int] NOT NULL,
	[dateAppointed] [date] NOT NULL,
	[termStarted] [date] NOT NULL,
	[termEnded] [date] NOT NULL,
	[isTermActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[viceMayorDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_witholdingTaxRates]    Script Date: 05/01/2024 6:02:28 am ******/
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
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_EmployeePicture_Signature]    Script Date: 05/01/2024 6:02:28 am ******/
CREATE UNIQUE NONCLUSTERED INDEX [UQ_EmployeePicture_Signature] ON [dbo].[tbl_employee]
(
	[employeePicture] ASC,
	[employeeSignature] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_allowanceList] ADD  DEFAULT ('Personnel Economic Relief Allowance') FOR [allowanceDescription]
GO
ALTER TABLE [dbo].[tbl_allowanceList] ADD  DEFAULT ((2000)) FOR [allowanceMinimumValue]
GO
ALTER TABLE [dbo].[tbl_companyDetails] ADD  DEFAULT ('Local Government Unit') FOR [companyType]
GO
ALTER TABLE [dbo].[tbl_companyDetails] ADD  DEFAULT ('initao_mayor@yahoo.com') FOR [companyEmail]
GO
ALTER TABLE [dbo].[tbl_companyDetails] ADD  DEFAULT ('LGU Initao') FOR [companyFacebookName]
GO
ALTER TABLE [dbo].[tbl_companyDetails] ADD  DEFAULT ('https://www.facebook.com/lgu.initao') FOR [companyFacebookLink]
GO
ALTER TABLE [dbo].[tbl_companyDetails] ADD  DEFAULT ('Jampason') FOR [barangay]
GO
ALTER TABLE [dbo].[tbl_companyDetails] ADD  DEFAULT ('Initao') FOR [municipality]
GO
ALTER TABLE [dbo].[tbl_companyDetails] ADD  DEFAULT ('Misamis Oriental') FOR [province]
GO
ALTER TABLE [dbo].[tbl_companyDetails] ADD  DEFAULT ('9022') FOR [zipCode]
GO
ALTER TABLE [dbo].[tbl_companyDetails] ADD  DEFAULT ('09061242507') FOR [contactNumber]
GO
ALTER TABLE [dbo].[tbl_companyDetails] ADD  DEFAULT ('initao-logo.jpg') FOR [companyLogo]
GO
ALTER TABLE [dbo].[tbl_employmentStatusAccess] ADD  DEFAULT ((1)) FOR [departmentId]
GO
ALTER TABLE [dbo].[tbl_payrollSched] ADD  DEFAULT ((22)) FOR [scheduleNumberOfDays]
GO
ALTER TABLE [dbo].[tbl_salaryRate] ADD  DEFAULT ('Monthly') FOR [salaryRateSchedule]
GO
ALTER TABLE [dbo].[tbl_salaryRateTranche] ADD  DEFAULT ((1)) FOR [isTrancheUsed]
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
ALTER TABLE [dbo].[tbl_contractLength]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employmentStatusLength] FOREIGN KEY([employmentStatusId])
REFERENCES [dbo].[tbl_employmentStatus] ([employmentStatusId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_contractLength] CHECK CONSTRAINT [fk_tbl_employmentStatusLength]
GO
ALTER TABLE [dbo].[tbl_deductionDetails]  WITH CHECK ADD  CONSTRAINT [fk_tbl_deductionDetails] FOREIGN KEY([detailsId])
REFERENCES [dbo].[tbl_appointmentFormBenefitsDetails] ([detailsId])
GO
ALTER TABLE [dbo].[tbl_deductionDetails] CHECK CONSTRAINT [fk_tbl_deductionDetails]
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
ALTER TABLE [dbo].[tbl_employeeAllowance]  WITH CHECK ADD  CONSTRAINT [fk_tbl_allowanceListAllocation] FOREIGN KEY([allowanceListId])
REFERENCES [dbo].[tbl_allowanceList] ([allowanceListId])
GO
ALTER TABLE [dbo].[tbl_employeeAllowance] CHECK CONSTRAINT [fk_tbl_allowanceListAllocation]
GO
ALTER TABLE [dbo].[tbl_employeeAllowance]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employeeAllowance] FOREIGN KEY([employeeId])
REFERENCES [dbo].[tbl_employee] ([employeeId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_employeeAllowance] CHECK CONSTRAINT [fk_tbl_employeeAllowance]
GO
ALTER TABLE [dbo].[tbl_employeeAllowanceAccess]  WITH CHECK ADD  CONSTRAINT [fk_tbl_allowanceAccess] FOREIGN KEY([allowanceListId])
REFERENCES [dbo].[tbl_allowanceList] ([allowanceListId])
GO
ALTER TABLE [dbo].[tbl_employeeAllowanceAccess] CHECK CONSTRAINT [fk_tbl_allowanceAccess]
GO
ALTER TABLE [dbo].[tbl_employeeAllowanceAccess]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employmentAllowance] FOREIGN KEY([employmentStatusId])
REFERENCES [dbo].[tbl_employmentStatus] ([employmentStatusId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_employeeAllowanceAccess] CHECK CONSTRAINT [fk_tbl_employmentAllowance]
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
ALTER TABLE [dbo].[tbl_employmentStatusAccess]  WITH CHECK ADD  CONSTRAINT [fk_tbl_departmentName] FOREIGN KEY([departmentId])
REFERENCES [dbo].[tbl_department] ([departmentId])
GO
ALTER TABLE [dbo].[tbl_employmentStatusAccess] CHECK CONSTRAINT [fk_tbl_departmentName]
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
ALTER TABLE [dbo].[tbl_lateRecord]  WITH CHECK ADD  CONSTRAINT [fk_tbl_lateLogs] FOREIGN KEY([timeLogId])
REFERENCES [dbo].[tbl_timeLog] ([timelogId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_lateRecord] CHECK CONSTRAINT [fk_tbl_lateLogs]
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
ALTER TABLE [dbo].[tbl_mayorDetails]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employeeMayorDetails] FOREIGN KEY([employeeId])
REFERENCES [dbo].[tbl_employee] ([employeeId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_mayorDetails] CHECK CONSTRAINT [fk_tbl_employeeMayorDetails]
GO
ALTER TABLE [dbo].[tbl_overtimeRecord]  WITH CHECK ADD  CONSTRAINT [fk_tbl_overtimeLogs] FOREIGN KEY([timeLogId])
REFERENCES [dbo].[tbl_timeLog] ([timelogId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_overtimeRecord] CHECK CONSTRAINT [fk_tbl_overtimeLogs]
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
ALTER TABLE [dbo].[tbl_timeLog]  WITH CHECK ADD  CONSTRAINT [fk_tbl_specialPrivilegeLog] FOREIGN KEY([specialPrivilegeId])
REFERENCES [dbo].[tbl_specialPrivilege] ([specialPrivilegeId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_timeLog] CHECK CONSTRAINT [fk_tbl_specialPrivilegeLog]
GO
ALTER TABLE [dbo].[tbl_timeLog]  WITH CHECK ADD  CONSTRAINT [fk_tbl_timeLogLogType] FOREIGN KEY([logTypeId])
REFERENCES [dbo].[tbl_logType] ([logTypeId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_timeLog] CHECK CONSTRAINT [fk_tbl_timeLogLogType]
GO
ALTER TABLE [dbo].[tbl_timeLog]  WITH CHECK ADD  CONSTRAINT [fk_tbl_timeLogPeriod] FOREIGN KEY([timePeriodId])
REFERENCES [dbo].[tbl_timePeriod] ([timePeriodId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_timeLog] CHECK CONSTRAINT [fk_tbl_timeLogPeriod]
GO
ALTER TABLE [dbo].[tbl_timeStatus]  WITH CHECK ADD  CONSTRAINT [fk_tbl_logTypeStatus] FOREIGN KEY([logTypeId])
REFERENCES [dbo].[tbl_logType] ([logTypeId])
GO
ALTER TABLE [dbo].[tbl_timeStatus] CHECK CONSTRAINT [fk_tbl_logTypeStatus]
GO
ALTER TABLE [dbo].[tbl_timeStatus]  WITH CHECK ADD  CONSTRAINT [fk_tbl_timePeriodStatus] FOREIGN KEY([timePeriodId])
REFERENCES [dbo].[tbl_timePeriod] ([timePeriodId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_timeStatus] CHECK CONSTRAINT [fk_tbl_timePeriodStatus]
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
ALTER TABLE [dbo].[tbl_undertimeRecord]  WITH CHECK ADD  CONSTRAINT [fk_tbl_undertimeLogs] FOREIGN KEY([timeLogId])
REFERENCES [dbo].[tbl_timeLog] ([timelogId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_undertimeRecord] CHECK CONSTRAINT [fk_tbl_undertimeLogs]
GO
ALTER TABLE [dbo].[tbl_viceMayorDetails]  WITH CHECK ADD  CONSTRAINT [fk_tbl_employeeViceMayorDetails] FOREIGN KEY([employeeId])
REFERENCES [dbo].[tbl_employee] ([employeeId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[tbl_viceMayorDetails] CHECK CONSTRAINT [fk_tbl_employeeViceMayorDetails]
GO
USE [master]
GO
ALTER DATABASE [payrollProject] SET  READ_WRITE 
GO
