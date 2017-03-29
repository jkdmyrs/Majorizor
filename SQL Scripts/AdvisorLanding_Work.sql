##############################################################################
#student info table
drop table student_info;
CREATE TABLE student_info (
	userID INT not null,
    year char(10) not null, 
    major1 char(50) not null, 
    major2 char(50) null,
    minor1 char(50) null,
    minor2 char(50) null,
    graduation char(20) not null,
    CONSTRAINT fk_info_userID FOREIGN KEY (userID)
		REFERENCES user (userID),
	CONSTRAINT fk_info_student_year foreign key (year)
		references student_year (student_year),
	CONSTRAINT fk_info_major1 foreign key (major1)
		references majors (major),
	CONSTRAINT fk_info_major2 foreign key (major2)
		references majors (major),
	CONSTRAINT fk_info_minor1 foreign key (minor1)
		references minors (minor),
	CONSTRAINT fk_info_minor2 foreign key (minor2)
		references minors (minor)
);
insert into student_info (userID, year, major1, graduation) values
(7, 'Freshman', 'MA', 'Spring 2021'),
(5, 'Senior', 'SE', 'Spring 2018');

update student_info set minor1 = 'CS' where userID = 7;

select * from user;
select * from student_info;

##############################################################################
#student_year
drop table student_year;
CREATE TABLE student_year (
	student_year char(10) PRIMARY KEY
);

INSERT INTO student_year (student_year) values ('Freshman'), ('Sophomore'), ('Junior'), ('Senior');
select * from student_year;

##############################################################################
#majors
drop table majors;
CREATE TABLE majors (
	major char(2) PRIMARY KEY, 
    description char(50)
);
INSERT INTO majors (major, description) values ('CE', 'Computer Engineering'), ('CS','Computer Science'), ('EE','Electrical Engineering'), ('MA','Math'), ('SE','Software Engineering');

select * from majors;

##############################################################################
#minors
drop table minors;
CREATE TABLE minors (
	minor char(2) PRIMARY KEY, 
    description char(50)
);
INSERT INTO minors (minor, description) values ('CS','Computer Science'), ('EE','Electrical Engineering'), ('MA','Math'), ('SE','Software Engineering');

select * from minors;

##############################################################################
#Advisees
drop table advisees;

create table advisees (
	advisorID int not null,
    studentID int not null,
    CONSTRAINT fk_advisorID FOREIGN KEY (advisorID)
		REFERENCES user (userID),
	CONSTRAINT fk_studentID FOREIGN KEY (studentID)
		REFERENCES student_info (userID)
);

insert into advisees (advisorID, studentID) values (6, 5), (6,7);

select * from advisees;
    

