--创建数据库
USE master
GO
-- Drop the database if it already exists
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'ExampleDB')
DROP DATABASE ExampleDB
GO
create database ExampleDB
on primary
(name=LoginDB_data, 
 filename='d:\data\ExampleDB_data.mdf',
 size=5,
 filegrowth=20%)
 log on
 (name=LoginDB_log,
  filename='d:\data\ExampleDB_log.ldf',    size=2mb,
  filegrowth=1mb)
GO

--创建表
Use ExampleDB
GO
--创建日志表
go
if OBJECT_ID('Syslog','U')is not null
	drop table SysLog
GO
create table  Syslog(
userid bigint,
dtime nchar(50),
daction nchar(50),
)




if OBJECT_ID('Users','U')is not null
	drop table Users
GO

create table  Users(
userid  bigint primary key identity(1,1),--登陆账号
username varchar(30) not null unique,
role	varchar(30) default '管理员',
userpassword varchar(30) not null,
userlevel tinyint
)
go

if OBJECT_ID('student','U')is not null
	drop table student
GO
create table student(
stuxuehao bigint primary key identity(2021,1),--学号（默认为学生登录账号）
stuname nvarchar(10),
stupasswd   bigint not null,
stugrade varchar(30),
stubanji varchar(30),
stusex varchar(2) ,
role	varchar(30) default '学生',
)
go
insert into student values('第一名','123123','初一年级','105','男','学生')
go


if OBJECT_ID('class','U')is not null
	drop table class
GO
create table class
(	claid bigint primary key identity(1,1),
	claname nvarchar(30) not null,
	teacherid varchar(30),
	teachername varchar(30),
	term varchar(30) not null
)


if OBJECT_ID('sctime','U')is not null
	drop table sctime
GO
create table  sctime(
sctimeid bigint primary key identity(1,1),--上课时间id
claid bigint,--课程的id
teacherid bigint,
sctime varchar(30),--上课时间
location varchar(30),--上课地点
term varchar(30) not null
)

go


if OBJECT_ID('sc','U')is not null--记录选课的学生学号，课程号，学期，成绩
	drop table sc
GO
create table  sc(
scid  bigint primary key identity(1,1),
stuxuehao bigint,
claid bigint,
grades bigint,
term varchar(30) not null
)

GO
if OBJECT_ID('Teacher','U')is not null
	drop table Teacher
GO
create table Teacher(
teachbm  bigint primary key identity(2021,1),--教师号（默认为登录账号）
tname nvarchar(10),
teachpasswd bigint not null,
telephone varchar(30),
addr varchar(60),
teachsort varchar(10),
tsex varchar(2) ,
role	varchar(30) default '教师',
)
go

insert into Users values('001','管理员','admin',0)


GO
--创建存储过程
--UserLogin
--1 用户名和口令均正确，返回1
--2 用户名正确口令不正确，返回2
--3 用户名不正确，返回3

IF OBJECT_ID('UserLogin','p') is not null
	DROP PROCEDURE UserLogin
GO

create procedure [dbo].[userLogin]
	@userID nchar(6),
	@password nchar(6)
as
if exists(select * from Users where username=@userID and userpassword =@password)
	return 1;
if exists(select * from Users where username=@userID and userpassword  <>@password)
	return 2;
if exists(select * from Users where username<>@userID  )
	return 3;
GO





IF OBJECT_ID('stuLogin','p') is not null--学生登录
	DROP PROCEDURE stuLogin
GO

create procedure [dbo].[stuLogin]
	@stuID nchar(30),
	@password nchar(30)
as
if exists(select * from student where stuxuehao=@stuID and stupasswd =@password)
	return 1;
if exists(select * from student where stuxuehao=@stuID and stupasswd  <>@password)
	return 2;
if exists(select * from student where stuxuehao<>@stuID  )
	return 3;
GO


IF OBJECT_ID('teachLogin','p') is not null--教师登录
	DROP PROCEDURE teachLogin
GO

create procedure [dbo].[teachLogin]
	@teachID nchar(30),
	@password nchar(30)
as
if exists(select * from Teacher where teachbm=@teachID and teachpasswd =@password)
	return 1;
if exists(select * from Teacher where teachbm=@teachID and teachpasswd  <>@password)
	return 2;
if exists(select * from Teacher where teachbm<>@teachID  )
	return 3;
GO



select * from mycourse5
--创建视图 我的课表
CREATE VIEW mycourse5 AS
SELECT class.claid,class.claname,class.teachername,location,sctime.term,sc.stuxuehao,sctime.sctime
FROM class,sctime,sc
where sc.claid=class.claid and class.claid=sctime.claid
go
--创建试图 所有老师开设的课程
CREATE VIEW allcourse AS
SELECT class.claid,class.claname,sctime,location,sctime.term,class.teachername
FROM class,sctime
where class.claid=sctime.claid 
go
---视图存在则删除
/*IF (EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME=N'deletteacher'))
DROP VIEW deletteacher
go*/
--创建视图  查看我的学生
CREATE VIEW ownstu2 AS
SELECT student.stuxuehao,student.stuname,student.stugrade,student.stubanji,student.stusex,class.claname,class.teacherid,sc.grades,class.term,class.claid
FROM class,sc,student
where class.claid=sc.claid and sc.stuxuehao=student.stuxuehao
go


--创建视图 查看老师课表
CREATE VIEW teachclass1 AS
SELECT class.claid,class.claname,class.teacherid,Teacher.tname,class.term,Teacher.teachsort,Teacher.tsex
FROM class,Teacher
where class.teacherid=Teacher.teachbm
go
select * from teachclass1
go
--创建视图 查看选课成绩
CREATE VIEW mygrades AS
SELECT class.claname,class.teachername,class.term,sc.stuxuehao,sc.grades
FROM class,sc
where class.claid=sc.claid
go
select * from mygrades


go
--创建视图 教师查看自己课表
CREATE VIEW mywork1 AS
SELECT class.claname,sctime.location,sctime.sctime,class.term,sctime.teacherid
FROM class,sctime
where class.claid=sctime.claid
go
select * from mywork1
go
--创建触发器--删除sctime里的课之后删除sc和class对应的课程
CREATE TRIGGER d
ON sctime
after delete
as 
begin
declare @id int
select @id=claid from deleted
delete from sc where claid=(@id)
delete from class where claid=(@id)
end
go
--创建触发器--删除teacher里的教师之后删除对应的课程
CREATE TRIGGER dt
ON Teacher
after delete
as 
begin
declare @id int
select @id=teachbm from deleted
delete from class where teacherid=(@id)
delete from sctime where teacherid=(@id)
end
go



select * from Teacher
select * from class

select * from sctime
select * from sc
select * from student
delete from teacher where teachbm=23

select claname as 课程名,teachername as 任课老师,term as 学期 from mygrades