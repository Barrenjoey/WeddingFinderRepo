-- Drop Existing
drop table "Subscription" ;
drop table "Review" ;
drop table "Business" ;
drop table "Contact" ;
drop table "Address" ;
drop table "Region" ;
drop table "Category" ;
drop table "SubscriptionType" ;
drop table "Content";
drop table "State";

-- Category
create table 
"Category" (
	"CategoryID" int primary key GENERATED ALWAYS AS IDENTITY,
	"CategoryName" varchar(50) not null
);

-- State
create table
"State" (
	"StateID" int primary key GENERATED ALWAYS AS IDENTITY,
	"StateName" varchar(3) not null,
	"StateDisplayName" varchar(100)
);

-- Region
create table
"Region"(
	"RegionID" int primary key GENERATED ALWAYS AS IDENTITY,	
	"RegionName" varchar(100) not null,
	"StateID" int not null,
	foreign key ("StateID") references "State"("StateID")
);

-- Address
create table
"Address"(
	"AddressID" int primary key GENERATED ALWAYS AS IDENTITY,
	"Country" varchar(50),
	"StateID" int not null,
	"RegionID" int not null,
	"Suburb" varchar(50),
	"Street" varchar(50),
	"SteetNumber" varchar(50),
	"Postcode" varchar(4),
	foreign key ("RegionID") references "Region"("RegionID"),
	foreign key ("StateID") references "State"("StateID")
);

-- Contact
create table
"Contact"(
	"ContactID" int primary key GENERATED ALWAYS AS identity,	
	"ContactNumber" varchar(10),
	"Mobile" varchar(10),
	"Email" varchar(100)
);

-- SubscriptionType
create table
"SubscriptionType"(
	"SubTypeID" int primary key GENERATED ALWAYS AS identity,
	"SubscriptionName" varchar(255),
	"MonthlyCost" money
);

-- content
create table
"Content"(
	"ContentID" int primary key GENERATED ALWAYS AS IDENTITY,
	"ShortBlurb" varchar(50),
	"Body1" varchar(255),
	"Body2" varchar(255),
	"Body3" varchar(255),
	"ImgProfile" varchar(255),
	"Img2" varchar(255),
	"Img3" varchar(255),
	"Img4" varchar(255),
	"ImgSortOrder" int
);

-- Business
create table 
"Business" (
	"WedFinID" int primary key GENERATED ALWAYS AS IDENTITY,	
	"BusinessName" varchar(100),
	"CategoryID" int not null,
	"AddressID" int not null,
	"ContactID" int not null,	
	"ContentID" int not null,
	"ServiceRegions" varchar(100),
	"ReviewRating" decimal(1,1),
	"Website" varchar(100),
	"IsActive" bool not null,
	"Created" date,
	foreign key ("CategoryID") references "Category"("CategoryID"),
	foreign key ("AddressID") references "Address"("AddressID"),
	foreign key ("ContactID") references "Contact"("ContactID"),
	foreign key ("ContentID") references "Content"("ContentID")
);

-- Subscription
create table
"Subscription"(
	"SubscriptionID" int primary key GENERATED ALWAYS AS IDENTITY,
	"WedFinID" int not null,	
	"SubTypeID" int not null,
	"SubStart" date not null,
	"SubExpire" date,
	"LastBilling" date,
	"IsFinancial" bool not null,
	foreign key ("WedFinID") references "Business"("WedFinID"),
	foreign key ("SubTypeID") references "SubscriptionType"("SubTypeID")
);

-- Review
create table
"Review"(
	"ReviewID" int primary key GENERATED ALWAYS AS IDENTITY,
	"WedFinID" int not null,
	"Content" varchar(255) not null,
	"Rating" int not null,
	"ReviewerName" varchar(50),
	"ReviewDate" date,
	foreign key ("WedFinID") references "Business"("WedFinID")
);