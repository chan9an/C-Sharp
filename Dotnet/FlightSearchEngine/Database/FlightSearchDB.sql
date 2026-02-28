CREATE DATABASE FlightSearchDB;
GO

USE FlightSearchDB;
GO

CREATE TABLE Flights (
    FlightId       INT            PRIMARY KEY IDENTITY(1,1),
    FlightName     NVARCHAR(100)  NOT NULL,
    FlightType     NVARCHAR(50)   NOT NULL,
    Source         NVARCHAR(100)  NOT NULL,
    Destination    NVARCHAR(100)  NOT NULL,
    PricePerSeat   DECIMAL(18,2)  NOT NULL
);
GO

CREATE TABLE Hotels (
    HotelId      INT            PRIMARY KEY IDENTITY(1,1),
    HotelName    NVARCHAR(100)  NOT NULL,
    HotelType    NVARCHAR(50)   NOT NULL,
    Location     NVARCHAR(100)  NOT NULL,
    PricePerDay  DECIMAL(18,2)  NOT NULL
);
GO

INSERT INTO Flights (FlightName, FlightType, Source, Destination, PricePerSeat) VALUES
('IndiGo 6E-101',    'Domestic', 'Mumbai',    'Delhi',     3500.00),
('Air India AI-202', 'Domestic', 'Mumbai',    'Delhi',     4200.00),
('SpiceJet SG-303',  'Domestic', 'Mumbai',    'Bangalore', 2800.00),
('IndiGo 6E-404',    'Domestic', 'Delhi',     'Mumbai',    3600.00),
('Vistara UK-505',   'Domestic', 'Delhi',     'Bangalore', 3900.00),
('Air India AI-606', 'Domestic', 'Delhi',     'Chennai',   4500.00),
('SpiceJet SG-707',  'Domestic', 'Bangalore', 'Mumbai',    2900.00),
('IndiGo 6E-808',    'Domestic', 'Bangalore', 'Delhi',     4000.00),
('Air India AI-909', 'Domestic', 'Chennai',   'Delhi',     5000.00),
('Vistara UK-100',   'Domestic', 'Chennai',   'Mumbai',    4100.00);
GO

INSERT INTO Hotels (HotelName, HotelType, Location, PricePerDay) VALUES
('The Grand Delhi',      'Luxury',   'Delhi',     8000.00),
('Mumbai Sea View',      'Luxury',   'Mumbai',    9000.00),
('Bangalore Tech Hotel', 'Standard', 'Bangalore', 5000.00),
('Chennai Palace',       'Standard', 'Chennai',   4500.00),
('Kolkata Heritage Inn', 'Budget',   'Kolkata',   3000.00);
GO

CREATE PROCEDURE sp_GetSources
AS
BEGIN
    SELECT DISTINCT Source FROM Flights ORDER BY Source;
END
GO

CREATE PROCEDURE sp_GetDestinations
AS
BEGIN
    SELECT DISTINCT Destination FROM Flights ORDER BY Destination;
END
GO

CREATE PROCEDURE sp_SearchFlights
    @Source      NVARCHAR(100),
    @Destination NVARCHAR(100),
    @Persons     INT
AS
BEGIN
    SELECT
        FlightId,
        FlightName,
        FlightType,
        Source,
        Destination,
        (PricePerSeat * @Persons) AS TotalCost
    FROM Flights
    WHERE Source = @Source
      AND Destination = @Destination;
END
GO

CREATE PROCEDURE sp_SearchFlightsWithHotels
    @Source      NVARCHAR(100),
    @Destination NVARCHAR(100),
    @Persons     INT
AS
BEGIN
    SELECT
        f.FlightId,
        f.FlightName,
        f.Source,
        f.Destination,
        h.HotelName,
        ((f.PricePerSeat + h.PricePerDay) * @Persons) AS TotalCost
    FROM Flights f
    INNER JOIN Hotels h ON f.Destination = h.Location
    WHERE f.Source = @Source
      AND f.Destination = @Destination;
END
GO
