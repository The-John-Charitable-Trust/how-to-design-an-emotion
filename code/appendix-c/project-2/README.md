Instructions for general environment setup can be found in: *How to Run the Code Examples in This Book*.

This README is the canonical source for the exact commands and expected outputs for Appendix C, Project 2.

## Build Command

Run from inside the `project-2` folder.

```bash
cd .\IdentityLayerDemo\
dotnet build
```

## Run Commands

```bash
dotnet run -- valid
```

## Expected Output

```text
Fish instance created: Goldfish (PET)
Fish instance created: Salmon (FOOD)
Shared structure: Fish (Species, Type)
```

## Other Options

```bash
dotnet run -- invalid
```

```text
Rejected: TOY is not a FishType
Reason: Type must be PET or FOOD
```
