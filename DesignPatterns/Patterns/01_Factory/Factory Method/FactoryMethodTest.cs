using DesignPatterns.Patterns._01_Factory._Base;
using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//工厂方法模式:通过面向对象编程中的多态性来将对象的创建延迟到具体工厂中
//从而解决了简单工厂模式中存在的问题，也很好地符合了开放封闭原则（即对扩展开发，对修改封闭）。
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
