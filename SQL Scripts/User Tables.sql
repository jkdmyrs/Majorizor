   
CREATE TABLE user_group (
	user_group CHAR (10) PRIMARY KEY,
    description CHAR (50)
);
    
INSERT INTO user_group (user_group, description) VALUES 
	('USER','Normal application users.'),
    ('ADVISOR', 'Advisor - Able to manage students.'),
    ('ADMIN', 'Admin - Able to manage users and application.');
    
CREATE TABLE user (
	userID INT PRIMARY KEY AUTO_INCREMENT,
    first_name CHAR(50),
    last_name CHAR(50),
    email CHAR(50),
    user_group CHAR(10),
    CONSTRAINT fk_user_group FOREIGN KEY (user_group)
		REFERENCES user_group (user_group)
);

CREATE TABLE user_password (
	userID INT,
    password CHAR(30),
    CONSTRAINT fk_userID FOREIGN KEY (userID)
		REFERENCES user (userID)
);

INSERT INTO user (first_name, last_name, email, user_group) VALUES ('Jackson', 'DeMeyers', 'demeyejg@clarkson.edu','ADMIN');

insert into user_password (userID, password) VALUES (1, 'testPass123');