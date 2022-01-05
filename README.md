# Zad1
Usługa wielokontenerowa


Dla zadania zostały przygotowane 4 usługi. Po stronie serwerowej wykorzystano platforme .NET, jako magazyny danych użyto Redisa oraz Microsoft SQL Server. Po stronie klienta wykorzystano Angulara.

![serwisy](https://user-images.githubusercontent.com/51209004/148280211-e068d415-55b0-42b9-b0dc-993713d341cc.PNG)

Aplikacja po stronie serwera działa na porcie 44361. Zastostowano zmienne środowiskowe dla certyfikatów, ponieważ aplikacja napisana w .NET domyślnie przekierowuje na https, dlatego przygotowano odpowiedni certyfikat w folderze conf. Podłączono wolumeny dla aplikacja, ale również dla ścieżki do usersecrets, gdzie mogą być przechowywane klucze. Aplikacja po stronie klienta działa na domyślnym porcie dla Angulara, czyli 4200. Także podłączono wolumeny, które umożliwią śledzenie zmian w kodzie. Do uruchomienia całej usługi wystarczy użyć polecenia docker compose -f docker-compose.dev.yml up --build
Pierwszy screen działającej usługi:

![pierwszy](https://user-images.githubusercontent.com/51209004/148280270-cbc78263-93d0-40ab-b8ca-74ec0244cc50.PNG)

Drugi screen działającej usługi:
![drugi](https://user-images.githubusercontent.com/51209004/148280304-0ad3c911-20b7-4cd8-89ae-918f4726c075.PNG)

Trzeci screen działającej usługi:
![desktop](https://user-images.githubusercontent.com/51209004/148280369-2491b208-c6e2-4b96-b59b-866669fccef2.PNG)
