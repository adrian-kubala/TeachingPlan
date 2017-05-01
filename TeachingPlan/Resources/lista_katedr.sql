SELECT DISTINCT Nazwa_katedry, Przedmiot.Nazwa_przedmiotu, Grupa_dziekanska.Id_grupy, Aktualny_semestr.Id_semestru 
FROM Katedra, Grupa_dziekanska, Nauczyciel, [PRZEDMIOT-NAUCZYCIEL], [SPECJALNOSC-PRZEDMIOT], Przedmiot,
	Specjalnosc, Kierunek, Wydzial, Aktualny_semestr
WHERE Nauczyciel.Id_katedry = Katedra.Id_katedry AND
	[PRZEDMIOT-NAUCZYCIEL].Id_nauczyciela = Nauczyciel.Id_nauczyciela AND
	[PRZEDMIOT-NAUCZYCIEL].Id_przedmiotu = Przedmiot.Id_przedmiotu AND
	[SPECJALNOSC-PRZEDMIOT].Id_przedmiotu = Przedmiot.Id_przedmiotu AND
	[SPECJALNOSC-PRZEDMIOT].Id_specjalnosci = Specjalnosc.Id_specjalnosci AND
	Specjalnosc.Id_kierunku = Kierunek.Id_kierunku AND
	Wydzial.Id_wydzialu = Kierunek.Id_wydzialu AND
	Grupa_dziekanska.Id_wydzialu = Wydzial.Id_wydzialu AND
	Aktualny_semestr.Id_semestru = Grupa_dziekanska.Id_semestru AND
	Grupa_dziekanska.Id_grupy = 1 AND Aktualny_semestr.Id_semestru = 6;