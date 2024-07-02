begin transaction 
	select @@SPID
	insert AUDITORIUM_TYPE values ('NEW', 'NEWNEWNEW'); 
	update AUDITORIUM set AUDITORIUM_CAPACITY  =  28 
                           where AUDITORIUM_CAPACITY = 50
				
rollback;

--------------

begin transaction 	 
update AUDITORIUM set AUDITORIUM_CAPACITY = 60 
                                       where AUDITORIUM_CAPACITY = 50
commit; 

----------------

begin transaction 	  
--insert AUDITORIUM values ('207-1', 'À - ', 60,  '207-1');
update AUDITORIUM set AUDITORIUM_CAPACITY = 50 where AUDITORIUM_NAME = '207-1';
commit; 

------------------

begin transaction 	  
	--delete AUDITORIUM where AUDITORIUM_NAME = '207-1';  
    insert AUDITORIUM values ('207-1', 'À - ', 60,  '207-1');
    --update AUDITORIUM set AUDITORIUM_NAME = '333' where AUDITORIUM_CAPACITY = 60;
    select AUDITORIUM_NAME from AUDITORIUM  where AUDITORIUM_CAPACITY = 60;
    -------------------------- t1 --------------------
    commit; 
    select  AUDITORIUM_NAME from AUDITORIUM  where  AUDITORIUM_CAPACITY = 60;

	delete AUDITORIUM where AUDITORIUM_NAME = '333';