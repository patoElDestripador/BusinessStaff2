DROP TABLE Employees;

--- CREATE TABLES ---
CREATE TABLE Employees (
  Id INT  AUTO_INCREMENT PRIMARY KEY,
  FirstName VARCHAR(45) NOT NULL,
  LastName VARCHAR(45) NOT NULL,
  Address VARCHAR(60) UNIQUE NOT NULL,
  Document VARCHAR(60) UNIQUE NOT NULL,
  Phone VARCHAR(60) NOT NULL,
  Status ENUM("Active", "Disable", "License"),
  Position VARCHAR(60) 
)

CREATE TABLE Users (
  Id INT  AUTO_INCREMENT PRIMARY KEY,
  IdEmployee INT NOT NULL,  
  Password VARCHAR(100) NOT NULL,
  UserName VARCHAR(100) NOT NULL,
  Status ENUM("Active", "Disable", "License"),
  Rol ENUM("Admin", "Employee")
)

CREATE TABLE CheckInCheckOut (
  Id INT  AUTO_INCREMENT PRIMARY KEY,
  Iduser INT NOT NULL,  
  EntryHour DATETIME NOT NULL,
  DespartureHour DATETIME NOT NULL,
)

--- M  ---