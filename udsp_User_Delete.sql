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
	var_UserId	varchar(45)
)
BEGIN
	DELETE FROM user_data WHERE UserId = var_UserId ;
END //
DELIMITER ;