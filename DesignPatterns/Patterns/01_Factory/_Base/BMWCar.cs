using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns._01_Factory._Base {
	/// <summary>
	/// 抽象BMW车类
	/// </summary>
	public abstract class BMW {
		protected string name;
		public abstract string getCarName();
	}

	/// <summary>
	/// BMW320
	/// </summary>
	public class BMW320 : BMW {
		public BMW320() {
			this.name = "BMW320";
		}
		public override string getCarName() {
			return this.name;
		}
	}

	/// <summary>
	/// BMW523
	/// </summary>
	public class BMW523 : BMW {
		public BMW523() {
			this.name = "BMW523";
		}
		public override string getCarName() {
			return this.name;
		}
	}
}
