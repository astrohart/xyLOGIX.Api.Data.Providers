# xyLOGIX.Api.Data.Providers
(C#/x86-64/Class Library/VS2019) Companion library to the Iterators, Iterables, and Repository libraries.  

This library implements API Data Providers. An API Data Provider object basically sits in front of a `Repository` (which itself serves as a Fa?ade for an `Iterable`/`Iterator` pair) and implements the details of wiring up the `Repository`, `Iterable`, and `Iterator` all in a package, and then delegates all its calls to the `Repository` object that it wraps.

Access to the underlying `Repository`, `Iterator`, and `Iterable` objects is still allowed because these can be accessed by the client through the `new` operator and factories.
