/*
 Test Data Script
 */
-- State
select * from "State";
insert into "State" ("StateName", "StateDisplayName") values ('NSW', 'New South Wales');
insert into "State" ("StateName", "StateDisplayName") values ('QLD', 'Queensland');
insert into "State" ("StateName", "StateDisplayName") values ('VIC', 'Victoria');

-- Category
select * from "Category";
insert into "Category" ("CategoryName") values ('Venues');
insert into "Category" ("CategoryName") values ('Photography');
insert into "Category" ("CategoryName") values ('Music');
insert into "Category" ("CategoryName") values ('Catering');
insert into "Category" ("CategoryName") values ('Videography');
insert into "Category" ("CategoryName") values ('Suits');
insert into "Category" ("CategoryName") values ('Decorations');
insert into "Category" ("CategoryName") values ('Flowers');
insert into "Category" ("CategoryName") values ('Dresses');
insert into "Category" ("CategoryName") values ('Bus Charter');
insert into "Category" ("CategoryName") values ('Wedding Planners');
insert into "Category" ("CategoryName") values ('Hair & Makeup');
insert into "Category" ("CategoryName") values ('Gifts & Favours');
insert into "Category" ("CategoryName") values ('Event Hire');
insert into "Category" ("CategoryName") values ('Celebrants');
insert into "Category" ("CategoryName") values ('Cakes');
insert into "Category" ("CategoryName") values ('Cars');

-- Regions
select * from "Region";
insert into "Region" ("RegionName", "StateID") values ('The Hunter Valley', 1);
insert into "Region" ("RegionName", "StateID") values ('Southern Highlands', 1);
insert into "Region" ("RegionName", "StateID") values ('Far North Coast / Byron Bay', 1);
insert into "Region" ("RegionName", "StateID") values ('Brisbane', 2);
insert into "Region" ("RegionName", "StateID") values ('Sunshine Coast / Noosa', 2);
insert into "Region" ("RegionName", "StateID") values ('Melbourne', 3);

-- Address
select * from "Address";
insert into "Address" ("Country", "StateID", "RegionID", "Suburb", "Street", "SteetNumber", "Postcode") values ('Australia', 1, 1, 'Pokolbin', 'Broke Rd', 1946, 2320);
insert into "Address" ("Country", "StateID", "RegionID", "Suburb", "Street", "SteetNumber", "Postcode") values ('Australia', 1, 1, 'PooTown', 'Poo Rd', 123, 2101);
insert into "Address" ("Country", "StateID", "RegionID", "Suburb", "Street", "SteetNumber", "Postcode") values ('Australia', 1, 1, 'Cessnock', 'Hello st', 5, 2000);
insert into "Address" ("Country", "StateID", "RegionID", "Suburb", "Street", "SteetNumber", "Postcode") values ('Australia', 3, 6, 'Yarra River', 'Hello st', 5, 3000);
insert into "Address" ("Country", "StateID", "RegionID", "Suburb", "Street", "SteetNumber", "Postcode") values ('Australia', 3, 6, 'Geelong', 'Hello st', 5, 3000);
insert into "Address" ("Country", "StateID", "RegionID", "Suburb", "Street", "SteetNumber", "Postcode") values ('Australia', 1, 1, 'Narrabeen', 'Hello st', 5, 2101);

-- Contact
select * from "Contact";
insert into "Contact" ("ContactNumber", "Mobile", "Email") values (99973833, 0415816728, 'J_vdm@hotmail.com');
insert into "Contact" ("ContactNumber", "Mobile", "Email") values (99999999, 0466530566, 'test@resimac.com.au');
insert into "Contact" ("ContactNumber", "Mobile", "Email") values (99876543, 0404040404, 'helo@test.com.au');
insert into "Contact" ("ContactNumber", "Mobile", "Email") values (99876543, 0404040404, 'helo@test.com.au');
insert into "Contact" ("ContactNumber", "Mobile", "Email") values (99876543, 0404040404, 'helo@test.com.au');
insert into "Contact" ("ContactNumber", "Mobile", "Email") values (99876543, 0404040404, 'helo@test.com.au');

-- SubscriptionType
select * from "SubscriptionType";
insert into "SubscriptionType" ("SubscriptionName", "MonthlyCost") values ('Standard', 0);
insert into "SubscriptionType" ("SubscriptionName", "MonthlyCost") values ('Silver', 14.99);
insert into "SubscriptionType" ("SubscriptionName", "MonthlyCost") values ('Gold', 24.99);

