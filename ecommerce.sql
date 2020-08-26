create table Category  
(  
    CategoryID INT IDENTITY (1,1) PRIMARY KEY
    ,NameCategory VARCHAR (25) NOT NULL  
);
create table Products  
(  
    ProductID INT IDENTITY (1,1) PRIMARY KEY
    ,NameProduct VARCHAR (25) NOT NULL
    ,Price FLOAT
    ,Sale BIT
    ,Category INT
    ,CONSTRAINT fk_Categoria FOREIGN KEY (Category) 
     REFERENCES category (CategoryID)  
);
create table ImageProducts
(
    ImageID INT IDENTITY (1,1) PRIMARY KEY
    ,SrcImage  VARCHAR (50) NOT NULL
    ,Products  INT
    ,CONSTRAINT fk_Products FOREIGN KEY (Products) 
    REFERENCES Products (ProductID)
);

create table Users
(  
     UserID INT IDENTITY (1,1) PRIMARY KEY
    ,FirstName VARCHAR (25) NOT NULL
    ,LastName VARCHAR (25) NOT NULL
    ,Email VARCHAR (25) NOT NULL
    ,Pass VARCHAR (200) NOT NULL
    ,Direction VARCHAR (200) NOT NULL
    ,Shoppingcart INT
    ,Purchaseorder INT   
);
create table Shoppingcart
(  
     ShopCartID INT IDENTITY (1,1) PRIMARY KEY
     ,Product INT
     ,OrderClient BIT
     ,Users INT
     ,CONSTRAINT fk_Product FOREIGN KEY (Product) 
      REFERENCES Products (ProductID) 
     ,CONSTRAINT fk_User FOREIGN KEY (Users) 
      REFERENCES Users (UserID) 
);
