USE UNIVER

-------------------------------------------------------------

SELECT PULPIT.PULPIT_NAME
FROM PULPIT, FACULTY
WHERE PULPIT.FACULTY = FACULTY.FACULTY
	And FACULTY.FACULTY In (SELECT PROFESSION.FACULTY FROM PROFESSION
							WHERE PROFESSION_NAME LIKE '%технология%' or PROFESSION_NAME LIKE '%технологии%')

-------------------------------------------------------------

SELECT PULPIT.PULPIT_NAME
FROM PULPIT INNER JOIN FACULTY
ON PULPIT.FACULTY = FACULTY.FACULTY
	WHERE FACULTY.FACULTY In (SELECT PROFESSION.FACULTY FROM PROFESSION
							WHERE PROFESSION_NAME LIKE '%технология%' or PROFESSION_NAME LIKE '%технологии%')

-------------------------------------------------------------

SELECT DISTINCT PULPIT.PULPIT_NAME
FROM PULPIT 
		INNER JOIN FACULTY ON PULPIT.FACULTY = FACULTY.FACULTY
		INNER JOIN PROFESSION ON PROFESSION.FACULTY = FACULTY.FACULTY
			WHERE PROFESSION_NAME LIKE '%технология%' or PROFESSION_NAME LIKE '%технологии%'

-------------------------------------------------------------

SELECT TABLE1.AUDITORIUM_TYPE, TABLE1.AUDITORIUM_CAPACITY
FROM AUDITORIUM TABLE1
WHERE TABLE1.AUDITORIUM_CAPACITY = (SELECT TOP(1) TABLE2.AUDITORIUM_CAPACITY
									FROM AUDITORIUM TABLE2
									WHERE TABLE1.AUDITORIUM_TYPE = TABLE2.AUDITORIUM_TYPE 
									ORDER BY AUDITORIUM_CAPACITY DESC)

-------------------------------------------------------------

SELECT FACULTY.FACULTY
FROM FACULTY
WHERE NOT EXISTS (SELECT * FROM PULPIT 
					WHERE PULPIT.FACULTY = FACULTY.FACULTY)

-------------------------------------------------------------

SELECT
	(SELECT AVG(PROGRESS.NOTE) FROM PROGRESS
		WHERE PROGRESS.SUBJECT LIKE 'ОАиП')[ОАиП],
	(SELECT AVG(PROGRESS.NOTE) FROM PROGRESS
		WHERE PROGRESS.SUBJECT LIKE 'БД')[БД],
	(SELECT AVG(PROGRESS.NOTE) FROM PROGRESS
		WHERE PROGRESS.SUBJECT LIKE 'СУБД')[СУБД]
FROM PROGRESS

------------------------------------------------------------

SELECT PROGRESS.SUBJECT, PROGRESS.NOTE
FROM PROGRESS
WHERE PROGRESS.NOTE >= ALL(SELECT PROGRESS.NOTE 
							FROM PROGRESS
							WHERE PROGRESS.SUBJECT LIKE 'ОАиП')

-----------------------------------------------------------

SELECT PROGRESS.SUBJECT, PROGRESS.NOTE
FROM PROGRESS
WHERE PROGRESS.NOTE > ANY(SELECT PROGRESS.NOTE 
							FROM PROGRESS
							WHERE PROGRESS.SUBJECT LIKE 'ОАиП')

-----------------------------------------------------------
-----------------------------------------------------------

USE V_MyBASE

SELECT ЗАКАЗЫ.Товар, ТОВАРЫ.Цена
FROM ЗАКАЗЫ, ТОВАРЫ
WHERE ЗАКАЗЫ.Товар = ТОВАРЫ.Наименование_товара AND
	ЗАКАЗЫ.Заказчик IN (SELECT ЗАКАЗЧИКИ.Наименование_фирмы 
						FROM ЗАКАЗЧИКИ
						WHERE ЗАКАЗЧИКИ.Контактное_лицо LIKE '%gmail%')

-----------------------------------------------------------

SELECT ЗАКАЗЫ.Товар, ТОВАРЫ.Цена
FROM ЗАКАЗЫ INNER JOIN ТОВАРЫ
ON ЗАКАЗЫ.Товар = ТОВАРЫ.Наименование_товара 
WHERE ЗАКАЗЫ.Заказчик IN (SELECT ЗАКАЗЧИКИ.Наименование_фирмы 
						FROM ЗАКАЗЧИКИ
						WHERE ЗАКАЗЧИКИ.Контактное_лицо LIKE '%gmail%')

-----------------------------------------------------------

SELECT ЗАКАЗЫ.Товар, ТОВАРЫ.Цена
FROM ЗАКАЗЫ 
	INNER JOIN ТОВАРЫ ON ЗАКАЗЫ.Товар = ТОВАРЫ.Наименование_товара
	INNER JOIN ЗАКАЗЧИКИ ON ЗАКАЗЫ.Заказчик = ЗАКАЗЧИКИ.Наименование_фирмы
						WHERE ЗАКАЗЧИКИ.Контактное_лицо LIKE '%gmail%'

-----------------------------------------------------------

SELECT TABLE1.Товар, TABLE1.Количество
FROM ЗАКАЗЫ TABLE1
WHERE TABLE1.Количество = (SELECT TOP(1) TABLE2.Количество
									FROM ЗАКАЗЫ TABLE2
									WHERE TABLE1.Товар = TABLE2.Товар 
									ORDER BY Количество DESC)

-----------------------------------------------------------

SELECT ТОВАРЫ.Наименование_товара
FROM ТОВАРЫ
WHERE NOT EXISTS (SELECT * FROM ЗАКАЗЫ
					WHERE ЗАКАЗЫ.Товар = ТОВАРЫ.Наименование_товара)

-------------------------------------------------------------

SELECT TOP 1
	(SELECT AVG(ТОВАРЫ.Цена) FROM ТОВАРЫ
		WHERE ТОВАРЫ.Наименование_товара LIKE 'Стол')[Стол],
	(SELECT AVG(ТОВАРЫ.Цена) FROM ТОВАРЫ
		WHERE ТОВАРЫ.Наименование_товара LIKE 'Шкаф')[Шкаф],
	(SELECT AVG(ТОВАРЫ.Цена) FROM ТОВАРЫ
		WHERE ТОВАРЫ.Наименование_товара LIKE 'Стеллаж')[Стеллаж]
FROM ТОВАРЫ

------------------------------------------------------------

SELECT ТОВАРЫ.Наименование_товара, ТОВАРЫ.Цена
FROM ТОВАРЫ
WHERE ТОВАРЫ.Цена >= ALL(SELECT ТОВАРЫ.Цена 
							FROM ТОВАРЫ
							WHERE ТОВАРЫ.Наименование_товара LIKE 'Шкаф')

-----------------------------------------------------------

SELECT ТОВАРЫ.Наименование_товара, ТОВАРЫ.Цена
FROM ТОВАРЫ
WHERE ТОВАРЫ.Цена > ANY(SELECT ТОВАРЫ.Цена 
							FROM ТОВАРЫ
							WHERE ТОВАРЫ.Наименование_товара LIKE 'Шкаф')