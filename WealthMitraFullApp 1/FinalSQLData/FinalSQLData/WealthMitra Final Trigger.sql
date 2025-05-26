
CREATE trigger [dbo].[Insert_On_Transactions]
on [dbo].[Transactions]

after Insert
as
declare @InvestorId int;
declare @InstrumentId int;
declare @NameOfInstrument varchar(100) ;
declare @SchemeCode varchar(100) ;
declare @Action varchar(100);
declare @Units int;
declare @UnitValue float;
declare @ActionDate datetime;
declare @IsActive Bit ;


select @InvestorId=InvestorId,@InstrumentId=InstrumentId,@NameOfInstrument=NameOfInstrument,@SchemeCode=SchemeCode,
@Action = Action,@Units=Units,@UnitValue=UnitValue,@ActionDate=ActionDate,@IsActive=IsActive  from Transactions;

if (@Action='buy')
begin

insert into TransactionBuy(InvestorId,InstrumentId,NameOfInstrument,SchemeCode,Action,Units,UnitValue,ActionDate,IsActive,RecordCreatedDate)   values
(@InvestorId,@InstrumentId,@NameOfInstrument,@SchemeCode,@Action,@Units,@UnitValue,@ActionDate,@IsActive,GetDate());

end
if (@Action='sell')
begin
exec sp_ROIProfitLossCalculation @SchemeCode=@SchemeCode,@InvestorId=@InvestorId

end
exec AverageValue @NameOfInstruments=@NameOfInstrument,@SchemeCode=@SchemeCode,@InvestorId=@InvestorId
GO

ALTER TABLE [dbo].[Transactions] ENABLE TRIGGER [Insert_On_Transactions]
GO

------------------------------------------------------------------
------------------------------------------------------------------

create trigger [dbo].[Insert_into_Stocks_to_Instrument]
on [dbo].[Stocks]
after insert

as
declare  @SchemeCode varchar(100);
declare @StockID int;
declare @AssetProductCatagoryID int;
select @SchemeCode=SchemeCode,@StockID=StockID,@AssetProductCatagoryID=AssetProductCategoryId from Stocks;
insert into Instruments(SchemeCode,MasterType,MasterTypeId,AssetProductCategoryId)values(@SchemeCode,'Stocks',@StockID,@AssetProductCatagoryID);

GO

ALTER TABLE [dbo].[Stocks] ENABLE TRIGGER [Insert_into_Stocks_to_Instrument]
GO

-------------------------------------------------------------------------------
-------------------------------------------------------------------------------

create trigger [dbo].[Insert_into_MutualFunds_to_Instrument]
on [dbo].[MutualFunds]
after insert

as
declare  @SchemeCode varchar(100);
declare @MutualFundId int;
declare @AssetProductCatagoryID int;
select @SchemeCode=SchemeCode,@MutualFundId=MutualFundId,@AssetProductCatagoryID=AssetProductCategoryId from MutualFunds;
insert into Instruments(SchemeCode,MasterType,MasterTypeId,AssetProductCategoryId)values(@SchemeCode,'MutualFunds',@MutualFundId,@AssetProductCatagoryID);

GO

ALTER TABLE [dbo].[MutualFunds] ENABLE TRIGGER [Insert_into_MutualFunds_to_Instrument]
GO




