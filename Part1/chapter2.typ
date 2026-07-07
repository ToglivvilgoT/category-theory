#import "@preview/diagraph:0.3.5"

The Category of Void, Unit and Bool with morphisms being all possible functions between theses objects.

#diagraph.render("digraph {
Void -> Unit[label=Absurd];
Void -> Bool[label=Absurd];
Unit -> Bool[label=True];
Unit -> Bool[label=False];
Bool -> Unit[label=Unit];

Void -> Void[label=Id];
Unit -> Unit[label=Id];
Bool -> Bool[label=Id];
Bool -> Bool[label=Not];
Bool -> Bool[label=True];
Bool -> Bool[label=False];
}");