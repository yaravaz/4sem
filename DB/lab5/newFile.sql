USE UNIVER

-------------------------------------------------------------

SELECT PULPIT.PULPIT_NAME
FROM PULPIT, FACULTY
WHERE PULPIT.FACULTY = FACULTY.FACULTY
	And FACULTY.FACULTY In (SELECT PROFESSION.FACULTY FROM PROFESSION
							WHERE PROFESSION_NAME LIKE '%����������%' or PROFESSION_NAME LIKE '%����������%')

-------------------------------------------------------------

SELECT PULPIT.PULPIT_NAME
FROM PULPIT INNER JOIN FACULTY
ON PULPIT.FACULTY = FACULTY.FACULTY
	WHERE FACULTY.FACULTY In (SELECT PROFESSION.FACULTY FROM PROFESSION
							WHERE PROFESSION_NAME LIKE '%����������%' or PROFESSION_NAME LIKE '%����������%')

-------------------------------------------------------------

SELECT DISTINCT PULPIT.PULPIT_NAME
FROM PULPIT 
		INNER JOIN FACULTY ON PULPIT.FACULTY = FACULTY.FACULTY
		INNER JOIN PROFESSION ON PROFESSION.FACULTY = FACULTY.FACULTY
			WHERE PROFESSION_NAME LIKE '%����������%' or PROFESSION_NAME LIKE '%����������%'

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
		WHERE PROGRESS.SUBJECT LIKE '����')[����],
	(SELECT AVG(PROGRESS.NOTE) FROM PROGRESS
		WHERE PROGRESS.SUBJECT LIKE '��')[��],
	(SELECT AVG(PROGRESS.NOTE) FROM PROGRESS
		WHERE PROGRESS.SUBJECT LIKE '����')[����]
FROM PROGRESS

------------------------------------------------------------

SELECT PROGRESS.SUBJECT, PROGRESS.NOTE
FROM PROGRESS
WHERE PROGRESS.NOTE >= ALL(SELECT PROGRESS.NOTE 
							FROM PROGRESS
							WHERE PROGRESS.SUBJECT LIKE '����')

-----------------------------------------------------------

SELECT PROGRESS.SUBJECT, PROGRESS.NOTE
FROM PROGRESS
WHERE PROGRESS.NOTE > ANY(SELECT PROGRESS.NOTE 
							FROM PROGRESS
							WHERE PROGRESS.SUBJECT LIKE '����')

-----------------------------------------------------------
-----------------------------------------------------------

USE V_MyBASE

SELECT ������.�����, ������.����
FROM ������, ������
WHERE ������.����� = ������.������������_������ AND
	������.�������� IN (SELECT ���������.������������_����� 
						FROM ���������
						WHERE ���������.����������_���� LIKE '%gmail%')

-----------------------------------------------------------

SELECT ������.�����, ������.����
FROM ������ INNER JOIN ������
ON ������.����� = ������.������������_������ 
WHERE ������.�������� IN (SELECT ���������.������������_����� 
						FROM ���������
						WHERE ���������.����������_���� LIKE '%gmail%')

-----------------------------------------------------------

SELECT ������.�����, ������.����
FROM ������ 
	INNER JOIN ������ ON ������.����� = ������.������������_������
	INNER JOIN ��������� ON ������.�������� = ���������.������������_�����
						WHERE ���������.����������_���� LIKE '%gmail%'

-----------------------------------------------------------

SELECT TABLE1.�����, TABLE1.����������
FROM ������ TABLE1
WHERE TABLE1.���������� = (SELECT TOP(1) TABLE2.����������
									FROM ������ TABLE2
									WHERE TABLE1.����� = TABLE2.����� 
									ORDER BY ���������� DESC)

-----------------------------------------------------------

SELECT ������.������������_������
FROM ������
WHERE NOT EXISTS (SELECT * FROM ������
					WHERE ������.����� = ������.������������_������)

-------------------------------------------------------------

SELECT TOP 1
	(SELECT AVG(������.����) FROM ������
		WHERE ������.������������_������ LIKE '����')[����],
	(SELECT AVG(������.����) FROM ������
		WHERE ������.������������_������ LIKE '����')[����],
	(SELECT AVG(������.����) FROM ������
		WHERE ������.������������_������ LIKE '�������')[�������]
FROM ������

------------------------------------------------------------

SELECT ������.������������_������, ������.����
FROM ������
WHERE ������.���� >= ALL(SELECT ������.���� 
							FROM ������
							WHERE ������.������������_������ LIKE '����')

-----------------------------------------------------------

SELECT ������.������������_������, ������.����
FROM ������
WHERE ������.���� > ANY(SELECT ������.���� 
							FROM ������
							WHERE ������.������������_������ LIKE '����')