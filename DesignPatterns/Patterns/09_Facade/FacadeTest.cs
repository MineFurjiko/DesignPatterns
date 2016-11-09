using DesignPatterns.Patterns._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Patterns._09_Facade {

	/// <summary>
	/// 以学生选课系统为例子演示外观模式的使用
	/// 学生选课模块包括功能有：
	/// 验证选课的人数是否已满
	/// 通知用户课程选择成功与否
	/// 客户端代码
	/// </summary>
	class Student {

	}

	// 外观类
	public class RegistrationFacade {
		private RegisterCourse registerCourse;
		private NotifyStudent notifyStudent;
		public RegistrationFacade() {
			registerCourse = new RegisterCourse();
			notifyStudent = new NotifyStudent();
		}

		public bool RegisterCourse(string courseName, string studentName) {
			if (!registerCourse.CheckAvailable(courseName)) {
				return false;
			}
			return notifyStudent.Notify(studentName);
		}
	}

	#region 子系统
	public class RegisterCourse {
		public bool CheckAvailable(string courseName) {
			Console.WriteLine("正在验证课程 {0} 是否有名额", courseName);
			return true;
		}
	}

	public class NotifyStudent {
		public bool Notify(string studentName) {
			Console.WriteLine("正在向 {0} 发生通知", studentName);
			return true;
		}
	}
	#endregion

	class FacadeTest : IMain {

		private static RegistrationFacade facade = new RegistrationFacade();

		public void AppMain() {
			if (facade.RegisterCourse("设计模式", "Learning Hard")) {
				Console.WriteLine("选课成功");
			}
			else {
				Console.WriteLine("选课失败");
			}

		}
	}
}
