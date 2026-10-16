# Appendix C: Are Concepts Just Goals?

## Putting Constructivist Concept Theory to the Test

Lisa Feldman Barrett (b. 1963) argues that concepts can adapt to changing purposes. She describes goal-based concepts as highly flexible and adaptable to the situation.<sup><a href="../references/notes/appendix-c.md#note-1">1</a></sup> She immediately ties that flexibility to goal variation, adding that concepts are malleable and context-dependent because goals can change with the situation. She illustrates the point with the fish example: when someone asks what kind of fish they would like, the active purpose constrains the answer. When the purpose is buying a pet, one may answer "goldfish" but not "poached salmon." She then generalizes the same mechanism with an artifact example: a single car can enter different concepts depending on the active purpose. In different contexts, a car may function as transportation, a status symbol, a bed, a murder weapon, or an artificial reef.

I agree that Barrett identifies a real phenomenon: goals regulate conceptual use. Research on ad hoc categories and situated conceptualization also supports the idea that agents form or activate categories relative to practical purposes.<sup><a href="../references/notes/appendix-c.md#note-2">2</a></sup> But that phenomenon does not establish that identity conditions are fluid. It supports a more precise interpretation: goal-indexed regulation can operate over a stable constraint structure.

This appendix reconstructs Barrett's examples at the level of constraint architecture. I do not deny goal flexibility. I deny that goal flexibility dissolves identity conditions. A goal can select, filter, emphasize, rank, or construct a use-specific specification. It does not thereby rewrite the deeper conditions that make something a possible instance of the concept in the first place.

The purpose of this appendix is therefore narrow but essential. I separate five layers that Barrett’s examples tend to compress: identity conditions, instantiation, goal selection, runtime construction, and multi-concept classification. Each layer performs a distinct function, and the argument fails when one layer substitutes for another.

The corresponding C# executables for the projects below appear in the matching project folders in this repository ([Project 1](../../code/appendix-c/project-1/), [Project 2](../../code/appendix-c/project-2/), [Project 3](../../code/appendix-c/project-3/), [Project 4](../../code/appendix-c/project-4/), [Project 5](../../code/appendix-c/project-5/)). Each folder includes a README with the canonical run commands and expected outputs. The prose that follows explains the conceptual purpose of each project rather than duplicating the execution blocks.

Project 1 implements identity conditions as admissibility constraints that operate before instantiation, selection, or context. The goal is to show that a concept must first specify what can count as an admissible instance at all. I isolate identity conditions from downstream processes so that goal-based selection and contextual variability cannot usurp their role.

In Project 1, I represent the concept Fish as a class with invariant admissibility conditions. A fish must be aquatic, and it must be an organism. These conditions do not vary with context. The constructor enforces them as necessary constraints. The system admits only candidates that satisfy them and rejects all others.

<img src="../../assets/figures/appendix-c/figure-01.png" />

<p align="center"><ins>Figure C-1. Fish UML Class Diagram</ins></p>

Figure C-1 defines the admissibility conditions that any instance must satisfy. No goals, parameters, or contextual modifiers appear at this level.

The valid and invalid candidates appear in separate object diagrams. Figure C-2 shows a valid Goldfish instance. Figure C-3 shows a valid Salmon instance. Figure C-4 shows an invalid Rock candidate.

<img src="../../assets/figures/appendix-c/figure-02.png" />

<p align="center"><ins>Figure C-2. Goldfish UML Object Diagram</ins></p>

<img src="../../assets/figures/appendix-c/figure-03.png" />

<p align="center"><ins>Figure C-3. Salmon UML Object Diagram</ins></p>

<img src="../../assets/figures/appendix-c/figure-04.png" />

<p align="center"><ins>Figure C-4. Rock UML Object Diagram (Invalid Fish)</ins></p>

In Project 1, the code evaluates a specific candidate passed as a command-line argument. This makes the admissibility test explicit. The system does not switch between an abstract valid mode and invalid mode. It evaluates whether a given candidate satisfies the admissibility conditions of Fish. The README for Project 1 provides the canonical run commands and expected outputs. When you execute the C# code with the following commands:

