use UNIVER;
go
Create procedure PSubject
as 
	begin
		declare @k int = (select count(*) from SUBJECT);
		select Subject[код], Subject_name[дисциплина], Pulpit[кафедра] from SUBJECT;
		return @k;
	end;

declare @k int = 0;
EXEC @k = PSubject;
print 'кол-во предметов' + cast(@k as varchar(3))

----------------------------------

Alter procedure PSubject @p varchar(20) = null, @c int output
as 
	begin
		declare @k int = (select count(*) from SUBJECT);
		print 'параметры: @p= '+ @p +', @c= '+cast(@c as varchar(3))
		select Subject[код], Subject_name[дисциплина], Pulpit[кафедра] from SUBJECT
		where PULPIT = @p;
		set @c = @@ROWCOUNT
		return @k;
	end;
drop procedure PSubject

declare @k int = 0, @r int = 0, @p varchar(20) = 'ИСиТ';
EXEC @k = PSubject @p, @r output;
print 'кол-во предметов ' + cast(@k as varchar(3));
print 'из каферды исит ' + cast(@r as varchar(3));

---------------------------------------------------

drop table #SUBJECT;
create table #SUBJECT(
	Код varchar(10) primary key,
	дисциплина varchar(50),
	кафедра varchar(10)
);

alter procedure PSUBJECT @p varchar(20)
as begin
	select * from SUBJECT where SUBJECT.PULPIT = @p;
end;

insert #SUBJECT exec PSUBJECT @p = 'ИСиТ'; 
SELECT * from #SUBJECT;

-----------------------------------------

drop procedure PAUDITORIUM_INSERT;
create procedure PAUDITORIUM_INSERT @a char(20), @n varchar(50),  @c int=0, @t char(10)
as 
begin try
	insert into AUDITORIUM(AUDITORIUM, AUDITORIUM_NAME, AUDITORIUM_CAPACITY, AUDITORIUM_TYPE)
		values (@a, @n, @c, @t)
	return 1;
end try
begin catch
	print 'номер ошибки: ' + cast(error_number() as varchar(6));	
	print 'сообщение: ' + error_message();
	print 'уровень: ' + cast(error_severity() as varchar(6));
	print 'метка: ' + cast(error_state() as varchar(8));
	print 'номер строки: ' + cast(error_line() as varchar(8));
	if error_procedure() is not null   
		print 'имя процедуры: ' + error_procedure();
	return -1;
end catch;

DECLARE @rc int; 
exec @rc=PAUDITORIUM_INSERT @a='207-7', @n='Лабораторная', @c=60, @t='ЛК';
print 'ответ: '+cast(@rc as varchar(3));
delete AUDITORIUM where AUDITORIUM='207-7';

select * from AUDITORIUM

--------------------------------------------------

drop procedure SUBJECT_REPORT
create procedure SUBJECT_REPORT @p char(10)
as 
declare @rc int = 0;
begin try
	if not exists (select SUBJECT from SUBJECT where PULPIT = @p)
	raiserror('ошибка', 11, 1);
	declare @slist char(300) = '', @subj char(10);
	declare SUBJECTS cursor for select SUBJECT from SUBJECT where PULPIT = @p;
	open SUBJECTS;
	fetch SUBJECTS into @subj;
	while (@@FETCH_STATUS = 0)
	begin
		set @slist = rtrim(@subj) + ', ' + @slist;
		set @rc += 1;
		fetch SUBJECTS into @subj;
	end;
	print 'Кафедра ' + rtrim(@p) + ':';
	print rtrim(@slist);
	close SUBJECTS;
	deallocate SUBJECTS;
	return @rc;
end try
begin catch
	print 'номер ошибки: ' + cast(error_number() as varchar(6));	
	print 'сообщение: ' + error_message();
	print 'уровень: ' + cast(error_severity() as varchar(6));
	print 'метка: ' + cast(error_state() as varchar(8));
	print 'номер строки: ' + cast(error_line() as varchar(8));
	if error_procedure() is not null   
		print 'имя процедуры: ' + error_procedure();
	return @rc;
