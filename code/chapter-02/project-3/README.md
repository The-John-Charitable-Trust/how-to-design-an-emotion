# Chapter 2 - Project 3: Core Affect Concept and Constructs

This project demonstrates how the concept `CoreAffect` declares the identity conditions of basic affective state and how particular affective states realize those conditions with determinate values.

- The concept declares valence, arousal, and motivational intensity.
- The construct realizes those dimensions with runtime values.
- Magnitude provides a simple computed measure over the realized construct.

Instructions for how to build and run the code can be found in: *How to Run the Code Examples in This Book*.

## Run Command

```bash
dotnet run -- 0.8 0.6 0.9
```

## Expected Output

```text
CoreAffect Concept
valence: float
arousal: float
motivationalIntensity: float

Construct Created
valence: 0.8
arousal: 0.6
motivationalIntensity: 0.9
magnitude: 1.345

Result
A core affect construct realizes the declared dimensions of valence, arousal, and motivational intensity.
Identity conditions remain fixed. Only the affective values vary.
```
