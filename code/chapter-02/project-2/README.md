# Chapter 2 - Project 2: Right Concept and Construct

This project demonstrates how the concept `Right` declares identity conditions and how a particular right becomes a construct through determinate values and attestation.

- The concept declares the required fields: identifier, value, assertion, and attestation.
- The construct realizes those fields as a specific attested right.
- Validation depends on substantiating attestation.

Instructions for how to build and run the code can be found in: *How to Run the Code Examples in This Book*.

## Run Command

```bash
dotnet run -- "drivingRight" "Operate a motor vehicle on public roads" "I have authority to drive" "state-issued driver's license"
```

## Expected Output

```text
Right Concept
identifier: string
value: string
assertion: string
attestation: string

Construct Created
identifier: "drivingRight"
value: "Operate a motor vehicle on public roads"
assertion: "I have authority to drive"
attestation: "state-issued driver's license"

Validation
The right is modeled as attested authority to gain or keep a value.
The construct is valid because the claim is paired with substantiating attestation.
```
