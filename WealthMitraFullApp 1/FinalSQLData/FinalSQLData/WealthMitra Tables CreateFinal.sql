
--Create database WealthMitra
--Use WealthMitra

--drop database WealthMitra

--Tables

create table Roles(
RoleId int primary key identity,
RoleName varchar(100) not null unique,
IsActive Bit default 1,
RecordCreatedBy varchar(100) not null default 'Admin',
RecordCreatedDate datetime,
RecordModifiedBy varchar(100),
RecordModifiedDate Datetime
)

create table sector(
SectorId int primary key identity,
SectorName varchar(100) not null unique,
IsActive Bit default 1,
RecordCreatedBy varchar(100) not null default 'Admin',
RecordCreatedDate datetime,
RecordModifiedBy varchar(100),
RecordModifiedDate Datetime
)

create table Assets(
AssetId int primary key identity,
AssetName varchar(100) not null unique,
IsActive Bit default 1,
RecordCreatedBy varchar(100) not null default 'Admin',
RecordCreatedDate datetime,
RecordModifiedBy varchar(100),
RecordModifiedDate Datetime
)

create table SubscriptionPlans(
SubscriptionPlanId int primary key identity,
SubscriptionPlanName varchar(100) not null unique,
Price float not null,
Features varchar(100) not null,
IsActive Bit default 1,
RecordCreatedBy varchar(100) not null default 'Admin',
RecordCreatedDate datetime,
RecordModifiedBy varchar(100),
RecordModifiedDate Datetime
)

create table Country(
CountryId int primary key identity,
CountryName varchar(100) not null unique,
IsActive Bit default 1,
RecordCreatedBy varchar(100) not null default 'Admin',
RecordCreatedDate datetime,
RecordModifiedBy varchar(100),
RecordModifiedDate Datetime
)

create table Credentials(
CredentialId int primary key identity,
UserName varchar(100) not null unique,
Password varchar(100) not null,
RoleId int references Roles(RoleId),
IsActive Bit default 1,
RecordCreatedBy varchar(100) not null default 'Admin',
RecordCreatedDate datetime,
RecordModifiedBy varchar(100),
RecordModifiedDate Datetime
)

create table State(
StateId int primary key identity,
StateName varchar(100) not null unique,
CountryId int references Country(CountryId),
IsActive Bit default 1,
RecordCreatedBy varchar(100) not null default 'Admin',
RecordCreatedDate datetime,
RecordModifiedBy varchar(100),
RecordModifiedDate Datetime
)

create table City(
CityId int primary key identity,
CityName varchar(100) not null unique,
StateId int references State(StateId),
IsActive Bit default 1,
RecordCreatedBy varchar(100) not null default 'Admin',
RecordCreatedDate datetime,
RecordModifiedBy varchar(100),
RecordModifiedDate Datetime
)

create table Employees(
EmployeeId int primary key identity,
FName varchar(100) not null,
MName varchar(100),
LName varchar(100) not null,
Email varchar(100) not null unique,
MobileNo bigint not null unique,
AltrnateMobileNo bigint ,
Age int,
Pan varchar(100) unique,
Gender varchar(100) ,
DOB Datetime ,
MaritalStatus varchar(100) ,
AddressLine1 varchar(100),
AddressLine2 varchar(100),
Pincode int,
AadharNo varchar(100) unique,
CityId int references City(CityId),
CredentialId int references Credentials(CredentialId),
RoleId int references Roles(RoleId),
Experience varchar(100),
JoiningDate datetime,
IsActive Bit default 1,
RecordCreatedBy varchar(100) not null default 'Admin',
RecordCreatedDate datetime,
RecordModifiedBy varchar(100),
RecordModifiedDate Datetime
)

create table Products(
ProductId int primary key identity,
ProductName varchar(100) not null unique,
AssetId int references Assets(AssetId),
IsActive Bit default 1,
RecordCreatedBy varchar(100) not null default 'Admin',
RecordCreatedDate datetime,
RecordModifiedBy varchar(100),
RecordModifiedDate Datetime
)

