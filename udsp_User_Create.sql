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