CREATE SCHEMA `QueueOverflow` ;

USE QueueOverflow;

CREATE TABLE `USER_DATA` 
	(
	  `UserAutoId` int(11) NULL AUTO_INCREMENT,
	  `UserId` varchar(60) NOT NULL,
	  `UserName` varchar(45) DEFAULT NULL,
	  `FullName` varchar(45) DEFAULT NULL,
	  `Phone` varchar(45) DEFAULT NULL,
	  `Email` varchar(45) DEFAULT NULL,
	  `City` varchar(45) DEFAULT NULL,
	  `Dob` varchar(45) DEFAULT NULL,
	  `Password` varchar(45) DEFAULT NULL,
	  CONSTRAINT  UserId   PRIMARY KEY (UserId)  ,
	  CONSTRAINT  UserAutoId  UNIQUE (UserAutoId)
	) ;

INSERT INTO `user_data`
   (
		`UserId`, 
		`UserName`, 
		`FullName`,
		`Phone`, 
		`Email`,
		`City`, 
		`Dob`, 
		`Password`
   )

VALUES
   (
		'6c479dce-3adf-4a7a-a124-2b35f30d4ez4',
		'admin', 
		'Gourav Goyal',	
		'8010822600',
		'gourav@leadsquared.com',
		'Bangalore',
		'07/17/1992', 
		'admin'
   );

