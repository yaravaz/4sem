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
		print 'количество строк в таблице X: ' + cast( @c as varchar(2));
		if @flag = 'c'  commit; 
	    else   rollback; 
      SET IMPLICIT_TRANSACTIONS  OFF
	
	if  exists (select * from  SYS.OBJECTS    
	            where OBJECT_ID= object_id(N'DBO.X') )
	print 'таблица X есть';  
      else print 'таблицы X нет'

-------------------------

use UNIVER;

select * from AUDITORIUM_TYPE;
select * from AUDITORIUM;

begin try
	begin tran;
		delete from AUDITORIUM_TYPE where AUDITORIUM_TYPE='ЛК';
		insert AUDITORIUM_TYPE values('ЛК', 'Лекционная');
		insert AUDITORIUM_TYPE values('NEW2', 'NEWNEWNEW2');
	commit tran;
end try
begin catch
	print 'ошибка '+ case
						when error_number() = 2627 and patindex('%AUDITORIUM_TYPE_PK%', error_message())>0
						then ' дублирование товара '
						else ' неизвестная ошибка '+ cast (error_number() as varchar(5))+ error_message()
					end;
	if @@TRANCOUNT > 0 rollback tran;
end catch


delete from AUDITORIUM_TYPE where AUDITORIUM_TYPE = 'NEW2'

--------------------------------------

declare @point varchar(32);
begin try
	begin tran;
	--delete from AUDITORIUM_TYPE where AUDITORIUM_TYPE='ЛК';
	set @point = 'p1'; save tran @point;
	insert AUDITORIUM_TYPE values('ЛК', 'Лекционная');
	set @point = 'p2'; save tran @point;
	insert AUDITORIUM_TYPE values('NEW2', 'NEWNEWNEW2');
	commit tran;
end try
begin catch
	print 'ошибка '+ case
						when error_number() = 2627 and patindex('%AUDITORIUM_TYPE_PK%', error_message())>0
						then ' дублирование товара '
						else ' неизвестная ошибка '+ cast (error_number() as varchar(5))+ error_message()
					end;
	if @@TRANCOUNT > 0 
		begin
			print 'контрольная точка ' + @point ;
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
	select @@SPID, 'insert AUDITORIUM' 'результат', * from AUDITORIUM_TYPE 
	                                                                where AUDITORIUM_TYPE = 'NEW';
	select @@SPID, 'update AUDITORIUM'  'результат',  AUDITORIUM_CAPACITY, 
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
	select  'update AUDITORIUM'  'результат', count(*)
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
end 'результат', AUDITORIUM_NAME from AUDITORIUM  where AUDITORIUM_CAPACITY = 60;
	commit; 

--- B ---	
	begin transaction 	  
	-------------------------- t1 --------------------
          insert AUDITORIUM values ('207-1', 'ЛК-К', 60,  '207-1');

          commit; 
	-------------------------- t2 --------------------



---------------------------------------------------------------------

select * from AUDITORIUM;

    -- A ---
    set transaction isolation level SERIALIZABLE 
	begin transaction 
	--delete AUDITORIUM where AUDITORIUM_NAME = '207-1';  
    insert AUDITORIUM values ('207-1', 'ЛК-К', 60,  '207-1');
    --update AUDITORIUM set AUDITORIUM_NAME = '333' where AUDITORIUM_CAPACITY = 60;
    select AUDITORIUM_NAME from AUDITORIUM  where AUDITORIUM_CAPACITY = 60;
	-------------------------- t1 -----------------
	select  AUDITORIUM_NAME from AUDITORIUM  where AUDITORIUM_CAPACITY = 60;
	-------------------------- t2 ------------------ 
	commit; 	

	--- B ---	
	begin transaction 	  
	--delete AUDITORIUM where AUDITORIUM_NAME = '207-1';  
    insert AUDITORIUM values ('207-1', 'ЛК-К', 60,  '207-1');
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

select * from Товары;

begin try
	begin tran;
		--delete from Товары where Наименование_товара='Стол';
		--insert Товары values('Стол', 345, 'Описание стула');
		insert Товары values('NEW2', 456, 'NEWNEWNEW2');
	commit tran;
end try
begin catch
	print 'ошибка '+ case
						when error_number() = 2627 and patindex('%PK__ТОВАРЫ%', error_message())>0
						then ' дублирование товара '
						else ' неизвестная ошибка '+ cast (error_number() as varchar(5))+ error_message()
					end;
	if @@TRANCOUNT > 0 rollback tran;
end catch


delete from ТОВАРЫ where Наименование_товара = 'NEW2'

---------------------------------------------

select * from Товары;

declare @point2 varchar(32);
begin try
	begin tran;
		--delete from Товары where Наименование_товара='Стол';
		set @point2 = 'p1'; save tran @point2;
		--insert Товары values('Стол', 345, 'Описание стула');
		set @point2 = 'p2'; save tran @point2;
		insert Товары values('NEW2', 456, 'NEWNEWNEW2');
	commit tran;