create table AssetProductCategory(
AssetProductCategoryId int primary key identity,
ProductId int references Products(ProductId),
CategoryName varchar(100) not null,
IsActive Bit default 1,
RecordCreatedBy varchar(100) not null default 'Admin',
RecordCreatedDate datetime,
RecordModifiedBy varchar(100),
RecordModifiedDate Datetime
)

create table Investors(
InvestorId int primary key identity,
FName varchar(100) not null,
MName varchar(100),
LName varchar(100) not null,
Email varchar(100) not null unique,
MobileNo bigint not null unique,
AltrnateMobileNo bigint ,
Age int ,
Pan varchar(100)  unique,
Gender varchar(100) ,
DOB Datetime ,
MaritalStatus varchar(100),
AddressLine1 varchar(100),
AddressLine2 varchar(100),
Pincode int,
AadharNo varchar(100) unique,
CityId int references City(CityId),
CredentialId int references Credentials(CredentialId),
EmployeeId int references Employees(EmployeeId),
SubscriptionPlanId int references SubscriptionPlans(SubscriptionPlanid),
CurrentStatus varchar(100),
PlanPurchasedDate datetime,
PlanExpirydate datetime,
IsActive Bit default 1,
RecordCreatedBy varchar(100) not null default 'Admin',
RecordCreatedDate datetime,
RecordModifiedBy varchar(100),
RecordModifiedDate Datetime
)

create table Stocks(
StockId int primary key identity,
StockName varchar(100) unique,
SchemeCode varchar(100) unique,
AssetProductCategoryId int references AssetProductCategory(AssetProductCategoryId),
SectorId int references Sector(SectorId),
IsActive Bit default 1,
RecordCreatedBy varchar(100) not null default 'Admin',
RecordCreatedDate datetime,
RecordModifiedBy varchar(100),
RecordModifiedDate Datetime
)

create table MutualFunds(
MutualFundId int primary key identity,
MutualFundName varchar(100) unique,
SchemeCode varchar(100) unique,
AssetProductCategoryId int references AssetProductCategory(AssetProductCategoryId),
SectorId int references Sector(SectorId),
IsActive Bit default 1,
RecordCreatedBy varchar(100) not null default 'Admin',
RecordCreatedDate datetime,
RecordModifiedBy varchar(100),
RecordModifiedDate Datetime
)

create table Instruments(
InstrumentId int primary key identity,
SchemeCode varchar(100) unique,
MasterType varchar(100),
MasterTypeId int,
AssetProductCategoryId int references AssetProductCategory(AssetProductCategoryId)
)

create table Transactions(
TransactionId int identity primary key,
InvestorId int references Investors(InvestorId),
InstrumentId int references Instruments(InstrumentId),
NameOfInstrument varchar(100) not null,
SchemeCode varchar(100) not null,
Action varchar(100),
Units int,
UnitValue float,
ActionDate datetime,
ProfitLoss float,
ROI float,
IsActive Bit default 1,
RecordCreatedBy varchar(100) not null default 'Admin',
RecordCreatedDate datetime,
RecordModifiedBy varchar(100),
RecordModifiedDate Datetime
)

create table TransactionBuy(
TransactionId int identity primary key,
InvestorId int references Investors(InvestorId),
InstrumentId int references Instruments(InstrumentId),
NameOfInstrument varchar(100) not null,
SchemeCode varchar(100) not null,
Action varchar(100),
Units int,
UnitValue float,
ActionDate datetime,
IsActive Bit default 1,
RecordCreatedBy varchar(100) not null default 'Admin',
RecordCreatedDate datetime,
RecordModifiedBy varchar(100),
RecordModifiedDate Datetime,
)

create table Summary(
SummaryId int primary key identity,
InvestorId int references Investors(InvestorId),
NameOfInstruments varchar(100) not null ,
SchemeCode varchar(100) not null,
Units int ,
AverageValue float,
TotalValueOfInvestment float,
RecordCreatedDate datetime
)


