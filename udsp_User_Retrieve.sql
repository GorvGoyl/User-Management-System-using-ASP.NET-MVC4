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
	var_Password VARCHAR(45)
)
BEGIN
	IF(IFNULL(var_UserId,'')!='') THEN 
		SELECT * FROM user_data WHERE UserId =var_UserId;
	ELSEIF(IFNULL(var_UserName,'')!='') THEN
		SELECT * FROM user_data WHERE UserName = var_UserName AND Password = var_Password;
	ELSE
		SELECT * FROM user_data;
	END IF;

END //
DELIMITER ;