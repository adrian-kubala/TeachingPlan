﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeachingPlan.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TeachingPlan.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO Przedmiot VALUES (@id_rodzaj_zajec, @nazwa, @ects, @godziny);.
        /// </summary>
        internal static string DodajPrzedmiot {
            get {
                return ResourceManager.GetString("DodajPrzedmiot", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT Grupa_dziekanska.Id_grupy, COUNT(Student.Id_studenta) as Ilosc_studentow_w_grupie
        ///FROM Grupa_dziekanska, Student
        ///WHERE Grupa_dziekanska.Id_grupy = 1 AND
        ///	Student.Id_grupy = Grupa_dziekanska.Id_grupy
        ///GROUP BY Grupa_dziekanska.Id_grupy;.
        /// </summary>
        internal static string ilosć_studentów_w_grupie {
            get {
                return ResourceManager.GetString("ilosć_studentów_w_grupie", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT Grupa_dziekanska.Id_grupy, COUNT(DISTINCT Nauczyciel.Id_nauczyciela) as Ilosc_nauczycieli
        ///FROM Nauczyciel, Przedmiot, [PRZEDMIOT-NAUCZYCIEL], [SPECJALNOSC-PRZEDMIOT], Specjalnosc, Kierunek,
        ///	Wydzial, Grupa_dziekanska
        ///WHERE Nauczyciel.Id_nauczyciela = [PRZEDMIOT-NAUCZYCIEL].Id_nauczyciela AND
        ///	[PRZEDMIOT-NAUCZYCIEL].Id_przedmiotu = Przedmiot.Id_przedmiotu AND 
        ///	[SPECJALNOSC-PRZEDMIOT].Id_przedmiotu = Przedmiot.Id_przedmiotu AND
        ///	[SPECJALNOSC-PRZEDMIOT].Id_specjalnosci = Specjalnosc.Id_specjalnos [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ilość_wykładowców_grupy {
            get {
                return ResourceManager.GetString("ilość_wykładowców_grupy", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT Katedra.Nazwa_katedry, COUNT(Nauczyciel.Id_nauczyciela) as Ilosc_nauczycieli_katedry
        ///FROM Katedra, Nauczyciel
        ///WHERE Katedra.Id_katedry = Nauczyciel.Id_katedry AND 
        ///	Katedra.Nazwa_katedry = &apos;Katedra Inzynierii Komputerowej&apos;
        ///GROUP BY Nazwa_katedry;.
        /// </summary>
        internal static string ilość_wykładowców_katedr {
            get {
                return ResourceManager.GetString("ilość_wykładowców_katedr", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT DISTINCT Nazwa_katedry, Przedmiot.Nazwa_przedmiotu, Grupa_dziekanska.Id_grupy, Aktualny_semestr.Id_semestru 
        ///FROM Katedra, Grupa_dziekanska, Nauczyciel, [PRZEDMIOT-NAUCZYCIEL], [SPECJALNOSC-PRZEDMIOT], Przedmiot,
        ///	Specjalnosc, Kierunek, Wydzial, Aktualny_semestr
        ///WHERE Nauczyciel.Id_katedry = Katedra.Id_katedry AND
        ///	[PRZEDMIOT-NAUCZYCIEL].Id_nauczyciela = Nauczyciel.Id_nauczyciela AND
        ///	[PRZEDMIOT-NAUCZYCIEL].Id_przedmiotu = Przedmiot.Id_przedmiotu AND
        ///	[SPECJALNOSC-PRZEDMIOT].Id_przedmiotu = Prz [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string lista_katedr {
            get {
                return ResourceManager.GetString("lista_katedr", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT Grupa_dziekanska.Id_grupy, Imie_studenta, Nazwisko_studenta, Plec_studenta, 
        ///	DATEPART(YYYY, Data_urodzenia_studenta) as Rok_urodzenia_studenta, DATEDIFF(YY, Data_urodzenia_studenta,
        ///	 GETDATE()) as Wiek_studenta, 
        ///	Obecnosc_dzieci_studenta, Obecnosc_stypendium, Rozmiar_stypendium
        ///FROM Wydzial, Grupa_dziekanska, Student
        ///WHERE Student.Id_grupy = Grupa_dziekanska.Id_grupy AND
        ///	Grupa_dziekanska.Id_wydzialu = Wydzial.Id_wydzialu AND Grupa_dziekanska.Id_grupy = 1
        ///	 ORDER BY Nazwisko_studenta;.
        /// </summary>
        internal static string lista_studentów_grupy {
            get {
                return ResourceManager.GetString("lista_studentów_grupy", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT DISTINCT Imie_nauczyciela, Nazwisko_nauczyciela, Grupa_dziekanska.Id_grupy
        ///FROM Nauczyciel, Przedmiot, [PRZEDMIOT-NAUCZYCIEL], [SPECJALNOSC-PRZEDMIOT], Specjalnosc, Kierunek,
        ///	Wydzial, Grupa_dziekanska
        ///WHERE Nauczyciel.Id_nauczyciela = [PRZEDMIOT-NAUCZYCIEL].Id_nauczyciela AND
        ///	[PRZEDMIOT-NAUCZYCIEL].Id_przedmiotu = Przedmiot.Id_przedmiotu AND 
        ///	[SPECJALNOSC-PRZEDMIOT].Id_przedmiotu = Przedmiot.Id_przedmiotu AND
        ///	[SPECJALNOSC-PRZEDMIOT].Id_specjalnosci = Specjalnosc.Id_specjalnosci AND
        ///	Kierun [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string lista_wykładowców_grupy {
            get {
                return ResourceManager.GetString("lista_wykładowców_grupy", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT DISTINCT Nazwa_przedmiotu, Nazwa_studiow as Studia, Nazwa_stopnia as Tryb_studiow, CONCAT (Imie_nauczyciela, &apos; &apos; ,Nazwisko_nauczyciela) as Wykladowca, Nazwa_kategorii as Kategoria, Nazwa_tytulu as Tytul,
        ///	Nazwa_specjalnosci as Specjalnosc,
        ///	substring(
        ///	(
        ///		Select &apos;, &apos; + CAST(GD.Id_grupy as varchar(1)) AS [text()]
        ///		From Grupa_dziekanska GD
        ///		Where GD.Id_wydzialu = Wydzial.Id_wydzialu
        ///		ORDER BY GD.Id_grupy
        ///		For XML PATH (&apos;&apos;)
        ///	), 2, 1000) [Grupy_dziekanskie], Ilosc_godzin, Id_semestru as Num [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string plan_kształcenia {
            get {
                return ResourceManager.GetString("plan_kształcenia", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT Imie_nauczyciela, Nazwisko_nauczyciela, Nazwa_kategorii, Nazwa_tytulu, Plec_nauczyciela, 
        ///DATEPART(YYYY, Data_urodzenia_nauczyciela) as Rok_urodzenia_nauczyciela, DATEDIFF(YY, Data_urodzenia_nauczyciela, 
        ///GETDATE()) as Wiek_nauczyciela, Obecnosc_dzieci_nauczyciela, Ilosc_dzieci, Pensja_nauczyciela
        ///FROM Nauczyciel, Katedra, Kategoria, Tytul
        ///WHERE Nauczyciel.Id_katedry = Katedra.Id_katedry AND
        ///	Katedra.Nazwa_katedry = &apos;Katedra Inzynierii Komputerowej&apos; AND
        ///	Kategoria.Id_kategorii = Nauczyciel.Id_k [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string wykładowcy_katedr {
            get {
                return ResourceManager.GetString("wykładowcy_katedr", resourceCulture);
            }
        }
    }
}
