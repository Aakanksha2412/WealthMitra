insert into Roles(RoleName,RecordCreatedDate) values('Admin',GETDATE())
insert into Roles(RoleName,RecordCreatedDate) values('CEO',GETDATE())
insert into Roles(RoleName,RecordCreatedDate) values('Advisor',GETDATE())
insert into Roles(RoleName,RecordCreatedDate) values('Investor',GETDATE())

---------------------------------

insert into sector(SectorName,RecordCreatedDate) values('IT',GETDATE())
insert into sector(SectorName,RecordCreatedDate) values('Electornics',GETDATE())
insert into sector(SectorName,RecordCreatedDate) values('Finance',GETDATE())
insert into sector(SectorName,RecordCreatedDate) values('Oil',GETDATE())

---------------------------------------

insert into Assets(AssetName,RecordCreatedDate) values('Equity',GETDATE())
insert into Assets(AssetName,RecordCreatedDate) values('Debt',GETDATE())
insert into Assets(AssetName,RecordCreatedDate) values('Liquid',GETDATE())

---------------------------------------------
insert into SubscriptionPlans(SubscriptionPlanName,Price,Features,RecordCreatedDate)
values('Platinum',2000,'20 Advices/Month and Portfolio Management',GETDATE())
insert into SubscriptionPlans(SubscriptionPlanName,Price,Features,RecordCreatedDate)
values('Gold',1500,'12 Advices/Month and Portfolio Management',GETDATE())
insert into SubscriptionPlans(SubscriptionPlanName,Price,Features,RecordCreatedDate)
values('Silver',1000,'8 Advices/Month and Portfolio Management',GETDATE())
insert into SubscriptionPlans(SubscriptionPlanName,Price,Features,RecordCreatedDate)
values('PMS',500,'Portfolio Management',GETDATE())


select * from SubscriptionPlans

-------------------------------

insert into Country(CountryName,RecordCreatedDate) values('India',GETDATE())
insert into Country(CountryName,RecordCreatedDate) values('USA',GETDATE())
insert into Country(CountryName,RecordCreatedDate) values('China',GETDATE())

----------------------------------

--insert into State(StateName,CountryId,RecordCreatedDate) values('Rajasthan',1,GETDATE())
--insert into State(StateName,CountryId,RecordCreatedDate) values('Maharastra',1,GETDATE())
--insert into State(StateName,CountryId,RecordCreatedDate) values('U.P',1,GETDATE())
--insert into State(StateName,CountryId,RecordCreatedDate) values('California',2,GETDATE())

exec sp_AddState @StateName ='Rajasthan',@CountryName ='India'
exec sp_AddState @StateName ='Maharashtra',@CountryName ='India'
exec sp_AddState @StateName ='Gujarat',@CountryName ='India'


----------------------------------------
select * from State
--insert into City(StateId,CityName,RecordCreatedDate) values (1,'Alwar',GETDATE())
--insert into City(StateId,CityName,RecordCreatedDate) values (2,'Pune',GETDATE())
--insert into City(StateId,CityName,RecordCreatedDate) values (4,'Los Angeles',GETDATE())

exec sp_AddCity @CityName='Pune' ,@StateName='Maharashtra'
exec sp_AddCity @CityName='Jaipur' ,@StateName='Rajasthan'
exec sp_AddCity @CityName='Surat' ,@StateName='Gujarat'

-------------------------------------------
select * from Credentials
--insert into Credentials(UserName,Password,RoleId,RecordCreatedDate) values('pkhandelwal@gmail.com','seed',1,GETDATE())
--insert into Credentials(UserName,Password,RoleId,RecordCreatedDate) values('kanaad@gmal.com','seed',2,GETDATE())
--insert into Credentials(UserName,Password,RoleId,RecordCreatedDate) values('sampada@gmail.com','seed',3,GETDATE())
--insert into Credentials(UserName,Password,RoleId,RecordCreatedDate) values('shubham@gmail.com','seed',3,GETDATE())
--insert into Credentials(UserName,Password,RoleId,RecordCreatedDate) values('avip@gmail.com','seed',4,GETDATE())
--insert into Credentials(UserName,Password,RoleId,RecordCreatedDate) values('umang@gmail.com','seed',4,GETDATE())

