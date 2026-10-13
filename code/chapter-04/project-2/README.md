Instructions for general environment setup can be found in: *How to Run the Code Examples in This Book*.

This README is the canonical source for the exact command and expected output for Chapter 4, Project 2.

## Run Command

```bash
dotnet run -- food
```

## Other option

```bash
dotnet run -- pest
```

## Expected Output

```text
Organism: grub
LarvalStage: True
LivingMatter: True
IsAdmissible(): True
CulturalContext: food
ForagingGoal.edible: True
PestControlGoal.pest: False
Category: food
ConceptualIdentity: grub
```

## Expected Output for Other Option

```text
Organism: grub
LarvalStage: True
LivingMatter: True
IsAdmissible(): True
CulturalContext: pest
ForagingGoal.edible: False
PestControlGoal.pest: True
Category: pest
ConceptualIdentity: grub
```
