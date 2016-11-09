using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//适配器模式
namespace DesignPatterns.Patterns._05_Adapter {
	interface IHoleUsing {
		void Request();
	}

	class TwoHole : IHoleUsing {
		public void Request() {
			Console.WriteLine("Two Hole Working!");
		}
	}

	/// <summary>
	/// 外部的三角插座 无法修改其源码
	/// </summary>
	class external_ThreeHole {
		public void external_ThreeRequest() {
			Console.WriteLine("external Three Hole Working!");
		}
	}

	class ThreeHole : IHoleUsing {
		external_ThreeHole ext_threeHole;

		public ThreeHole(external_ThreeHole th) {
			this.ext_threeHole = th;
		}

		public void Request() {
			this.ext_threeHole.external_ThreeRequest();
		}
	}

	class AdapterTest:IMain {
		public void AppMain() {
			IHoleUsing th = new TwoHole();
			th.Request();
			IHoleUsing trh = new ThreeHole(new external_ThreeHole());
			trh.Request();
		}
	}
}
