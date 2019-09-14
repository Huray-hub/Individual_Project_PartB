use master
go

drop database if exists IndividualPartB
create database IndividualPartB
go

use IndividualPartB
go

create table Streams (
	StreamID int identity(1,1) primary key,
	StreamName nvarchar(10)
)
insert into Streams(StreamName) values ('Java')
insert into Streams(StreamName) values ('C#')

create table [Types] (
	TypeID int identity(1,1) primary key,
	[Type] nvarchar(10)
)
insert into [Types]([Type]) values ('Part-Time')
insert into [Types]([Type]) values ('Full-Time')

create table Courses (
	CourseID int identity(1,1) primary key,
	Title nvarchar(50),
	StreamID int foreign key references Streams(StreamID),
	TypeID int foreign key references [Types](TypeID),
	StartingDate date,
	EndingDate date
)

create table Assignments (
	AssignmentID int identity(1,1) primary key,
	Title nvarchar(50),
	[Description] nvarchar(200),
	SubmissionDateTime datetime,
	OralMark decimal,
	TotalMark decimal,
	CourseID int foreign key references Courses(CourseID)
)

create table Trainers (
	TrainerID int identity(1,1) primary key,
	FirstName nvarchar(20),
	LastName nvarchar(20),
	[Subject] nvarchar(50)	 
)

create table Students (
	StudentID int identity(1,1) primary key,
	FirstName nvarchar(20),
	LastName nvarchar(20),
	DateOfBirth date,
	TuitionFees decimal,
)

create table StudentsPerCourse (
	CourseID int foreign key references Courses(CourseID),
	StudentID int foreign key references Students(StudentID),
	primary key (CourseID, StudentID)
)

create table TrainersPerCourse (
	CourseID int foreign key references Courses(CourseID),
	TrainerID int foreign key references Trainers(TrainerID),
	primary key (CourseID, TrainerID)
)

create table AssignmentsPerStudent (
	StudentID int foreign key references Students(StudentID),
	AssignmentID int foreign key references Assignments(AssignmentID),
	PersonalOralMark decimal,
	PersonalTotalMark decimal,
	primary key (StudentID, AssignmentID)
)