end try
begin catch
	print 'ошибка '+ case
						when error_number() = 2627 and patindex('%PK__ТОВАРЫ%', error_message())>0
						then ' дублирование товара '
						else ' неизвестная ошибка '+ cast (error_number() as varchar(5))+ error_message()
					end;
	if @@TRANCOUNT > 0 
		begin
			print 'контрольная точка ' + @point2 ;
			rollback tran @point2;
			--commit tran;
		end;
end catch


delete from ТОВАРЫ where Наименование_товара = 'NEW2'

---------------------------------------------

-- A ---
	set transaction isolation level READ UNCOMMITTED 
	begin transaction 
	-------------------------- t1 ------------------
	select @@SPID, 'insert Товары' 'результат', * from Товары 
	                                                    where Наименование_товара = 'Блокнот';
	select @@SPID, 'update Заказы'  'результат',  Товар, 
                      Количество from Заказы   where Товар = 'Блокнот';
	commit; 
	-------------------------- t2 -----------------
	--- B --	
	begin transaction 
	select @@SPID
	insert Товары values ('Блокнот', 2, 80); 
	update Заказы set Товар  =  'Блокнот' 
                           where Товар = 'Стол' 
	-------------------------- t1 --------------------
	-------------------------- t2 --------------------
	rollback;


	delete ТОВАРЫ where Наименование_товара ='NEW'
	update ЗАКАЗЫ set Товар  =  'Стол' 
                           where Товар  =  'Блокнот'

-----------------------------------------------------

-- A ---
    set transaction isolation level READ COMMITTED 
	begin transaction 
	select count(*) from Заказы 	where Товар = 'Стул';
	-------------------------- t1 ------------------ 
	-------------------------- t2 -----------------
	select  'update Заказы'  'результат', count(*)
	                           from Заказы  where Товар = 'Стул';
	commit; 

	--- B ---	
	begin transaction 	  
	-------------------------- t1 --------------------
          update Заказы set Товар = 'Стул' 
                                       where Товар = 'Стол' 
          commit; 
	-------------------------- t2 --------------------	

	update ЗАКАЗЫ set Товар = 'Стол' 
			where Товар = 'Стул' ;

-------------------------------------------------------

select * from ЗАКАЗЫ;

-- A ---
    set transaction isolation level  REPEATABLE READ 
	begin transaction 
	select Заказчик from Заказы where Товар = 'Стул';
	-------------------------- t1 ------------------ 
	-------------------------- t2 -----------------
	select  case
          when Заказчик = 'Эвергрин Мебель' then 'insert  Заказы'  else ' ' 
		end 'результат', Заказчик from Заказы  where Товар = 'Стул';
	commit; 

	--- B ---	
	begin transaction 	  
	-------------------------- t1 --------------------
          insert Заказы values (12,  'Стул',  78, '01.12.2014', 'Ул. Какая-то', 'самовывоз', 'Эвергрин Мебель');
          commit; 
	-------------------------- t2 --------------------

---------------------------------------------------------

	-- A ---
          set transaction isolation level SERIALIZABLE 
	begin transaction 
		delete Заказы where Заказчик = 'Эвергрин Мебель';  
        insert Заказы values (13,  'Стул',  78, '01.12.2014', 'Ул. Какая-то', 'самовывоз', 'Эвергрин Мебель');
        update Заказы set Заказчик = 'Эвергрин Мебель' where Товар = 'Стул';
        select  Заказчик from Заказы  where Товар = 'Стул';
	-------------------------- t1 -----------------
	select  Заказчик from Заказы  where Товар = 'Стул';
	-------------------------- t2 ------------------ 
	commit; 	

	--- B ---	
	begin transaction 	  
	delete Заказы where Заказчик = 'Эвергрин Мебель';  
          delete Заказы where Заказчик = 'Эвергрин Мебель';  
        insert Заказы values (13,  'Стул',  78, '01.12.2014', 'Ул. Какая-то', 'самовывоз', 'Эвергрин Мебель');
        update Заказы set Заказчик = 'Эвергрин Мебель' where Товар = 'Стул';
          -------------------------- t1 --------------------
          commit; 
          select  Заказчик from Заказы  where Товар = 'Стул';
      -------------------------- t2 --------------------

----------------------------

begin tran 
 insert ЗАКАЗЧИКИ values('Луч', '375291823746', 'difhb@main.ru');
 begin tran 
	update ЗАКАЗЫ set Количество=666 where Заказчик = 'Эвергрин Мебель';
	commit;
	if @@trancount > 0 rollback;
select 
	(select count(*) from ЗАКАЗЫ where Товар = 'Стуууууул') 'Название',
	(select count(*) from ЗАКАЗЧИКИ where Наименование_фирмы ='Луч') 'Название_фирмы';

select * from ЗАКАЗЧИКИ;
select * from ЗАКАЗЫ;