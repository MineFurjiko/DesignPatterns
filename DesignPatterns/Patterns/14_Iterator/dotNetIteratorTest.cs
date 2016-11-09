using DesignPatterns.Patterns._Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns._14_Iterator {
	abstract class Box {
		protected string[] items = new string[10];
		protected int ctr = 0;
		protected Box(params string[] initialStrings) {
			foreach (string s in initialStrings) {
				items[ctr++] = s;
			}
		}

		public void Add(string str) {
			items[ctr++] = str;
		}

		public int GetLength() {
			return ctr;
		}
	}

	class ListBox : Box, IEnumerable {
		public ListBox(params string[] initialStrings)
			: base(initialStrings) {}

		public IEnumerator GetEnumerator() {
			return new ListBoxEnumerator(this);
		}

		private class ListBoxEnumerator : IEnumerator {
			private int _index;
			private ListBox _aggregate;

			public ListBoxEnumerator(ListBox aggregate) {
				this._aggregate = aggregate;
				this._index = -1;
			}
			public object Current {
				get { return _aggregate.items[_index]; }
			}

			public bool MoveNext() {
				if (++_index < _aggregate.ctr) {
					return true;
				}
				return false;
			}

			public void Reset() {
				_index = -1;
			}
		}

	}

	/// <summary>
	/// C# 2.0 
	/// </summary>
	class NewListBox : Box, IEnumerable<string> {

		public NewListBox(params string[] initialStrings)
			: base(initialStrings) {}

		public IEnumerator<string> GetEnumerator() {
			for (int i = 0; i < ctr; i++) {
				yield return items[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}



	class dotNetIteratorTest : IMain {
		public void AppMain() {
			//ListBox lb = new ListBox("hello", "Hi", "Hey");
			//foreach (var item in lb) {
			//	Console.WriteLine(item);
			//}
			//Console.WriteLine("----");
			//lb.Add("hallo");
			//foreach (var item in lb) {
			//	Console.WriteLine(item);
			//}

			NewListBox nlb = new NewListBox("hello", "Hi", "Hey");
			//var it = nlb.GetEnumerator();
			//while (it.MoveNext()) {
			//	Console.WriteLine(it.Current);
			//}
			//it.Reset();

			foreach (var item in nlb) {
				Console.WriteLine(item);
			}
		}
	}
}