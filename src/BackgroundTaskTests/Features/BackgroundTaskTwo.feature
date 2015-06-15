Feature: Background Task Feature Two
	In order to check tests run in parallel
	As a test runner
	I want to run features in parallel

@AsyncBDD
Scenario: Check happy path background task 2 seconds
	Given A background task
	When Delay action 4 seconds
	Then A valid response is detected after 2 seconds

@AsyncBDD
Scenario: Check happy path background task 12 seconds
	Given A background task
	When Delay action 9 seconds
	Then A valid response is detected after 12 seconds