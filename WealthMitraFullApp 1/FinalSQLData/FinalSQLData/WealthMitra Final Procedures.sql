----------------------------------------------------------------------------

CREATE procedure [dbo].[AverageValue](@NameOfInstruments varchar(100),@SchemeCode varchar(100),@InvestorId int)
as
begin

	declare @test int;
	declare @temp int;
	declare @TransactionIdscope int;
	declare @BuyUnitValue float;
	declare @BuyunitsTotalValue float;
	declare @averageValue float;
	declare @IsActive Bit;
	declare @IsActiveValue Bit;
	declare @UnitsTotal int;
	declare @summarySchemecode varchar(100);
	declare @SummaryId int;
	declare @test2 int;
	declare @Is bit;
	set @summarySchemecode=null;
	set @BuyunitsTotalValue=0;
	set @UnitsTotal=0;
	set @averageValue=0;
	set	@test=(select Count( Units) from TransactionBuy  where TransactionBuy.SchemeCode=@SchemeCode and TransactionBuy.InvestorId=@InvestorId   ) ;
	select Top 1 @IsActiveValue=IsActive from TransactionBuy  where TransactionBuy.SchemeCode=@SchemeCode and TransactionBuy.InvestorId=@InvestorId  order by RecordCreatedDate;
	while(@test>0)---15|10
		begin
			select Top 1 @temp=Units,@TransactionIdscope=TransactionBuy.TransactionId ,@BuyUnitValue=TransactionBuy.UnitValue ,@IsActive=IsActive from TransactionBuy  where TransactionBuy.SchemeCode=@SchemeCode and IsActive=@IsActiveValue and TransactionBuy.InvestorId=@InvestorId order by RecordCreatedDate;
			set @BuyunitsTotalValue=@BuyunitsTotalValue+@temp*@BuyUnitValue;
			set @UnitsTotal=@UnitsTotal+@temp
			if(@IsActive=0)
			begin
				set	@Is=1;
				update TransactionBuy set IsActive=@Is where TransactionId=@TransactionIdscope
			end
			else if (@IsActive=1)
			begin
				set	@Is=0;
				update TransactionBuy set IsActive=@Is where TransactionId=@TransactionIdscope
			end
			set @test=@test-1;
			end
			set @averageValue=(@BuyunitsTotalValue/@UnitsTotal);
			insert into Summary(NameOfInstruments,SchemeCode,Units,AverageValue,TotalValueOfInvestment,RecordCreatedDate,InvestorId) values(@NameOfInstruments,@SchemeCode,@UnitsTotal,@averageValue,@BuyunitsTotalValue,GetDate(),@InvestorId);
			set	@test2=(select Count( SummaryId) from Summary  where Summary.SchemeCode=@SchemeCode and Summary.InvestorId=@InvestorId) ;
			select Top 1 @SchemeCode=SchemeCode,@SummaryId=SummaryId from Summary where SchemeCode=@SchemeCode and Summary.InvestorId=@InvestorId order by RecordCreatedDate
			if @test2!=1
			begin
				delete from Summary Where SummaryId=@SummaryId and Summary.InvestorId=@InvestorId
			end
			update TransactionBuy set IsActive=1;
end

---------------------------------------------------------------------------------
----------------------------------------------------------------------------------
--create procedure sp_AddInvestor(
--	 @Fname varchar(100),
--	 @Mname varchar(100),
--	 @Lname varchar(100),
--	 @Email varchar(100),    
--	 @MobileNo bigint, 
--	 @PAN varchar(100),
--	 @AadharNo varchar(100),
--	 @Password varchar(100),
--	 @CityName varchar(100)
--) 
--as 
--begin

--	declare @RoleId int;
--	declare @CredentialId int;
--	declare @scope int
--	declare @Email2 varchar;
--	declare @CityId int;
--	declare @Email varchar(100);
--	set @CredentialId=null;
--	set @CityId=(select CityId from City Where CityName=@CityName)
--	set @RoleId =(select RoleId from Roles where RoleName='Investor') ;
--	set @CredentialId=(select CredentialId from Credentials where UserName=@Email);
--	if(@CredentialId=null)
--	begin
--		insert into Credentials(UserName,Password,RoleId,RecordCreatedDate) values(@Email,@Password,@RoleId,getDate());
--		set @scope = SCOPE_IDENTITY();
--	end
--	set @CredentialId=(select CredentialId from Credentials where UserName=@Email);
--	insert into Investors(FName,MName,LName,Email,CityId,MobileNo,CredentialId,Pan,AadharNo,RecordCreatedDate)
--		values(@Fname,@Mname,@Lname,@Email,@CityId,@MobileNo,@scope,@PAN,@AadharNo,GetDate());

