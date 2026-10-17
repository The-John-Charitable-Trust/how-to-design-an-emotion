# Appendix B: Blueprinting the Mind

## Reverse Engineering How Emotions Are Made

In Chapter 2, I argued that a definition can do its work only when it specifies the architecture that governs identity. Appendix A then tested Basic Emotion Theory against the demands of identity, non-circularity, and analytic consequence. This appendix turns from critique to formal construction. If I treat emotion as something the mind constructs rather than something the body simply reveals, then I must show how construction can preserve identity without collapsing into arbitrariness. 

Natural language can state that requirement, but it cannot always discipline it. Prose tolerates ambiguity. It can conceal category errors. It can let identity drift across explanations without warning. UML and design patterns give me a stricter grammar. They force me to separate type from instance, structure from realization, and conceptual identity from contextual variation.<sup><a href="../references/notes/appendix-b.md#note-1">1</a></sup> 

In the diagrams and design patterns that follow, I do not claim to model neural activity or psychological mechanism. I model structure. Each figure formalizes a requirement the main text develops: the separation of genus and species in affective states, the distinction between identity and instantiation, the syntagmatic ordering required for meaning, and the principled generation of emotional episodes from stable conceptual architecture.<sup><a href="../references/notes/appendix-b.md#note-2">2</a></sup> The diagrams show how emotions can arise as context-sensitive instantiations of declared structure rather than as detected entities or post hoc labels. This appendix therefore demonstrates, rather than merely asserts, how emotional construction can remain explicit, inspectable, and constrained.

<img src="../../assets/figures/appendix-b/figure-01.png" alt="UML class diagram of the inheritance hierarchy of affective states" />

<p align="center"><ins>Figure B-1. UML Class Diagram: Inheritance Hierarchy of Affective States</ins></p>

Figure B-1 models how affective kinds can differ structurally without presupposing different biological substrates. I model Feeling as the genus that fixes shared affective structure, and Emotion, Mood, and DriveState as species that inherit that structure while adding differentiating constraints. Affective diversity arises from structural specialization, not from distinct biological kinds, essences, or mechanisms.<sup><a href="../references/notes/appendix-b.md#note-3">3</a></sup> 

Feeling specifies core affect dimensions, including valence and arousal, as structural primitives within this formal model. They operate as genus-level admissibility constraints that fix shared affective structure for modeling purposes. This specification concerns modeling architecture rather than empirical reduction or biological necessity. It does not deny competing accounts that reject dimensional necessity in favor of basic affective systems.<sup><a href="../references/notes/appendix-b.md#note-4">4</a></sup> 

Emotion, Mood, and DriveState inherit this core structure and introduce kind-specific constraints. Emotion adds appraisal and attitude, marking emotions as affective states that involve interpretive evaluation and propositional stance toward something. Mood adds duration and diffuseness, distinguishing moods as persistent affective states without a specific object. DriveState adds action bias and goal direction, distinguishing drives as affective states oriented toward action selection and pursuit.<sup><a href="../references/notes/appendix-b.md#note-5">5</a></sup> 

In Aristotelian terms, feeling supplies the genus and the others function as species defined by differentiae. In object-oriented terms, feeling functions as the superclass and the others as subclasses that preserve identity through inheritance while introducing functional constraints. The diagram encodes a proposed set of identity conditions for affective kinds and blocks category error by showing that emotions, moods, and drives differ by how the same affective substrate receives structure and specialization, not by belonging to separate ontological kinds.<sup><a href="../references/notes/appendix-b.md#note-6">6</a></sup>

<img src="../../assets/figures/appendix-b/figure-02.png" alt="UML activity diagram of syntagmatic appraisal structure" />

<p align="center"><ins>Figure B-2. UML Activity Diagram: Syntagmatic Appraisal Structure</ins></p>

Figure B-2 addresses a problem that prose can hide. Prose can describe appraisal as if it were merely something that happens inside the mind. That description misses the structure I need to preserve. Appraisal has an agent, an object, a relation, and an end point. Someone appraises something as something. If prose does not make those roles explicit, appraisal can blur into feeling, mechanism, or private impression. The object of appraisal then disappears from the theory.<sup><a href="../references/notes/appendix-b.md#note-7">7</a></sup> 