end catch;
go

declare @rc int;
exec @rc = SUBJECT_REPORT 'ИСиТ';
print 'Количество: ' + cast(@rc as varchar);

---------------------------------------------------------

drop procedure PAUDITORIUM_INSERTX;
create procedure PAUDITORIUM_INSERTX 
@aud char(20), @name varchar(50), @capacity int = 0,
@type char(10), @typename varchar(70)
as begin try
	set transaction isolation level SERIALIZABLE
	begin tran
		insert into AUDITORIUM_TYPE (AUDITORIUM_TYPE, AUDITORIUM_TYPENAME) values (@type, @typename)
		exec PAUDITORIUM_INSERT @aud, @type, @capacity, @name
	commit tran
end try
begin catch
	print 'номер:  ' + cast(ERROR_NUMBER() as varchar)
	print 'уровень: ' + cast(ERROR_SEVERITY() as varchar)
	print 'сообщение:   ' + cast(ERROR_MESSAGE() as varchar)
	if @@TRANCOUNT > 0 
		rollback tran
	return -1
end catch

exec PAUDITORIUM_INSERTX @aud = '207-1', @name = '207', 
@capacity = 50, @type = '207', @typename = '207'
delete AUDITORIUM where AUDITORIUM_TYPE='207';
delete AUDITORIUM_TYPE where AUDITORIUM_TYPE='207'
select * from AUDITORIUM;

--------------------V_MyBase-----------------------------------

use V_MyBASE;
go
Create procedure PЗаказы
as 
	begin
		declare @k int = (select count(*) from Заказы);
		select ID_заказа[id], Товар[товар], Заказчик[заказчик] from ЗАКАЗЫ;
		return @k;
	end;

declare @k_n int = 0;
EXEC @k_n = PЗаказы;
print 'кол-во заказов' + cast(@k_n as varchar(3))

select * from заказы

---------------------------------------------------------------

Alter procedure PЗаказы @p varchar(20) = null, @c int output
as 
	begin
		declare @k int = (select count(*) from Заказы);
		print 'параметры: @p= '+ @p +', @c= '+cast(@c as varchar(3))
		select ID_заказа[id], Товар[товар], Заказчик[заказчик] from ЗАКАЗЫ
		where Заказчик = @p;
		set @c = @@ROWCOUNT
		return @k;
	end;
drop procedure PЗаказы

declare @k_n int = 0, @r_n int = 0, @p_n varchar(20) = 'Прима-Стайл Мебель';
EXEC @k_n = PЗаказы @p_n, @r_n output;
print 'кол-во товаров ' + cast(@k_n as varchar(3));
print 'заказанных Прима-Стайл Мебель ' + cast(@r_n as varchar(3));

---------------------------------------------------------

drop table #Zk;
create table #Zk(
	id varchar(10) primary key,
	товар varchar(20),
	заказчик varchar(20)
);

alter procedure PЗаказы @p varchar(20)
as begin
	select ID_заказа, Товар, Заказчик from заказы where заказы.заказчик = @p;
end;

insert #Zk exec PЗаказы @p = 'Прима-Стайл Мебель'; 
SELECT * from #Zk;

---------------------------------------------------------

drop procedure PТовары_INSERT;
create procedure PТовары_INSERT @a char(20), @c int=0, @t char(30)
as 
begin try
	insert into ТОВАРЫ(Наименование_товара, Цена, Описание)
		values (@a, @c, @t)
	return 1;
end try
begin catch
	print 'номер ошибки: ' + cast(error_number() as varchar(6));	
	print 'сообщение: ' + error_message();
	print 'уровень: ' + cast(error_severity() as varchar(6));
	print 'метка: ' + cast(error_state() as varchar(8));
	print 'номер строки: ' + cast(error_line() as varchar(8));
	if error_procedure() is not null   
		print 'имя процедуры: ' + error_procedure();
	return -1;
end catch;

DECLARE @rc_n int; 
exec @rc_n=PТовары_INSERT @a='кровать', @c=10000, @t='лктерлнтрелнротенлт';
print 'ответ: '+cast(@rc_n as varchar(3));
delete Товары where Цена=10000;

