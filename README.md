# BDD-Parallel
Proof of concept to run SpecFlow features in parallel

## Proof of Concept

The idea being tested is running SpecFlow tests in parallel.

This is facilitated by using the parallel test features of NUnit 3, currently in beta. This is working fine, though parallel tests are supported only at class level, not individual tests.

In SpecFlow this translates as features. Being limited to running features, rather than individual tests, is a little resticting, but not not much. Lots of benefit can be gained by running features in parallel and may even have a desired side-effect of keeping features short.

### Thread safety.

There is a problem with SpecFlow. Though it does run in parallel, there appear to be some thread safety issues around context storage between steps.

[Issue 448]( https://github.com/techtalk/SpecFlow/issues/448) is open for this on the TechTalk SpecFlow site.
