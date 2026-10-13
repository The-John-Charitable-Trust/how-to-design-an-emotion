# Project 2 — Semiotic Availability vs Semantic Achievement

This project demonstrates that a feeling can be available for interpretation without already having emotional meaning.

## Build
dotnet build

## Run

### Feeling available, but no meaning yet
dotnet run -- dark_garage 7 available

### Feeling interpreted as fear
dotnet run -- dark_garage 7 fear

## Expected behavior
The first run shows a feeling that is context-bound and available for interpretation, but still has no meaning.
The second run shows the same feeling after interpretation, where emotional meaning has been assigned.
