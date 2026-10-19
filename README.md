# RezeptApi

Kleine REST-API für Rezepte, gebaut mit C# und ASP.NET Core (.NET 10).

Das Projekt ist ein Lernprojekt: Ich wollte ausprobieren, wie sich .NET im Vergleich zu Java und Spring Boot anfühlt, mit dem ich bisher gearbeitet habe. Die Rezepte liegen nur im Speicher und sind nach einem Neustart weg.

## Starten

Voraussetzung: [.NET SDK](https://dotnet.microsoft.com/download) (getestet mit 10.0).

```bash
dotnet run --project src/RezeptApi --launch-profile http
```

Die API läuft danach unter `http://localhost:5131`.

## Tests

```bash
dotnet test
```

## Endpoints

| Methode | Pfad | Beschreibung |
| --- | --- | --- |
| GET | `/api/recipes` | Alle Rezepte |
| GET | `/api/recipes/{id}` | Ein Rezept (404, wenn es fehlt) |
| POST | `/api/recipes` | Rezept anlegen (`title` ist Pflicht, sonst 400) |
| PUT | `/api/recipes/{id}` | Rezept ändern (404, wenn es fehlt) |
| DELETE | `/api/recipes/{id}` | Rezept löschen (404, wenn es fehlt) |

Beispiel:

```bash
curl -X POST http://localhost:5131/api/recipes \
  -H "Content-Type: application/json" \
  -d '{"title":"Pasta","ingredients":["Nudeln","Tomaten"],"instructions":"Kochen."}'
```

## Aufbau

- `src/RezeptApi/Models` – Datenklasse `Recipe`
- `src/RezeptApi/Services` – Logik (`IRecipeService`, `RecipeService`)
- `src/RezeptApi/Controllers` – HTTP-Endpoints
- `tests/RezeptApi.Tests` – Unit-Tests mit xUnit für den Service
