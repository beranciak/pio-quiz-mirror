# Proces pracy zespołu

## Praca przez semestr

Projekt rozwijamy przyrostowo przez cały semestr. Wszystkie zespoły pracują nad tym samym tematem i według wspólnego harmonogramu. Punktem wyjścia są wspólne, ogólne wymagania; zespół analizuje je, doprecyzowuje i samodzielnie uzasadnia decyzje projektowe.

Większość pracy nad projektem wykonujemy między laboratoriami. Zajęcia pomagają rozpocząć kolejne etapy, przećwiczyć techniki, omówić trudności, sprawdzić kierunek pracy i ustalić zadania przed następnym spotkaniem. Informacja zwrotna ma charakter bieżący, a ocena punktowa następuje na koniec semestru.

## SDLC

Proces jest iteracyjny — kolejne przyrosty i zmiany wymagań mogą wymagać powrotu do wcześniejszych etapów.

| Etap | Cel |
| --- | --- |
| **Discovery** | Poznajemy problem, użytkowników, potrzeby, cele produktu i ryzyka. |
| **Analiza** | Doprecyzowujemy wymagania, przypadki użycia i kryteria akceptacji. |
| **Projektowanie** | Ustalamy architekturę i projekt rozwiązania oraz uzasadniamy decyzje. |
| **Implementacja** | Budujemy działający przyrost produktu. |
| **Weryfikacja** | Sprawdzamy działanie, jakość i spełnienie kryteriów akceptacji. |
| **Wydanie** | Przygotowujemy i przekazujemy gotową wersję. |

## Typowy przebieg laboratorium

1. **Cel i kontekst** — co rozwijamy i jak łączy się to z dotychczasową pracą.
2. **Wprowadzenie lub pokaz** — pojęcie, technika albo narzędzie potrzebne do zadania.
3. **Warsztat zespołowy** — zastosowanie omawianych zagadnień w projekcie.
4. **Przegląd i konsultacje** — omówienie rezultatów, problemów i wskazówek.
5. **Dalsza praca** — ustalenie, co dokończyć lub przygotować przed kolejnym LAB-em.

### LAB 1 — discovery, wymagania i GitHub Flow (90 minut)

Pierwsze laboratorium obejmuje rozpoznanie celu, użytkowników, potrzeb, ograniczeń i ryzyk projektu oraz wprowadzenie do repozytorium i docelowego produktu. Zespół poznaje podstawy Git i GitHub Projects: pierwsze zmiany, Issues, tablicę, odpowiedzialność i statusy zadań.

W części warsztatowej zespół przygotowuje przypadki użycia, User Stories, kryteria akceptacji i kontrakt CLI. Ćwiczy przepływ `Issue` → `branch` → `PR` → `review` → `merge`, rozwiązywanie konfliktu scalania i code review. Omawia też gotowość i zakończenie zadań przez DoR i DoD.

**Rezultat:** wspólne rozumienie projektu, wstępne ustalenia discovery, repozytorium i tablica zadań, opis wymagań i kontraktu oraz przećwiczony proces pracy nad zmianą.

## GitHub Flow

Każde zadanie prowadzimy przez `Issue` → `branch` → `Pull Request (PR)` → `review` → `merge`.

- Issue opisuje problem, cel, zakres i kryteria akceptacji.
- Pracę wykonujemy na osobnej gałęzi powiązanej z Issue.
- PR opisuje zmianę i umożliwia jej przegląd przez inną osobę.
- Autor odpowiada na uwagi i aktualizuje zmianę.
- Po akceptacji PR scalany jest z `main`, a powiązane Issue zamykane.
- Od drugiego warsztatu nie commitujemy bezpośrednio do `main`.

## Code review

Podczas review sprawdzamy dokumentację, kod i pozostałe wprowadzane zmiany. Oceniamy zgodność z zasadami kursu, celem Issue i kryteriami akceptacji, czytelność oraz użyteczność rozwiązania. Zmianę akceptujemy, gdy rezultat został sprawdzony, uwagi wyjaśniono lub uwzględniono, a kryteria DoD są spełnione.

## Tablica GitHub Projects

- **To do** — zadanie spełnia DoR i czeka na rozpoczęcie.
- **In progress** — praca nad zadaniem trwa.
- **In review** — PR jest gotowy i czeka na sprawdzenie.
- **Done** — PR zaakceptowano i scalono, uwagi rozpatrzono, Issue zamknięto, a karta otrzymała status Done.

## Definition of Ready (DoR)

Zadanie jest gotowe do rozpoczęcia, gdy:

- jasno określono problem, cel i użytkownika lub odbiorcę;
- zakres jest zrozumiały i wystarczająco mały do realizacji;
- kryteria akceptacji są konkretne i możliwe do sprawdzenia;
- znane zależności, ryzyka i pytania wymagające decyzji są zapisane;
- zespół rozumie, jaki rezultat ma powstać.

## Definition of Done (DoD)

Zadanie jest zakończone, gdy:

- spełniono kryteria akceptacji powiązanego Issue;
- kod lub dokumentacja są kompletne i spójne z projektem;
- przeprowadzono odpowiednią weryfikację i opisano jej wynik;
- inny członek zespołu wykonał review, a uwagi zostały rozpatrzone;
- PR został zaakceptowany i scalony z `main`;
- Issue zamknięto, a kartę na GitHub Projects przeniesiono do Done.

DoR i DoD są wstępną propozycją zespołu; możemy doprecyzować je w miarę zdobywania doświadczenia.

## Komunikacja

- Pytania z fazy *discovery* i odpowiedzi prowadzącego publikujemy na głównym kanale przedmiotu w MS Teams.
- Bieżące sprawy organizacyjne, konsultacje, problemy zespołu i blokery, na przykład konflikty scalania, omawiamy na wewnętrznym kanale zespołu w MS Teams.
