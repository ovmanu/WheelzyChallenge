USE WheelzyDb


--GET ONE CAR AND ITS QUOTE
DECLARE @carId INT = 1

SELECT TOP 1
    c.Id AS CarId,
    c.Year AS Year,
    c.Brand AS Brand,
    c.Model AS Model,
    c.SubModel AS SubModel,
    c.ZipCode AS ZipCode,
    b.Name AS BuyerName,
    bzq.Amount AS Quote,
    s.Name AS CurrentStatus,
    csh.StatusDate AS StatusDate
FROM Cars c
INNER JOIN CarQuotes cq ON c.Id = cq.CarId
INNER JOIN BuyerZipQuotes bzq ON cq.BuyerZipQuoteId = bzq.Id
INNER JOIN Buyers b ON bzq.BuyerId = b.Id
INNER JOIN CarStatusHistories csh ON c.Id = csh.CarId
INNER JOIN Statuses s ON csh.StatusId = s.Id
WHERE c.Id = @carId
  AND cq.IsCurrent = 1
  AND csh.IsCurrent = 1;


  
--GET ALL CARS WITH CURRENT QUOTE
SELECT
    c.Id AS CarId,
    c.Year AS Year,
    c.Brand AS Brand,
    c.Model AS Model,
    c.SubModel AS SubModel,
    c.ZipCode AS ZipCode,
    b.Name AS BuyerName,
    bzq.Amount AS Quote,
    s.Name AS CurrentStatus,
    csh.StatusDate AS StatusDate
FROM Cars c
INNER JOIN CarQuotes cq ON c.Id = cq.CarId
INNER JOIN BuyerZipQuotes bzq ON cq.BuyerZipQuoteId = bzq.Id
INNER JOIN Buyers b ON bzq.BuyerId = b.Id
INNER JOIN CarStatusHistories csh ON c.Id = csh.CarId
INNER JOIN Statuses s ON csh.StatusId = s.Id
WHERE cq.IsCurrent = 1
AND csh.IsCurrent = 1;









