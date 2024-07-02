use UNIVER;

set nocount on
	if  exists (select * from  SYS.OBJECTS
	            where OBJECT_ID= object_id(N'DBO.X') )	            
	drop table X;           
	declare @c int, @flag char = 'c';
	SET IMPLICIT_TRANSACTIONS  ON
	CREATE table X(K int ); 
		INSERT X values (1),(2),(3);
		set @c = (select count(*) from X);
		print '���������� ����� � ������� X: ' + cast( @c as varchar(2));
		if @flag = 'c'  commit; 
	    else   rollback; 
      SET IMPLICIT_TRANSACTIONS  OFF
	
	if  exists (select * from  SYS.OBJECTS    
	            where OBJECT_ID= object_id(N'DBO.X') )
	print '������� X ����';  
      else print '������� X ���'

-------------------------

use UNIVER;

select * from AUDITORIUM_TYPE;
select * from AUDITORIUM;

begin try
	begin tran;
		delete from AUDITORIUM_TYPE where AUDITORIUM_TYPE='��';
		insert AUDITORIUM_TYPE values('��', '����������');
		insert AUDITORIUM_TYPE values('NEW2', 'NEWNEWNEW2');
	commit tran;
end try
begin catch
	print '������ '+ case
						when error_number() = 2627 and patindex('%AUDITORIUM_TYPE_PK%', error_message())>0
						then ' ������������ ������ '
						else ' ����������� ������ '+ cast (error_number() as varchar(5))+ error_message()
					end;
	if @@TRANCOUNT > 0 rollback tran;
end catch


delete from AUDITORIUM_TYPE where AUDITORIUM_TYPE = 'NEW2'

--------------------------------------

declare @point varchar(32);
begin try
	begin tran;
	--delete from AUDITORIUM_TYPE where AUDITORIUM_TYPE='��';
	set @point = 'p1'; save tran @point;
	insert AUDITORIUM_TYPE values('��', '����������');
	set @point = 'p2'; save tran @point;
	insert AUDITORIUM_TYPE values('NEW2', 'NEWNEWNEW2');
	commit tran;
end try
begin catch
	print '������ '+ case
						when error_number() = 2627 and patindex('%AUDITORIUM_TYPE_PK%', error_message())>0
						then ' ������������ ������ '
						else ' ����������� ������ '+ cast (error_number() as varchar(5))+ error_message()
					end;
	if @@TRANCOUNT > 0 
		begin
			print '����������� ����� ' + @point ;
			rollback tran @point;
			--commit tran;
		end;
end catch;


delete from AUDITORIUM_TYPE where AUDITORIUM_TYPE = 'NEW2'

---------------------------------------------

select * from AUDITORIUM_TYPE;
select * from AUDITORIUM;

-- A ---
	set transaction isolation level READ UNCOMMITTED 
	begin transaction 
	-------------------------- t1 ------------------
	select @@SPID, 'insert AUDITORIUM' '���������', * from AUDITORIUM_TYPE 
	                                                                where AUDITORIUM_TYPE = 'NEW';
	select @@SPID, 'update AUDITORIUM'  '���������',  AUDITORIUM_CAPACITY, 
                      AUDITORIUM_TYPE from AUDITORIUM   where AUDITORIUM_CAPACITY = 50;
	commit; 
	-------------------------- t2 -----------------
--- B --	
	begin transaction 
	select @@SPID
	insert AUDITORIUM_TYPE values ('NEW', 'NEWNEWNEW'); 
	update AUDITORIUM set AUDITORIUM_CAPACITY  =  28 
                           where AUDITORIUM_CAPACITY = 50
	-------------------------- t1 --------------------
	-------------------------- t2 --------------------
	rollback;


	delete AUDITORIUM_TYPE where AUDITORIUM_TYPE='NEW'
	update AUDITORIUM set AUDITORIUM_CAPACITY  =  50 
                           where AUDITORIUM_CAPACITY = 28

------------------------------------------------------------

-- A ---
    set transaction isolation level READ COMMITTED 
	begin transaction 
	select count(*) from AUDITORIUM 
	where AUDITORIUM_CAPACITY = 60;
	-------------------------- t1 ------------------ 
	-------------------------- t2 -----------------
	select  'update AUDITORIUM'  '���������', count(*)
	                           from AUDITORIUM  where AUDITORIUM_CAPACITY = 60;
	commit; 

