SELECT Specjalnosc.Nazwa_specjalnosci, Nauczyciel.Imie_nauczyciela, Nauczyciel.Nazwisko_nauczyciela, Aktualny_semestr.Id_semestru, SUM(DISTINCT Przedmiot.Ilosc_godzin) as Obciazenie
FROM Rodzaj_zajec, Przedmiot, [SPECJALNOSC-PRZEDMIOT], Specjalnosc, Kierunek, Wydzial, Grupa_dziekanska, Aktualny_semestr,
	[PRZEDMIOT-NAUCZYCIEL], Nauczyciel
WHERE Rodzaj_zajec.Id_rodzaju_zajec = Przedmiot.Id_rodzaju_zajec AND
	Przedmiot.Id_przedmiotu = [SPECJALNOSC-PRZEDMIOT].Id_przedmiotu AND
	[SPECJALNOSC-PRZEDMIOT].Id_specjalnosci = Specjalnosc.Id_specjalnosci AND
	Specjalnosc.Id_kierunku = Kierunek.Id_kierunku AND
	Kierunek.Id_wydzialu = Wydzial.Id_wydzialu AND
	Wydzial.Id_wydzialu = Grupa_dziekanska.Id_wydzialu AND
	Grupa_dziekanska.Id_semestru = Aktualny_semestr.Id_semestru AND
	Przedmiot.Id_przedmiotu = [PRZEDMIOT-NAUCZYCIEL].Id_przedmiotu AND
	[PRZEDMIOT-NAUCZYCIEL].Id_nauczyciela = Nauczyciel.Id_nauczyciela AND
	Specjalnosc.Nazwa_specjalnosci = 'Technologie Internetowe i Mobilne'
GROUP BY Specjalnosc.Nazwa_specjalnosci, Nauczyciel.Imie_nauczyciela, Nauczyciel.Nazwisko_nauczyciela, Aktualny_semestr.Id_semestru
ORDER BY Nazwisko_nauczyciela