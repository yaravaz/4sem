
USE UNIVER;

CREATE VIEW [Преподаватель] AS
	SELECT
		TEACHER.TEACHER AS [Код],
		TEACHER.TEACHER_NAME AS [Имя преподавателя],
		TEACHER.GENDER AS [Пол],
		TEACHER.PULPIT AS [Код кафедры]
	FROM TEACHER;
	go
	SELECT * FROM [Преподаватель]

DROP VIEW Преподаватель

-------------------------------------

CREATE VIEW [Количество кафедр] 
	as SELECT FACULTY.FACULTY_NAME [Название факультета], COUNT(PULPIT.FACULTY)[Количество]
	FROM FACULTY JOIN PULPIT 
	ON FACULTY.FACULTY = PULPIT.FACULTY
	GROUP BY FACULTY.FACULTY_NAME
	go
	SELECT * FROM [Количество кафедр]

-------------------------------------

CREATE VIEW [Аудитории](Код, [Наименование аудитории], Вместительность, Аудитория) 
	as SELECT AUDITORIUM.AUDITORIUM_TYPE, AUDITORIUM.AUDITORIUM_NAME, AUDITORIUM_CAPACITY, AUDITORIUM.AUDITORIUM
	FROM AUDITORIUM
	WHERE AUDITORIUM.AUDITORIUM_TYPE LIKE 'ЛК%'
	go
	SELECT * FROM [Аудитории]

insert Аудитории values('ЛК-К', '100-3a', 40, '100-3a')
delete Аудитории where [Вместительность] = 40 
insert Аудитории values('ЛК-К', '200-3а', 40, '200-3а')

SELECT *
FROM AUDITORIUM

DROP VIEW [Аудитории]

-------------------------------------

CREATE VIEW [Лекционные_аудитории](Код, [Наименование аудитории], Вместительность, Аудитория) 
	as SELECT AUDITORIUM.AUDITORIUM_TYPE, AUDITORIUM.AUDITORIUM_NAME, AUDITORIUM_CAPACITY,AUDITORIUM.AUDITORIUM
	FROM AUDITORIUM
	WHERE AUDITORIUM.AUDITORIUM_TYPE like 'ЛК%' and AUDITORIUM.AUDITORIUM_CAPACITY > 40 with check option
	go
	SELECT * FROM [Лекционные_аудитории]

insert [Лекционные_аудитории] values('ЛК-К', '200-3а', 60, '200-3а')
delete [Лекционные_аудитории] where [Вместительность] = 60 
insert [Лекционные_аудитории] values('ЛК-К', '200-3а', 40, '200-3а')

DROP VIEW [Лекционные_аудитории]

------------------------------------

CREATE VIEW [Дисциплины](Код, [Наименование дисциплины], [Код кафедры])
	as SELECT TOP 100 SUBJECT.SUBJECT, SUBJECT.SUBJECT_NAME, SUBJECT.PULPIT
	FROM SUBJECT
	ORDER BY SUBJECT.SUBJECT
	go
	SELECT * FROM [Дисциплины]

DROP VIEW [Дисциплины]

-----------------------------------

ALTER VIEW [Количество кафедр] WITH SCHEMABINDING
	as SELECT FACULTY.FACULTY_NAME, COUNT(PULPIT.FACULTY)[Количество]
	FROM dbo.FACULTY JOIN dbo.PULPIT 
	ON FACULTY.FACULTY = PULPIT.FACULTY
	GROUP BY FACULTY.FACULTY_NAME
	go
	SELECT * FROM [Количество кафедр]

DROP VIEW [Количество кафедр]

---------------------------------

USE V_MyBASE

CREATE VIEW [Заказанные товары](Товар, Заказчик, Дата)
	as select ЗАКАЗЫ.Товар, ЗАКАЗЫ.Заказчик, ЗАКАЗЫ.Дата
	from ЗАКАЗЫ
	go
	select * from [Заказанные товары]

DROP VIEW [Заказанные товары]

------------------------------

CREATE VIEW [Продажи](Товар, [Цена товара], [Цена продажи], Заказчик)
	as select t.Наименование_товара, t.Цена, (o.Количество * t.Цена), o.Заказчик
	from ТОВАРЫ t join ЗАКАЗЫ o
	on t.Наименование_товара = o.Товар
	group by t.Наименование_товара, t.Цена, o.Количество, o.Заказчик
	go
	select * from [Продажи]

DROP VIEW [Продажи]

-------------------------------

CREATE VIEW [Дорогие_товары](Товар, Цена, Описание)
	as select t.Наименование_товара, t.Цена, t.Описание
	from ТОВАРЫ t
	where t.Цена > 200
	go
	select * from [Дорогие_товары]

insert [Дорогие_товары] values ('мебель', 300, 'дорогая')
delete [Дорогие_товары] where [Цена] = 300
insert [Дорогие_товары] values ('мебель', 100, 'дорогая(неочень)')

-----------------------------------

ALTER VIEW [Дорогие_товары](Товар, Цена, Описание)
	as select t.Наименование_товара, t.Цена, t.Описание
	from ТОВАРЫ t
	where t.Цена > 200 WITH CHECK OPTION
	go
	select * from [Дорогие_товары]

insert [Дорогие_товары] values ('мебель', 300, 'дорогая')
delete [Дорогие_товары] where [Товар] = 'мебель'
insert [Дорогие_товары] values ('мебель', 100, 'дорогая(неочень)')

DROP VIEW [Дорогие_товары]

-------------------------------------

CREATE VIEW [Дорогие_товары](Товар, Цена, Описание)
	as select top 5 t.Наименование_товара, t.Цена, t.Описание
	from ТОВАРЫ t
	order by t.Цена desc
	go
	select * from [Дорогие_товары]

DROP VIEW [Дорогие_товары]

------------------------------------

CREATE VIEW [Продажи](Товар, [Цена товара], [Цена продажи], Заказчик) WITH SCHEMABINDING
	as select t.Наименование_товара, t.Цена, (o.Количество * t.Цена), o.Заказчик
	from dbo.ТОВАРЫ t join dbo.ЗАКАЗЫ o
	on t.Наименование_товара = o.Товар
	group by t.Наименование_товара, t.Цена, o.Количество, o.Заказчик
	go
	select * from [Продажи]

DROP VIEW [Продажи]