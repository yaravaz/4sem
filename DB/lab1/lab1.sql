SELECT ����_��������, ������������_������
FROM     ������
WHERE  (����_�������� > CONVERT(DATETIME, '2023-01-01 00:00:00', 102))
SELECT ����, ������������
FROM     ������
WHERE  (���� > 5 AND ���� < 20)
SELECT ������.������������_������, ���������.������������_�����
FROM     ��������� INNER JOIN
                  ������ ON ���������.������������_����� = ������.��������
WHERE  (������.������������_������ = N'������')
SELECT ���������.������������_�����, ������.������������_������, ������.����_��������
FROM     ��������� INNER JOIN
                  ������ ON ���������.������������_����� = ������.��������
WHERE  (���������.������������_����� = N'����')
ORDER BY ������.����_��������