CREATE DATABASE toys_shop COLLATE hebrew_100_ci_as
use toys_shop

CREATE TABLE category(  
categoryId INT IDENTITY NOT NULL PRIMARY KEY,  
categoryName VARCHAR(30) NOT NULL
)
CREATE TABLE company(  
companyId INT IDENTITY NOT NULL PRIMARY KEY,  
companyName VARCHAR(30) NOT NULL
)
CREATE TABLE products(  
productId INT IDENTITY NOT NULL PRIMARY KEY,  
productName VARCHAR(30) NOT NULL,
productCategoryId INT NOT NULL,
productCompanyId INT NOT NULL,
productDescription VARCHAR(100) NOT NULL,
productPrice INT NOT NULL,
productImage  VARCHAR(250) NOT NULL,
productLastUpdate DATE NOT NULL,
CONSTRAINT FK_products_category FOREIGN KEY(productCategoryId) REFERENCES category(categoryId),
CONSTRAINT FK_products_company FOREIGN KEY(productCompanyId) REFERENCES company(companyId)			
)	
CREATE TABLE customers(  
customerId INT IDENTITY NOT NULL PRIMARY KEY,  
customerName VARCHAR(30) NOT NULL,
customerPhone VARCHAR(10) NOT NULL,
customerEmail VARCHAR(30) NOT NULL,
customerPassword VARCHAR(30) NOT NULL,
customerDateOfBirth DATE NOT NULL
)

CREATE TABLE purchases(  
purchaseId INT IDENTITY NOT NULL PRIMARY KEY,  
purchaseCustomerId INT NOT NULL,
purchaseDate DATE NOT NULL,
purchaseAmountToPay INT NOT NULL,
purchaseMention VARCHAR(40) NOT NULL,
CONSTRAINT FK_purchases_customer FOREIGN KEY(purchaseCustomerId) REFERENCES customers(customerId)
)

CREATE TABLE purchaseDetails(  
purchaseDetailsId INT IDENTITY NOT NULL PRIMARY KEY,  
purchaseDetailsPurchaseId INT NOT NULL,
purchaseDetailsProductsId INT NOT NULL,
purchaseDetailsAmount INT NOT NULL,
CONSTRAINT FK_purchase_details_purchases FOREIGN KEY(purchaseDetailsPurchaseId) REFERENCES purchases(purchaseId),
CONSTRAINT FK_purchase_details_products FOREIGN KEY(purchaseDetailsProductsId) REFERENCES products(productId)
)
					
-- category table
INSERT INTO category (categoryName) VALUES
('Board games'),
('Thinking games'),
('Dolls'),
('Toddler toys'),
('Yard games')
-- company table
INSERT INTO company (companyName) VALUES
('Fox mind'),
('Kodkod'),
('Fisher Price'),
('HaKubiya'),
('a&d')

-- products table
INSERT INTO products (productName,productCategoryId,productCompanyId, productDescription, productPrice, productImage, productLastUpdate )VALUES
('Lego Classic', 1, 1, 'Lego Classic Beginner', 150, 'https://cdn.pixabay.com/photo/2018/05/10/17/48/lego-3388163_1280.png', GETDATE()),
('Talking Doll', 3, 3, 'A Doll That Speaks in Different Languages', 200, 'https://cdn.pixabay.com/photo/2018/08/12/18/03/doll-3601322_640.jpg', GETDATE()),
('Puzzle 1000 pieces', 1, 2, '1000 piece landscape puzzle', 120, 'https://cdn.pixabay.com/photo/2015/01/08/11/49/pieces-of-the-puzzle-592780_640.jpg', GETDATE()),
('Monopoly game', 1, 4, 'Family Monopoly game', 180, 'https://cdn.pixabay.com/photo/2014/11/24/17/20/childrens-games-544309_640.jpg', GETDATE()),
('Toddler activity ball', 4, 3, 'Toddler colorful ball with rattles', 80, 'https://cdn.pixabay.com/photo/2014/12/21/23/28/beach-ball-575425_640.png', GETDATE()),
('Chess Game', 2, 1, 'Classic chess game with wooden pieces', 130, 'https://cdn.pixabay.com/photo/2021/08/28/09/19/chess-6580492_640.jpg', GETDATE()),
('Football Game', 5, 5, 'Outdoor football game with net and ball', 250, 'https://cdn.pixabay.com/photo/2014/04/02/16/17/ball-306820_640.png', GETDATE())
-- customers table
INSERT INTO customers (customerName, customerPhone, customerEmail, customerPassword, customerDateOfBirth) VALUES
('Dana Levi', '0541234567', 'danaLevi@gmail.com','AB123@', '1990-05-12'),
('Yossi Cohen', '0527654321', 'yossiCohen@gmail.com','yosssss', '1985-11-22'),
('Ronit Barak', '0539876543', 'ronitBarak@gmail.com', 'karabTinor','1995-07-01'),
('Moshe Ohana', '0545556677', 'mosheOhana@gmail.com','myNameIsMoyshalek', '1980-03-15'),
('Efrat Kedem', '0523334455', 'efratKedem@gmail.com','qwert963', '1992-08-08')


-- purchase table
INSERT INTO purchases (purchaseCustomerId, purchaseDate, purchaseAmountToPay, purchaseMention) VALUES
(1, '2024-11-01', 300, 'Purchase in store'),
(2, '2024-10-28', 500, 'Order online'),
(3, '2024-11-02', 200, 'Purchase in cash'),
(4, '2024-10-30', 400, 'Order online'),
(5, '2024-11-03', 250, 'Purchase on sale')

-- purchase_details table
INSERT INTO purchaseDetails (purchaseDetailsPurchaseId, purchaseDetailsProductsId, purchaseDetailsAmount) VALUES
(1, 1, 2), 
(1, 3, 1), 
(2, 4, 1), 
(2, 2, 1), 
(3, 5, 3), 
(4, 3, 2), 
(5, 1, 1)
-- selects
select*from purchaseDetails
select*from purchases
select*from customers
select*from products
select*from company
select*from category


