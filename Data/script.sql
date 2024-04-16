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
    EntryHour DATETIME NOT NULL,
    DespartureHour DATETIME NOT NULL,
    FOREIGN KEY (IdUser) REFERENCES Users(Id)
);

--- M  ---

INSERT INTO Employees (FirstName, LastName, Address, Document, Phone, Status, Position) 
VALUES 
('John', 'Doe', '123 Main St', '123456789', '555-1234', 'Active', 'Manager'),
('Jane', 'Smith', '456 Oak St', '987654321', '555-5678', 'Active', 'Assistant'),
('Michael', 'Johnson', '789 Elm St', '456123789', '555-9012', 'Disable', 'Clerk'),
('Emily', 'Brown', '101 Pine St', '654987321', '555-3456', 'Active', 'Supervisor'),
('David', 'Lee', '234 Cedar St', '321789654', '555-7890', 'License', 'Coordinator');

INSERT INTO Users (IdEmployee, Password, UserName, Status, Rol) 
VALUES 
(1, 'password1', 'john_doe', 'Active', 'Admin'),
(2, 'password2', 'jane_smith', 'Active', 'Employee'),
(3, 'password3', 'michael_johnson', 'Disable', 'Employee'),
(4, 'password4', 'emily_brown', 'Active', 'Employee'),
(5, 'password5', 'david_lee', 'License', 'Employee');

INSERT INTO CheckInCheckOuts (IdUser, EntryHour, DespartureHour) 
VALUES 
(1, '2024-04-16 08:00:00', '2024-04-16 17:00:00'),
(2, '2024-04-16 09:00:00', '2024-04-16 18:00:00'),
(3, '2024-04-16 10:00:00', '2024-04-16 19:00:00'),
(4, '2024-04-16 11:00:00', '2024-04-16 20:00:00'),
(5, '2024-04-16 12:00:00', '2024-04-16 21:00:00');

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

SELECT * FROM TheViewSita;


