Instructions for general environment setup can be found in: *How to Run the Code Examples in This Book*.

This README is the canonical source for the exact commands and expected outputs for Appendix C, Project 3.

## Build Command

Run from inside the `project-3` folder.

```bash
dotnet build GoalLayerDemo
```

## Run Commands

```bash
dotnet run --project GoalLayerDemo -- dinner
```

## Expected Output

```text
Active Goal: DinnerGoal

Selected: Salmon (FOOD)
```

## Other Options

```bash
dotnet run --project GoalLayerDemo -- pet
```

```text
Active Goal: PetGoal

Selected: Goldfish (PET)
```
