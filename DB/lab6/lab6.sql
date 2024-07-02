use UNIVER;

SELECT AUDITORIUM.AUDITORIUM_TYPE,
		MAX(AUDITORIUM.AUDITORIUM_CAPACITY)[Максимальная вместительность],
		MIN(AUDITORIUM.AUDITORIUM_CAPACITY)[Минимальная вместительность],
		AVG(AUDITORIUM.AUDITORIUM_CAPACITY)[Средняя вместительность],
		SUM(AUDITORIUM.AUDITORIUM_CAPACITY)[Сумма вместительностей],
		COUNT(*)[Количество аудиторий]
FROM AUDITORIUM
GROUP BY AUDITORIUM.AUDITORIUM_TYPE;

--------------------------------------------------------------------------

SELECT *
FROM (SELECT CASE 
			 WHEN PROGRESS.NOTE BETWEEN 1 AND 3 THEN 'незачёт'
			 WHEN PROGRESS.NOTE BETWEEN 4 AND 7 THEN 'зачёт'
			 ELSE 'зачёт на отлично'
			 END [Пределы оценок], COUNT (*) [Количество]
	  FROM PROGRESS GROUP BY CASE
							 WHEN PROGRESS.NOTE BETWEEN 1 AND 3 THEN 'незачёт'
							 WHEN PROGRESS.NOTE BETWEEN 4 AND 7 THEN 'зачёт'
							 ELSE 'зачёт на отлично'
							 END ) AS T 
								   ORDER BY CASE[Пределы оценок]
											WHEN 'незачёт' THEN 3
											WHEN 'зачёт' THEN 2
											WHEN 'зачёт на отлично' THEN 1
											ELSE 0
											END;

--------------------------------------------------------------------------

SELECT F.FACULTY, G.PROFESSION, 
	   (2013 - G.YEAR_FIRST + 1)[Курс],
	   ROUND(AVG(CAST(P.NOTE AS FLOAT(4))), 2)[Средняя оценка]
FROM FACULTY F 
	INNER JOIN GROUPS G ON F.FACULTY = G.FACULTY
	INNER JOIN STUDENT S ON G.IDGROUP = S.IDGROUP
	INNER JOIN PROGRESS P ON S.IDSTUDENT = P.IDSTUDENT
GROUP BY F.FACULTY, G.PROFESSION, G.YEAR_FIRST;

--------------------------------------------------------------------------

SELECT F.FACULTY, G.PROFESSION, 
	   (2013 - G.YEAR_FIRST + 1)[Курс],
	   ROUND(AVG(CAST(P.NOTE AS FLOAT(4))), 2)[Средняя оценка]
FROM FACULTY F 
	INNER JOIN GROUPS G ON F.FACULTY = G.FACULTY
	INNER JOIN STUDENT S ON G.IDGROUP = S.IDGROUP
	INNER JOIN PROGRESS P ON S.IDSTUDENT = P.IDSTUDENT
						  WHERE P.SUBJECT IN ('ОАиП', 'СУБД')
GROUP BY F.FACULTY, G.PROFESSION, G.YEAR_FIRST;

--------------------------------------------------------------------------

SELECT G.PROFESSION, P.SUBJECT, ROUND(AVG(CAST(P.NOTE AS FLOAT(4))), 2)[Средняя оценка]
FROM GROUPS G
		INNER JOIN FACULTY ON G.FACULTY = FACULTY.FACULTY
		INNER JOIN STUDENT ON G.IDGROUP = STUDENT.IDGROUP
		INNER JOIN PROGRESS P ON P.IDSTUDENT = STUDENT.IDSTUDENT
		WHERE FACULTY.FACULTY = 'ТOB'
GROUP BY G.PROFESSION, P.SUBJECT

-------------------------------------------------------------------------- 

SELECT P.SUBJECT, COUNT(*)[Количество]
FROM PROGRESS P
GROUP BY P.SUBJECT, P.NOTE
					HAVING P.NOTE >= 8 AND P.NOTE <= 9

--------------------------------------------------------------------------

USE V_MyBASE

SELECT ЗАКАЗЫ.Товар,
	   MAX(ЗАКАЗЫ.Количество)[Максимальное количество],
	   MIN(ЗАКАЗЫ.Количество)[Минимальное количество],
	   AVG(ЗАКАЗЫ.Количество)[Среднее количество]
FROM ЗАКАЗЫ
GROUP BY ЗАКАЗЫ.Товар

-----------------

SELECT *
FROM (SELECT CASE
			 WHEN ТОВАРЫ.Цена < 100 THEN 'меньше 100'
			 WHEN ТОВАРЫ.Цена > 100 and ТОВАРЫ.Цена < 500 THEN 'от 100 до 500'
			 ELSE 'больше 500'
			 END[Пределы цен], COUNT(*)[Количество]
	  FROM ТОВАРЫ
	  GROUP BY CASE
			   WHEN ТОВАРЫ.Цена < 100 THEN 'меньше 100'
			   WHEN ТОВАРЫ.Цена > 100 and ТОВАРЫ.Цена < 500 THEN 'от 100 до 500'
			   ELSE 'больше 500'
			   END) as T
			   ORDER BY CASE[Пределы цен]
						WHEN 'меньше 100' THEN 3
						WHEN 'от 100 до 500' THEN 2
						ELSE 1
						END

---------------------------

SELECT ЗАКАЗЫ.Товар,
	   ROUND(AVG(CAST(ЗАКАЗЫ.Количество AS FLOAT(4))),2)[Среднее количество]
FROM ЗАКАЗЫ
GROUP BY ЗАКАЗЫ.Товар

--------------------------

SELECT ЗАКАЗЫ.Товар,
	   ROUND(AVG(CAST(ЗАКАЗЫ.Количество AS FLOAT(4))),2)[Среднее количество]
FROM ЗАКАЗЫ 
WHERE ЗАКАЗЫ.Вид_доставки IN ('курьер','почта')
GROUP BY ЗАКАЗЫ.Товар

--------------------------

SELECT ЗАКАЗЫ.Товар, ЗАКАЗЫ.Количество
FROM ЗАКАЗЫ
GROUP BY ЗАКАЗЫ.Товар, ЗАКАЗЫ.Количество
		HAVING ЗАКАЗЫ.Количество >= 10 and ЗАКАЗЫ.Количество <= 100