--end
--------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------
create procedure sp_AddEmployee(
	 @Fname varchar(100),
	 @Mname varchar(100),
	 @Lname varchar(100),
	 @Email varchar(100),    
	 @MobileNo bigint, 
	 @PAN varchar(100),
	 @AadharNo varchar(100),
	 @RoleName varchar(100),
     @CityName varchar(100),
	 @Password varchar(100)
) 
as 
begin
	declare @RoleId int;
	declare @scope int
	set @RoleId =(select RoleId  from Roles where RoleName=@RoleName) ;
	insert into Credentials(UserName,Password,RoleId,RecordCreatedDate) values(@Email,@Password,@RoleId,getDate());
	set @scope = SCOPE_IDENTITY();
	insert into Employees(FName,MName,LName,Email,MobileNo,RoleId,CredentialId,Pan,AadharNo,RecordCreatedDate,RecordCreatedBy)
		values(@Fname,@Mname,@Lname,@Email,@MobileNo,@RoleId,@scope,@PAN,@AadharNo, GetDate(),@Email);
	insert into Investors(FName,MName,LName,Email,MobileNo,CredentialId,Pan,AadharNo,RecordCreatedDate)
		values(@Fname,@Mname,@Lname,@Email,@MobileNo,@scope,@PAN,@AadharNo,GetDate());

end

--------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------
create procedure sp_UpdateInvestor(
	 @Fname varchar(100),
	 @Mname varchar(100),
	 @Lname varchar(100),   
	 @Email varchar(100),
	 @MobileNo bigint,
	 @AltrnateMobileNo bigint,
	 @Age int,
	 @PAN varchar(100),
	 @Gender varchar(100),
	 @DOB datetime ,
	 @MaritalStatus varchar(100),
	 @AddressLine1 varchar(100),
	 @AddressLine2 varchar(100),
	 @PinCode int,
	 @AadharNo varchar(100),
	 @CityName varchar(100),
	 @id int
)
as 
begin

	declare @CityId int;
	set @CityId=(select CityId from City where CityName=@CityName);
	update Investors set FName = @Fname, MName = @Mname, LName = @Lname, 
	MobileNo = @MobileNo, AltrnateMobileNo = @AltrnateMobileNo,
	Age = @Age, Pan = @PAN, Gender = @Gender, DOB = @DOB, MaritalStatus = @MaritalStatus,
	AddressLine1 = @AddressLine1, AddressLine2 = @AddressLine2,
	Pincode = @PinCode, AadharNo = @AadharNo, CityId = @CityId, RecordModifiedBy =@Email, RecordModifiedDate = GETDATE()
	where InvestorId = @id;

end

--exec sp_UpdateInvestor @Fname = 'Avip', @Mname ='', @Lname ='Kumar', @Email ='avip@gmail.com', @MobileNo =1234367, @AltrnateMobileNo =13214233, @Age =23,@PAN ='JLPK22112', @Gender ='Male',@DOB ='1998-05-09', @MaritalStatus ='Unmarried', @AddressLine1 ='ert xyz', @AddressLine2 ='fwer', @PinCode =422001, @AadharNo ='ASD3423200923', @CityName ='Pune', @Id=1
----------------------------------------------------------------------------------
----------------------------------------------------------------------------------
create procedure sp_UpdateEmployee(
	 @Fname varchar(100),
	 @Mname varchar(100),
	 @Lname varchar(100),
	 @Email varchar(100) ,    
	 @MobileNo bigint,
	 @AltrnateMobileNo bigint,
	 @Age int,
	 @PAN varchar(100),
	 @Gender varchar(100),
	 @DOB datetime ,
	 @MaritalStatus varchar(100),
	 @AddressLine1 varchar(100),
	 @AddressLine2 varchar(100),
	 @PinCode int,
	 @AadharNo varchar(100),
	 @CityName varchar(100),
	 @Experience varchar(100),
	 @JoiningDate datetime,
	 @RoleName varchar(100),
	 @id int
)
as 
begin

	declare @CityId int;
	declare @RoleId int;
	set @CityId=(select CityId from City where CityName=@CityName);
	set @RoleId = (select RoleId from Roles where RoleName = @RoleName);
	update Employees set FName = @Fname, MName = @Mname, LName = @Lname, 
	Email = @Email, MobileNo = @MobileNo, AltrnateMobileNo = @AltrnateMobileNo,
	Age = @Age, Pan = @PAN, Gender = @Gender, DOB = @DOB, MaritalStatus = @MaritalStatus,
	AddressLine1 = @AddressLine1, AddressLine2 = @AddressLine2,
	Pincode = @PinCode, AadharNo = @AadharNo, CityId = @CityId, RecordModifiedBy =@Email, RecordModifiedDate = GETDATE()
	where EmployeeId = @id;