---------------------------------
select * from Credentials
select * from City
--insert into Employees(FName,MName,LName,Email,MobileNo,AltrnateMobileNo,Age,Pan,Gender,DOB,MaritalStatus,AddressLine1,AddressLine2,Pincode,AadharNo,CityId,CredentialId,RoleId,Experience,JoiningDate,RecordCreatedDate)
--values('Sampada','','Pote','sampada@gmail.com',1234567,12314223,21,'JLPK12312','Female','1998-05-20','Married','abc xyz','qwer',422001,'ASD342323423423',2,3,3,'2 years','2020-08-05',GETDATE())

--insert into Employees(FName,MName,LName,Email,MobileNo,AltrnateMobileNo,Age,Pan,Gender,DOB,MaritalStatus,AddressLine1,AddressLine2,Pincode,AadharNo,CityId,CredentialId,RoleId,Experience,JoiningDate,RecordCreatedDate)
--values('Shubham','','Premi','shubham@gmail.com',1244567,02314223,21,'JLPK14412','Male','1998-06-12','Married','sddf xdfz','rewf',301001,'MSP342323423423',1,4,3,'1 year','2020-08-05',GETDATE())

--insert into Employees(FName,MName,LName,Email,MobileNo,AltrnateMobileNo,Age,Pan,Gender,DOB,MaritalStatus,AddressLine1,AddressLine2,Pincode,AadharNo,CityId,CredentialId,RoleId,Experience,JoiningDate,RecordCreatedDate)
--values('Niteshkumar','Ramesh','Singh','niteshsingh@gmail.com',7483268723,3487912363,22,'JLPK15512','Male','1998-06-12','Married','sddf xdfz','rewf',301001,'342553423423',1,4,3,'1 year','2020-08-05',GETDATE())

--insert into Employees(FName,MName,LName,Email,MobileNo,AltrnateMobileNo,Age,Pan,Gender,DOB,MaritalStatus,AddressLine1,AddressLine2,Pincode,AadharNo,CityId,CredentialId,RoleId,Experience,JoiningDate,RecordCreatedDate)
--values('Aakanksha','Ajay','Shinde','aaks@gmail.com',7483255723,3487911163,21,'JLPK16412','Female','1998-06-12','Unmarried','sddf xdfz','rewf',411027,'342344423423',1,4,3,'1 year','2020-08-05',GETDATE())
exec sp_AddEmployee @Fname='Prashant', @Mname='Ajay', @Lname='Kote', @Email='prashant@gmail.com', @MobileNo = 1235567890,@PAN = 'frt79sda', @AadharNo = '123885464666', @Password='seed', @RoleName='Admin',@Experience='1 year'
exec sp_AddEmployee @Fname='Kannad', @Mname='Vilas', @Lname='Rampurkar', @Email='kannad@gmail.com', @MobileNo = 1235567780,@PAN = 'frtt9sda', @AadharNo = '123885676666', @Password='seed', @RoleName='CEO',@Experience='6 months'
exec sp_AddEmployee @Fname='Shubham', @Mname='Amol', @Lname='Premi', @Email='shubham@gmail.com', @MobileNo = 1235222890,@PAN = 'frtersda', @AadharNo = '123885464888', @Password='seed', @RoleName='Advisor',@Experience='2 months'
exec sp_AddEmployee @Fname='Rani', @Mname='Mitesh', @Lname='Bachate', @Email='rani@gmail.com', @MobileNo = 1235564540,@PAN = 'frt79dfa', @AadharNo = '123885464668', @Password='seed', @RoleName='Advisor',@Experience='1 year'

