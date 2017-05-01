SELECT Grupa_dziekanska.Id_grupy, COUNT(Student.Id_studenta) as Ilosc_studentow_w_grupie
FROM Grupa_dziekanska, Student
WHERE Grupa_dziekanska.Id_grupy = 1 AND
	Student.Id_grupy = Grupa_dziekanska.Id_grupy
GROUP BY Grupa_dziekanska.Id_grupy;