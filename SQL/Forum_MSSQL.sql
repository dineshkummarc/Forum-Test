-- Copyright (C) 2001 YesSoftware. All rights reserved.
-- Forum_MSSQL.sql

if exists (select * from sysobjects where id = object_id(N'messages') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table messages
GO
if exists (select * from sysobjects where id = object_id(N'smileys') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table smileys
GO

create table messages (
	message_id integer IDENTITY primary key,
	message_parent_id integer null,
	smiley_id integer NULL,
	topic varchar(50) NULL,
	author varchar(50) NULL,
	date_entered datetime NULL,
	last_modified datetime NULL,
	message text NULL
)
GO


INSERT INTO messages (message_parent_id,smiley_id,topic,author,date_entered,last_modified,message)
	values(null,1,"error message!!! in DB MSG","seopo","1/4/2001 11:28:41 AM","10/4/2001 7:03:35 PM","I have a problem in DB MSG at brinkster 

It is in a SQL statement... 

''select * from tablename''--> It is well operated... 

But ''delete from tablename'' or ''update set No =1 where No=3...etc''----> It is not well operated.... 
There appears error message 
It is..... 
"" 
Query Results 


ADODB.Recordset error ''800a0e78'' 
Operation is not allowed when the object is closed. 

/DatabaseManager.asp, line 473 "" 

I want to find a way... 
please! give me an answer....")
GO

INSERT INTO messages (message_parent_id,smiley_id,topic,author,date_entered,last_modified,message)
	values(1,2,"RE: error message!!! in DB MSG","nhsa","1/4/2001 3:00:42 PM","1/4/2001 3:00:42 PM","DELETE * FROM tablename WHERE stringfield=''stringvalue'' 

UPDATE tablename SET stringfield=''hello'' WHERE numberfield=10 

HTH 
Nige - nhsa@yahoo.com")
GO

INSERT INTO messages (message_parent_id,smiley_id,topic,author,date_entered,last_modified,message)
	values(1,3,"RE: error message!!! in DB MSG","hiflyer","1/4/2001 3:00:42 PM","1/4/2001 3:00:42 PM","Nige is right with his SQL string examples, but the error you are getting is because you are trying to perform operations on a recordset which has been closed. If you look at your code you will probably find a line such as dbConn.close, or RS.close or Set RS = nothing somewhere before line 473. 

HTH, 
Bod. 
www5.brinkster.com/hiflyer");

insert into messages (message_parent_id,smiley_id,topic,author,date_entered,last_modified,message)
	values(null,0,"writing db results to multiple pages","shiaislamasp","1/4/2001 7:56:52 PM","1/4/2001 7:56:52 PM","how do i write say 10 db results, from a select statement, on a page, then link to another page, with the next 10, and so on.. 

I would be very grateful for any help 

Thank you")
GO

INSERT INTO messages (message_parent_id,smiley_id,topic,author,date_entered,last_modified,message)
	values(4,0,"RE: writing db results to multiple pages","adom","1/5/2001 3:33:07 AM","1/5/2001 3:33:07 AM","Asuming your database is sorted by a incrementing value you can use the BETWEEN statement in your querry. 

That is on the first page you do: 

SELECT * from Table WHERE OrderValue BETWEEN 1 and 10 

Then you pass along the last value to the next page ""show_rewults?start=11"" for example and go from there 

SELECT * from Table WHERE OrderValue BETWEEN 11 and 20 

and so one")
GO

INSERT INTO messages (message_parent_id,smiley_id,topic,author,date_entered,last_modified,message)
	values(null,0,"what is this error... It works on my iis","feiyeung","1/4/2001 5:02:30 AM","10/4/2001 6:21:19 PM","keyword =url =comment = there is an error 
Microsoft JET Database Engine error ''80040e09'' 

Cannot update. Database or object is read-only. 

/input.asp, line 39 

it wokrs on my iis5.0 fine. It is because the db dir isn''t set rite or what? 
anyone has any ideaS 
FELIX")
GO

INSERT INTO messages (message_parent_id,smiley_id,topic,author,date_entered,last_modified,message)
	values(null,0,"dynamic queries","vpl","1/3/2001 3:21:26 AM","1/3/2001 3:21:26 AM","i want to rerieve the value from the database based upon the selection criteria that is out of ten text fields if the user select two values means,i should get the output based upon that value.the query should be a single query.")
GO

INSERT INTO messages (message_parent_id,smiley_id,topic,author,date_entered,last_modified,message)
	values(7,0,"RE: dynamic queries","product","1/3/2001 6:49:58 AM","1/3/2001 6:49:58 AM","The Best Way is to write SQl Statement .

For Example 
Select Empno,Ename from emp where empno = ''1001'' or Sal >100 

if you can provide a code, will try to provide a solution.")
GO

INSERT INTO messages (message_parent_id,smiley_id,topic,author,date_entered,last_modified,message)
	values(null,0,"CF Custom Tag directory???","Michael","1/19/2001 5:18:28 PM","10/4/2001 10:00:13 PM","Hi, 

how do i change the default directory of the CUSTOM TAG where CF_ tags are places to a directory of my choice???? 

thankxs")
GO

INSERT INTO messages (message_parent_id,smiley_id,topic,author,date_entered,last_modified,message)
	values(9,0,"CF Custom Tag directory???","vpl","1/19/2001 5:18:28 PM","1/19/2001 5:18:28 PM","You can edit the registry key HKEY_LOCAL_MACHINE\SOFTWARE\Allaire\ColdFusion\CurrentVersion\CustomTags\CFMLTagSearchPath 
And then restart the server. 

/Ruben")
GO

INSERT INTO messages (message_parent_id,smiley_id,topic,author,date_entered,last_modified,message)
	values(null,0,"Pictures embeded in Email","Rocky Ang","1/19/2001 5:37:24 PM","1/19/2001 5:37:24 PM","I am trying to use the cfmail command to send HTML based emails. This can be easily done by referencing the pictures within the mail to download from an url. 

However, this caused a problem when the recipient tries to read the mail offline. The pictures disappeared. 

A way to solve this would be to embed the pictures and send the pictures with the mail. Is there any way to do this with cold fusion. 

Any prompt help would be deeply appreciated by a desperate guy.")
GO

INSERT INTO messages (message_parent_id,smiley_id,topic,author,date_entered,last_modified,message)
	values(11,0,"relative","Glenn Channon","1/19/2001 5:38:15 PM","1/19/2001 5:38:15 PM","Try relative URL''s http://www.domainname.com/images/imagename.gif")
GO

INSERT INTO messages (message_parent_id,smiley_id,topic,author,date_entered,last_modified,message)
	values(null,1,"This forum is soooooooooooo cooooooooooooooool !","CoolBoy","10/4/2001 9:23:07 PM","10/4/2001 9:24:08 PM","What a coooooooooooool forum!

CB")
GO

INSERT INTO messages (message_parent_id,smiley_id,topic,author,date_entered,last_modified,message)
	values(13,9,"Oh Yeah","CoolGirl","10/4/2001 9:23:47 PM",null,"CoolForum it is...

CG")
GO


CREATE TABLE smileys (
	smiley_id	integer IDENTITY primary key,
	smiley_name	varchar(50) NULL,
	smiley_url	varchar(50) NULL
)
GO

insert into smileys (smiley_name,smiley_url) 
values ('cool','images/icons/cool.gif')
GO

insert into smileys (smiley_name,smiley_url) 
values ('mad','images/icons/mad.gif')
GO

insert into smileys (smiley_name,smiley_url) 
values ('sad','images/icons/sad.gif')
GO

insert into smileys (smiley_name,smiley_url) 
values ('big grin','images/icons/biggrin.gif')
GO

insert into smileys (smiley_name,smiley_url) 
values ('colgate','images/icons/colgate.gif')
GO

insert into smileys (smiley_name,smiley_url) 
values ('confused','images/icons/confused.gif')
GO

insert into smileys (smiley_name,smiley_url) 
values ('sigh','images/icons/sigh.gif')
GO

insert into smileys (smiley_name,smiley_url) 
values ('smile','images/icons/smile.gif')
GO

insert into smileys (smiley_name,smiley_url) 
values ('tongue','images/icons/tounge.gif')
GO

insert into smileys (smiley_name,smiley_url) 
values ('wink','images/icons/wink.gif')
GO

insert into smileys (smiley_name,smiley_url) 
values ('wow!','images/icons/wow.gif')
GO

