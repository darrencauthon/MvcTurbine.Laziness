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
	Then the result should be an implementation of TestClass from the service locator

Scenario: Resolve a generic class properly
	Given I have been set up to intercept calls to a service locator
	And a class named TestGenericClass<T> exists
	When I resolve TestGenericClass<string>
	Then the result should be an implementation of TestGenericClass<string> from the service locator

Scenario: Resolve a generic interface properly
	Given I have been set up to intercept calls to a service locator
	And a class named ITestGenericClass<T> exists
	When I resolve ITestGenericClass<string>
	Then the result should be an implementation of ITestGenericClass<string> from the service locator

Scenario: Something other than Resolve is called
	Given I have been set up to intercept calls to a service locator
	When I call Release
	Then the Release call should be invoked