-------------------------------------------
select * from Investors
truncate table investors
select * from Roles
select * from Credentials
select * from Employees
--insert into Investors(FName,MName,LName,Email,MobileNo,AltrnateMobileNo,Age,Pan,Gender,DOB,MaritalStatus,AddressLine1,AddressLine2,Pincode,AadharNo,CityId,CredentialId,EmployeeId,SubscriptionPlanId,CurrentStatus,PlanPurchasedDate,PlanExpirydate,RecordCreatedDate)
--values('Avip','','Kumar','avip@gmail.com',1234367,13214233,23,'JLPK22112','Male','1998-05-09','Unmarried','ert xyz','fwer',422001,'ASD3423200923',2,5,1,1,'','2020-09-07','2020-10-07',GETDATE())

--insert into Investors(FName,MName,LName,Email,MobileNo,AltrnateMobileNo,Age,Pan,Gender,DOB,MaritalStatus,AddressLine1,AddressLine2,Pincode,AadharNo,CityId,CredentialId,EmployeeId,SubscriptionPlanId,CurrentStatus,PlanPurchasedDate,PlanExpirydate,RecordCreatedDate)
--values('Umang','','Jain','umang@gmail.com',1245367,99321423,23,'JLPK12472','Female','1999-10-09','Unmarried','polkchd','djfhd',301001,'ASD345345623',1,6,2,2,'','2020-08-07','2020-09-07',GETDATE())

--insert into Investors(FName,MName,LName,Email,MobileNo,AltrnateMobileNo,Age,Pan,Gender,DOB,MaritalStatus,AddressLine1,AddressLine2,Pincode,AadharNo,CityId,CredentialId,EmployeeId,SubscriptionPlanId,CurrentStatus,PlanPurchasedDate,PlanExpirydate,RecordCreatedDate)
--values('Gayatri','','Jadhav','gj@gmail.com',1245367890,1244467890,23,'JLPK22272','Female','1999-10-09','Unmarried','polkchd','djfhd',301001,'ASD345345623',1,6,2,2,'','2020-08-07','2020-09-07',GETDATE())

--insert into Investors(FName,MName,LName,Email,MobileNo,AltrnateMobileNo,Age,Pan,Gender,DOB,MaritalStatus,AddressLine1,AddressLine2,Pincode,AadharNo,CityId,CredentialId,EmployeeId,SubscriptionPlanId,CurrentStatus,PlanPurchasedDate,PlanExpirydate,RecordCreatedDate)
--values('Umang','','Jain','umang@gmail.com',1245367,99321423,23,'JLPK12472','Female','1999-10-09','Unmarried','polkchd','djfhd',301001,'ASD345345623',1,6,2,2,'','2020-08-07','2020-09-07',GETDATE())
--------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------

exec sp_AddInvestor @Fname='Avip', @Mname='Ramesh', @Lname='Patil', @Email='avip@gmail.com', @MobileNo = 1234567890,@PAN = 'fd879sda', @AadharNo = '123435464666', @Password='seed',@CityName='Pune'
exec sp_AddInvestor @Fname='Umang', @Mname='Amar', @Lname='Jain', @Email='umang@gmail.com', @MobileNo = 1234567888,@PAN = 'fd777sda', @AadharNo = '123435464777', @Password='seed',@CityName='Pune'
exec sp_AddInvestor @Fname='Shubham', @Mname='Rajeev', @Lname='Premi', @Email='shubham@gmail.com', @MobileNo = 1234567777,@PAN = 'fd777sds', @AadharNo = '123435123777', @Password='seed',@CityName='Pune'
exec sp_AddInvestor @Fname='Kanaad', @Mname='Rahul', @Lname='Rampurkar', @Email='kanaad@gmail.com', @MobileNo = 1234569990,@PAN = 'fd777wer', @AadharNo = '123435456777', @Password='seed',@CityName='Pune'