<img src="../../assets/figures/appendix-c/figure-05.png" />

<p align="center"><ins>Project 1 Run Commands</ins></p>

<img src="../../assets/figures/appendix-c/figure-06.png" />

<p align="center"><ins>Project 1 Valid Output</ins></p>

<img src="../../assets/figures/appendix-c/figure-07.png" />

<p align="center"><ins>Project 1 invalid Output</ins></p>

You get a valid response for the first two object diagrams; for example, when you pass goldfish as an input parameter:

However, you get an invalid response when you pass rock as the input parameter:

This behavior demonstrates that identity conditions operate upstream of all other processes. They constrain the space of possible instances before any goal-based filtering or contextual interpretation occurs. Project 1 therefore establishes the first architectural claim: identity conditions define admissibility and constrain what can count as an instance in the first place.

Project 2 isolates the instantiation layer. The goal is to show that multiple instances can satisfy the same identity conditions while differing in parametric values. Variation occurs within the boundary set by identity conditions, not by rewriting them. The rationale is to separate property assignment from the admissibility conditions Project 1 defined.

In Project 2, the concept Fish remains unchanged. The system applies its admissibility conditions upstream. What changes at this stage is the assignment of parameter values to instances that already qualify as fish. Each instance has properties such as species and type, where type may take values such as PET or FOOD.

<img src="../../assets/figures/appendix-c/figure-08.png" />

<p align="center"><ins>Figure C-5. Shared Structure Fish UML Class Diagram</ins></p>

Figure C-5 defines the shared structure that all instances must satisfy. The admissibility layer has already done its work. The focus now shifts to how admitted instances differ within that structure.

The object diagrams show distinct instantiations of the same concept. Figure C-6 represents a Goldfish instance. Figure C-7 represents a Salmon instance.

<img src="../../assets/figures/appendix-c/figure-09.png" />

<p align="center"><ins>Figure C-6. Goldfish UML Object Diagram</ins></p>

<img src="../../assets/figures/appendix-c/figure-10.png" />

<p align="center"><ins>Figure C-7. Salmon UML Object Diagram</ins></p>

Both instances satisfy the identity conditions of Fish established in Project 1. Their difference lies entirely in their parameter values. These parameters do not redefine the concept. They specify the realization of the concept in particular instances.

In Project 2, the code creates fish instances with different parameter assignments. The system does not ask whether every possible object is a fish at this stage. It works only with candidates that satisfy the admissibility layer and then assigns determinate values. The README for Project 2 provides the canonical run commands and expected outputs.

<img src="../../assets/figures/appendix-c/figure-11.png" />

<p align="center"><ins>Project 2 Valid Run Commands</ins></p>

<img src="../../assets/figures/appendix-c/figure-12.png" />

<p align="center"><ins>Project 2 Valid Output</ins></p>

<img src="../../assets/figures/appendix-c/figure-13.png" />

<p align="center"><ins>Project 2 Invalid Run Commands</ins></p>

<img src="../../assets/figures/appendix-c/figure-14.png" />

<p align="center"><ins>Project 2 Invalid Output</ins></p>

This behavior demonstrates that instantiation assigns determinate values within a stable constraint structure. Variation occurs at the level of parameters such as species and type. It does not alter the concept.

Project 2 therefore establishes the second architectural claim: instantiation introduces variability without altering identity conditions. Identity conditions determine what can count as an instance. Instantiation assigns determinate values to the instance.

Project 3 isolates the goal layer. The goal is to show that purpose regulates selection among admissible instances without altering identity conditions or instantiation. Context enters the system as a selection mechanism. It does not determine conceptual identity.

The concept Fish remains unchanged. The instantiated objects remain unchanged. The system now introduces a goal interface that evaluates which instances matter under a given purpose. Different goals apply different selection criteria to the same set of admitted instances.

<img src="../../assets/figures/appendix-c/figure-15.png" />

<p align="center"><ins>Figure C-8. Goal Layer Selection Structure UML Class Diagram</ins></p>

