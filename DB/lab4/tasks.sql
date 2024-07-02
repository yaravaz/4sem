
USE UNIVER;

SELECT AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
	FROM AUDITORIUM_TYPE Inner Join AUDITORIUM
	ON AUDITORIUM.AUDITORIUM_TYPE=AUDITORIUM_TYPE.AUDITORIUM_TYPE;

--------------------------

USE  UNIVER;

SELECT AUDITORIUM.AUDITORIUM,AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
	FROM AUDITORIUM_TYPE INNER JOIN AUDITORIUM
	ON AUDITORIUM.AUDITORIUM_TYPE=AUDITORIUM_TYPE.AUDITORIUM_TYPE And
			AUDITORIUM_TYPE.AUDITORIUM_TYPENAME LIKE '%компьютер%'

----------------------

USE UNIVER;

SELECT STUDENT.NAME, FACULTY.FACULTY, PULPIT.PULPIT, PROFESSION.PROFESSION_NAME, SUBJECT.SUBJECT_NAME,
       CASE
           WHEN (PROGRESS.NOTE = 6) THEN 'шесть'
           WHEN (PROGRESS.NOTE = 7) THEN 'семь'
           WHEN (PROGRESS.NOTE = 8) THEN 'восемь'
           END [Oценка]
FROM PROGRESS
          inner join STUDENT On PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT
          inner join SUBJECT On SUBJECT.SUBJECT = PROGRESS.SUBJECT
		  inner join PULPIT On PULPIT.PULPIT = SUBJECT.PULPIT
          inner join GROUPS On GROUPS.IDGROUP = STUDENT.IDGROUP
          inner join PROFESSION On PROFESSION.PROFESSION = GROUPS.PROFESSION
          inner join FACULTY On FACULTY.FACULTY = PULPIT.FACULTY
WHERE PROGRESS.NOTE between 6 and 8
ORDER BY PROGRESS.NOTE DESC

------------------

USE UNIVER;

SELECT PULPIT.PULPIT_NAME, ISNULL(TEACHER.TEACHER_NAME, '***')[TEACHER_NAME]
	FROM PULPIT Left Outer JOIN TEACHER
	On TEACHER.PULPIT = PULPIT.PULPIT;

------------------

USE UNIVER;

-- привер коммутативности

SELECT PROGRESS.NOTE, STUDENT.NAME
	FROM PROGRESS FULL OUTER JOIN STUDENT
	ON PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT
	ORDER BY PROGRESS.NOTE DESC

SELECT STUDENT.NAME, PROGRESS.NOTE 
	FROM STUDENT FULL OUTER JOIN PROGRESS
	ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
	ORDER BY PROGRESS.NOTE DESC

-- содержит данные левой таблицы и не содержит данные правой

SELECT STUDENT.NAME, PROGRESS.SUBJECT 
	FROM STUDENT FULL OUTER JOIN PROGRESS
	ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
	WHERE PROGRESS.NOTE IS NULL

-- содержит данные правой таблицы и не содержит данные левой

SELECT PROGRESS.NOTE, STUDENT.NAME 
	FROM PROGRESS FULL OUTER JOIN STUDENT
	ON PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT
	WHERE PROGRESS.NOTE IS NULL

-- содержит данные правой таблицы и левой таблиц

SELECT PROGRESS.NOTE, STUDENT.NAME 
	FROM PROGRESS FULL OUTER JOIN STUDENT
	ON PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT
	WHERE PROGRESS.NOTE IS NOT NULL

---------------------

USE UNIVER;

SELECT AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
	FROM AUDITORIUM CROSS JOIN AUDITORIUM_TYPE
	WHERE AUDITORIUM.AUDITORIUM_TYPE = AUDITORIUM_TYPE.AUDITORIUM_TYPE;

---------------------

USE V_MyBASE;

SELECT ЗАКАЗЫ.Товар, ЗАКАЗЧИКИ.Контактное_лицо
	FROM ЗАКАЗЫ inner join ЗАКАЗЧИКИ
	ON ЗАКАЗЫ.Заказчик = ЗАКАЗЧИКИ.Наименование_фирмы;

SELECT ЗАКАЗЫ.Товар, ЗАКАЗЧИКИ.Контактное_лицо
	FROM ЗАКАЗЫ inner join ЗАКАЗЧИКИ
	ON ЗАКАЗЫ.Заказчик = ЗАКАЗЧИКИ.Наименование_фирмы AND 
					ЗАКАЗЫ.Товар like '%Стол%';

SELECT ЗАКАЗЫ.Товар, ЗАКАЗЧИКИ.Наименование_фирмы,
		CASE 
		WHEN (ЗАКАЗЫ.Количество between 1 and 50) then 'мало'
		WHEN (ЗАКАЗЫ.Количество between 50 and 500) then 'средне'
		WHEN (ЗАКАЗЫ.Количество between 500 and 1000) then 'ого'
		end [Количество]
FROM ЗАКАЗЫ inner join ЗАКАЗЧИКИ
ON ЗАКАЗЫ.Заказчик = ЗАКАЗЧИКИ.Наименование_фирмы;

SELECT ТОВАРЫ.Наименование_товара, isnull(ЗАКАЗЫ.Заказчик, '***')[Заказчик]
	FROM ТОВАРЫ Left outer join ЗАКАЗЫ
	ON ТОВАРЫ.Наименование_товара = ЗАКАЗЫ.Товар;

SELECT ТОВАРЫ.Наименование_товара, ЗАКАЗЫ.Заказчик
	FROM ТОВАРЫ Left outer join ЗАКАЗЫ
	ON ТОВАРЫ.Наименование_товара = ЗАКАЗЫ.Товар
	WHERE ЗАКАЗЫ.Заказчик IS NUll;

SELECT ЗАКАЗЫ.Товар, ЗАКАЗЧИКИ.Контактное_лицо
	FROM ЗАКАЗЫ cross join ЗАКАЗЧИКИ
	WHERE ЗАКАЗЫ.Заказчик = ЗАКАЗЧИКИ.Наименование_фирмы;
