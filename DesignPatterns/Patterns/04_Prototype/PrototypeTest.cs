using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns._04_Prototype {
	class PrototypeTest:IMain {
		interface IDoppelganger {
			bool isRoot { get; set; }
			IDoppelganger doppelganger();
		}

		class Naruto : IDoppelganger {

			public bool isRoot { get; set; }

			public Naruto() {
				isRoot = true;
			}

			public IDoppelganger doppelganger() {
				if (!isRoot) {
					return null;
				}
				var cloneObj=(Naruto)this.MemberwiseClone();
				cloneObj.isRoot=false;
				return cloneObj;
			}
		}

		public void AppMain() {
			Naruto naruto = new Naruto();
			Console.WriteLine(naruto.isRoot);
			Console.WriteLine();
			var narutoDoppelganger = naruto.doppelganger();
			Console.WriteLine(naruto.isRoot);
			Console.WriteLine(narutoDoppelganger.isRoot);
		}
	}
}
