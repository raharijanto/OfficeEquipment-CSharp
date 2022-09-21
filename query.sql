CREATE DATABASE OFFICEEQUIPMENT;

CREATE TABLE INVENTORY(
	InventId int NOT NULL,			-- Primary Key
	InventName varchar(50) NOT NULL
);

CREATE TABLE USERS(
	UserId int NOT NULL,			-- Primary Key
	UserName varchar(50) NOT NULL,
	RefUser int NOT NULL			-- Foreign Key
);

CREATE TABLE PLACEMENT(
	PlaceId int NOT NULL,			-- Primary Key
	PlaceName varchar(50) NOT NULL,
	RefPlace int NOT NULL			-- Foreign Key
);

CREATE TABLE QUANTITY(
	ItemUsed int NOT NULL,
	RefNumber int NOT NULL			-- Foreign Key
);

-- Primary Key Alter
ALTER TABLE INVENTORY
ADD CONSTRAINT PK_InventId PRIMARY KEY (InventId);

ALTER TABLE PLACEMENT
ADD CONSTRAINT PK_PlaceId PRIMARY KEY (PlaceId);

ALTER TABLE USERS
ADD CONSTRAINT PK_UserId PRIMARY KEY (UserId);

-- Foreign Key Alter
ALTER TABLE PLACEMENT
ADD CONSTRAINT FK_RefPlace
FOREIGN KEY (RefPlace) REFERENCES INVENTORY(InventId);

ALTER TABLE QUANTITY
ADD CONSTRAINT FK_RefNumber
FOREIGN KEY (RefNumber) REFERENCES INVENTORY(InventId);

ALTER TABLE USERS
ADD CONSTRAINT FK_RefUser
FOREIGN KEY (RefUser) REFERENCES INVENTORY(InventId);

-- Data
--- Inventory Data
INSERT INTO INVENTORY(InventId, InventName) VALUES
(1, 'Mechanic Toolsets'),
(2, 'Utensils'),
(3, 'Circuit Printers'),
(4, 'Computer'),
(5, 'Photocopy');

--- Placement Data
INSERT INTO PLACEMENT(PlaceId, PlaceName, RefPlace) VALUES
(1, 'Mechanical Engineering Workplace', 1),		-- Will be updated to (Mechanical Engineering Workspace) using SQL Connection
(2, 'Electrical Engineering Workplace', 3),
(3, 'Software Engineering Workplace', 4),
--(4, 'General Workplace', 2);		-- Will be inserted and deleted using SQL Connection

--- Quantity Data
INSERT INTO QUANTITY(ItemUsed, RefNumber) VALUES
(17, 1),
(19, 2),
(8, 3),
(25, 4);

--- Users Data
INSERT INTO USERS(UserId, UserName, RefUser) VALUES
(1, 'Mr. 0', 4),
(2, 'Mr. 1', 1),
(3, 'Mr. 2', 3),
(4, 'Mr. 3', 1),
(5, 'Mr. 4', 2),
(6, 'Mr. 5', 2);