CREATE SCHEMA `QueueOverflow` ;

USE QueueOverflow;

CREATE TABLE `USER_DATA` 
	(
	  `UserAutoId` INT(11) NULL AUTO_INCREMENT,
	  `UserId` VARCHAR(60) NOT NULL,
	  `UserName` VARCHAR(45) DEFAULT NULL,
	  `FullName` VARCHAR(45) DEFAULT NULL,
	  `Phone` VARCHAR(45) DEFAULT NULL,
	  `Email` VARCHAR(45) DEFAULT NULL,
	  `City` VARCHAR(45) DEFAULT NULL,
	  `Dob` VARCHAR(45) DEFAULT NULL,
	  `Password` VARCHAR(45) DEFAULT NULL,
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

