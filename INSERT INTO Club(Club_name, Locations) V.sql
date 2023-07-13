INSERT INTO Club(Club_name, Locations) VALUES('Liverpool' , 'brazil')
SELECT * FROM Club
INSERT INTO Staduim(staduim_name, Locations, Capacity) VALUES('popo' , 'egy' , 1000)
SELECT * FROM Staduim
SELECT C1.Club_name FROM Club C1 INNER JOIN Match m ON C1.id = m.Host_club_id
INSERT INTO addNewMatch(Guestname , Hostname, start_time ,end_time)VALUES('olalezo' , 'honz' ,'6/6/2010','6/7/2010')
EXEC addNewMatch'olalezo', 'honz' ,'6/6/2010','6/7/2010'