end

--exec sp_UpdateInvestor @Fname = 'Avip', @Mname ='', @Lname ='Kumar', @Email ='avip@gmail.com', @MobileNo =1234367, @AltrnateMobileNo =13214233, @Age =23,@PAN ='JLPK22112', @Gender ='Male',@DOB ='1998-05-09', @MaritalStatus ='Unmarried', @AddressLine1 ='ert xyz', @AddressLine2 ='fwer', @PinCode =422001, @AadharNo ='ASD3423200923', @CityName ='Pune', @Id=1


----------------------------------------------------------------------------------
----------------------------------------------------------------------------------

CREATE procedure [dbo].[sp_ROIProfitLossCalculation](@SchemeCode varchar(100),@InvestorId int)
as
begin
	declare @sellUnits int;
	declare @temp int;
	declare @temp2 int;
	declare @TransactionIdscope int;
	declare @SellUnitsValue float;
	declare @sellUnitsTotalvalue float;
	declare @BuyUnitValue float;
	declare @BuyunitsTotalValue float;
	declare @TransactionIdProfitLoss int;
	declare @ROI float;
	set @BuyunitsTotalValue=0;
			select Top 1 @sellUnits=Units,@SellUnitsValue=UnitValue,@TransactionIdProfitLoss=TransactionId from Transactions where Transactions.SchemeCode=@SchemeCode and Transactions.Action='sell' and Transactions.InvestorId = @InvestorId order by  TransactionId desc;
			set @sellUnitsTotalvalue=@sellUnits * @SellUnitsValue;
			while(@sellUnits>0)---15|10
			begin
			select Top 1 @temp=Units,@TransactionIdscope=TransactionBuy.TransactionId ,@BuyUnitValue=TransactionBuy.UnitValue from TransactionBuy  where TransactionBuy.SchemeCode=@SchemeCode and TransactionBuy.InvestorId=@InvestorId order by RecordCreatedDate;
			if(@sellUnits>=@temp)--15   15>=5  true|10>=15---false so else
				begin
				set @temp2=@temp-@sellUnits---5-15=-10
				if(@temp2<=0)-- -10<=0  true
					begin
					set @BuyunitsTotalValue=@BuyunitsTotalValue+@temp*@BuyUnitValue;
					delete from TransactionBuy where TransactionBuy.TransactionId=@TransactionIdscope
					end
				end
			else
				begin
				 set @temp2=@temp-@sellUnits--15-10=5
				 set @BuyunitsTotalValue=@BuyunitsTotalValue+@sellUnits*@BuyUnitValue;
				 Update TransactionBuy set Units=@temp2 where TransactionBuy.TransactionId=@TransactionIdscope;
				end
			set @sellUnits=@sellUnits-@temp;--15-5=10|10-15=-5
			end
			set @ROI = ((@sellUnitsTotalvalue-@BuyunitsTotalValue)*100)/@BuyunitsTotalValue;
			update Transactions set ProfitLoss=@sellUnitsTotalvalue-@BuyunitsTotalValue, ROI=@ROI where TransactionId=@TransactionIdProfitLoss;
end
---------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------

create Procedure sp_AddState(
	@StateName varchar(100),
    @CountryName varchar(100)
)
as
begin
	declare @CountryId int;
	select @CountryId=CountryId from Country where CountryName=@CountryName
	insert into State(StateName,CountryId,RecordCreatedDate) values(@StateName,@CountryId,GETDATE()) 
end
--------------------------------------------------------------
--------------------------------------------------------------
create procedure sp_AddCity(
	@CityName varchar(100),
	@StateName varchar(100)
)
as
begin
	declare @StateId int;
	select @StateId=StateId from State where StateName=@StateName
	insert into City(CityName,StateId,RecordCreatedDate) values(@CityName,@StateId,GETDATE()) 
end

-----------------------------------------------------------------
-----------------------------------------------------------------