--- B ---	
	begin transaction 	  
	-------------------------- t1 --------------------
          update AUDITORIUM set AUDITORIUM_CAPACITY = 60 
                                       where AUDITORIUM_CAPACITY = 50
          commit; 
	-------------------------- t2 --------------------	

	update AUDITORIUM set AUDITORIUM_CAPACITY = 50 
	where AUDITORIUM_CAPACITY = 60;

----------------------------------------------------------------

select * from AUDITORIUM;

-- A ---
set transaction isolation level  REPEATABLE READ 
	begin transaction 
	select AUDITORIUM_NAME from AUDITORIUM where AUDITORIUM_CAPACITY = 60;
	-------------------------- t1 ------------------ 
	-------------------------- t2 -----------------
	select  case
          when AUDITORIUM_NAME = '207-1' then 'insert  AUDITORIUM'  else ' ' 
end '���������', AUDITORIUM_NAME from AUDITORIUM  where AUDITORIUM_CAPACITY = 60;
	commit; 

--- B ---	
	begin transaction 	  
	-------------------------- t1 --------------------
          insert AUDITORIUM values ('207-1', '��-�', 60,  '207-1');

          commit; 
	-------------------------- t2 --------------------



---------------------------------------------------------------------

select * from AUDITORIUM;

    -- A ---
    set transaction isolation level SERIALIZABLE 
	begin transaction 
	--delete AUDITORIUM where AUDITORIUM_NAME = '207-1';  
    insert AUDITORIUM values ('207-1', '��-�', 60,  '207-1');
    --update AUDITORIUM set AUDITORIUM_NAME = '333' where AUDITORIUM_CAPACITY = 60;
    select AUDITORIUM_NAME from AUDITORIUM  where AUDITORIUM_CAPACITY = 60;
	-------------------------- t1 -----------------
	select  AUDITORIUM_NAME from AUDITORIUM  where AUDITORIUM_CAPACITY = 60;
	-------------------------- t2 ------------------ 
	commit; 	

	--- B ---	
	begin transaction 	  
	--delete AUDITORIUM where AUDITORIUM_NAME = '207-1';  
    insert AUDITORIUM values ('207-1', '��-�', 60,  '207-1');
    --update AUDITORIUM set AUDITORIUM_NAME = '333' where AUDITORIUM_CAPACITY = 60;
    select AUDITORIUM_NAME from AUDITORIUM  where AUDITORIUM_CAPACITY = 60;
    -------------------------- t1 --------------------
    commit; 
    select  AUDITORIUM_NAME from AUDITORIUM  where  AUDITORIUM_CAPACITY = 60;
    -------------------------- t2 --------------------
	delete AUDITORIUM where AUDITORIUM_NAME = '333';

	

--------------------------------------------

select * from AUDITORIUM;
select * from AUDITORIUM_TYPE;

begin tran
 insert AUDITORIUM_TYPE values ('NEW', 'NEWNEWNEW');
 begin tran
	update AUDITORIUM set AUDITORIUM_CAPACITY = 77 where AUDITORIUM_NAME = '207-1';
	commit;
	if @@TRANCOUNT > 0 rollback;
select 
	(select count(*) from AUDITORIUM where AUDITORIUM_NAME = '207-1') 'AUDITORIUM',
	(select count(*) from AUDITORIUM_TYPE where AUDITORIUM_TYPE='NEW') 'AUDITORIUM_TYPE';



------------------------------------------------

use V_MyBASE;

select * from ������;

begin try
	begin tran;
		--delete from ������ where ������������_������='����';
		--insert ������ values('����', 345, '�������� �����');
		insert ������ values('NEW2', 456, 'NEWNEWNEW2');
	commit tran;
end try
begin catch
	print '������ '+ case
						when error_number() = 2627 and patindex('%PK__������%', error_message())>0
						then ' ������������ ������ '
						else ' ����������� ������ '+ cast (error_number() as varchar(5))+ error_message()
					end;
	if @@TRANCOUNT > 0 rollback tran;
end catch


delete from ������ where ������������_������ = 'NEW2'

---------------------------------------------

select * from ������;

