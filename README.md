Aplikacja Lista 'Todo'

Aplikacja rozproszona typu Client-Server służąca do zarządzania zadaniami. System umożliwia wielu użytkownikom jednoczesną edycję listy zadań, zapewniając synchronizację widoku w czasie rzeczywistym (Real-Time) bez konieczności odświeżania strony.
🚀 Technologie

Projekt został zrealizowany w ekosystemie .NET 8 z wykorzystaniem następujących technologii:

    Język: C#

    Back-End: ASP.NET Core Web API

    Front-End: Blazor WebAssembly

    Komunikacja Real-Time: SignalR

    Baza Danych: Entity Framework Core (In-Memory Database)

    IDE: Visual Studio 2022

📂 Struktura Projektu

Rozwiązanie (Solution) podzielone jest na trzy warstwy:

    Server:

        Udostępnia REST API (GET, POST, DELETE) do zarządzania danymi.

        Zawiera Hub SignalR (TodoHub) do wysyłania powiadomień do klientów.

        Przechowuje logikę bazy danych (EF Core).

    Client:

        Interfejs użytkownika napisany w Blazor WebAssembly.

        Komunikuje się z serwerem przez HTTP (dane) oraz WebSocket/SignalR (powiadomienia).

    Shared:

        Biblioteka współdzielona zawierająca model danych (TodoItem).

        Zapewnia spójność typów między klientem a serwerem.

⚙️ Wymagania

    .NET SDK 8.0 (lub nowszy)

    Visual Studio 2022 (z workloadem "ASP.NET and web development")

▶️ Uruchomienie (Krok po kroku)

    Otwórz projekt: Uruchom plik TodoApp.sln w Visual Studio.

    Przywróć pakiety: Jeśli to konieczne, kliknij prawym przyciskiem myszy na Solucję i wybierz Przywróć pakiety NuGet.

    Skonfiguruj start:

        Kliknij prawym przyciskiem na Solucję -> Ustaw projekty startowe (Set Startup Projects).

        Wybierz Wiele projektów startowych (Multiple startup projects).

        Ustaw akcję Uruchom (Start) dla projektów Server oraz Client.

    Uruchom: Kliknij przycisk Start (zielona strzałka) w Visual Studio.

Otworzą się dwa okna przeglądarki (Serwer/Swagger oraz Klient). Możesz otworzyć adres Klienta w wielu kartach, aby przetestować synchronizację.
✅ Funkcjonalności

    Dodawanie zadań: Nowe zadanie jest wysyłane do API i zapisywane w bazie.

    Usuwanie zadań: Możliwość usunięcia wybranego zadania.

    Synchronizacja w czasie rzeczywistym: Dzięki SignalR, dodanie lub usunięcie zadania w jednym oknie powoduje natychmiastową aktualizację listy u wszystkich innych podłączonych użytkowników.

    Trwałość sesji: Dane są przechowywane w pamięci RAM serwera (InMemory) – resetują się po restarcie serwera.

🔧 Rozwiązywanie problemów

Jeśli wystąpi błąd wersji pakietu Microsoft.EntityFrameworkCore.InMemory:

    Otwórz Menedżer pakietów NuGet dla projektu Server.

    Zmień wersję pakietu z 10.x.x na najnowszą z serii 8.x.x (np. 8.0.11).

    Przebuduj projekt (Rebuild).
