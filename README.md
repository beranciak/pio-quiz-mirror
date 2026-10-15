# Quiz / Ankieta

Konsolowa aplikacja w C#/.NET do przygotowywania quizów i ankiet oraz zbierania odpowiedzi. Projekt jest rozwijany przyrostowo przez semestr jako wspólna praca zespołu.

## Problem

Rozbudowane narzędzia online bywają niepotrzebnie złożone przy prostych zadaniach dydaktycznych i ewaluacyjnych. W salach komputerowych przeszkadzają też niestabilny internet, logowanie i ograniczenia IT, a rozproszone wyniki utrudniają przygotowanie ocen i raportów.

## Dla kogo

- **Prowadzący, trenerzy i HR** chcą szybko przygotować zestaw i zebrać wyniki bez kont oraz dostępu do sieci.
- **Studenci i uczestnicy szkoleń** chcą łatwo udzielić odpowiedzi i otrzymać czytelny rezultat.
- **Uczelnie i firmy** potrzebują prostego narzędzia do pracy offline, również na słabszych komputerach.

## Cel i założenia

- Aplikacja działa w konsoli i nie wymaga przeglądarki, konta ani połączenia z internetem.
- Odpowiedzi są początkowo przechowywane w pamięci operacyjnej. Sposób trwałego zapisu wybierzemy po analizie wymagań biznesowych i technicznych.
- Import i eksport danych będą obsługiwać pliki CSV.
- Rozwiązanie i decyzje projektowe będą doprecyzowywane przez zespół na podstawie wspólnych wymagań kursu.

Szczegółowe wymagania, przypadki użycia, wstępne User Stories i propozycję kontraktu CLI opisuje [dokument wymagań](docs/wymagania.md). Zasady rozwoju, pracy na laboratoriach, GitHub Flow oraz kryteria DoR i DoD znajdują się w [opisie procesu zespołowego](docs/proces-zespolowy.md).

## Zespół

- Paweł Kościelak
- Jakub Świątek
- Mikołaj Bernaciak
- Karol Staszewski

## Jak rozwijamy projekt

Projekt rozwijamy przyrostowo przez cały semestr. Laboratoria pomagają rozpocząć kolejne etapy, przećwiczyć techniki, omówić problemy i ustalić dalsze zadania. Większość pracy nad projektem wykonujemy między zajęciami.

Pracujemy iteracyjnie przez etapy SDLC: **discovery → analiza → projektowanie → implementacja → weryfikacja → wydanie**. Wracamy do nich przy kolejnych przyrostach i zmianach wymagań.

## Współpraca i GitHub Flow

Zmiany realizujemy przez `Issue` → `branch` → `Pull Request (PR)` → `review` → `merge`. Proces ćwiczymy na laboratoriach; od drugiego warsztatu nie commitujemy bezpośrednio do gałęzi `main`.

Pracę organizujemy na tablicy GitHub Projects:

- **To do** — zadanie jest gotowe do rozpoczęcia.
- **In progress** — ktoś pracuje nad zadaniem.
- **In review** — PR czeka na sprawdzenie przez inną osobę.
- **Done** — PR został zaakceptowany i scalony, uwagi rozpatrzono, a powiązane Issue zamknięto.

Przed rozpoczęciem zadanie powinno spełniać **Definition of Ready (DoR)**. Uznajemy je za zakończone po spełnieniu **Definition of Done (DoD)**. Proponowane checklisty i zasady review są w [opisie procesu zespołowego](docs/proces-zespolowy.md).

## Komunikacja

- Pytania z fazy *discovery* i odpowiedzi prowadzącego publikujemy na głównym kanale przedmiotu w MS Teams.
- Sprawy organizacyjne, konsultacje, problemy i blokery omawiamy na wewnętrznym kanale zespołu w MS Teams.
