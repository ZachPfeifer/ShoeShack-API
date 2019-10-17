USE zachshack;
-- CREATE TABLE brands
-- (
--     id INT NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- );

-- CREATE TABLE shoes
-- (
--     id VARCHAR(255) NOT NULL,
--     name VARCHAR(255) NOT NULL,
--     color VARCHAR(255) NOT NULL,
--     price DECIMAL(9, 2) NOT NULL,
--     size DECIMAL(3, 1) NOT NULL,
--     brandId INT NOT NULL,

--     FOREIGN KEY(brandId)
--         REFERENCES brands(id)
--         ON DELETE CASCADE,

--     PRIMARY KEY (id)
-- );

-- CREATE TABLE orders
-- (
--     id INT NOT NULL AUTO_INCREMENT,
--     customerName VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- );

-- CREATE TABLE shoesorders
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   shoeId VARCHAR(255) NOT NULL,
--   orderId INT NOT NULL,

--   INDEX (orderId),

--     FOREIGN KEY(shoeId) 
--         REFERENCES shoes(id) 
--         ON DELETE CASCADE,
    
--     FOREIGN KEY(orderId)
--         REFERENCES orders(id)
--         ON DELETE CASCADE,

--     PRIMARY KEY(id)
-- );



------------------------------------------------------------------------------------------

-- CREATE TABLE brands
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,

--   PRIMARY KEY(id)

-- );

--  CREATE TABLE shoes
-- (
--     id VARCHAR(255) NOT NULL,
--     name VARCHAR(255) NOT NULL,
--     color VARCHAR(255) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     price DECIMAL(5,2) DEFAULT .99,
--     size DECIMAL(3,1) NOT NULL,
--     brandId INT NOT NULL,

--     FORIEGN KEY(brandId)
--       REFERENCES brands(id)
--       ON DELETE CASCADE, -- Cascade deletes only things with this brand (ONE to MANY)

--     PRIMARY KEY(id)
-- );

-- --Append Missing info
-- -- ALTER TABLE shoes
-- -- ADD brandId INT

-- -- CREATE
-- -- INSERT INTO shoes 
-- -- (id, name, color, size, price, description)
-- -- VALUES
-- -- ("1", "Feast MEe", "White", 8, 1.99, "Bread made into shoes. GET AT DEM");

-- -- GET ALL
-- -- SELECT * FROM shoes;

-- -- GET BY (Find)
-- -- SELECT * FROM shoes WHERE id = 123;


-- -- EDIT
-- -- UPDATE shoes
-- -- SET name = "Aloha Zach"
-- -- WHERE id = 123;

-- -- REMOVE by
-- -- DELETE FROM shoes WHERE id = 235;

