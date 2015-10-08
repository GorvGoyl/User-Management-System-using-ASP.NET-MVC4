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
	var_Email VARCHAR(45)
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