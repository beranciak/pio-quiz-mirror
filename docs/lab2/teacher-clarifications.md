# Doprecyzowania prowadzącego wykorzystane w analizie LAB 2

Notatka porządkuje odpowiedzi prowadzącego przekazane zespołom w materiałach z pytań discovery. Opisuje wskazówki dla docelowego produktu; nie oznacza, że wszystkie funkcje weszły do prototypu.

| Temat | Doprecyzowanie |
| --- | --- |
| Pytania i zestawy | Pytania można wprowadzić w aplikacji albo zaimportować z CSV. Baza SQLite może w przyszłości ułatwić przenoszenie danych między uruchomieniami i komputerami. |
| Identyfikacja | Oceniany test wymaga identyfikatora. Ankieta może być anonimowa. |
| Przerwanie pracy | Plik CSV może służyć jako zapis tymczasowy przed trwałą bazą. Docelowa persystencja w bazie jest wymagana; zapis przy każdej zmianie ogranicza ryzyko utraty danych. |
| Typy pytań | Oczekiwane są pytania zamknięte. Pytania otwarte są dopuszczalne, ale bez automatycznego oceniania i mają niski priorytet. |
| Puste odpowiedzi | Uczestnik może pominąć pytanie. |
| Wybór opcji | Domyślny typ pytania ma jedną poprawną odpowiedź. Wybór wielokrotny jest opcjonalnym rozszerzeniem; interfejs ma nie przyjąć niezgodnej odpowiedzi bez ponowienia lub wyjaśnienia. |
| Import wyników | Różne zestawy wyników zachowujemy. Dokładne ponowne wczytanie tych samych wyników powinno wykryć duplikat i zapytać o zgodę na nadpisanie. Import wsadowy całego folderu jest opcjonalny. |
| Długi import | Jeżeli generowanie statystyk przekracza około 7 sekund, interfejs powinien pokazać postęp. Próg i zachowanie należy dopracować przy implementacji. |
| Zgodność plików | MVP gwarantuje zgodność z jedną wersją formatu CSV. Zgodność wsteczna wersji pośrednich nie jest gwarantowana; polityka przechowywania plików należy do użytkownika. |
| Uruchomienie | Przyjęto, że komputer docelowy ma .NET Runtime. Publikacja self-contained jest dopuszczalna, lecz nie wymagana. Dokładną wersję .NET trzeba sprawdzić dla środowiska zajęć. |

## Zastosowanie do pierwszego przyrostu

Pierwszy przyrost obejmuje quiz oceniany, więc wymaga identyfikatora; pozwala pominąć pytanie; używa pytania zamkniętego z jedną poprawną odpowiedzią; przechowuje podejścia w pamięci do końca procesu. Szczegóły są w [opisie przyrostu](first-increment.md). Pytania otwarte, ankiety anonimowe, import CSV, baza i ochrona przed utratą danych należą do dalszych przyrostów.
