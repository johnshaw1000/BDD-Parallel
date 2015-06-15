Feature: Background Task Feature Three
	In order to check tests run in parallel
	As a test runner
	I want to run features in parallel

@AsyncBDD
Scenario: Check happy path background task 3 seconds
	Given A background task
	When Delay action 3 seconds
	Then A valid response is detected after 3 seconds

@AsyncBDD
Scenario: Check happy path background task 13 seconds
	Given A background task
	When Delay action 13 seconds
	Then A valid response is detected after 13 seconds