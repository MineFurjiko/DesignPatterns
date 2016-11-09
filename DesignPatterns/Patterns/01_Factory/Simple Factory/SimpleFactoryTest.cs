using DesignPatterns.Patterns._01_Factory._Base;
using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns._01_Factory.Simple_Factory {
	/// <summary>
	/// BMW工厂类
	/// </summary>
	class BMWFactory {
		public enum CarType {
			BMW320,
			BMW523
		}

		/// <summary>
		/// 生产车 违背开闭原则（需要新增case）
		/// </summary>
		/// <param name="ct"></param>
		/// <returns></returns>
		public BMW createBMW(CarType ct) {
			switch (ct) {
				case CarType.BMW320:
					return new BMW320();
				case CarType.BMW523:
					return new BMW523();
				default:
					return null;
			}
		}
	}


	class SimpleFactoryTest:IMain {

		public void AppMain() {
			Customer customer = new Customer();
			BMWFactory bmwFactory = new BMWFactory();
			//客户通过工厂获取车
			customer.my_BMW = bmwFactory.createBMW(BMWFactory.CarType.BMW320);
			customer.PrintCarName();
		}
	}
}
