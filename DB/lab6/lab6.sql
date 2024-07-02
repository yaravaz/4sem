use UNIVER;

SELECT AUDITORIUM.AUDITORIUM_TYPE,
		MAX(AUDITORIUM.AUDITORIUM_CAPACITY)[������������ ���������������],
		MIN(AUDITORIUM.AUDITORIUM_CAPACITY)[����������� ���������������],
		AVG(AUDITORIUM.AUDITORIUM_CAPACITY)[������� ���������������],
		SUM(AUDITORIUM.AUDITORIUM_CAPACITY)[����� ����������������],
		COUNT(*)[���������� ���������]
FROM AUDITORIUM
GROUP BY AUDITORIUM.AUDITORIUM_TYPE;

--------------------------------------------------------------------------

SELECT *
FROM (SELECT CASE 
			 WHEN PROGRESS.NOTE BETWEEN 1 AND 3 THEN '�������'
			 WHEN PROGRESS.NOTE BETWEEN 4 AND 7 THEN '�����'
			 ELSE '����� �� �������'
			 END [������� ������], COUNT (*) [����������]
	  FROM PROGRESS GROUP BY CASE
							 WHEN PROGRESS.NOTE BETWEEN 1 AND 3 THEN '�������'
							 WHEN PROGRESS.NOTE BETWEEN 4 AND 7 THEN '�����'
							 ELSE '����� �� �������'
							 END ) AS T 
								   ORDER BY CASE[������� ������]
											WHEN '�������' THEN 3
											WHEN '�����' THEN 2
											WHEN '����� �� �������' THEN 1
											ELSE 0
											END;

--------------------------------------------------------------------------

SELECT F.FACULTY, G.PROFESSION, 
	   (2013 - G.YEAR_FIRST + 1)[����],
	   ROUND(AVG(CAST(P.NOTE AS FLOAT(4))), 2)[������� ������]
FROM FACULTY F 
	INNER JOIN GROUPS G ON F.FACULTY = G.FACULTY
	INNER JOIN STUDENT S ON G.IDGROUP = S.IDGROUP
	INNER JOIN PROGRESS P ON S.IDSTUDENT = P.IDSTUDENT
GROUP BY F.FACULTY, G.PROFESSION, G.YEAR_FIRST;

--------------------------------------------------------------------------

SELECT F.FACULTY, G.PROFESSION, 
	   (2013 - G.YEAR_FIRST + 1)[����],
	   ROUND(AVG(CAST(P.NOTE AS FLOAT(4))), 2)[������� ������]
FROM FACULTY F 
	INNER JOIN GROUPS G ON F.FACULTY = G.FACULTY
	INNER JOIN STUDENT S ON G.IDGROUP = S.IDGROUP
	INNER JOIN PROGRESS P ON S.IDSTUDENT = P.IDSTUDENT
						  WHERE P.SUBJECT IN ('����', '����')
GROUP BY F.FACULTY, G.PROFESSION, G.YEAR_FIRST;

--------------------------------------------------------------------------

SELECT G.PROFESSION, P.SUBJECT, ROUND(AVG(CAST(P.NOTE AS FLOAT(4))), 2)[������� ������]
FROM GROUPS G
		INNER JOIN FACULTY ON G.FACULTY = FACULTY.FACULTY
		INNER JOIN STUDENT ON G.IDGROUP = STUDENT.IDGROUP
		INNER JOIN PROGRESS P ON P.IDSTUDENT = STUDENT.IDSTUDENT
		WHERE FACULTY.FACULTY = '�OB'
GROUP BY G.PROFESSION, P.SUBJECT

-------------------------------------------------------------------------- 

SELECT P.SUBJECT, COUNT(*)[����������]
FROM PROGRESS P
GROUP BY P.SUBJECT, P.NOTE
					HAVING P.NOTE >= 8 AND P.NOTE <= 9

--------------------------------------------------------------------------

USE V_MyBASE

SELECT ������.�����,
	   MAX(������.����������)[������������ ����������],
	   MIN(������.����������)[����������� ����������],
	   AVG(������.����������)[������� ����������]
FROM ������
GROUP BY ������.�����

-----------------

SELECT *
FROM (SELECT CASE
			 WHEN ������.���� < 100 THEN '������ 100'
			 WHEN ������.���� > 100 and ������.���� < 500 THEN '�� 100 �� 500'
			 ELSE '������ 500'
			 END[������� ���], COUNT(*)[����������]
	  FROM ������
	  GROUP BY CASE
			   WHEN ������.���� < 100 THEN '������ 100'
			   WHEN ������.���� > 100 and ������.���� < 500 THEN '�� 100 �� 500'
			   ELSE '������ 500'
			   END) as T
			   ORDER BY CASE[������� ���]
						WHEN '������ 100' THEN 3
						WHEN '�� 100 �� 500' THEN 2
						ELSE 1
						END

---------------------------

SELECT ������.�����,
	   ROUND(AVG(CAST(������.���������� AS FLOAT(4))),2)[������� ����������]
FROM ������
GROUP BY ������.�����

--------------------------

SELECT ������.�����,
	   ROUND(AVG(CAST(������.���������� AS FLOAT(4))),2)[������� ����������]
FROM ������ 
WHERE ������.���_�������� IN ('������','�����')
GROUP BY ������.�����

--------------------------

SELECT ������.�����, ������.����������
FROM ������
GROUP BY ������.�����, ������.����������
		HAVING ������.���������� >= 10 and ������.���������� <= 100