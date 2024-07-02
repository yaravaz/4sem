
USE UNIVER;

SELECT AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
	FROM AUDITORIUM_TYPE Inner Join AUDITORIUM
	ON AUDITORIUM.AUDITORIUM_TYPE=AUDITORIUM_TYPE.AUDITORIUM_TYPE;

--------------------------

USE  UNIVER;

SELECT AUDITORIUM.AUDITORIUM,AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
	FROM AUDITORIUM_TYPE INNER JOIN AUDITORIUM
	ON AUDITORIUM.AUDITORIUM_TYPE=AUDITORIUM_TYPE.AUDITORIUM_TYPE And
			AUDITORIUM_TYPE.AUDITORIUM_TYPENAME LIKE '%���������%'

----------------------

USE UNIVER;

SELECT STUDENT.NAME, FACULTY.FACULTY, PULPIT.PULPIT, PROFESSION.PROFESSION_NAME, SUBJECT.SUBJECT_NAME,
       CASE
           WHEN (PROGRESS.NOTE = 6) THEN '�����'
           WHEN (PROGRESS.NOTE = 7) THEN '����'
           WHEN (PROGRESS.NOTE = 8) THEN '������'
           END [O�����]
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

-- ������ ���������������

SELECT PROGRESS.NOTE, STUDENT.NAME
	FROM PROGRESS FULL OUTER JOIN STUDENT
	ON PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT
	ORDER BY PROGRESS.NOTE DESC

SELECT STUDENT.NAME, PROGRESS.NOTE 
	FROM STUDENT FULL OUTER JOIN PROGRESS
	ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
	ORDER BY PROGRESS.NOTE DESC

-- �������� ������ ����� ������� � �� �������� ������ ������

SELECT STUDENT.NAME, PROGRESS.SUBJECT 
	FROM STUDENT FULL OUTER JOIN PROGRESS
	ON STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
	WHERE PROGRESS.NOTE IS NULL

-- �������� ������ ������ ������� � �� �������� ������ �����

SELECT PROGRESS.NOTE, STUDENT.NAME 
	FROM PROGRESS FULL OUTER JOIN STUDENT
	ON PROGRESS.IDSTUDENT = STUDENT.IDSTUDENT
	WHERE PROGRESS.NOTE IS NULL

-- �������� ������ ������ ������� � ����� ������

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

SELECT ������.�����, ���������.����������_����
	FROM ������ inner join ���������
	ON ������.�������� = ���������.������������_�����;

SELECT ������.�����, ���������.����������_����
	FROM ������ inner join ���������
	ON ������.�������� = ���������.������������_����� AND 
					������.����� like '%����%';

SELECT ������.�����, ���������.������������_�����,
		CASE 
		WHEN (������.���������� between 1 and 50) then '����'
		WHEN (������.���������� between 50 and 500) then '������'
		WHEN (������.���������� between 500 and 1000) then '���'
		end [����������]
FROM ������ inner join ���������
ON ������.�������� = ���������.������������_�����;

SELECT ������.������������_������, isnull(������.��������, '***')[��������]
	FROM ������ Left outer join ������
	ON ������.������������_������ = ������.�����;

SELECT ������.������������_������, ������.��������
	FROM ������ Left outer join ������
	ON ������.������������_������ = ������.�����
	WHERE ������.�������� IS NUll;

SELECT ������.�����, ���������.����������_����
	FROM ������ cross join ���������
	WHERE ������.�������� = ���������.������������_�����;