Figure C-8 shows the goal layer at the class level. The interface IGoal defines a selection function over Fish instances. PetGoal selects instances where Type = PET. DinnerGoal selects instances where Type = FOOD. These goals do not modify the instances. They evaluate them.

The object diagrams show how the same set of instances receives different selection treatment under different goals.

<img src="../../assets/figures/appendix-c/figure-16.png" />

<p align="center"><ins>Figure C-9. Selection Under a Pet Goal</ins></p>

<img src="../../assets/figures/appendix-c/figure-17.png" />

<p align="center"><ins>Figure C-10. Selection Under a Dinner Goal</ins></p>

In Project 3, the code applies a goal to a fixed set of instances. The goal determines which instances satisfy its selection constraint, but it does not alter the instances themselves or the concept they instantiate. The README for Project 3 provides the canonical run commands and expected outputs.

<img src="../../assets/figures/appendix-c/figure-18.png" />

<p align="center"><ins>Project 3 Dinner Run Commands</ins></p>

<img src="../../assets/figures/appendix-c/figure-19.png" />

<p align="center"><ins>Project 3 Dinner Output</ins></p>

<img src="../../assets/figures/appendix-c/figure-20.png" />

<p align="center"><ins>Project 3 Pet Run Commands</ins></p>

<img src="../../assets/figures/appendix-c/figure-21.png" />

<p align="center"><ins>Project 3 Pet Output</ins></p>

This behavior demonstrates that goals operate downstream of identity conditions and instantiation. Goals regulate relevance by selecting among admissible instances. They do not redefine what a fish is. They do not reassign the values of the instance.

Project 3 therefore establishes the third architectural claim: goals introduce context as selection over a fixed set of valid instances. Selection varies with purpose. Identity conditions and instantiated values remain stable.

Project 4 isolates runtime construction. The goal is to show that flexibility can operate through a dynamically built constraint specification rather than through the collapse of identity conditions. This project distinguishes selection over pre-existing instances from the construction of a goal-bound constraint structure for a particular episode.

The system no longer applies a goal directly as a filter over instances. Instead, a builder constructs a constraint specification at runtime based on the active goal. This specification determines which condition the instance must satisfy in that context. The concept does not vanish into use. The system constructs a determinate constraint structure and then evaluates instances under it.

<img src="../../assets/figures/appendix-c/figure-22.png" />

<p align="center"><ins>Figure C-11. Runtime Construction Layer UML Class Diagram</ins></p>

The ConceptSpecification class encapsulates a constraint function. The RuntimeConceptBuilder constructs this function based on the goal. For a pet goal, the constraint evaluates whether Type == PET. For a dinner goal, the constraint evaluates whether Type == FOOD. Each invocation of the builder produces a determinate constraint structure tied to the active purpose.

The object diagrams show the constructed constraint specifications.

<img src="../../assets/figures/appendix-c/figure-23.png" />

<p align="center"><ins>Figure C-12. Runtime Specification for Pet Goal</ins></p>

<img src="../../assets/figures/appendix-c/figure-24.png" />

<p align="center"><ins>Figure C-13. Runtime Specification for Dinner Goal</ins></p>

These constraints are not predefined classes. The system constructs them at runtime and applies them to the available instances. At this layer, the constructed constraint determines whether the instance qualifies. The code builds a ConceptSpecification based on the input goal and applies its constraint to the set of Fish instances. It performs two steps: it constructs the constraint, then it evaluates instances against that constraint. The README for Project 4 provides the canonical run commands and expected outputs.

<img src="../../assets/figures/appendix-c/figure-25.png" />

<p align="center"><ins>Project 4 Dinner Run Commands</ins></p>

<img src="../../assets/figures/appendix-c/figure-26.png" />

<p align="center"><ins>Project 4 Dinner Output</ins></p>

<img src="../../assets/figures/appendix-c/figure-27.png" />

<p align="center"><ins>Project 4 Pet Run Commands</ins></p>

<img src="../../assets/figures/appendix-c/figure-21.png" />

<p align="center"><ins>Project 4 Pet Output</ins></p>

