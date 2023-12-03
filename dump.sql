CREATE DATABASE trip_planner;

CREATE TABLE Accommodations (
    AccommodationID INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Location VARCHAR(255) NOT NULL,
    Type VARCHAR(50) NOT NULL,
    PricePerNight FLOAT NOT NULL,
    Description TEXT
);

CREATE TABLE Activities (
    ActivityID INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Type VARCHAR(50) NOT NULL,
    Location VARCHAR(255) NOT NULL,
    Price FLOAT,
    Description TEXT
);

CREATE TABLE Users (
    UserID INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL,
    Description TEXT
);