I introduce Figure B-2 to make appraisal explicit as a syntagmatic operation. The activity diagram forces sequence, separates roles, and fixes termination. The Agent initiates the process. APPRAISES mediates the relation. The activity terminates in the Threat lane, fixing appraisal as about something rather than as a free-floating inner state. Meaning arises from ordered structure, not from isolated elements.<sup><a href="../references/notes/appendix-b.md#note-8">8</a></sup> 

This diagram solves a representational problem, not an empirical one. It renders appraisal as an architectural relation between agent and world. By making structure visible, it blocks category error and prepares the transition from internal coherence to reference.<sup><a href="../references/notes/appendix-b.md#note-9">9</a></sup> 

With the next two diagrams, I introduce Gang of Four design patterns to solve a specific modeling problem: how to represent construction without collapsing identity into instance. Erich Gamma, Richard Helm, Ralph E. Johnson, and John M. Vlissides developed these patterns as reusable solutions to recurring object-oriented design problems, including creational problems such as object instantiation.<sup><a href="../references/notes/appendix-b.md#note-10">10</a></sup> Emotion theories can confuse what an emotion is with how an emotional episode arises; Appendix A traces that confusion in Basic Emotion Theory. I isolate that distinction by using formal architectural patterns that separate definition from realization.<sup><a href="../references/notes/appendix-b.md#note-11">11</a></sup>

The Gang of Four patterns do not describe mental mechanisms. They formalize structural solutions to recurring problems of construction. I use them here as disciplined syntactic tools. They allow me to model how stable conceptual identities can generate context-sensitive instances without treating emotions as discovered objects, biological essences, or free-floating labels. The aim is not empirical accuracy, but architectural clarity.<sup><a href="../references/notes/appendix-b.md#note-12">12</a></sup> 

<img src="../../assets/figures/appendix-b/figure-03.png" alt="UML class diagram of the parameterized Factory Method pattern for emotion construction" />

<p align="center"><ins>Figure B-3. Parameterized Factory Method Pattern: Emotion Construction</ins></p>

Figure B-3 models emotion construction using a parameterized form of the Factory Method pattern, which separates the declaration of a type from the logic responsible for creating its instances. In this architecture, Emotion functions as an abstract class that fixes the shared structural properties of an emotion, such as valence, context, and expression. The class defines identity conditions but does not instantiate any emotional episode.<sup><a href="../references/notes/appendix-b.md#note-13">13</a></sup>

Concrete subclasses, Joy, Fear, and Anger, inherit this structure and specialize it. In object-oriented terms, generalization lets subclasses share a superclass’s structure, and individual instances vary in the values they assign to it; I read that sharing as preserving conceptual identity.<sup><a href="../references/notes/appendix-b.md#note-14">14</a></sup>

The EmotionFactory centralizes instantiation. Instead of constructing a concrete emotion directly, the client requests an emotion from the factory, which selects the appropriate subclass and returns it as the abstract type Emotion. The client therefore interacts with the stable abstract interface rather than with specific implementations.<sup><a href="../references/notes/appendix-b.md#note-15">15</a></sup>

Architecturally, this structure separates identity from instantiation. The abstract class corresponds to the emotion concept, while the instantiated object corresponds to a specific emotional episode. The factory models rule-governed construction that preserves conceptual identity while allowing contextual differentiation.<sup><a href="../references/notes/appendix-b.md#note-16">16</a></sup> 

The pattern illustrates how emotional episodes can be generated as instances of a stable conceptual architecture without treating emotional kinds as discovered entities or biological essences. I do not claim that minds implement software patterns. I use the pattern to make explicit a structural requirement of any coherent theory of emotion: the distinction between the identity of an emotion concept and the generation of its instances.<sup><a href="../references/notes/appendix-b.md#note-17">17</a></sup>

The corresponding C# project appears in this repository’s code folder for Appendix B, [Project 1](../../code/appendix-b/project-1/). The project README provides the canonical build command, run command, supported input values, and expected output. The appendix explains the conceptual purpose of the code; the README governs execution.

After navigating to the folder containing the project, build it:

