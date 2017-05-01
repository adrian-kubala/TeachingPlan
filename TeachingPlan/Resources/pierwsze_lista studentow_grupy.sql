SELECT Grupa_dziekanska.Id_grupy, Imie_studenta, Nazwisko_studenta, Plec_studenta, 
	DATEPART(YYYY, Data_urodzenia_studenta) as Rok_urodzenia_studenta, DATEDIFF(YY, Data_urodzenia_studenta,
	 GETDATE()) as Wiek_studenta, 
	Obecnosc_dzieci_studenta, Obecnosc_stypendium, Rozmiar_stypendium
FROM Wydzial, Grupa_dziekanska, Student
WHERE Student.Id_grupy = Grupa_dziekanska.Id_grupy AND
	Grupa_dziekanska.Id_wydzialu = Wydzial.Id_wydzialu AND Grupa_dziekanska.Id_grupy = 1
	 ORDER BY Nazwisko_studenta;