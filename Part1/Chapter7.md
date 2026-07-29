# Proof of functor laws for list (by induction)

## Definition

fmap _ [] = []
fmap f x:xs = Cons (f x) (fmap f xs)

## 1. Base case

fmap id [] = []

f :: a -> b
g :: b -> c
(fmap g) . (fmap f) [] =
fmap g (fmap f []) =
fmap g [] =
[] =
fmap (g . f) []

## 2. Assume

Assume functor laws hold for lists of length n >= 0

## 3. Show for n + 1

lst :: t -> lst t      // (I think, im a bit rusty on my haskell)
length lst = n + 1

fmap id lst  =
fmap id x:xs = Cons (id x) (fmap id xs) =
               Cons x (fmap id xs) = (from assumption in step 2.)
               Cons x xs =
               lst

f :: a -> b
g :: b -> c

(fmap g) . (fmap f) lst                 =
(fmap g) . (fmap f) x:xs                =
fmap g (fmap f x:xs)                    =
fmap g (Cons (f x) (fmap f xs))         =
Cons (g (f x)) (fmap g (fmap f xs))     =
Cons (g . f x) ((fmap g) . (fmap f) xs) = (from assumption in step 2.)
Cons (g . f x) (fmap (g . f) xs)        =
fmap (g . f) x:xs                       =
fmap (g . f) lst

## I here by declare that it is of out most certainty that thy list follows thy law of thy functor thy there thy for since induction has thy proven