truncate table Investors
truncate table Credentials
delete from Investors
delete from Credentials
select * from Investors
select * from Credentials


-----------------------------------------
select * from Products
insert into Products(ProductName,AssetId,RecordCreatedDate) values ('Stocks',1,GETDATE())
insert into Products(ProductName,AssetId,RecordCreatedDate) values ('Debt Mutual Funds',2,GETDATE())
insert into Products(ProductName,AssetId,RecordCreatedDate) values ('Liquid Mutual Funds',3,GETDATE())
insert into Products(ProductName,AssetId,RecordCreatedDate) values ('Equity Mutual Funds',1,GETDATE())
insert into Products(ProductName,AssetId,RecordCreatedDate) values ('Cash',3,GETDATE())

------------------------------------------
select * from Products
select * from AssetProductCategory
--insert Into AssetProductCategory(ProductId,CategoryName,RecordCreatedDate) values(1,'SmallCap',GETDATE())
--insert Into AssetProductCategory(ProductId,CategoryName,RecordCreatedDate) values(2,'MidCap',GETDATE())
--insert Into AssetProductCategory(ProductId,CategoryName,RecordCreatedDate) values(1,'LargeCap',GETDATE())
--insert Into AssetProductCategory(ProductId,CategoryName,RecordCreatedDate) values(4,'LargeCap',GETDATE())
--insert Into AssetProductCategory(ProductId,CategoryName,RecordCreatedDate) values(3,'LargeCap',GETDATE())
--insert Into AssetProductCategory(ProductId,CategoryName,RecordCreatedDate) values(5,'MidCap',GETDATE())

exec sp_AddCategory @CategoryName='Small Cap', @ProductName='Stocks' 
exec sp_AddCategory @CategoryName='MidCap', @ProductName='Stocks' 
exec sp_AddCategory @CategoryName='LargeCap', @ProductName='Stocks' 
exec sp_AddCategory @CategoryName='LargeCap', @ProductName='Liquid Mutual Funds' 
exec sp_AddCategory @CategoryName='Small Cap', @ProductName='Liquid Mutual Funds' 
exec sp_AddCategory @CategoryName='MidCap', @ProductName='Liquid Mutual Funds' 
exec sp_AddCategory @CategoryName='Small Cap', @ProductName='Debt Mutual Funds'
exec sp_AddCategory @CategoryName='MidCap', @ProductName='Debt Mutual Funds'
exec sp_AddCategory @CategoryName='LargeCap', @ProductName='Debt Mutual Funds'
exec sp_AddCategory @CategoryName='Small Cap', @ProductName='Equity Mutual Funds'
exec sp_AddCategory @CategoryName='MidCap', @ProductName='Equity Mutual Funds'
exec sp_AddCategory @CategoryName='LargeCap', @ProductName='Equity Mutual Funds'

delete from AssetProductCategory where AssetProductCategoryId = 5 

-------------------------------------------------

--insert into Stocks(StockName,SchemeCode,AssetProductCategoryId,SectorId,IsActive,RecordCreatedDate) values('Bajaj Ltd','BAJLTD',1,3,1,GETDATE());
--insert into Stocks(StockName,SchemeCode,AssetProductCategoryId,SectorId,IsActive,RecordCreatedDate) values('COFORGE','COFOE',1,1,1,GETDATE());
--insert into Stocks(StockName,SchemeCode,AssetProductCategoryId,SectorId,IsActive,RecordCreatedDate) values('TCS','TCS23',2,2,1,GETDATE());
--insert into Stocks(StockName,SchemeCode,AssetProductCategoryId,SectorId,IsActive,RecordCreatedDate) values('Bajaj Motors','BAJMTS',3,3,1,GETDATE());

