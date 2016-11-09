using DesignPatterns.Patterns._01_Factory._Base;
using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns._01_Factory.Factory_Method {
	/// <summary>
	/// 工厂接口
	/// </summary>
	interface BMWFactory {
		BMW createBMW();
	}

	/// <summary>
	/// BMW320工厂
	/// </summary>
	class BMW320Factory : BMWFactory {
		public BMW createBMW() {
			return new BMW320();
		}
	}
	/// <summary>
	/// BMW523工厂
	/// </summary>
	class BMW523Factory : BMWFactory {
		public BMW createBMW() {
			return new BMW523();
		}
	}

	class FactoryMethodTest : IMain {

		public void AppMain() {
			Customer customer = new Customer();

			BMWFactory bmwf = new BMW523Factory();
			customer.my_BMW = bmwf.createBMW();
			customer.PrintCarName();
		}
	}
}
