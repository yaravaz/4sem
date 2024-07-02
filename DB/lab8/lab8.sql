
USE UNIVER;

CREATE VIEW [�������������] AS
	SELECT
		TEACHER.TEACHER AS [���],
		TEACHER.TEACHER_NAME AS [��� �������������],
		TEACHER.GENDER AS [���],
		TEACHER.PULPIT AS [��� �������]
	FROM TEACHER;
	go
	SELECT * FROM [�������������]

DROP VIEW �������������

-------------------------------------

CREATE VIEW [���������� ������] 
	as SELECT FACULTY.FACULTY_NAME [�������� ����������], COUNT(PULPIT.FACULTY)[����������]
	FROM FACULTY JOIN PULPIT 
	ON FACULTY.FACULTY = PULPIT.FACULTY
	GROUP BY FACULTY.FACULTY_NAME
	go
	SELECT * FROM [���������� ������]

-------------------------------------

CREATE VIEW [���������](���, [������������ ���������], ���������������, ���������) 
	as SELECT AUDITORIUM.AUDITORIUM_TYPE, AUDITORIUM.AUDITORIUM_NAME, AUDITORIUM_CAPACITY, AUDITORIUM.AUDITORIUM
	FROM AUDITORIUM
	WHERE AUDITORIUM.AUDITORIUM_TYPE LIKE '��%'
	go
	SELECT * FROM [���������]

insert ��������� values('��-�', '100-3a', 40, '100-3a')
delete ��������� where [���������������] = 40 
insert ��������� values('��-�', '200-3�', 40, '200-3�')

SELECT *
FROM AUDITORIUM

DROP VIEW [���������]

-------------------------------------

CREATE VIEW [����������_���������](���, [������������ ���������], ���������������, ���������) 
	as SELECT AUDITORIUM.AUDITORIUM_TYPE, AUDITORIUM.AUDITORIUM_NAME, AUDITORIUM_CAPACITY,AUDITORIUM.AUDITORIUM
	FROM AUDITORIUM
	WHERE AUDITORIUM.AUDITORIUM_TYPE like '��%' and AUDITORIUM.AUDITORIUM_CAPACITY > 40 with check option
	go
	SELECT * FROM [����������_���������]

insert [����������_���������] values('��-�', '200-3�', 60, '200-3�')
delete [����������_���������] where [���������������] = 60 
insert [����������_���������] values('��-�', '200-3�', 40, '200-3�')

DROP VIEW [����������_���������]

------------------------------------

CREATE VIEW [����������](���, [������������ ����������], [��� �������])
	as SELECT TOP 100 SUBJECT.SUBJECT, SUBJECT.SUBJECT_NAME, SUBJECT.PULPIT
	FROM SUBJECT
	ORDER BY SUBJECT.SUBJECT
	go
	SELECT * FROM [����������]

DROP VIEW [����������]

-----------------------------------

ALTER VIEW [���������� ������] WITH SCHEMABINDING
	as SELECT FACULTY.FACULTY_NAME, COUNT(PULPIT.FACULTY)[����������]
	FROM dbo.FACULTY JOIN dbo.PULPIT 
	ON FACULTY.FACULTY = PULPIT.FACULTY
	GROUP BY FACULTY.FACULTY_NAME
	go
	SELECT * FROM [���������� ������]

DROP VIEW [���������� ������]

---------------------------------

USE V_MyBASE

CREATE VIEW [���������� ������](�����, ��������, ����)
	as select ������.�����, ������.��������, ������.����
	from ������
	go
	select * from [���������� ������]

DROP VIEW [���������� ������]

------------------------------

CREATE VIEW [�������](�����, [���� ������], [���� �������], ��������)
	as select t.������������_������, t.����, (o.���������� * t.����), o.��������
	from ������ t join ������ o
	on t.������������_������ = o.�����
	group by t.������������_������, t.����, o.����������, o.��������
	go
	select * from [�������]

DROP VIEW [�������]

-------------------------------

CREATE VIEW [�������_������](�����, ����, ��������)
	as select t.������������_������, t.����, t.��������
	from ������ t
	where t.���� > 200
	go
	select * from [�������_������]

insert [�������_������] values ('������', 300, '�������')
delete [�������_������] where [����] = 300
insert [�������_������] values ('������', 100, '�������(�������)')

-----------------------------------

ALTER VIEW [�������_������](�����, ����, ��������)
	as select t.������������_������, t.����, t.��������
	from ������ t
	where t.���� > 200 WITH CHECK OPTION
	go
	select * from [�������_������]

insert [�������_������] values ('������', 300, '�������')
delete [�������_������] where [�����] = '������'
insert [�������_������] values ('������', 100, '�������(�������)')

DROP VIEW [�������_������]

-------------------------------------

CREATE VIEW [�������_������](�����, ����, ��������)
	as select top 5 t.������������_������, t.����, t.��������
	from ������ t
	order by t.���� desc
	go
	select * from [�������_������]

DROP VIEW [�������_������]

------------------------------------

CREATE VIEW [�������](�����, [���� ������], [���� �������], ��������) WITH SCHEMABINDING
	as select t.������������_������, t.����, (o.���������� * t.����), o.��������
	from dbo.������ t join dbo.������ o
	on t.������������_������ = o.�����
	group by t.������������_������, t.����, o.����������, o.��������
	go
	select * from [�������]

DROP VIEW [�������]