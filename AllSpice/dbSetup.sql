-- Active: 1666715682905@@SG-bumpy-salsa-2352-6840-mysql-master.servers.mongodirector.com@3306@garbagecollector
CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS recipes(
        id INT NOT NULL primary key AUTO_INCREMENT,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        title VARCHAR(255) NOT NULL,
        instructions VARCHAR(1000) NOT NULL,
        img VARCHAR(255) NOT NULL,
        category VARCHAR(255) NOT NULL,
        archived TINYINT DEFAULT 0,
        creatorId VARCHAR(255) NOT NULL,
        Foreign Key (creatorId) REFERENCES accounts(id) 
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS ingredient(
        id INT NOT NULL primary key AUTO_INCREMENT,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name VARCHAR(255) NOT NULL,
        quantity varchar(255) NOT NULL,
        recipeId INT NOT NULL,
        Foreign Key (recipeId) REFERENCES recipes(id) 
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS favorites(
        id VARCHAR(255) NOT NULL primary key,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        accountId VARCHAR(255) NOT NULL,
        recipeId INT NOT NULL,
        Foreign Key (accountId) REFERENCES accounts(id) ,
        Foreign Key (recipeId) REFERENCES recipes(id) 
    ) default charset utf8 COMMENT '';