exec sp_AddMutualFundsAndInstruments @SchemeCode='12345' ,@MutualFundName='Accenture LTD' ,@ProductName = 'Debt Mutual Funds',@CategoryName='SmallCap' ,@SectorName='IT'
exec sp_AddMutualFundsAndInstruments @SchemeCode='12346' ,@MutualFundName='Accenture2 LTD' ,@ProductName = 'Equity Mutual Funds',@CategoryName='MidCap' ,@SectorName='IT'
exec sp_AddMutualFundsAndInstruments @SchemeCode='12347' ,@MutualFundName='Bajaj LTD Funds' ,@ProductName = 'Liduid Mutual Funds',@CategoryName='LargeCap' ,@SectorName='IT'
exec sp_AddMutualFundsAndInstruments @SchemeCode='12348' ,@MutualFundName='Bajaj LTD2 Funds' ,@ProductName = 'Equity Mutual Funds',@CategoryName='MidCap' ,@SectorName='IT'
exec sp_AddMutualFundsAndInstruments @SchemeCode='12349' ,@MutualFundName=' ICICI Funds' ,@ProductName = 'Liquid Mutual Funds',@CategoryName='SmallCap' ,@SectorName='Finance'
exec sp_AddMutualFundsAndInstruments @SchemeCode='12644' ,@MutualFundName='ICICIDebt Funds ' ,@ProductName = 'Debt Mutual Funds',@CategoryName='MidCap' ,@SectorName='Finance'
exec sp_AddStocksAndInstruments @SchemeCode='ACCT' ,@StockName='Accenture' ,@CategoryName='Small Cap',@ProductName='Stocks' ,@SectorName='Finance'
exec sp_AddStocksAndInstruments @SchemeCode='TCS45' ,@StockName='TCS' ,@CategoryName='Small Cap',@ProductName='Stocks' ,@SectorName='IT'
exec sp_AddStocksAndInstruments @SchemeCode='COFOREG' ,@StockName='COFOREG' ,@CategoryName='midCap',@ProductName='Stocks' ,@SectorName='IT'
exec sp_AddStocksAndInstruments @SchemeCode='BjLtd' ,@StockName='BajajLtd' ,@CategoryName='largeCap',@ProductName='Stocks' ,@SectorName='IT'
select * from AssetProductCategory
select * from Sector
delete from Stocks
select * from Products
-----------------------------------------------------
--insert into MutualFunds(MutualFundName,SchemeCode,AssetProductCategoryId,SectorId,IsActive,RecordCreatedDate) values('Bajaj Ltd Fund','23423',4,1,1,GETDATE());
--insert into MutualFunds(MutualFundName,SchemeCode,AssetProductCategoryId,SectorId,IsActive,RecordCreatedDate) values('KForge','23424',6,1,1,GETDATE());
--insert into MutualFunds(MutualFundName,SchemeCode,AssetProductCategoryId,SectorId,IsActive,RecordCreatedDate) values('Xoriant','23425',7,2,1,GETDATE());
--insert into MutualFunds(MutualFundName,SchemeCode,AssetProductCategoryId,SectorId,IsActive,RecordCreatedDate) values('Nihilent Ltd Fund','23426',11,2,1,GETDATE());
--insert into MutualFunds(MutualFundName,SchemeCode,AssetProductCategoryId,SectorId,IsActive,RecordCreatedDate) values('ICICI Ltd Fund','23427',9,3,1,GETDATE());
--insert into MutualFunds(MutualFundName,SchemeCode,AssetProductCategoryId,SectorId,IsActive,RecordCreatedDate) values('Capgemini Ltd Fund','23428',8,3,1,GETDATE());

delete from MutualFunds where MutualFundId = 8
----------------------------------------------------------
select * from MutualFunds
select * from Stocks
select * from Instruments
select * from Products
select * from AssetProductCategory
select * from MutualFunds

drop table Stocks

---------------------------------------------------------
-------------------------------------------------------------

