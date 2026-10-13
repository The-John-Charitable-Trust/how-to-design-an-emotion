Instructions for general environment setup can be found in: *How to Run the Code Examples in This Book*.

This README is the canonical source for the exact commands and expected outputs for Appendix C, Project 1.

## Run Commands

Run from inside the `Project_1` folder.

```bash
cd .\IdentityLayerDemo\
dotnet run -- goldfish
```

## Expected Output

```text
Valid Fish created: Goldfish
```

## Other Options

```bash
dotnet run -- salmon
```

```text
Valid Fish created: Salmon
```

```bash
dotnet run -- rock
```

```text
Rejected: rock is not a Fish
Reason: Object does not satisfy Fish admissibility conditions
```
