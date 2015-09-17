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


/*
Name		: udsp_User_Create
Description	: Creates User
Author		: Gourav Goyal

Modification Log: Change
---------------------------------------------------------------------------
Description                  Date			Changed By
Created procedure            03-Sep-2015    Gourav Goyal
---------------------------------------------------------------------------
CALL udsp_User_Create()
*/

DROP PROCEDURE IF EXISTS udsp_User_Create;
DELIMITER //

CREATE PROCEDURE udsp_User_Create
(
	var_UserId		VARCHAR(45), 
	var_UserName	VARCHAR(45),
	var_FullName    VARCHAR(45),
	var_Phone	    VARCHAR(45),
	var_Email	    VARCHAR(45),
	var_City		VARCHAR(45),
	var_Dob			VARCHAR(45),
	var_Password    VARCHAR(45)
)
BEGIN

DECLARE error_InvalidInputs       CONDITION FOR SQLSTATE 'HY000';
IF NOT EXISTS(SELECT * FROM USER_DATA WHERE UserName=var_UserName ) THEN
	INSERT INTO USER_DATA
	(
		UserId,
		UserName,
		FullName,
		Phone,
		Email,
		City,
		Dob,
		Password
	) 

	VALUES
	( 
		var_UserId, 
		var_UserName,
		var_FullName,
		var_Phone,
		var_Email,
		var_City,
		var_Dob,
		var_Password
	);
	
ELSE
 SIGNAL error_InvalidInputs
 SET MESSAGE_TEXT    = "UserName already exists",
 MYSQL_ERRNO      = 2002;
END IF;

END //
DELIMITER ;

/*
Name		: udsp_User_Delete
Description	: Delete User
Author		: Gourav Goyal

Modification Log: Change
---------------------------------------------------------------------------
Description                  Date			Changed By
Created procedure            03-Sep-2015    Gourav Goyal
---------------------------------------------------------------------------
CALL udsp_User_Delete()
*/

DROP PROCEDURE IF EXISTS udsp_User_Delete;
DELIMITER //

CREATE PROCEDURE udsp_User_Delete
(
	var_UserId	VARCHAR(45)
)
BEGIN
	DELETE FROM USER_DATA WHERE UserId = var_UserId ;
END //
DELIMITER ;


/*
Name		: udsp_User_Retrieve
Description	: Retrieve User Details
Author		: Gourav Goyal

Modification Log: Change
---------------------------------------------------------------------------
Description                  Date			Changed By
Created procedure            03-Sep-2015    Gourav Goyal
---------------------------------------------------------------------------
CALL udsp_User_Retrieve()
*/

DROP PROCEDURE IF EXISTS udsp_User_Retrieve;
DELIMITER //

CREATE PROCEDURE udsp_User_Retrieve
(
	var_UserId	 VARCHAR(45),
	var_UserName VARCHAR(45),
	var_Password VARCHAR(45),
	var_Email varchar(45)
)
BEGIN

	IF(IFNULL(var_UserId,'')!='') THEN 
		SELECT * FROM USER_DATA WHERE UserId =var_UserId;
	ELSEIF(IFNULL(var_UserName,'')!='' and IFNULL(var_Password,'')!='') THEN
		SELECT * FROM USER_DATA WHERE UserName = var_UserName AND Password = var_Password;
	ELSEIF(IFNULL(var_UserName,'')!='' and IFNULL(var_Email,'')!='' ) THEN
		SELECT * FROM USER_DATA WHERE UserName = var_UserName AND Email = var_Email;
	ELSEIF(IFNULL(var_UserName,'')!='' and IFNULL(var_Password,'')='') THEN
		SELECT * FROM USER_DATA WHERE UserName = var_UserName;
	ELSE
		SELECT * FROM USER_DATA;
	END IF;

END//
DELIMITER ;


/*
Name		: udsp_User_Update
Description	: Update User
Author		: Gourav Goyal

Modification Log: Change
---------------------------------------------------------------------------
Description                  Date			Changed By
Created procedure            03-Sep-2015    Gourav Goyal
---------------------------------------------------------------------------
CALL udsp_User_Update()
*/

DROP PROCEDURE IF EXISTS udsp_User_Update;
DELIMITER //

CREATE PROCEDURE udsp_User_Update
(
	var_UserId		VARCHAR(45), 
	var_UserName	VARCHAR(45),
	var_FullName    VARCHAR(45),
	var_Phone	    VARCHAR(45),
	var_Email	    VARCHAR(45),
	var_City		VARCHAR(45),
	var_Dob			VARCHAR(45),
	var_Password    VARCHAR(45)
)
BEGIN
DECLARE error_InvalidInputs       CONDITION FOR SQLSTATE 'HY000';
IF NOT EXISTS(SELECT * FROM USER_DATA WHERE UserName=var_UserName ) THEN
	UPDATE     USER_DATA SET 
	UserName = var_UserName ,
	FullName = var_FullName	,
	Phone    = var_Phone	,
	Email    = var_Email	,
	City     = var_City		,
	Dob      = var_Dob 

	WHERE 
	UserId     = var_UserId	    ;
ELSE
 SIGNAL error_InvalidInputs
 SET MESSAGE_TEXT    = "UserName already exists",
 MYSQL_ERRNO      = 2002;
END IF;
END //
DELIMITER ;