/*
Name		: udsp_User_Create
Description	: Create User
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
	INSERT INTO user_data
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

END //
DELIMITER ;