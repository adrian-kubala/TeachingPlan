SELECT DISTINCT Imie_nauczyciela, Nazwisko_nauczyciela, Grupa_dziekanska.Id_grupy
FROM Nauczyciel, Przedmiot, [PRZEDMIOT-NAUCZYCIEL], [SPECJALNOSC-PRZEDMIOT], Specjalnosc, Kierunek,
	Wydzial, Grupa_dziekanska
WHERE Nauczyciel.Id_nauczyciela = [PRZEDMIOT-NAUCZYCIEL].Id_nauczyciela AND
	[PRZEDMIOT-NAUCZYCIEL].Id_przedmiotu = Przedmiot.Id_przedmiotu AND 
	[SPECJALNOSC-PRZEDMIOT].Id_przedmiotu = Przedmiot.Id_przedmiotu AND
	[SPECJALNOSC-PRZEDMIOT].Id_specjalnosci = Specjalnosc.Id_specjalnosci AND
	Kierunek.Id_kierunku = Specjalnosc.Id_kierunku AND
	Wydzial.Id_wydzialu = Kierunek.Id_wydzialu AND
	Grupa_dziekanska.Id_wydzialu = Wydzial.Id_wydzialu AND
	Grupa_dziekanska.Id_grupy = 3;