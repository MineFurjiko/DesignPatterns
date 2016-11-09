using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns._01_Factory._Base {
	/// <summary>
	/// 客户类
	/// </summary>
	class Customer {
		public BMW my_BMW;
		public void PrintCarName() {
			Console.WriteLine(this.my_BMW.getCarName());
		}
	}
}
