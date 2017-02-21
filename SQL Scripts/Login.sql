CREATE DEFINER=`demeyejg`@`%` PROCEDURE `Login`(IN email char(50), IN password char(30), OUT user_group char(10))
BEGIN
	SELECT 
		u.email,
		u.user_group INTO user_group 
	FROM user u
	INNER JOIN user_password p
		ON u.userID = p.userID
	WHERE 
		u.email = @email
		AND p.password = @password;
END