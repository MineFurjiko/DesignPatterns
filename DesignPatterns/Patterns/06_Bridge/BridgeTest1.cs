using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//桥接模式 蜡笔与毛笔
namespace DesignPatterns.Patterns._06_Bridge {
	abstract class my_Brush {
		protected my_Color color;
		public abstract void Paint();

		public void SetColor(my_Color c) { this.color = c; }
	}

	class BigBrush : my_Brush {
		public override void Paint() {
			Console.WriteLine("Using Big brush and Color {0} painting!",color.name);
		}
	}


	class SmallBrush : my_Brush {
		public override void Paint() {
			Console.WriteLine("Using Small brush and Color {0} painting!", color.name);
		}
	}

	class my_Color {
		public string name;
	}

	class Red : my_Color {
		public Red() { this.name = "Red"; }
	}

	class Blue : my_Color {
		public Blue() { this.name = "Blue"; }
	}

	class BridgeTest1:IMain {
		public void AppMain() {
			my_Brush b = new BigBrush();
			b.SetColor(new Red());
			b.Paint();
			b.SetColor(new Blue());
			b.Paint();

			b = new SmallBrush();
			b.SetColor(new Red());
			b.Paint();
		}
	}
}
