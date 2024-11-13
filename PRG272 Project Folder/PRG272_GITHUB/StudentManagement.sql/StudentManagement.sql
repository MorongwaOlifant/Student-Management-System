-- 1. Create the StudentManagement Database
CREATE DATABASE StudentManagement;
GO

-- 2. Switch to the StudentManagement Database
USE StudentManagement;
GO

-- 3. Create the Students Table
CREATE TABLE Students (
    StudentID NVARCHAR(50) PRIMARY KEY,  -- Custom StudentID as primary key
    Name NVARCHAR(100) NOT NULL,         -- Student name
    Age INT CHECK (Age >= 0),            -- Age with a constraint to prevent negative values
    Course NVARCHAR(100) NOT NULL        -- Course name
);

-- 4. Create the ReportSummary Table
CREATE TABLE ReportSummary (
    ID INT PRIMARY KEY IDENTITY(1,1),    -- Auto-incrementing primary key
    TotalStudents INT,                   -- Total number of students
    AverageAge FLOAT,                    -- Average age of students
    ReportDate DATETIME DEFAULT GETDATE() -- Date of report generation
);