Instructions for general environment setup can be found in: *How to Run the Code Examples in This Book*.

This README is the canonical source for the exact commands and expected outputs for Appendix C, Project 2.

## Run Command

Run from inside the `Project_2` folder.

```bash
dotnet run --project IdentityLayerDemo -- valid
```

## Expected Output

```text
Scenario: Valid Fish Instantiation
----------------------------------
Created: Goldfish
IsOrganism: True
IsAquatic: True
Result: admissible instance of Fish.
```

## Other Option

```bash
dotnet run --project IdentityLayerDemo -- invalid
```

```text
Scenario: Invalid Fish Instantiation
------------------------------------
Identity violation: 'House Cat' cannot instantiate Fish because Habitat='Terrestrial'. A Fish must be aquatic.
Result: rejected at the identity layer.
```
