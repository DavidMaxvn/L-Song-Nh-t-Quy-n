using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lê_Song_Nhật_Quyền
{
    public class Todo
    {
        public string name { get; set; }
        public int priority { get; set; }
        public string description { get; set; }
        public int status { get; set; }

        public Todo()
        {
            name = "";
            priority = 1;
            description = "";
            status = 0;
        }

        public Todo(string name, int priority, string description, int status)
        {
            this.name = name;
            this.priority = priority;
            this.description = description;
            this.status = status;
        }

        public void DisplayHeader()
        {
            Console.WriteLine($"{"Tên việc",-40} |{"Độ ưu tiên",-15} |{"Mô tả",-50} |{"Trạng thái",-15}");
            Console.WriteLine(new string('-', 120)); // Tạo dòng kẻ ngang để dễ nhìn hơn
        }

        public void DisplayRow()
        {
            string trangthai;
            switch (this.status)
            {
                case 0:
                    trangthai = "Hủy";
                    break;
                case 1:
                    trangthai = "Hoàn thành";
                    break;
                case 2:
                    trangthai = "Chờ";
                    break;
                default:
                    trangthai = "Không xác định";
                    break;
            }

            // Hiển thị dưới dạng bảng, với các cột được căn lề trái (khoảng cách cố định)
            Console.WriteLine($"{name,-40} |{priority,-15} |{description,-50} |{trangthai,-15}");
        }

    }
    public class Program
    {
        static void DeleteTodo(List<Todo> todoList)
        {
            Console.Clear();
            DisplayAllTodos(todoList);
            Console.Write("Nhập vị trí của việc làm cần xóa: ");
            int index = int.Parse(Console.ReadLine());

            if (index >= 0 && index < todoList.Count)
            {
                todoList.RemoveAt(index);
                Console.WriteLine("Việc đã được xóa thành công!");
            }
            else
            {
                Console.WriteLine("Chỉ số không hợp lệ!");
            }
            Console.WriteLine("Nhấn phím bất kỳ để tiếp tục...");
            Console.ReadKey();
        }

        static void UpdateTodoStatus(List<Todo> todoList)
        {
            Console.Clear();
            DisplayAllTodos(todoList);
            Console.Write("Nhập vị trí của việc làm cần cập nhật trạng thái: ");
            int index = int.Parse(Console.ReadLine());

            if (index >= 0 && index < todoList.Count)
            {
                Console.Write("Nhập trạng thái mới (0-Hủy, 1-Hoàn thành, 2-Chờ): ");
                int newStatus = int.Parse(Console.ReadLine());
                todoList[index].status = newStatus;
                Console.WriteLine("Trạng thái đã được cập nhật thành công!");
            }
            else
            {
                Console.WriteLine("Chỉ số không hợp lệ!");
            }
            Console.WriteLine("Nhấn phím bất kỳ để tiếp tục...");
            Console.ReadKey();
        }

        static void SearchTodoByName(List<Todo> todoList)
        {
            Console.Clear();
            Console.Write("Nhập tên việc cần tìm: ");
            string searchName = Console.ReadLine();
            var results = todoList.Where(t => t.name.IndexOf(searchName, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            if (results.Count > 0)
            {
                
                Todo tempTodo = new Todo();
                tempTodo.DisplayHeader(); 

                
                foreach (var todo in results)
                {
                    todo.DisplayRow(); 
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy việc nào phù hợp.");
            }

            Console.WriteLine("Nhấn phím bất kỳ để tiếp tục...");
            Console.ReadKey();
        }


        static void DisplayTodosByPriority(List<Todo> todoList)
        {
            Console.Clear();
            var sortedList = todoList.OrderByDescending(t => t.priority).ToList();

            if (sortedList.Count == 0)
            {
                Console.WriteLine("Không có việc nào trong danh sách.");
            }
            else
            {
                
                Todo tempTodo = new Todo();
                tempTodo.DisplayHeader(); 

                
                foreach (var todo in sortedList)
                {
                    todo.DisplayRow();
                }
            }
            Console.WriteLine("Nhấn phím bất kỳ để tiếp tục...");
            Console.ReadKey();
        }

        static void DisplayAllTodos(List<Todo> todoList)
        {
            Console.Clear();
            if (todoList.Count == 0)
            {
                Console.WriteLine("Chưa có việc nào được khai báo.");
            }
            else
            {
                
                Todo tempTodo = new Todo();
                tempTodo.DisplayHeader(); 

                
                foreach (var todo in todoList)
                {
                    todo.DisplayRow();
                }
            }
            Console.WriteLine("Nhấn phím bất kỳ để tiếp tục...");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            List<Todo> todoList = new List<Todo>()
            {
                new Todo("Tư tưởng Hồ Chí Minh",3,"Thứ 3 có tiết 6,7,8",2), //index 0
                new Todo("Phân tích thiết kế hướng đối tượng",4,"Thứ 4 có tiết 6,7,8,9,10",2), //index 1
                new Todo("Cơ sở dữ liệu nâng cao",4,"Thứ 5 có tiết 1,2,3,4,5",2), //index 2
                new Todo("Ngôn ngữ lập trình C#",5,"Thứ 5 có tiết 6,7,8,9,10",2), //index 3
                new Todo("Tiếng Anh B2 - 2",3,"Thứ 4 có tiết 6,7,8,9,10",2), //index 4
                new Todo("Giáo dục quốc phòng và an ninh III",2,"Đã hoàn thành",1), //index 5
                new Todo("Đi làm",1,"Tới công ty làm việc ?",0), //index 6
            };
            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();
                Console.WriteLine("==== Quản lý việc cần làm ====");
                Console.WriteLine("1. Xóa việc cần làm");
                Console.WriteLine("2. Cập nhật trạng thái việc cần làm");
                Console.WriteLine("3. Tìm kiếm việc cần làm theo tên");
                Console.WriteLine("4. Hiển thị danh sách việc cần làm theo độ ưu tiên giảm dần");
                Console.WriteLine("5. Hiển thị toàn bộ danh sách việc cần làm");
                Console.WriteLine("Esc hoặc nhấn q để thoát");
                Console.Write("Chọn chức năng: ");

                keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        DeleteTodo(todoList);
                        break;
                    case ConsoleKey.D2:
                        UpdateTodoStatus(todoList);
                        break;
                    case ConsoleKey.D3:
                        SearchTodoByName(todoList);
                        break;
                    case ConsoleKey.D4:
                        DisplayTodosByPriority(todoList);
                        break;
                    case ConsoleKey.D5:
                        DisplayAllTodos(todoList);
                        break;
                }

            } while (keyInfo.Key != ConsoleKey.Escape && keyInfo.Key != ConsoleKey.Q);
        }
    }
}