create procedure sp_InsertTransactions(
	@NameOfInstrument varchar(100),
	@SchemeCode varchar(100),
	@Action varchar(100),
	@Units int,
	@UnitValue float,
	@InvestorId int
)
as 
begin
	declare @InstrumentId int;
	declare @InsSchemeCode varchar(100);
	set @InsSchemeCode = (select SchemeCode from Instruments where SchemeCode = @SchemeCode);
	if(@InsSchemeCode = @SchemeCode)
	begin
		set @InstrumentId = (select InstrumentId from Instruments where SchemeCode = @SchemeCode )
		insert into Transactions(InvestorId, InstrumentId, NameOfInstrument, SchemeCode,Action,Units,UnitValue,ActionDate)
		values(@InvestorId, @InstrumentId, @NameOfInstrument,@SchemeCode,@Action,@Units,@UnitValue,GETDATE())
	end
end

--exec sp_InsertTransactions @NameOfInstrument='TCS',@SchemeCode='12345',@Action='buy',@Units=10,@UnitValue=200,@ActionDate='2021-11-11',@InvestorId=1

------------------------------------------------------------------------
------------------------------------------------------------------------

create procedure sp_AddCategory(
	@CategoryName varchar(100),
	@ProductName varchar(100)
)
as
begin

	declare @ProductId int;
	set @ProductId=(select ProductId from Products where ProductName=@ProductName)
	insert into AssetProductCategory(ProductId,CategoryName, RecordCreatedDate) values (@ProductId,@CategoryName,GETDATE());
end


-------------------------------------------------------------------------------------------------------

create procedure [dbo].[sp_AddMutualFundsAndInstruments]
(
	@SchemeCode varchar(100),
	@MutualFundName varchar(100),
	@CategoryName varchar(100),
	@ProductName varchar(100),
	@SectorName varchar(100)
)
as 
begin 
	
    declare @CategoryId int;
	declare @SectorId int;
	declare @ProductId int;
	set @ProductId=(select ProductId from Products where ProductName = @ProductName);
	set @CategoryId = (select AssetProductCategoryId from AssetProductCategory where CategoryName = @CategoryName and ProductId = @ProductId);
	set @SectorId = (select SectorId from sector where SectorName = @SectorName); 
	insert into MutualFunds(SchemeCode,MutualFundName,AssetProductCategoryId,SectorId,RecordCreatedDate) values(@SchemeCode,@MutualFundName,@CategoryId,@SectorId,GETDATE())

end

----------------------------------------------------------------------------------
----------------------------------------------------------------------------------

create procedure [dbo].[sp_AddStocksAndInstruments]
(
	@SchemeCode varchar(100),
	@StockName varchar(100),
	@CategoryName varchar(100),
	@ProductName varchar(100),
	@SectorName varchar(100)
)
as 
begin 
	declare @CategoryId int;
	declare @SectorId int;
	declare @ProductId int;
	set @ProductId=(select ProductId from Products where ProductName = @ProductName);
	set @CategoryId = (select AssetProductCategoryId from AssetProductCategory where CategoryName = @CategoryName and ProductId = @ProductId);
	set @SectorId = (select SectorId from sector where SectorName = @SectorName); 
	insert into Stocks(SchemeCode,StockName,AssetProductCategoryId,SectorId,RecordCreatedDate) values(@SchemeCode,@StockName,@CategoryId,@SectorId,GETDATE())

end 

create procedure sp_AddProduct(
	@AssetName varchar(100),
	@ProductName varchar(100)
)
as
begin

	declare @AssetId int;
	set @AssetId=(select AssetId from Assets where AssetName=@AssetName)
	insert into Products(ProductName,AssetId, RecordCreatedDate) values (@ProductName,@AssetId,GETDATE());
end

--exec sp_AddProduct @AssetName='Equity',@ProductName='Cash2'
--------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------
create Procedure sp_UpadteState(@StateName varchar(100),@CountryName varchar(100),@StateId int)
as
begin
	declare @CountryId int;
	select @CountryId=CountryId from Country where CountryName=@CountryName
	update State set StateName=@StateName,CountryId=@CountryId,RecordModifiedBy='Admin',RecordModifiedDate=GETDATE() where StateId=@StateId
end

--exec sp_UpadteState @StateName='Hariyanaaa',@CountryName='India', @StateId=4
--------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------
create procedure sp_UpdateCity(@CityName varchar(100),@StateName varchar(100),@CityId int)
as
begin
	declare @StateId int;
	select @StateId=StateId from State where StateName=@StateName
	update City set CityName=@CityName,StateId=@StateId,RecordModifiedBy='Admin',RecordModifiedDate=GETDATE() where CityId=@CityId
end
--exec sp_UpdateCity @CityName='Aajmer',@StateName='Rajasthan',@cityId=6
------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------
create procedure sp_UpdateCategory(
	@CategoryName varchar(100),
	@ProductName varchar(100),
	@CategoryId int
)
as
begin

	declare @ProductId int;
	set @ProductId=(select ProductId from Products where ProductName=@ProductName)
	update AssetProductCategory set CategoryName=@CategoryName,ProductId=@ProductId,RecordModifiedBy='Admin',RecordModifiedDate=GETDATE()  where AssetProductCategoryId=@CategoryId
