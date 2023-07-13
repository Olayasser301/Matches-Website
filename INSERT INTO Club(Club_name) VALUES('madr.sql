INSERT INTO Club(Club_name) VALUES('spain')
INSERT INTO System_userr(username,Passwords)VALUES('lili','lilies')
INSERT INTO Club_Representitave(CR_name, username)VALUES('Lili','lili',6)
SELECT* FROM Club
SELECT * FROM Club_Representitave
SELECT Club_name , Club.id, Locations FROM Club , Club_Representitave WHERE Club.id= Club_Representitave.Club_id
UPDATE Club 
SET Locations = 'balabezo' WHERE Club.id IN (SELECT Club_id FROM Club_Representitave WHERE Club.id =Club_Representitave.Club_id)

SELECT CR_name, Club_Representitave.id , username, Club_name FROM Club_Representitave INNER JOIN Club ON Club_Representitave.Club_id = Club.id 
INSERT INTO System_userr(username,Passwords)VALUES('yehya1','lilies')
INSERT INTO Fan(Fan_name, nationalId,username,birth_date,Statuss,Phone_num,Addresss)VALUES('yehya',19293,'yehya1','8/10/2022',1,0120094432,'haay 4')
SELECT * FROM Fan
SELECT m.Host_club_id , m.Guest_club_id 
FROM Club C1 inner join Match m on m.Host_club_id= C1.id 
inner JOIN Club C2 on m.Guest_club_id =C2.id
WHERE C2.Club_name = 'bobo' AND C1.Club_name= 'hehe'
INSERT INTO Match( start_time , end_time) VALUES( '3/4/2012' , '4/4/2012')
INSERT INTO Club(Club_name, Locations) VALUES('football','england')
INSERT INTO Club(Club_name, Locations) VALUES('ball','germany')
INSERT INTO Club(Club_name , Locations) VALUES('bobo','tanzania')
INSERT INTO Club(Club_name, Locations) VALUES('hehe','lebanon')

SELECT * FROM Club
SELECT * FROM [Match]
SELECT C1.Club_name , C2.Club_name , m.start_time, m.end_time
FROM Club C1 inner join Match m on m.Host_club_id= C1.id 
inner JOIN Club C2 on m.Guest_club_id =C2.id

INSERT INTO Staduim(staduim_name)VALUES('okay')
INSERT INTO Staduim_manager(SM_name, Staduim_id)VALUES('hoda', 1)
SELECT * FROM Staduim
SELECT * FROM Staduim_manager
INSERT INTO System_userr(username,Passwords)VALUES('lilo','1234')
UPDATE Staduim_manager 
SET username = 'lilo'
SELECT * FROM Fan
INSERT INTO Fan(Fan_name, nationalId,username,birth_date,Statuss,Phone_num,Addresss)VALUES('yehya',19293,'yehya1','8/10/2022',1,0120094432,'haay 4')
UPDATE Fan 
SET Statuss = 1
SELECT * FROM Sports_Assosciation_manager
EXEC addNewMatch bobo, ball, '2/1/2010','2/1/2013'
SELECT * FROM [Match]
SELECT* FROM allMatches