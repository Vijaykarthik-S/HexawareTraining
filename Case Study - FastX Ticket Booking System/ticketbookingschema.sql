-- Create Users table
create table Users (
    UserId int identity(1,1) primary key,
    UserName varchar(50),
    UserPhone varchar(15),
    UserGender varchar(10),
    UserEmail varchar(40)
);

-- Create Admin table
create table Admin (
    AdminId int identity(1,1) primary key,
    AdminName varchar(50),
    AdminEmail varchar(40),
    AdminPhone varchar(15)
);

-- Create Buses table
create table Buses (
    BusId int identity(1,1) primary key,
    BusName varchar(50),
    BusSource varchar(50),
    BusDestination varchar(50),
    BusTiming datetime,
    SeatsAvailable int
);

-- Create BusRoute table
create table BusRoute (
    RouteId int identity(1,1) primary key,
    BusId int foreign key references Buses(BusId),
    RouteSource varchar(50),
    RouteDestination varchar(50),
    RouteDistance float -- Distance in kilometers or miles
);

-- Create BusBooking table
create table BusBooking (
    BookingId int identity(1,1) primary key,
    BookingDescription varchar(100),
    BusID int foreign key references Buses(BusId),
    UserId int foreign key references Users(UserId)
);

-- Create BusOperator table
create table BusOperator (
    OperatorId int identity(1,1) primary key,
    OperatorName varchar(50),
    OperatorPhone varchar(15),
    OperatorGender varchar(10),
    BusID int foreign key references Buses(BusId)
);
