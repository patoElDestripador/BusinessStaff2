-- Active: 1713250790058@@bhrc6pnxeuglc3rpqrod-mysql.services.clever-cloud.com@3306@bhrc6pnxeuglc3rpqrod

CREATE TABLE Employees (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(45) NOT NULL,
    LastName VARCHAR(45) NOT NULL,
    Address VARCHAR(60) UNIQUE NOT NULL,
    Document VARCHAR(60) UNIQUE NOT NULL,
    Phone VARCHAR(60) NOT NULL,
    Status ENUM("Active", "Disable", "License"),
    Position VARCHAR(60)
);

CREATE TABLE Users (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    IdEmployee INT NOT NULL,
    Password VARCHAR(100) NOT NULL,
    UserName VARCHAR(100) NOT NULL,
    Status ENUM("Active", "Disable", "License"),
    Rol ENUM("Admin", "Employee"),
    FOREIGN KEY (IdEmployee) REFERENCES Employees(Id)
);

CREATE TABLE CheckInCheckOuts (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    IdUser INT NOT NULL,
    EntryHour DATETIME,
    DespartureHour DATETIME,
    FOREIGN KEY (IdUser) REFERENCES Users(Id)
);

SELECT * FROM CheckInCheckOuts;
DROP TABLE CheckInCheckOuts;
--- M  ---

EXPLAIN SELECT u.id, e.FirstName, c.EntryHour, c.DepartureHour 
FROM `Employees` e 
RIGHT JOIN `Users` u ON e.Id = u.IdEmployee 
RIGHT JOIN `CheckInCheckOuts` c ON c.IdUser = u.Id;

EXPLAIN SELECT e.FirstName, c.EntryHour, c.DepartureHour 
FROM `CheckInCheckOuts` c 
LEFT JOIN `Users` u ON c.IdUser = u.id
LEFT JOIN `Employees` e ON u.IdEmployee = e.Id;

CREATE VIEW TheViewSita AS SELECT u.Id, e.FirstName, c.EntryHour, c.DepartureHour 
FROM `CheckInCheckOuts` c 
LEFT JOIN `Users` u ON c.IdUser = u.Id
LEFT JOIN `Employees` e ON u.IdEmployee = e.Id;

SELECT * FROM Users;


