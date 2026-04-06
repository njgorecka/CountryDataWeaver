# CountryDataWeaver API

Prosta aplikacja Web API napisana w ASP.NET Core, która pobiera dane o krajach z publicznego API, zapisuje je w bazie SQLite oraz udostępnia własne endpointy do ich przeglądania i analizy.


I. Funkcjonalności

- Import danych o krajach z zewnętrznego API
- Zapis danych w lokalnej bazie SQLite
- Wyszukiwanie krajów po nazwie
- Statystyki (liczba krajów, regiony, najludniejszy kraj)


II. Technologie

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger (Swashbuckle)


III. Uruchomienie projektu

1. Sklonuj repozytorium

```bash
git clone https://github.com/njgorecka/CountryDataWeaver.git
cd CountryDataWeaver
```

2. Zainstaluj zależności

```bash
dotnet restore
```

3.Wykonaj migrację bazy danych

```bash
dotnet ef database update
```

4. Uruchom aplikację

```bash
dotnet run
```


IV. Endpointy API

1. Import danych
	POST /api/Countries/import - Pobiera dane z zewnętrznego API i zapisuje je do bazy.

2. Lista krajów
	GET /api/Countries - Wyświetla listę wszystkich krajów znajdujących się w bazie.

3. Wyszukiwanie
	GET /api/Countries/search?name=pol - Wyszukuje kraje na podstawie fragmentu nazwy podanego przez użytkownika (ten przykład zwraca m.in. Poland)

4. Statystyki
	GET /api/Countries/stats - Zwraca podstawowe statystyki (liczbę krajów, unikalnych regionów oraz najludniejszy kraj).


V. Struktura projektu

- Controllers/
- Data/
- Models/
- Services/


VI. Dodatkowe informacje

- Aplikacja zapobiega dodawaniu duplikatów podczas importu
- Dane przechowywane są lokalnie w pliku countries.db
- Dokumentacja API dostępna w Swagger UI:
	/swagger


VII. Podgląd

Po uruchomieniu aplikacji dokumentacja Swagger UI jest dostępna pod adresem:

	http://localhost:<port>/swagger


