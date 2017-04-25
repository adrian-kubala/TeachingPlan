SELECT DISTINCT Nazwa_przedmiotu, Nazwa_studiow as Studia, Nazwa_stopnia as Tryb_studiow, CONCAT (Imie_nauczyciela, ' ' ,Nazwisko_nauczyciela) as Wykladowca, Nazwa_kategorii as Kategoria, Nazwa_tytulu as Tytul,
	Nazwa_specjalnosci as Specjalnosc,
	substring(
	(
		Select ', ' + CAST(GD.Id_grupy as varchar(1)) AS [text()]
		From Grupa_dziekanska GD
		Where GD.Id_wydzialu = Wydzial.Id_wydzialu
		ORDER BY GD.Id_grupy
		For XML PATH ('')
	), 2, 1000) [Grupy_dziekanskie], Ilosc_godzin, Id_semestru as Numer_semestru, Nazwa_rodzaju_zajec as Tryb_zajec, Punkty_ECTS

FROM Przedmiot, [SPECJALNOSC-PRZEDMIOT], Specjalnosc, Kierunek, Wydzial, Grupa_dziekanska, Studia, Stopien_studiow, [PRZEDMIOT-NAUCZYCIEL], Nauczyciel, Kategoria, Tytul, Rodzaj_zajec
WHERE Przedmiot.Id_przedmiotu = [SPECJALNOSC-PRZEDMIOT].Id_przedmiotu AND
	[SPECJALNOSC-PRZEDMIOT].Id_specjalnosci = Specjalnosc.Id_specjalnosci AND
	Specjalnosc.Id_kierunku = Kierunek.Id_kierunku AND
	Kierunek.Id_wydzialu = Wydzial.Id_wydzialu AND
	Wydzial.Id_wydzialu = Grupa_dziekanska.Id_wydzialu AND
	Grupa_dziekanska.Id_studiow = Studia.Id_studiow AND
	Grupa_dziekanska.Id_stopnia_studiow = Stopien_studiow.Id_stopnia_studiow AND
	[PRZEDMIOT-NAUCZYCIEL].Id_przedmiotu = Przedmiot.Id_przedmiotu AND
	[PRZEDMIOT-NAUCZYCIEL].Id_nauczyciela = Nauczyciel.Id_nauczyciela AND
	Kategoria.Id_kategorii = Nauczyciel.Id_kategorii AND
	Tytul.Id_tytulu = Nauczyciel.Id_tytulu AND
	Przedmiot.Id_rodzaju_zajec = Rodzaj_zajec.Id_rodzaju_zajec
