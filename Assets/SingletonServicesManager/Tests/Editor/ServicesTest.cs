using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class ServicesTest {

	class MockService {}
	class MockClient {}


	[Test]
	public void itThrowsExceptionIfFindingStuffThatIsNotRegistered()
	{
		Assert.Throws(typeof(Services.ServiceNotFoundException), FindNotRegisteredStuff);
	}
	protected void FindNotRegisteredStuff()
	{
		Services.Clear ();
		Services.Find<MockService> ();
	}


	[Test]
	public void itThrowsExceptionIfRegisteringStuffThatIsAlreadyRegistered()
	{
		Assert.Throws(typeof(Services.ServiceAlreadyRegisteredException), RegisterAlreadyRegisteredStuff);
	}
	protected void RegisterAlreadyRegisteredStuff()
	{
		Services.Clear ();
		Services.Register<MockService> (new MockService());
		Services.Register<MockService> (new MockService());
	}


	[Test]
	public void itRegistersAServiceAndFindsItProperly()
	{
		Services.Clear ();

		MockService A = new MockService();
		MockService B = null;

		Services.Register<MockService>(A);
		B = Services.Find<MockService> ();
			
		Assert.AreSame (A, B);
	}


}
