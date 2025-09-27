# Mobile-RankingSystem-

This repository hosts an MVP for a .NET MAUI application that ranks people who compete in two-player teams. The ranking is determined by the outcomes of matches that can involve more than two teams. The app also demonstrates how to automatically build balanced teams from a pool of available players.

## Project structure

- `MobileRankingSystem.sln` – Visual Studio solution that references the MAUI project.
- `MobileRankingSystem/` – .NET MAUI single-project structure containing:
  - `App.xaml` / `App.xaml.cs` – application resources and bootstrap logic.
  - `AppShell.xaml` – shell navigation definition.
  - `MainPage.xaml` – first screen that lists calculated team rankings.
  - `Models/` – core domain entities such as players, teams, and match results.
  - `Services/RankingService.cs` – logic for creating balanced teams and converting match results into a ranking table.
  - `ViewModels/RankingViewModel.cs` – sample data pipeline that powers the UI.
  - `Platforms/Android` and `Platforms/iOS` – platform entry points and manifests required by the MAUI tooling.
  - `Resources/` – shared fonts, styles, splash screen, and app icon assets used by both platforms.

## Current functionality

- Builds a set of balanced teams from a list of players with individual skill ratings.
- Calculates league-style standings using recent match results (win = 3 points, draw = 1 point).
- Presents the ranking in a simple UI backed by an observable collection.
- Highlights upcoming improvements for persistence, manual match entry, and cloud sync.

## Getting started

> **Note:** The container used to author this repository does not ship with the .NET SDK or MAUI workloads, so the project cannot be compiled here. The project files were created manually following the default MAUI single-project pattern.

1. Install the [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download) and the required MAUI workloads for Android (add iOS support if you're on macOS) by following the [official setup guide](https://learn.microsoft.com/dotnet/maui/get-started/installation).
2. Clone the repository and open `MobileRankingSystem.sln` in Visual Studio 2022 (17.8 or later) or run `dotnet build MobileRankingSystem.sln` from a terminal with the MAUI workloads installed.
3. In Visual Studio, ensure that the **MobileRankingSystem** project is set as the startup project and choose an Android emulator or device from the run target dropdown before pressing **Run**. The included Android and iOS platform heads provide the necessary entry points for deployment.
4. Deploy primarily to Android (emulator or device); if you have access to the necessary tooling on macOS you can also target iOS from Visual Studio or the `dotnet` CLI.

## Next steps

- Persist match history and player profiles in a lightweight database such as SQLite.
- Provide UI flows for creating matches, editing scores, and adjusting teams.
- Integrate authentication and real-time sync for league play.