This behavior demonstrates that runtime flexibility does not require conceptual drift. The system may construct a use-specific constraint structure, but the structure remains determinate for each execution. The active goal changes the constraint specification. It does not erase the need for constraint.

Project 4 therefore establishes the fourth architectural claim: conceptual flexibility can take the form of dynamic constraint construction. What changes is not identity itself, nor the deeper identity conditions of Fish, but the goal-bound specification that determines relevance in a given context.

Project 5 isolates multi-concept participation. The goal is to show that a single object can participate in multiple goal-bound concepts without changing its identity. Conceptual plurality arises when different constraint structures evaluate the same object under different purposes. It does not require a transformation of the object itself.

In Project 5, the object Car remains constant across all evaluations. What varies is the goal under which the system evaluates it. Each goal defines a different constraint structure, and the same object may satisfy more than one such structure.

<img src="../../assets/figures/appendix-c/figure-28.png" />

<p align="center"><ins>Figure C-14. Goal Layer Selection Structure for Car UML Class Diagram</ins></p>

The Car class defines the object's identity and properties. The goal interface defines a selection function. Each goal applies a different constraint. TransportGoal selects all cars. StatusGoal selects cars above a value threshold. ShelterGoal selects cars that can function as temporary shelter.

The UML object diagrams show how the same objects participate differently under each goal.

<img src="../../assets/figures/appendix-c/figure-29.png" />

<p align="center"><ins>Figure C-15. Transport Goal UML Object Diagram</ins></p>

<img src="../../assets/figures/appendix-c/figure-30.png" />

<p align="center"><ins>Figure C-16. Status Goal UML Object Diagram</ins></p>

<img src="../../assets/figures/appendix-c/figure-31.png" />

<p align="center"><ins>Figure C-17. Shelter Goal UML Object Diagram</ins></p>

In Project 5, the code applies multiple goals sequentially to the same set of objects. Each goal evaluates the objects according to its own constraint. The objects do not change. Only their participation in the selected set changes. The README for Project 5 provides the canonical run command and expected output.

<img src="../../assets/figures/appendix-c/figure-32.png" />

<p align="center"><ins>Project 5 Run Commands</ins></p>

<img src="../../assets/figures/appendix-c/figure-33.png" />

<p align="center"><ins>Project 5 Run Output</ins></p>

This behavior demonstrates that a single object can satisfy multiple goal-bound constraint structures. Its identity remains stable across all evaluations. What changes is the role the object plays under different goals.

Project 5 therefore establishes the fifth architectural claim: conceptual plurality does not imply identity change. It reflects the application of different constraint structures to the same object.

In this appendix, I have tested Barrett's goal-based account at the level of executable constraint architecture. The result is not that Barrett is wrong to emphasize goal flexibility. She is right that concepts can shift with purpose and context. The question is what must remain stable for that flexibility to count as conceptual use rather than conceptual drift. The five projects answer that question directly: flexibility requires layers, and each layer must do its own work.

Project 1 fixes identity conditions as admissibility constraints: before a candidate can be selected for dinner, pet, transport, status, or shelter, it must first be a possible instance of the relevant concept. Project 2 then shows how instantiation permits variation inside that boundary without rewriting it. Project 3 shows that goals select among admissible instances rather than create their identity. Project 4 shows that runtime construction can bind determinate goal-specific specifications without abandoning constraint. Project 5 shows that one object can participate in multiple goal-bound concepts while retaining its own identity across evaluations.

These results preserve the strongest part of Barrett's account while correcting its architectural compression. Goals can select, filter, emphasize, and construct relevance. They cannot replace the identity conditions that determine what can count as an instance in the first place. Context and purpose operate downstream from admissibility. They modify use, not the basic fact that conceptual application answers to criteria.

Appendix C therefore confirms the thesis of Chapter 3 in executable form. Goal-based concepts are flexible because constraint structures can operate at several levels, not because identity conditions must be absorbed into goal-sensitive use. Variability does not entail indeterminacy. Runtime construction does not abolish structure. Multi-concept participation does not imply identity change. Flexibility presupposes constraint.
