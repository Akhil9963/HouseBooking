/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Paymentid]
      ,[Bookingid]
      ,[Amount]
      ,[Date]
      ,[Details]
  FROM [HouseBooking].[dbo].[Payment]