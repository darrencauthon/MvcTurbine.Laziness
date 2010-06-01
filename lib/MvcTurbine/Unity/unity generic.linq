<Query Kind="Program">
  <Reference>C:\Users\cauthond\Desktop\MvcTurbine.NoRM\lib\MvcTurbine\Unity\Microsoft.Practices.ObjectBuilder2.dll</Reference>
  <Reference>C:\Users\cauthond\Desktop\MvcTurbine.NoRM\lib\MvcTurbine\Unity\Microsoft.Practices.Unity.dll</Reference>
  <Reference>C:\Users\cauthond\Desktop\MvcTurbine.NoRM\lib\MvcTurbine\Unity\MvcTurbine.dll</Reference>
  <Reference>C:\Users\cauthond\Desktop\MvcTurbine.NoRM\lib\MvcTurbine\Unity\MvcTurbine.Unity.dll</Reference>
  <Namespace>MvcTurbine.Unity</Namespace>
</Query>

void Main()
{
	var serviceLocator = new UnityServiceLocator();
	//serviceLocator.Dump();
	//
	//using (serviceLocator.Batch()){
		//var kernel = new StandardKernel();
		var container = serviceLocator.Container;

		//container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
		serviceLocator.Register(typeof(IRepository<>), typeof(Repository<>));

		//var test = kernel.Get<IRepository<Account>>();
	
	//}
	
	serviceLocator.Resolve<IRepository<Account>>().Dump();
	//container.Resolve<IRepository<Account>>().Dump();
	
}

// Define other methods and classes here
public interface IRepository<T>{
}

public class Repository<T> : IRepository<T>{
public Repository()
	{
	}
}

public class Account{}

public class Product{}