--Trainers---------------------------------------------------------------------------------------
insert into Trainers(FirstName, LastName, [Subject]) 
values ('KwaiGon', 'Jin', 'How to be komparsos in your own movie')
insert into Trainers(FirstName, LastName, [Subject]) 
values ('Anakin', 'Skywalker', 'Path to the Dark Side')
insert into Trainers(FirstName, LastName, [Subject]) 
values ('Luke', 'Skywalker', 'Sand Survive Tactics')
insert into Trainers(FirstName, LastName, [Subject]) 
values ('Darth', 'Maul', 'How to cut yourself in half')
insert into Trainers(FirstName, LastName, [Subject]) 
values ('Darth', 'Vader', 'How to breath like a retard')
insert into Trainers(FirstName, LastName, [Subject]) 
values ('Kylo', 'Ren', 'How wear a mask for no reason')
--Courses-----------------------------------------------------------------------------------------
insert into Courses(Title, StreamID, TypeID, StartingDate, EndingDate)
values ('Speak Chewbacish now', 1, 2, '2019-9-13', '2020-12-23')
insert into Courses(Title, StreamID, TypeID, StartingDate, EndingDate)
values ('Escape with Hyperspeed', 2, 1, '2019-10-12', '2019-11-23') 
insert into Courses(Title, StreamID, TypeID, StartingDate, EndingDate)
values ('Lightsaber art', 2, 1, '2019-11-13', '2020-2-23') 
insert into Courses(Title, StreamID, TypeID, StartingDate, EndingDate)
values ('Force basics', 1, 2, '2019-09-13', '2019-12-03') 
insert into Courses(Title, StreamID, TypeID, StartingDate, EndingDate)
values ('Learn to communicate with Kylo', 2, 2, '2020-4-1', '2019-12-23') 
insert into Courses(Title, StreamID, TypeID, StartingDate, EndingDate)
values ('Move things with Force', 2, 2, '2194-10-13', '2019-12-23')
insert into Courses(Title, StreamID, TypeID, StartingDate, EndingDate)
values ('Learn to fly Millenium Falcon', 1, 1, '2019-09-13', '2020-12-03') 
insert into Courses(Title, StreamID, TypeID, StartingDate, EndingDate)
values ('Bored to write more', 2, 2, '2020-01-02', '2020-02-12')  
--Assignments-------------------------------------------------------------------------------------
insert into Assignments (Title, [Description], SubmissionDateTime, OralMark, TotalMark, CourseID) 
values ('Phantom Menace','Years ago, in a galaxy far far away...','2020-01-17', 100, 100, 1)
insert into Assignments (Title, [Description], SubmissionDateTime, OralMark, TotalMark, CourseID) 
values ('Attack of the Clones','Episode II','2020-01-06', 100, 100, 1)
insert into Assignments (Title, [Description], SubmissionDateTime, OralMark, TotalMark, CourseID) 
values ('Revenge of Sith','Episode III','2020-01-07', 100, 100, 3)
insert into Assignments (Title, [Description], SubmissionDateTime, OralMark, TotalMark, CourseID) 
values ('New Hope','Episode IV','2223-7-6', 100, 100, 4)
insert into Assignments (Title, [Description], SubmissionDateTime, OralMark, TotalMark, CourseID) 
values ('Empire Strikes Back','Episode V','2019-12-03', 100, 100, 5)
insert into Assignments (Title, [Description], SubmissionDateTime, OralMark, TotalMark, CourseID) 
values ('Return of the Jedi','Episode VI','2019-12-06', 100, 100, 6)
--Students----------------------------------------------------------------------------------------
insert into Students(FirstName, LastName, DateOfBirth, TuitionFees)
values ('Panos', 'Skiadas', '1997-9-12', '2500')
insert into Students(FirstName, LastName, DateOfBirth, TuitionFees)
values ('Mixalis', 'Kapiniaris', '1983-2-3', '2500')
insert into Students(FirstName, LastName, DateOfBirth, TuitionFees)
values ('Helen', 'Skiada', '1993-3-3', '2500')
insert into Students(FirstName, LastName, DateOfBirth, TuitionFees)
values ('Ifigeneia', 'Adamakh', '1991-1-1', '2500')
insert into Students(FirstName, LastName, DateOfBirth, TuitionFees)
values ('Kostas', 'Tsiggenopoulos', '1989-1-1', '2500')
insert into Students(FirstName, LastName, DateOfBirth, TuitionFees)
values ('Bill', 'Tsiggenopoulos', '1993-2-9', '2500')
insert into Students(FirstName, LastName, DateOfBirth, TuitionFees)
values ('Konstantinos', 'Petrakis', '1996-3-4', '2500')
insert into Students(FirstName, LastName, DateOfBirth, TuitionFees)
values ('Vaggelis', 'Boltzis', '1930-8-3','2500')
insert into Students(FirstName, LastName, DateOfBirth, TuitionFees)
values ('Mike', 'Fasolakis', '1996-4-10', '2500')
insert into Students(FirstName, LastName, DateOfBirth, TuitionFees)
values ('Mikeius', 'Neti', '1990-4-10', '2500')
--Assignments-Per-Student----------------------------------------------------------------------------
insert into AssignmentsPerStudent(StudentID, AssignmentID, PersonalOralMark, PersonalTotalMark) values (1, 1, 0, 0)
insert into AssignmentsPerStudent(StudentID, AssignmentID, PersonalOralMark, PersonalTotalMark) values (1, 2, 0, 0)
insert into AssignmentsPerStudent(StudentID, AssignmentID, PersonalOralMark, PersonalTotalMark) values (2, 3, 0, 0)
insert into AssignmentsPerStudent(StudentID, AssignmentID, PersonalOralMark, PersonalTotalMark) values (3, 1, 0, 0)
insert into AssignmentsPerStudent(StudentID, AssignmentID, PersonalOralMark, PersonalTotalMark) values (4, 3, 0, 0)
insert into AssignmentsPerStudent(StudentID, AssignmentID, PersonalOralMark, PersonalTotalMark) values (5, 3, 0, 0)
insert into AssignmentsPerStudent(StudentID, AssignmentID, PersonalOralMark, PersonalTotalMark) values (6, 3, 0, 0)
--Trainers-Per-Course-------------------------------------------------------------------------------
insert into TrainersPerCourse(CourseID, TrainerID) values (1,1)
insert into TrainersPerCourse(CourseID, TrainerID) values (1,2)
insert into TrainersPerCourse(CourseID, TrainerID) values (2,3)
insert into TrainersPerCourse(CourseID, TrainerID) values (2,4)
insert into TrainersPerCourse(CourseID, TrainerID) values (3,3)
insert into TrainersPerCourse(CourseID, TrainerID) values (4,5)
insert into TrainersPerCourse(CourseID, TrainerID) values (5,6)
--Students-Per-Course-------------------------------------------------------------------------------
insert into StudentsPerCourse(CourseID, StudentID) values (1,1)
insert into StudentsPerCourse(CourseID, StudentID) values (1,2)
insert into StudentsPerCourse(CourseID, StudentID) values (1,3)
insert into StudentsPerCourse(CourseID, StudentID) values (2,1)
insert into StudentsPerCourse(CourseID, StudentID) values (2,3)
insert into StudentsPerCourse(CourseID, StudentID) values (2,5)
insert into StudentsPerCourse(CourseID, StudentID) values (3,4)
insert into StudentsPerCourse(CourseID, StudentID) values (3,5)
insert into StudentsPerCourse(CourseID, StudentID) values (3,6)
insert into StudentsPerCourse(CourseID, StudentID) values (4,7)
insert into StudentsPerCourse(CourseID, StudentID) values (4,8)
insert into StudentsPerCourse(CourseID, StudentID) values (5,1)
insert into StudentsPerCourse(CourseID, StudentID) values (6,8)
insert into StudentsPerCourse(CourseID, StudentID) values (7,9)

