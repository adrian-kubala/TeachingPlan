SELECT Katedra.Nazwa_katedry, COUNT(Nauczyciel.Id_nauczyciela) as Ilosc_nauczycieli_katedry
FROM Katedra, Nauczyciel
WHERE Katedra.Id_katedry = Nauczyciel.Id_katedry AND 
	Katedra.Nazwa_katedry = 'Katedra Inzynierii Komputerowej'
GROUP BY Nazwa_katedry;