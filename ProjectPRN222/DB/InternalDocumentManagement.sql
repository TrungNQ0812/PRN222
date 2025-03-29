USE [master]
GO

IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'InternalDocumentManagement')
BEGIN
	ALTER DATABASE InternalDocumentManagement SET OFFLINE WITH ROLLBACK IMMEDIATE;
	ALTER DATABASE InternalDocumentManagement SET ONLINE;
	DROP DATABASE InternalDocumentManagement;
END

GO

CREATE DATABASE InternalDocumentManagement;
GO
USE InternalDocumentManagement;
GO

-- Bảng Account
CREATE TABLE Account (
    AccountId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(100) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Role INT NOT NULL CHECK (Role BETWEEN 1 AND 3),  -- 1: Manager, 2: Leader, 3: Staff
    PhoneNumber NVARCHAR(15),
    AccountStatus INT NOT NULL CHECK (AccountStatus IN (0,1)), -- 0: Inactive, 1: Active
    Email NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(200),
    CreateAt DATETIME DEFAULT GETDATE()
);

-- Bảng DocumentStatus
CREATE TABLE DocumentStatus (
    DocumentStatusId INT PRIMARY KEY IDENTITY(1,1),
    DocumentStatusName NVARCHAR(100) NOT NULL
);

-- Bảng Category
CREATE TABLE Category (
    CategoryId INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(100) NOT NULL
);

-- Bảng Document
CREATE TABLE Document (
    DocumentId INT PRIMARY KEY IDENTITY(1,1),
    DocumentContent NVARCHAR(MAX) NOT NULL,
    DocumentTitle NVARCHAR(255) NOT NULL,
    CreateAt DATETIME DEFAULT GETDATE(),
    UpdateAt DATETIME DEFAULT GETDATE(),
    DocumentStatusId INT NOT NULL,
    AccountId INT NOT NULL,  -- Người tạo tài liệu
    CategoryId INT NOT NULL,
    FOREIGN KEY (DocumentStatusId) REFERENCES DocumentStatus(DocumentStatusId),
    FOREIGN KEY (AccountId) REFERENCES Account(AccountId),
    FOREIGN KEY (CategoryId) REFERENCES Category(CategoryId)
);

-- Bảng PermissionType (Định nghĩa các loại quyền)
CREATE TABLE Permission (
    PermissionId INT PRIMARY KEY IDENTITY(1,1),
    PermissionName NVARCHAR(50) NOT NULL 
);

INSERT INTO Permission (PermissionName) VALUES ('Read Only');  -- 1: Chỉ xem
INSERT INTO Permission (PermissionName) VALUES ('Can Edit');   -- 2: Có thể sửa
INSERT INTO Permission (PermissionName) VALUES ('Can Delete'); -- 3: Có thể xóa

-- Bảng AccountPermission (Lưu quyền của từng tài khoản)
CREATE TABLE AccountPermission (
    AccountPermissionId INT PRIMARY KEY IDENTITY(1,1),
    AccountId INT NOT NULL,        -- Tài khoản nào
    PermissionId INT NOT NULL, -- Quyền gì

    FOREIGN KEY (AccountId) REFERENCES Account(AccountId) ON DELETE CASCADE,
    FOREIGN KEY (PermissionId) REFERENCES Permission(PermissionId) ON DELETE CASCADE
);


-- Insert giá trị hợp lệ
INSERT INTO Category (CategoryName) VALUES
('Public'),
('Internal'),
('Confidential'),
('Restricted');


-- Insert giá trị hợp lệ
INSERT INTO DocumentStatus (DocumentStatusName) VALUES
('Pending'),
('Approved'),
('Released'),
('Rejected'),
('Canceled');


-- Insert trực tiếp vào Account (1: Manager, 2: Leader, 3: Staff; 0: Inactive, 1: Active)
INSERT INTO Account (Username, Password, Role, PhoneNumber, AccountStatus, Email, FullName) VALUES
('admin01', 'hashedpassword1', 1, '0123456789', 1, 'admin01@example.com', 'Admin User'),
('manager01', 'hashedpassword2', 2, '0987654321', 1, 'manager01@example.com', 'Manager User'),
('leader01', 'hashedpassword3', 3, '0909090909', 1, 'leader01@example.com', 'Leader User'),
('staff01', 'hashedpassword4', 3, '0919191919', 1, 'staff01@example.com', 'Staff User'),
('intern01', 'hashedpassword5', 3, '0929292929', 0, 'intern01@example.com', 'Intern User');

INSERT INTO Document (DocumentContent, DocumentTitle, DocumentStatusId, AccountId, CategoryId) VALUES
('Public1', 'Public Document 1', 2, 1, 1),
('Internal1', 'Internal Document 1', 1, 2, 2),
('Secret1', 'Confidential Document 1', 3, 3, 3),
('Nội dung tài liệu giới hạn 1', 'Restricted Document 1', 4, 4, 4),
('Nội dung tài liệu công khai 2', 'Public Document 2', 2, 5, 1);