declare @point2 varchar(32);
begin try
	begin tran;
		--delete from ������ where ������������_������='����';
		set @point2 = 'p1'; save tran @point2;
		--insert ������ values('����', 345, '�������� �����');
		set @point2 = 'p2'; save tran @point2;
		insert ������ values('NEW2', 456, 'NEWNEWNEW2');
	commit tran;
end try
begin catch
	print '������ '+ case
						when error_number() = 2627 and patindex('%PK__������%', error_message())>0
						then ' ������������ ������ '
						else ' ����������� ������ '+ cast (error_number() as varchar(5))+ error_message()
					end;
	if @@TRANCOUNT > 0 
		begin
			print '����������� ����� ' + @point2 ;
			rollback tran @point2;
			--commit tran;
		end;
end catch


delete from ������ where ������������_������ = 'NEW2'

---------------------------------------------

-- A ---
	set transaction isolation level READ UNCOMMITTED 
	begin transaction 
	-------------------------- t1 ------------------
	select @@SPID, 'insert ������' '���������', * from ������ 
	                                                    where ������������_������ = '�������';
	select @@SPID, 'update ������'  '���������',  �����, 
                      ���������� from ������   where ����� = '�������';
	commit; 
	-------------------------- t2 -----------------
	--- B --	
	begin transaction 
	select @@SPID
	insert ������ values ('�������', 2, 80); 
	update ������ set �����  =  '�������' 
                           where ����� = '����' 
	-------------------------- t1 --------------------
	-------------------------- t2 --------------------
	rollback;


	delete ������ where ������������_������ ='NEW'
	update ������ set �����  =  '����' 
                           where �����  =  '�������'

-----------------------------------------------------

-- A ---
    set transaction isolation level READ COMMITTED 
	begin transaction 
	select count(*) from ������ 	where ����� = '����';
	-------------------------- t1 ------------------ 
	-------------------------- t2 -----------------
	select  'update ������'  '���������', count(*)
	                           from ������  where ����� = '����';
	commit; 

	--- B ---	
	begin transaction 	  
	-------------------------- t1 --------------------
          update ������ set ����� = '����' 
                                       where ����� = '����' 
          commit; 
	-------------------------- t2 --------------------	

	update ������ set ����� = '����' 
			where ����� = '����' ;

-------------------------------------------------------

select * from ������;

-- A ---
    set transaction isolation level  REPEATABLE READ 
	begin transaction 
	select �������� from ������ where ����� = '����';
	-------------------------- t1 ------------------ 
	-------------------------- t2 -----------------
	select  case
          when �������� = '�������� ������' then 'insert  ������'  else ' ' 
		end '���������', �������� from ������  where ����� = '����';
	commit; 

	--- B ---	
	begin transaction 	  
	-------------------------- t1 --------------------
          insert ������ values (12,  '����',  78, '01.12.2014', '��. �����-��', '���������', '�������� ������');
          commit; 
	-------------------------- t2 --------------------

---------------------------------------------------------

	-- A ---
          set transaction isolation level SERIALIZABLE 
	begin transaction 
		delete ������ where �������� = '�������� ������';  
        insert ������ values (13,  '����',  78, '01.12.2014', '��. �����-��', '���������', '�������� ������');
        update ������ set �������� = '�������� ������' where ����� = '����';
        select  �������� from ������  where ����� = '����';
	-------------------------- t1 -----------------
	select  �������� from ������  where ����� = '����';
	-------------------------- t2 ------------------ 
	commit; 	

	--- B ---	
	begin transaction 	  
	delete ������ where �������� = '�������� ������';  
          delete ������ where �������� = '�������� ������';  
        insert ������ values (13,  '����',  78, '01.12.2014', '��. �����-��', '���������', '�������� ������');
        update ������ set �������� = '�������� ������' where ����� = '����';
          -------------------------- t1 --------------------
          commit; 
          select  �������� from ������  where ����� = '����';
      -------------------------- t2 --------------------

----------------------------

begin tran 
 insert ��������� values('���', '375291823746', 'difhb@main.ru');
 begin tran 
	update ������ set ����������=666 where �������� = '�������� ������';
	commit;
	if @@trancount > 0 rollback;
select 
	(select count(*) from ������ where ����� = '���������') '��������',
	(select count(*) from ��������� where ������������_����� ='���') '��������_�����';

select * from ���������;
select * from ������;