<img src="../../assets/figures/appendix-b/figure-04-build.png" alt="Console command: dotnet build" />

<p align="center"><ins>Project 1 Build Command</ins></p>

Then run it:

<img src="../../assets/figures/appendix-b/figure-04.png" alt="Console command: dotnet run -- fear" />

<p align="center"><ins>Project 1 Run Command</ins></p>

<img src="../../assets/figures/appendix-b/figure-05.png" alt="Console input: emotion construction example with input parameter fear" />

<p align="center"><ins>Project 1 Input</ins></p>

<img src="../../assets/figures/appendix-b/figure-06.png" alt="Console output: constructed fear emotion with negative valence, danger context, and wide-eyes expression" />

<p align="center"><ins>Project 1 Output</ins></p>

If the input parameter were joy or anger, the output would change accordingly; the README lists the expected output for each.

<img src="../../assets/figures/appendix-b/figure-07.png" alt="UML class diagram of the Prototype design pattern for emotion construction" />

<p align="center"><ins>Figure B-4. Prototype Design Pattern: Emotion Construction UML</ins></p>

Figure B-4 models emotion construction using the Prototype design pattern. The diagram shows how new emotional instances can arise through structured reuse rather than fresh construction.<sup><a href="../references/notes/appendix-b.md#note-18">18</a></sup>

Here, Emotion again defines the abstract identity of an emotion and declares a clone() operation. This operation specifies how instances replicate structural identity while allowing contextual variation.<sup><a href="../references/notes/appendix-b.md#note-19">19</a></sup>

JoyEmotion, FearEmotion, and AngerEmotion serve as concrete prototypes. Each implements cloning so that Joy produces Joy instances, Fear produces Fear instances, and Anger produces Anger instances. Identity remains fixed. Realization varies.

The EmotionCache stores initialized prototypes indexed by key. When the client requests an emotion, the cache returns a clone of the appropriate prototype rather than constructing a new object from scratch.

The architectural mapping remains precise:

• The concept corresponds to the prototype's declared structure.

• The construct corresponds to each cloned instance.

• The cache models stored conceptual templates.

• Cloning models instantiation through reuse rather than discovery.

This pattern formalizes a central constructionist claim without psychologizing it. Emotional episodes arise as context-specific realizations of stable conceptual templates. Identity precedes instance. Structure governs variation.

These diagrams do not claim that the mind implements factories or prototypes. They claim something narrower and stronger: any coherent account of emotion must separate identity from instantiation. The Gang of Four patterns provide a formal grammar for making that separation explicit, inspectable, and non-rhetorical.

Please see *Appendix E: Under the Hood of Mind and Meaning: A Software Developer’s Guide to Layered Ontology* for a code walkthrough of the JavaScript Prototype Object Model.

Appendix B completes Chapter 2’s constructive argument: emotion can be constructed without losing identity, provided the model preserves the architecture that distinguishes concept, instance, context, and interpretation. The inheritance diagram separates genus from species: Feeling supplies shared affective structure, while Emotion, Mood, and DriveState specialize that structure through different constraints. The syntagmatic appraisal diagram then fixes the relational form that meaning requires. An agent appraises something as something. That ordered relation prevents appraisal from collapsing into a private impression, a bodily mechanism, or an isolated label.

The Factory and Prototype diagrams extend the same discipline to construction. Factory formalizes rule-governed instantiation: the abstract emotion concept remains stable while concrete episodes vary. Prototype formalizes structured reuse: cloned emotional instances can differ contextually while preserving the declared identity of the template from which they arise. These patterns do not claim that the mind runs software, and they do not reduce emotion to code. They supply a formal grammar for separating concept from construct, identity conditions from realized identity, and construction from arbitrary invention.

The appendix therefore defends a narrow but crucial proposition. A constructionist theory of emotion does not have to choose between rigid natural kinds and conceptual drift. It can accept contextual generation, variation, and reuse while preserving the identity conditions that govern valid instantiation. Identity precedes instance; structure governs variation; construction produces realizations rather than replacing the concept that makes realization intelligible. Appendix B therefore turns the critique of Appendix A into a constructive modeling standard: emotion may be made, but it must be made under constraints.
