# LOL Ranked Data

A .NET MAUI desktop application for fetching and displaying League of Legends ranked game data.

## Features

- **Account Lookup**: Search for players using their Riot ID (GameName#TagLine)
- **Ranked Stats**: View Solo/Duo and Flex queue rankings, LP, wins/losses, and win rate
- **Match History**: Browse detailed ranked game history including:
  - Champion played
  - Role/Position
  - KDA (Kills/Deaths/Assists)
  - CS (Creep Score)
  - Vision Score
  - Damage dealt to champions
  - Game duration and date
- **Multi-Region Support**: Search players across all major regions (NA, EUW, EUN, KR, etc.)

## Requirements

- Windows 10 version 17763 or higher
- .NET 8.0 SDK
- Visual Studio 2022 with .NET MAUI workload
- Riot Games API Key (get one at [developer.riotgames.com](https://developer.riotgames.com))

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/IsFriskis/lolrankeddata.git
cd lolrankeddata
```

### 2. Get a Riot API Key

1. Visit [developer.riotgames.com](https://developer.riotgames.com)
2. Log in with your Riot Games account
3. Generate a Development API Key (valid for 24 hours) or apply for a Production Key

### 3. Build and Run

Open the solution in Visual Studio 2022 and run the project, or use the command line:

```bash
cd LolRankedData
dotnet build -f net8.0-windows10.0.19041.0
dotnet run -f net8.0-windows10.0.19041.0
```

## Usage

1. Enter your Riot API Key in the API Key field
2. Select your region (e.g., euw1, na1, kr)
3. Enter the player's Game Name and Tag Line (e.g., "SummonerName" and "EUW")
4. Choose how many matches to fetch (10-100)
5. Click "Fetch Data" to retrieve ranked game data

## Project Structure

```
LolRankedData/
├── Models/                 # Data models for Riot API responses
│   ├── Summoner.cs
│   ├── LeagueEntry.cs
│   ├── Match.cs
│   ├── MatchInfo.cs
│   ├── MatchParticipant.cs
│   ├── MatchTeam.cs
│   ├── RiotAccount.cs
│   └── RankedGameDisplay.cs
├── Services/               # API service layer
│   ├── IRiotApiService.cs
│   └── RiotApiService.cs
├── ViewModels/             # MVVM view models
│   └── MainViewModel.cs
├── Views/                  # UI pages
│   ├── MainPage.xaml
│   └── MainPage.xaml.cs
├── Converters/             # Value converters for XAML
│   ├── StringToBoolConverter.cs
│   └── ObjectToBoolConverter.cs
├── Resources/              # App resources
│   └── Styles/
│       ├── Colors.xaml
│       └── Styles.xaml
└── Platforms/              # Platform-specific code
    └── Windows/
```

## API Endpoints Used

This application uses the following Riot Games API endpoints:

- **Account-V1**: `/riot/account/v1/accounts/by-riot-id/{gameName}/{tagLine}`
- **Summoner-V4**: `/lol/summoner/v4/summoners/by-puuid/{puuid}`
- **League-V4**: `/lol/league/v4/entries/by-summoner/{summonerId}`
- **Match-V5**: `/lol/match/v5/matches/by-puuid/{puuid}/ids`
- **Match-V5**: `/lol/match/v5/matches/{matchId}`

## Technologies

- **.NET 8.0**: Latest .NET framework
- **.NET MAUI**: Cross-platform UI framework
- **CommunityToolkit.Mvvm**: MVVM helpers and source generators
- **System.Text.Json**: JSON serialization for API responses

## License

This project is for educational purposes. League of Legends and Riot Games are trademarks of Riot Games, Inc.

## Disclaimer

This application is not endorsed by Riot Games and does not reflect the views or opinions of Riot Games or anyone officially involved in producing or managing League of Legends. League of Legends and Riot Games are trademarks or registered trademarks of Riot Games, Inc.