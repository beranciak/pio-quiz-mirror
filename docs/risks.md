# Ryzyka projektu

Top-5 ryzyk dla projektu Quiz / Ankieta na etapie discovery i analizy.

**Skala L/M/H** (propozycja zespołu, nie wynik pomiaru):

| Poziom | Prawdopodobieństwo | Wpływ |
| --- | --- | --- |
| L (niskie) | Mało prawdopodobne przy znanych warunkach. | Drobna niedogodność możliwa do opanowania w bieżącej pracy. |
| M (średnie) | Realna możliwość, mamy powody ją rozważyć. | Wyraźne opóźnienie lub przeplanowanie części pracy. |
| H (wysokie) | Silne przesłanki, że wystąpi. | Zagrożenie kluczowego zakresu, jakości lub terminu oddania. |

Pole „Osoba odpowiedzialna” trzeba uzupełnić po uzgodnieniu w zespole. Właściciel pilnuje ryzyka i sygnału do reakcji, ale nie musi sam wykonywać wszystkich działań.

### R1: Niejasne wymagania dotyczące wyników, odpowiedzi i anonimowości

**Opis:** Wizja zostawia otwarte pytania: czym różnią się wyniki quizu i ankiety, co oznacza „odpowiedź”, jak ocenia się pytania wielokrotnego wyboru, czy odpowiedzi są anonimowe. Jeśli przyjmiemy złe założenia, zbudujemy zły model danych i będziemy musieli przerabiać gotowe części.

**Prawdopodobieństwo:** H. Kilka istotnych pytań nadal nie ma odpowiedzi sponsora.

**Wpływ:** H. Odpowiedzi wpływają na model danych, CSV, wyniki i kontrakt dialogu.

**Strategia:** Łagodzenie.

**Działanie:** Opublikować pytania do sponsora na głównym kanale przedmiotu w MS Teams przed LAB 2. W dokumentach oznaczać każdy domysł jako założenie, a nie ustalenie.

**Osoba odpowiedzialna:** [do uzgodnienia w zespole]

**Sygnał do reakcji:** Brak odpowiedzi sponsora na kluczowe pytania do rozpoczęcia projektowania na LAB 2.

**Reakcja:** Przyjąć jawne założenia robocze, zaprojektować model tak, by późniejsza zmiana była tania, i potwierdzić założenia na zajęciach.

### R2: Utrata odpowiedzi lub zestawów przy danych tylko w pamięci

**Opis:** Dane na początku są tylko w pamięci operacyjnej. Jeśli program zostanie zamknięty lub zawiesi się, zanim prowadzący wyeksportuje wyniki lub uczestnik zapisze odpowiedzi, wynik zajęć przepadnie.

**Prawdopodobieństwo:** M. W typowych warunkach łatwo o przypadkowe zamknięcie okna konsoli.

**Wpływ:** H. Utrata wyników całej grupy nie do odtworzenia.

**Strategia:** Łagodzenie.

**Działanie:** Zapisać w kontrakcie ostrzeżenie przy zamykaniu programu, gdy są niewyeksportowane dane. Zapytać sponsora o oczekiwany poziom ochrony (kopie, odtwarzanie). Zaplanować trwały zapis na etap trwałości danych (LAB 3).

**Osoba odpowiedzialna:** [do uzgodnienia w zespole]

**Sygnał do reakcji:** Podczas przećwiczenia dialogu użytkownik kończy program z niewyeksportowanymi danymi.

**Reakcja:** Wzmocnić ostrzeżenie lub zapis automatyczny, uzgodnić zmianę ze sponsorem.

### R3: Problemy z formatem CSV i wymianą plików

**Opis:** Różne separatory, kodowanie, polskie znaki, cudzysłowy w treści pytań, zduplikowane lub niezgodne pliki odpowiedzi mogą dać błędne wyniki albo plik nieczytelny w Excelu.

**Prawdopodobieństwo:** H. Excel różnie traktuje separatory i kodowanie, a pliki zbiera się ręcznie.

**Wpływ:** M. Błędy da się wykryć i naprawić, ale psują wiarygodność wyników i opóźniają import oraz eksport.

**Strategia:** Łagodzenie.

**Działanie:** Zdefiniować schemat CSV (nagłówki, separator, kodowanie) z przykładowymi plikami i sprawdzić ich otwieranie w Excelu. Przy imporcie walidować pliki i raportować pominięte wraz z powodem.

**Osoba odpowiedzialna:** [do uzgodnienia w zespole]

**Sygnał do reakcji:** Przykładowy plik otwiera się w Excelu w jednej kolumnie lub z błędnymi znakami.

**Reakcja:** Zmienić kodowanie lub separator i zaktualizować kontrakt oraz kryteria akceptacji.

### R4: Środowisko docelowe bez wymaganego .NET lub z blokadą uruchamiania

**Opis:** Komputery uczelniane z Windows 11 bez internetu mogą nie mieć środowiska .NET albo blokować uruchamianie nieznanych programów. Wtedy aplikacja nie uruchomi się na zajęciach.

**Prawdopodobieństwo:** M. Nie sprawdziliśmy konfiguracji komputerów.

**Wpływ:** H. Wizja wymaga uruchamiania bez złożonej instalacji; brak uruchomienia przekreśla wartość produktu.

**Strategia:** Łagodzenie.

**Działanie:** Zapytać sponsora, co jest zainstalowane na komputerach i jak przekazywać aplikację. Zaplanować wydanie możliwe do uruchomienia bez instalacji i sprawdzić je na „czystym” komputerze.

**Osoba odpowiedzialna:** [do uzgodnienia w zespole]

**Sygnał do reakcji:** Brak potwierdzenia dostępnego środowiska do LAB 3 albo nieudane uruchomienie na komputerze testowym.

**Reakcja:** Przejść na wariant wydania niezależny od zainstalowanego środowiska i zaktualizować opis uruchomienia.

### R5: Rozproszona praca zespołu i nierówny postęp między zajęciami

**Opis:** Większość pracy odbywa się asynchronicznie między rzadkimi spotkaniami. Brak aktualnych zadań i statusów może prowadzić do dublowania pracy, konfliktów scalania i niedomkniętego zakresu przed kolejnym LAB-em.

**Prawdopodobieństwo:** M. Praca poza salą i wiele zależnych dokumentów.

**Wpływ:** H. Opóźnienie lub niespójny produkt zespołu; wkład każdej osoby musi być widoczny w repozytorium.

**Strategia:** Łagodzenie.

**Działanie:** Prowadzić pracę przez Issues z przypisaną osobą i aktualnymi statusami na tablicy. Przeglądać tablicę regularnie na kanale zespołu i dzielić pracę na małe PR-y.

**Osoba odpowiedzialna:** [do uzgodnienia w zespole]

**Sygnał do reakcji:** Zadanie w statusie In progress bez aktywności przez ustalony przez zespół czas (propozycja: 3 dni) albo PR czekający na review dłużej niż ustalony czas.

**Reakcja:** Zgłosić bloker na kanale zespołu, podzielić zadanie na mniejsze lub przydzielić drugą osobę do pomocy.

## Rozważone, poza Top-5

- **Wydajność przy dużej liczbie odpowiedzi** (kilkaset quizów, dziesiątki tysięcy odpowiedzi): ryzyko realne, ale skala jest niewielka dla współczesnego komputera, a progi czasowe czekają na ustalenia ze sponsorem. Wrócimy do niego przy projektowaniu i pomiarach.
- **Aktualizacja aplikacji bez utraty danych:** dotyczy etapu trwałości danych; rozważymy przy wyborze sposobu zapisu.
