/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Custmid]
      ,[Firstname]
      ,[Lastname]
      ,[Mobile]
      ,[Email]
      ,[Address]
  FROM [HouseBooking].[dbo].[CustEnquiry]