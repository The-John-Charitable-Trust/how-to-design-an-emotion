Instructions for how to build and run the code can be found in: *How to Run the Code Examples in This Book*.

## Run Command

```text
# Test 1
dotnet run -- --test arbitrariness --concept familyClan

# Test 2
dotnet run -- --test underdetermination --identifier family

# Test 3
dotnet run -- --test essence --identifier family

# Test 4
dotnet run -- --test identity --concept family

# Test 5
dotnet run -- --test significance --identifier jobInterview
```

## Expected Output

```text
TEST 1: ARBITRARINESS

Input concept: familyClan
Same admissible sign configuration relative to context:
  IdentityConditions = { relation: shared ancestry, rule: recognized kinship group }
  Members = { Suri, Mako, Rika }

Identifiers by socio-cultural context:
  English -> family
  Spanish -> familia
  Swahili -> ukoo

Conclusion:
  No intrinsic feature of the sign determines the identifier.
  Agents assign identifiers under constraint within a socio-cultural context.
```

```text
TEST 2: UNDERDETERMINATION

Input identifier: family

Admissible sign configurations:
  1. Biological family
     IdentityConditions = { relation: biological descent, rule: bloodline }
     Members = { Suri, Mako, Rika }

  2. Chosen family
     IdentityConditions = { relation: voluntary affiliation, rule: chosen bonds }
     Members = { Suri, Mako, Rika }

  3. Legal household
     IdentityConditions = { relation: co-residence, rule: legal or domestic unit }
     Members = { Suri, Mako, Rika }

Conclusion:
  The identifier does not uniquely determine the sign configuration.
  The identifier underdetermines the sign configuration.
```

```text
TEST 3: ABSENCE OF UNIVERSAL OBJECTIVE ESSENCE

Input identifier: family

Admissible instances by identity conditions:
  1. Biological Essence
     IdentityConditions = { relation: biological descent, rule: bloodline }
     Members = { Suri, Mako }

  2. Chosen Essence
     IdentityConditions = { relation: voluntary affiliation, rule: chosen bonds }
     Members = { Suri, Mako, Rika }

  3. Institutional Essence
     IdentityConditions = { relation: legal or domestic unit, rule: co-residence }
     Members = { Suri, Rika, Toma }

Invariant essence found: NO

Conclusion:
  No single set of identity conditions governs all admissible instances.
  There are no universal objective essences.
```

```text
TEST 4: ABSENCE OF UNIVERSAL OBJECTIVE IDENTITY

Input concept: family
Stable admissibility conditions:
  IdentityConditions = { relation: shared affiliation, rule: recognized group membership }
  Members = { Suri, Mako, Rika }

Admissible identity assignments:
  English -> family (kinship identity)
  Spanish -> familia (lineage identity)
  Swahili -> ukoo (clan identity)

Conclusion:
  No intrinsic feature of the sign determines a single universal identity.
  There are no universal objective identities.
```

```text
TEST 5: ABSENCE OF UNIVERSAL OBJECTIVE SIGNIFICANCE

Constant sign: job interview
  IdentityConditions = { type: employment evaluation, rule: formal candidate assessment }
  Context = professional setting

Interpreters:
  Candidate A -> low
    Reason: Already employed; outcome has minimal impact.
  Candidate B -> moderate
    Reason: Seeks career progression; outcome is beneficial but not critical.
  Candidate C -> high
    Reason: Unemployed; outcome directly affects livelihood.

Conclusion:
  The sign does not carry a single invariant significance for every interpreter.
  There is no universal objective significance.
```