end
--exec sp_UpdateCategory @CategoryName='Small Cap',@ProductName='Stocks',@CategoryId=1
-----------------------------------------------------------------------
---------------------------------------------------------------------------
create procedure sp_UpdateProduct(
	@AssetName varchar(100),
	@ProductName varchar(100),
	@ProductId int
)
as
begin

	declare @AssetId int;
	set @AssetId=(select AssetId from Assets where AssetName=@AssetName)
	update Products set ProductName=@ProductName,AssetId=@AssetId,RecordModifiedBy='Admin',RecordModifiedDate=GETDATE()  where ProductId=@ProductId
end
--exec sp_UpdateProduct @AssetName='Equity',@ProductName='Cash',@ProductId=6
-----------------------------------------------------------------------
---------------------------------------------------------------------------
create procedure sp_UpdateStocksAndInstruments
(
	@SchemeCode varchar(100),
	@StockName varchar(100),
	@CategoryName varchar(100),
	@ProductName varchar(100),
	@SectorName varchar(100),
	@StockId int
)
as 
begin 
	declare @CategoryId int;
	declare @SectorId int;
	declare @ProductId int;
	set @ProductId=(select ProductId from Products where ProductName = @ProductName);
	set @CategoryId = (select AssetProductCategoryId from AssetProductCategory where CategoryName = @CategoryName and ProductId = @ProductId);
	set @SectorId = (select SectorId from sector where SectorName = @SectorName); 
	update Stocks set StockName=@StockName,SchemeCode=@SchemeCode,AssetProductCategoryId=@CategoryId,SectorId=@SectorId,RecordModifiedBy='Admin',RecordModifiedDate=GETDATE()  where StockId=@StockId 
end
--exec sp_UpdateStocksAndInstruments @SchemeCode='BajLtd',@StockName='BajajLtd',@CategoryName='LargeCap',@ProductName='Stocks',@SectorName='Finance',@StockId=6
-----------------------------------------------------------------------
---------------------------------------------------------------------------
Create procedure sp_UpdateMutualFundsAndInstruments
(
	@SchemeCode varchar(100),
	@MutualFundName varchar(100),
	@CategoryName varchar(100),
	@ProductName varchar(100),
	@SectorName varchar(100),
	@MutualFundId int
)
as 
begin 
	
    declare @CategoryId int;
	declare @SectorId int;
	declare @ProductId int;
	set @ProductId=(select ProductId from Products where ProductName = @ProductName);
	set @CategoryId = (select AssetProductCategoryId from AssetProductCategory where CategoryName = @CategoryName and ProductId = @ProductId);
	set @SectorId = (select SectorId from sector where SectorName = @SectorName); 
	update MutualFunds Set MutualFundName=@MutualFundName,SchemeCode=@SchemeCode,AssetProductCategoryId=@CategoryId,SectorId=@SectorId,RecordModifiedBy='Admin',RecordModifiedDate=GETDATE() where MutualFundId=@MutualFundId


end
--exec sp_UpdateMutualFundsAndInstruments @SchemeCode='12346',@MutualFundName='Accenture2 LTD',@CategoryName='LargeCap',@ProductName='Debt Mutual Funds',@SectorName='Finance',@MutualFundId=8


create procedure sp_AddInvestor(
@Fname varchar(100),
@Mname varchar(100),
@Lname varchar(100),
@Email varchar(100),
@MobileNo bigint,
@PAN varchar(100),
@AadharNo varchar(100),
@Password varchar(100),
@CityName varchar(100)
)
as
begin





declare @RoleId int;
declare @CredentialId int;
declare @scope int
declare @CityId int;
set @CityId=(select CityId from City Where CityName=@CityName)
set @RoleId =(select RoleId from Roles where RoleName='Investor') ;
set @CredentialId=(select CredentialId from Credentials where UserName=@Email);



insert into Credentials(UserName,Password,RoleId,RecordCreatedDate) values(@Email,@Password,@RoleId,getDate());
set @scope = SCOPE_IDENTITY();



set @CredentialId=(select CredentialId from Credentials where UserName=@Email);
insert into Investors(FName,MName,LName,Email,CityId,MobileNo,CredentialId,Pan,AadharNo,RecordCreatedDate)
values(@Fname,@Mname,@Lname,@Email,@CityId,@MobileNo,@scope,@PAN,@AadharNo,GetDate());


end