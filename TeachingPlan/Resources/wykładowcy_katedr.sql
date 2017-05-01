SELECT Imie_nauczyciela, Nazwisko_nauczyciela, Nazwa_kategorii, Nazwa_tytulu, Plec_nauczyciela, 
DATEPART(YYYY, Data_urodzenia_nauczyciela) as Rok_urodzenia_nauczyciela, DATEDIFF(YY, Data_urodzenia_nauczyciela, 
GETDATE()) as Wiek_nauczyciela, Obecnosc_dzieci_nauczyciela, Ilosc_dzieci, Pensja_nauczyciela
FROM Nauczyciel, Katedra, Kategoria, Tytul
WHERE Nauczyciel.Id_katedry = Katedra.Id_katedry AND
	Katedra.Nazwa_katedry = 'Katedra Inzynierii Komputerowej' AND
	Kategoria.Id_kategorii = Nauczyciel.Id_kategorii AND
	Nauczyciel.Id_tytulu = Tytul.Id_tytulu;