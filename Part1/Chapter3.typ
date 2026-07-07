#import "@preview/diagraph:0.3.5"

= Chapter 3

== 1. Free construction:

=== A graph with one node and no edges
#diagraph.render("digraph {
a -> a[label=id];
}")

=== A graph with one node and one (directed) edge (hint: this edge can be composed with itself)
#diagraph.render("digraph {
a -> a[label=id];
a -> a[label=f];
a -> a[label=\"f . f\"];
a -> a[label=\"...\"];
}")
hom-set(a, a) = {id, f, f . f, f . f . f, ...}
(monoid where f is the generator)

=== A graph with two nodes and a single arrow between them
#diagraph.render("digraph {
a -> b[label=f];
a -> a[label=id];
b -> b[label=id];
}")

=== A graph with a single node and 26 arrows marked with the letters of the alphabet: a, b, c … z.

Similar to the previous monoid but now with more possible combinations of arrows.
#box[hom-set = {a..z}\*] where ab = "a after b".
Isomorphic to all possible strings. I.e. composition = string concatenation.

== 2. Orders

=== A set of sets with the inclusion relation: A is included in B if every element of A is also an element of B.

$ A in B and B in A => A subset.eq B and B subset.eq A => A = B$

So when both are contained in one another, we get equality.
If exactly one is contained in the other, we have a ordering between them.
But if we have two sets, e.g. {0} and {1}, that don't contain each other, we cannot compare them!
So this is a _partial_ order.

=== C++ types with the following subtyping relation: T1 is a subtype of T2 if a pointer to T1 can be passed to a function that expects a pointer to T2 without triggering a compilation error.

partial order.
Trivially reflexive.
Equivalent to extending a class.
So antisymmetric also trivial (A extends B and B extends A => A = B).
Transitive also true probably.

== 3. Considering that Bool is a set of two values True and False, show that it forms two (set-theoretical) monoids with respect to, respectively, operator && (AND) and || (OR).

(a && b) && c = a && (b && c) (can be shown with truth table).
Similar for ||.
Identity for && is true:
a && true = a = true && a.
Identity for || is false.

== 4. Represent the Bool monoid with the AND operator as a category: List the morphisms and their rules of composition.

#diagraph.render("digraph {
Bool -> \"Bool'\"[label=id];
Bool -> \"Bool'\"[label=True];
Bool -> \"Bool'\"[label=False];
}")
(Bool = Bool', they are drawn as different nodes for readability but represent the same object).

- True && True = True
- True && False = False && True = False && False = False.
- True && id = True
- False && id = False

Note: id = True since:
- True && id = True && True == True
- False && id = False && Ture == False

== 5. Represent addition modulo 3 as a monoid category.

#diagraph.render("digraph {
AddMod3 -> \"AddMod3'\"[label=id];
AddMod3 -> \"AddMod3'\"[label=0];
AddMod3 -> \"AddMod3'\"[label=1];
AddMod3 -> \"AddMod3'\"[label=2];
}")

- n + m = n + m % 3.
- E.g.
  - 0 + 1 = 1
  - 2 + 1 = 0.

id = 0
inverse of 1 = 2
So this is an isomorphism???
Yes!
Isomorphism mapping:
- 0 -> 0
- 1 -> 2
- 2 -> 1