-- Content
select * from "Content";
insert into "Content" ("ShortBlurb", "Body1", "Body2", "Body3", "ImgProfile") values ('This is the short blurb about the business.', 'This is some example body content bla bla.', 'This is body number 2', 'This is body number 3', '~/images/profileTest1.jpg');
insert into "Content" ("ShortBlurb", "Body1", "Body2", "Body3", "ImgProfile") values ('This is the short blurb about the business.', 'hihklaksdnlkadoadklandladnkaosidnkladnlk adkln aslknd aklsnd aklsnd ansdklnas dlkand alskndlan skn', 'This is body number 2', 'This is body number 3', '~/images/defaultImage.png');
insert into "Content" ("ShortBlurb", "Body1", "Body2", "Body3", "ImgProfile") values ('This is the short blurb about the business.', 'This is some example body content bla bla. bla blab asdjas ido aodja skjasodj', 'This is body number 2', 'This is body number 3', '~/images/defaultImage.png');
insert into "Content" ("ShortBlurb", "Body1", "Body2", "Body3", "ImgProfile") values ('This is the short blurb about the business.', 'This is some example body content bla bla. bla blab asdjas ido aodja skjasodj', 'This is body number 2', 'This is body number 3', '~/images/defaultImage.png');
insert into "Content" ("ShortBlurb", "Body1", "Body2", "Body3", "ImgProfile") values ('This is the short blurb about the business.', 'This is some example body content bla bla. bla blab asdjas ido aodja skjasodj', 'This is body number 2', 'This is body number 3', '~/images/defaultImage.png');
insert into "Content" ("ShortBlurb", "Body1", "Body2", "Body3", "ImgProfile") values ('This is the short blurb about the business.', 'This is some example body content bla bla. bla blab asdjas ido aodja skjasodj', 'This is body number 2', 'This is body number 3', '~/images/defaultImage.png');

-- Businesses
select * from "Business";
insert into "Business" ("BusinessName", "CategoryID", "AddressID", "ContactID", "ContentID", "ServiceRegions", "Website", "IsActive", "Created") values ('Peppers Creek Estate', 1, 1, 1, 1, '1', 'https://www.winecountryweddings.net.au/', true, current_timestamp);
insert into "Business" ("BusinessName", "CategoryID", "AddressID", "ContactID", "ContentID", "ServiceRegions", "Website", "IsActive", "Created") values ('Sydney Dresses', 9, 2, 2, 2, '1', 'www.google.com', true, current_timestamp);
insert into "Business" ("BusinessName", "CategoryID", "AddressID", "ContactID", "ContentID", "ServiceRegions", "Website", "IsActive", "Created") values ('Mobys', 1, 3, 3, 3, '1', 'www.facebook.com', true, current_timestamp);
insert into "Business" ("BusinessName", "CategoryID", "AddressID", "ContactID", "ContentID", "ServiceRegions", "Website", "IsActive", "Created") values ('Yarra Valley Venue', 1, 4, 4, 4, '6', 'www.facebook.com', true, current_timestamp);
insert into "Business" ("BusinessName", "CategoryID", "AddressID", "ContactID", "ContentID", "ServiceRegions", "Website", "IsActive", "Created") values ('Melbourne Dresses', 9, 5, 5, 5, '6', 'www.facebook.com', true, current_timestamp);
insert into "Business" ("BusinessName", "CategoryID", "AddressID", "ContactID", "ContentID", "ServiceRegions", "Website", "IsActive", "Created") values ('Sydney Photos', 2, 6, 6, 6, '1,2,3', 'www.facebook.com', true, current_timestamp);

-- subscription
select * from "Subscription";
insert into "Subscription" ("WedFinID", "SubTypeID", "SubStart", "LastBilling", "IsFinancial") values (1, 2, '01-Sep-2019', current_timestamp, false);
insert into "Subscription" ("WedFinID", "SubTypeID", "SubStart", "LastBilling", "IsFinancial") values (2, 1, '01-Sep-2019', current_timestamp, false);
insert into "Subscription" ("WedFinID", "SubTypeID", "SubStart", "LastBilling", "IsFinancial") values (3, 1, '01-Sep-2019', current_timestamp, false);
insert into "Subscription" ("WedFinID", "SubTypeID", "SubStart", "LastBilling", "IsFinancial") values (4, 2, '01-Sep-2019', current_timestamp, false);
insert into "Subscription" ("WedFinID", "SubTypeID", "SubStart", "LastBilling", "IsFinancial") values (5, 1, '01-Sep-2019', current_timestamp, false);
insert into "Subscription" ("WedFinID", "SubTypeID", "SubStart", "LastBilling", "IsFinancial") values (6, 2, '01-Sep-2019', current_timestamp, false);