--Trainers-------------------------------------------------------------------------------------------------------------
--select * from Trainers

--Courses--------------------------------------------------------------------------------------------------------------
/*
select c.Title, s.StreamName, t.[Type], c.StartingDate, c.EndingDate from Courses as c
join Streams as s
on c.StreamID = s.StreamID
join [Types] as t
on c.TypeID = T.TypeID
*/

--Assignments----------------------------------------------------------------------------------------------------------
--select * from Assignments

--Students-------------------------------------------------------------------------------------------------------------
--select * from Students

--StudentsPerCourse----------------------------------------------------------------------------------------------------
/*
select c.Title, s.FirstName + ' ' + s.LastName as Students from Courses as c
join StudentsPerCourse as spc
on c.CourseID = spc.CourseID
join Students as s
on spc.StudentID = s.StudentID
order by c.Title
*/

--Trainers Per Course------------------------------------------------------------------------------------------------
/*
select c.Title as Course, t.FirstName + ' ' + t.LastName as Trainers from Courses as c
join TrainersPerCourse as tpc
on c.CourseID = tpc.CourseID
join Trainers as t
on tpc.TrainerID = t.TrainerID
order by c.Title
*/

--Assignments Per Course---------------------------------------------------------------------------------------------
/*
select c.Title as [Courses' Title], a.Title as [Assignments' Title] from Courses as c
join Assignments as a
on c.CourseID = a.CourseID
order by c.Title
*/

--Assignments Per Course Per Student----------------------------------------------------------------------------------
/*
select s.FirstName + ' ' + s.LastName as Student, c.Title as Courses, a.Title as Assignments from Courses as c
join Assignments as a
on c.CourseID = a.CourseID
join StudentsPerCourse as spc
on spc.CourseID = c.CourseID
join Students as s
on s.StudentID = spc.StudentID
order by s.StudentID
*/

