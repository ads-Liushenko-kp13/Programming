Select Lot.Name,Lot.Description,Lot.StartPrice,AuctionHistory.SalesPrice,AuctionHistory.SalesPrice-Lot.StartPrice AS 'DeltaPrice',
Buyer.LastName AS 'Buyer Name',SalesMan.LastName AS 'SalesMan Name' 
FROM Lot Join AuctionHistory ON Lot.ID = AuctionHistory.LotID
Left Join Participant AS SalesMan ON Lot.SalesmanID = SalesMan.ID
Left Join Participant AS Buyer ON AuctionHistory.BuyerID = Buyer.ID
Where AuctionHistory.AuctionId = 7