--insert into Transactions(InvestorId,InstrumentId,NameOfInstrument,SchemeCode,Action,Units,UnitValue,ActionDate,RecordCreatedDate)
--values(1,1,'Coforge Limited','COFORGE','buy',10,290,GETDATE(),GETDATE())
--insert into Transactions(InvestorId,InstrumentId,NameOfInstrument,SchemeCode,Action,Units,UnitValue,ActionDate,RecordCreatedDate)
--values(2,2,'Bajaj Finance','BAJFINANCE','buy',8,1000,GETDATE(),GETDATE())
--insert into Transactions(InvestorId,InstrumentId,NameOfInstrument,SchemeCode,Action,Units,UnitValue,ActionDate,RecordCreatedDate)
--values(1,3,'Bajaj Finserv','BAJAJFINSV','buy',5,500,GETDATE(),GETDATE())
select * from Transactions 
select * from TransactionBuy
select * from Summary
select * from Roles

select * from Investors
select * from Stocks
select * from MutualFunds
select * from Employees
select * from Transactions
select * from Credentials
select * from Instruments
select * from AssetProductCategory


print GETDATE()
exec sp_InsertTransactions @NameOfInstrument='Accenture LTD',@SchemeCode='87654',@Action='buy',@Units=12,@UnitValue=100,@InvestorId=1
exec sp_InsertTransactions @NameOfInstrument='ICICI Funds',@SchemeCode='12344',@Action='buy',@Units=15,@UnitValue=400,@InvestorId=1
exec sp_InsertTransactions @NameOfInstrument='Bajaj LTD2 Funds',@SchemeCode='12348',@Action='buy',@Units=11,@UnitValue=10,@InvestorId=1
exec sp_InsertTransactions @NameOfInstrument='Accenture2 LTD',@SchemeCode='12346',@Action='buy',@Units=12,@UnitValue=350,@InvestorId=2
exec sp_InsertTransactions @NameOfInstrument='ICICIDebt Funds ',@SchemeCode='12644',@Action='buy',@Units=11,@UnitValue=400,@InvestorId=2
exec sp_InsertTransactions @NameOfInstrument='Accenture LTD',@SchemeCode='87654',@Action='buy',@Units=10,@UnitValue=300,@InvestorId=2
exec sp_InsertTransactions @NameOfInstrument='Accenture',@SchemeCode='ACCT',@Action='buy',@Units=12,@UnitValue=100,@InvestorId=1
exec sp_InsertTransactions @NameOfInstrument='TCS',@SchemeCode='TCS45',@Action='buy',@Units=15,@UnitValue=400,@InvestorId=1
exec sp_InsertTransactions @NameOfInstrument='TCS',@SchemeCode='TCS45',@Action='buy',@Units=11,@UnitValue=10,@InvestorId=1
exec sp_InsertTransactions @NameOfInstrument='BajajLtd',@SchemeCode='BjLtd',@Action='buy',@Units=12,@UnitValue=350,@InvestorId=2
exec sp_InsertTransactions @NameOfInstrument='COFOREG',@SchemeCode='COFOREG',@Action='buy',@Units=11,@UnitValue=400,@InvestorId=2
exec sp_InsertTransactions @NameOfInstrument='COFOREG',@SchemeCode='COFOREG',@Action='buy',@Units=10,@UnitValue=300,@InvestorId=2

exec sp_AddEmployee @Fname='Avip', @Mname='Ramesh', @Lname='Patil', @Email='avip12@gmail.com', @MobileNo = 3334567890,@RoleName = 'Advisor',@PAN = 'fa879sda', @AadharNo = '443435464666', @Password='seed',@CityName='Pune'
exec sp_AddEmployee @Fname='Umang', @Mname='Amar', @Lname='Jain', @Email='umang12@gmail.com', @MobileNo = 3334567888,@RoleName = 'Admin',@PAN = 'fa777sda',@AadharNo = '443435464777', @Password='seed',@CityName='Pune'
exec sp_AddEmployee @Fname='Shubham', @Mname='Rajeev', @Lname='Premi', @Email='shubham12@gmail.com', @MobileNo = 3334567777,@RoleName = 'CEO',@PAN = 'fa777sds', @AadharNo = '443435123777', @Password='seed',@CityName='Pune'
exec sp_AddEmployee @Fname='Kanaad', @Mname='Rahul', @Lname='Rampurkar', @Email='kanaad12@gmail.com', @MobileNo = 3334569990,@RoleName = 'Advisor',@PAN = 'fa777wer',@AadharNo = '443435456777', @Password='seed',@CityName='Pune'