select * from Товары

---------------------------------------------------

drop procedure Zkz_REPORT
create procedure Zkz_REPORT  @p CHAR(50)
   as  
   declare @rc int = 0;                            
   begin try    
      declare @tv char(20), @t char(300) = ' ';  
      declare ZkTov CURSOR  for 
      select Товар from Заказы where Заказчик = @p;
      if not exists (select Товар from Заказы where Заказчик = @p)
            raiserror('ошибка', 11, 1);
       else 
        open ZkTov;	  
    fetch  ZkTov into @tv;   
    print   'Заказанные товары';   
    while @@fetch_status = 0                                     
    begin 
         set @t = rtrim(@tv) + ', ' + @t;  
         set @rc = @rc + 1;       
         fetch  ZkTov into @tv; 
     end;   
	print @t;        
	close  ZkTov;
    return @rc;
   end try  
   begin catch              
        print 'ошибка в параметрах' 
        if error_procedure() is not null   
  print 'имя процедуры : ' + error_procedure();
        return @rc;
   end catch; 

declare @rc_n int;
exec @rc_n = Zkz_REPORT 'Прима-Стайл Мебель';
print 'Количество: ' + cast(@rc_n as varchar);

-----------------------------------------------------

drop procedure TovaryInsert_X;
create  procedure TovaryInsert_X
     @i int, @name NVARCHAR(50), @count int, @d date, 
     @adr nvarchar(20), @dost NVARCHAR(50), @zakazch nvarchar(20), @price real, @dec nvarchar(30)  
as  declare @rc int=1;                            
begin try 
    set transaction isolation level SERIALIZABLE;          
    begin tran
	exec @rc=PТовары_INSERT @name, @price, @dec;
    insert into Заказы (ID_заказа, Товар,  
         Количество, Дата, Адрес, Вид_доставки, Заказчик)
                                               values (@i, @name, @count, @d, @adr, @dost, @zakazch)
    
    commit tran; 
    return @rc;           
end try
begin catch 
    print 'номер ошибки  : ' + cast(error_number() as varchar(6));
    print 'сообщение     : ' + error_message();
    print 'уровень       : ' + cast(error_severity()  as varchar(6));
    print 'метка         : ' + cast(error_state()   as varchar(8));
    print 'номер строки  : ' + cast(error_line()  as varchar(8));
    if error_procedure() is not  null   
                     print 'имя процедуры : ' + error_procedure();
     if @@trancount > 0 rollback tran ; 
     return -1;	  
end catch;

declare @rc_n int;  
exec @rc_n = TovaryInsert_X @i = 20, @name = 'полка', @count = 78,
@d = '01.12.2014', @adr =  'Площадь Победы, дом 7, город Звездное',
@dost = 'самовывоз', @zakazch = 'Прима-Стайл Мебель', @price = 919, @dec = 'jsnfnbnbnfmngkfjn' ;  
print 'код ошибки=' + cast(@rc_n as varchar(3));  

select * from Товары
select * from Заказы

delete Заказы where ID_заказа='20';
delete Товары where Наименование_товара='полка'


select * from TEACHER
go
drop procedure EditPrep
go
Create procedure EditPrep @fio varchar(30), @newfio varchar(30)
as 
--(select substring(Teacher_name, 1, charindex(' ', Teacher_name)-1) from Teacher);
	begin
		declare @surname varchar(10) = substring(@fio, 1, charindex(' ', @fio)-1);
		declare @rest varchar(20) = substring(@fio, charindex(' ', @fio)+1, LEN(@fio));
		declare @newsurname varchar(10) = substring(@newfio, 1, charindex(' ', @fio)-1);
		
		print @surname +' '+ @rest;
		return 1;
	end;
go
declare @k varchar(10), @fio varchar(30) = 'Смелов Владимир Владиславович', @newfio varchar(30) = 'Неверов Александр Васильевич';
EXEC @k = EditPrep @fio, @newfio;
print @k;