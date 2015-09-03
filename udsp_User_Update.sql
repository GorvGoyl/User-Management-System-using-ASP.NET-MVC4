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
	var_UserId		varchar(45), 
	var_UserName	varchar(45),
	var_FullName    varchar(45),
	var_Phone	    varchar(45),
	var_Email	    varchar(45),
	var_City		varchar(45),
	var_Dob			varchar(45),
	var_Password    varchar(45)
)
BEGIN
	UPDATE     user_data SET 
	UserName = var_UserName ,
	FullName = var_FullName	,
	Phone    = var_Phone	,
	Email    = var_Email	,
	City     = var_City		,
	Dob      = var_Dob 

	WHERE 
	UserId     = var_UserId	    ;

END //
DELIMITER ;