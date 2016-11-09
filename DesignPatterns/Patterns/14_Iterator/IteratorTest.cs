using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns._14_Iterator {
	/// <summary>
	/// 迭代器接口
	/// </summary>
	interface Iterator {
		bool MoveNext();
		Object GetCurrent();
		void Next();
		void Reset();
	}

	/// <summary>
	/// 具体迭代器
	/// </summary>
	class ConcreteIterator : Iterator {
		private IAggregate _aggregate;
		private int _index;

		public ConcreteIterator(IAggregate aggregate){
			this._aggregate = aggregate;
			this._index = 0;
		}

		public bool MoveNext() {
			if (_index<_aggregate.Length) {
				return true;
			}
			return false;
		}

		public object GetCurrent() {
			return _aggregate.GetElement(_index);
		}

		public void Next() {
			if (_index < _aggregate.Length) {
				_index++;
			}
		}

		public void Reset() {
			_index = 0;
		}
	}

	/// <summary>
	/// 聚集抽象接口 
	/// </summary>
	interface IAggregate {
		int Length { get;  }
		Object GetElement(int index);
		Iterator GetIterator();
	}

	/// <summary>
	/// 具体聚合类
	/// </summary>
	class ConcreteAggregate<T> : IAggregate {
		T[] collection;
		int length;

		public int Length { get { return this.length; } }
		public ConcreteAggregate(int length) {
			this.collection = new T[length];
			this.length = length;
		}

		public T this[int index]{
			get { return this.collection[index]; }
			set { this.collection[index] = value; }
		}

		public Iterator GetIterator() {
			return new ConcreteIterator(this);
		}


		public object GetElement(int index) {
			return this[index];
		}
	}


	class Point{
		private int x, y;

		public int X {
			get { return x; }
			set { x = value; }
		}

		public int Y {
			get { return y; }
			set { y = value; }
		}

		public Point(int x, int y) {
			this.x = x;
			this.y = y;
		}

		public string PrintPoint() {
			return string.Format( "Point:({0} , {1})",this.x,this.y);
		}

		public override string ToString() {
			return PrintPoint();
		}
	}

	class IteratorTest:IMain{
		public void AppMain() {
			const int arrayLength = 5;
			ConcreteAggregate<int> ca = new ConcreteAggregate<int>(arrayLength);
			for (int i = 0; i < arrayLength; i++) {
				ca[i] = i;
			}
			Iterator it = ca.GetIterator();
			while (it.MoveNext()) {
				Console.WriteLine(it.GetCurrent());
				it.Next();
			}
			Console.WriteLine();

			ConcreteAggregate<Point> ca2 = new ConcreteAggregate<Point>(arrayLength);
			for (int i = 0; i < arrayLength; i++) {
				ca2[i] = new Point(i, i * 2);
			}

			it = ca2.GetIterator();
			while (it.MoveNext()) {
				Console.WriteLine(it.GetCurrent());
				it.Next();
			}

		}
	}
}
