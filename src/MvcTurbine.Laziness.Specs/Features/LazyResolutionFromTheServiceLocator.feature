Feature: Lazy resolution from the service locator
	In order to resolve some dependencies after an object is constructed
	As a programmer
	I want to resolve implementations of ILazy<T> from the container

Scenario: Resolve ILazy<T> from a Unity container
	Given I have a UnityServiceLocator
	And I have spun the Laziness blade
	When I resolve an ILazy<Repository>
	Then I should get an ILazy<Repository>

Scenario: Resolve ILazy<T> from a StructureMap container
	Given I have a StructureMapServiceLocator
	And I have spun the Laziness blade
	When I resolve an ILazy<Repository>
	Then I should get an ILazy<Repository>

Scenario: Resolve ILazy<T> from a Ninject container
	Given I have a NinjectServiceLocator
	And I have spun the Laziness blade
	When I resolve an ILazy<Repository>
	Then I should get an ILazy<Repository>

Scenario: Resolve ILazy<T> from a Windsor container
	Given I have a WindsorServiceLocator
	And I have spun the Laziness blade
	When I resolve an ILazy<Repository>
	Then I should get an ILazy<Repository>
