Feature: Background Task Feature One
	In order to check tests run in parallel
	As a test runner
	I want to run features in parallel

@AsyncBDD
Scenario: Check happy path background task 1 seconds
	Given A background task
	When Delay action 1 seconds
	Then A valid response is detected after 1 seconds

@AsyncBDD
Scenario: Check happy path background task 11 seconds
	Given A background task
	When Delay action 11 seconds
	Then A valid response is detected after 11 seconds