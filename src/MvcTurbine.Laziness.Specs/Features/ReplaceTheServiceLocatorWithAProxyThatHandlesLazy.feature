Feature: Replace the service locator with a proxy that handles lazy
	In order to add the ability to handle lazy types
	As a service registration
	I want to replace the service locator with a proxy that handles the lazy type

Scenario: Register
	Given a service locator proxy creator that will create X
	When I have a chance to register things in the service locator
	Then I should register the X instance with the service locator