select sum (ProfitLoss) as ProfitLoss,sum (ROI) as ROI ,(select  sum(TotalValueOfInvestment) from Summary join Investors on Investors.InvestorId=Summary.InvestorId
                                    where Investors.EmployeeId=1 ) as TotalValueOfInvestment
                                    from Transactions join Investors on Transactions.InvestorId=Investors.InvestorId
                                    where Investors.InvestorId=11
select sum (ProfitLoss) as ProfitLoss,sum (ROI) as ROI,(select  sum(TotalValueOfInvestment) from Summary where InvestorId=11) as TotalValueOfInvestment from Transactions where InvestorId=11

update Investors set EmployeeId = 1 where InvestorId = 11
update Investors set EmployeeId = 1 where InvestorId = 11
update Investors set EmployeeId = 4 where InvestorId = 11
update Investors set EmployeeId = 4 where InvestorId = 11

select * from Roles
select * from Investors

select Investors.InvestorId,FName,MName,LName,Email,MobileNo,Pan,AadharNo,
                                PlanPurchasedDate,PlanExpirydate,Investors.RecordCreatedDate from Investors where Investors.Email='avip@gmail.com'
                                --join City on Investors.CityId=city.CityId
                                --join state on City.StateId=State.StateId 
                                --join Country on State.CountryId=Country.CountryId where Investors.Email='avip@gmail.com'

update Investors set AltrnateMobileNo = 346738642386, Age = 22, CityId =1, SubscriptionPlanId = 1 where Investors.Email='avip@gmail.com'
update Investors set CityId =2, SubscriptionPlanId = 2 where InvestorId=12
update Investors set CityId =2, SubscriptionPlanId = 2 where InvestorId=13
update Investors set CityId =2, SubscriptionPlanId = 2 where InvestorId=14

select * from Stocks
select * from Credentials
update Credentials set Password='seed' where CredentialId=11;

select Transactions.NameOfInstrument,Transactions.SchemeCode,Transactions.Action,Transactions.Units,Transactions.UnitValue,(Units*UnitValue) as TotalValue,Transactions.ProfitLoss,Transactions.ROI,sector.SectorName,AssetProductCategory.CategoryName,Products.ProductName,Assets.AssetName
                                from Transactions join Instruments on Transactions.InstrumentId = Instruments.InstrumentId
                                join Stocks on Instruments.MasterTypeId=Stocks.StockId
                                join sector on Stocks.SectorId=sector.SectorId
                                join AssetProductCategory on Instruments.AssetProductCategoryId = AssetProductCategory.AssetProductCategoryId
                                join Products on AssetProductCategory.ProductId=Products.ProductId
                                join Assets on Products.AssetId=Assets.AssetId
                                where Transactions.InvestorId = 11 and Instruments.MasterType='Stocks' and Action='buy'

exec sp_UpdateInvestor @Fname = 'Avip', @Mname ='', @Lname ='Kumar', @Email ='avip@gmail.com', @MobileNo =1234367, @AltrnateMobileNo =13214233, @Age =23,@PAN ='JLPK22112', @Gender ='Male',@DOB ='1998-05-09', @MaritalStatus ='Unmarried', @AddressLine1 ='ert xyz', @AddressLine2 ='fwer', @PinCode =422001, @AadharNo ='ASD3423200923', @CityName ='Pune', @Id=11