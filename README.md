# Steganografia

Aplikacja Windows Forms, która ukrywa tekst w obrazku metodą **LSB (Least Significant Bit)** — techniką steganografii, 
	ukrywa że jakakolwiek wiadomość istnieje — z zewnątrz to zwykły obrazek.

## Jak działa aplikacja:

- Należy wybrać obrazek wejściowy (podgląd od razu w oknie, dzięki `PictureBox` z `SizeMode = Zoom`)
- Wpisać dowolny tekst (mogą być użyte polskie znaki, `Encoding.UTF8`)
- Tekst mozna dodatkowo zaszyfrować z użyciem hasła ("Tekst szyfrowany?" [ ]). 
	AES-GCM (używam do tego klasę `Encryptor` z mojego wcześniejszego projektu [Szyfrowanie](https://github.com/Miky1971/Szyfrowanie))
- [Zapisz tekst] - program wkłada tekst w najmłodsze bity kanałów R, G, B kolejnych pikseli i zapisuje nowy plik (bezstratnie, PNG)
- [Odczytaj tekst] - żeby odzyskać tekst, należy wskazać zapisany obrazek (i ew. podać hasło jeśli było szyfrowanie tekstu) 
- Każdy obrazek z ukrytym tekstem posiada swój własny `artefakt` i tylko obrazki zapisane w tym programie można tutaj odczytać.

## Jak działa ukrywanie (w skrócie)

Zmiana ostatniego najmniej znaczącego bitu koloru piksela zmienia jego wartość o maksymalnie 1 (np. 200 → 201) — różnica niewidoczna gołym okiem. 
	Wykorzystuję 3 kanały (R, G, B) na piksel, więc mogę ukryć 3 bity na piksel, bez marnowania miejsca — traktuję wszystkie dane jako jeden ciągły strumień bitów, 
	nie dzielę ich sztywno po znaku.
Wykorzystuje operacje na pojedynczych bitach (przesunięcia bitowe (`<<`, `>>`), maskowanie (`&`, `|`) ), oraz bezpośredni dostępem do pikseli obrazka 
	(`GetPixel`/`SetPixel`, `PictureBoxSizeMode`). 

Przed samym tekstem zapisuję:
1. **Artefakt** (może być dowolnej długości) — żeby przy odczycie od razu wiedzieć, czy dany obrazek w ogóle zawiera coś, co ja tam wstawiłem, 
	czy to zwykłe, nieprzetworzone zdjęcie.
2. **Długość tekstu** (4 bajty) — zapisana bezpośrednio w pliku (liczba int na 4 bajtach), bo obrazek zwykle ma dużo więcej miejsca niż potrzeba, 
	więc czytanie pliku do końca wprowadzało by przypadkowe znaczki (czytelne lub nie).
3. **właściwy tekst** zaszyfrowany lub nie.

## Dlaczego plik wyjściowy jest w PNG, nie JPG?

Plik wynikowy musi być zapisany w formacie **bezstratnym**. JPEG kompresuje obrazek w sposób, który lekko zmienia wartości pikseli — dokładnie te bity, 
	w których jest ukryty tekst, zostałyby zniszczone.

## Wymagania

.NET (Windows Forms) — korzystam wyłącznie z wbudowanych klas (`System.Drawing`, `System.Security.Cryptography`), żadnych dodatkowych pakietów NuGet.
