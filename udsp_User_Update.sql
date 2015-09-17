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