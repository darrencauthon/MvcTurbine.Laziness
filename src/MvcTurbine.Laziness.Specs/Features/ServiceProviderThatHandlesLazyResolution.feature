Feature: Service provider interceptor that resolves ILazy<T>
	In order to allow lazy resolution of dependencies
	As a service locator interceptor
	I want to intercept requests for ILazy<T> and return a Lazy<T> implementation

Scenario: Get ILazy<T> with Resolve<TestClass> 
	Given I have been set up to intercept calls to a service locator
	And a class named TestClass exists
	When Resolve<ILazy<TestClass>> is called
	Then the result should be an implementation of Lazy<TestClass>

Scenario: Get ILazy<T> with Resolve(typeof(TestClass))
	Given I have been set up to intercept calls to a service locator
	And a class named TestClass exists
	When Resolve(typeof(ILazy<TestClass>)) is called
	Then the result should be an implementation of Lazy<TestClass>

Scenario: Get the normal result from the service locator when not resolving ILazy
	Given I have been set up to intercept calls to a service locator
	And a class named TestClass exists
	When I resolve TestClass
	Then the result should be an implementation of TestClasss
