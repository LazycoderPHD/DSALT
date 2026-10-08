using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("================ BÀI TẬP DANH SÁCH LIÊN KẾT ================");
            Console.WriteLine("1. Chạy Bài 1: Tạo DS, thêm 315 trước 900, sắp xếp tăng dần, tìm node trước 113");
            Console.WriteLine("2. Chạy Bài Nâng Cao 1: Thêm phần tử vào DS sao cho luôn giữ thứ tự tăng dần");
            Console.WriteLine("3. Chạy Bài Nâng Cao 2: Xóa tất cả các số chia hết cho 2");
            Console.WriteLine("4. Chạy Bài Nâng Cao 3: Sắp xếp danh sách giảm dần");
            Console.WriteLine("0. Thoát chương trình");
            Console.Write("Nhập lựa chọn của bạn (0-4): ");
            
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    ChayBai1();
                    break;
                case "2":
                    ChayBaiNangCao1();
                    break;
                case "3":
                    ChayBaiNangCao2();
                    break;
                case "4":
                    ChayBaiNangCao3();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ! Vui lòng chọn lại.");
                    break;
            }

            Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
            Console.ReadKey();
        }
    }

    // ================= BÀI 1 =================
    static void ChayBai1()
    {
        Console.WriteLine("--- CHẠY BÀI 1 ---");
        // 1. Tạo danh sách lưu trữ dãy số: 234, 77, 0, 113, 404, 94, 900, 113, 15, 300, 13, 135
        LinkedList<int> list = new LinkedList<int>(new int[] { 234, 77, 0, 113, 404, 94, 900, 113, 15, 300, 13, 135 });

        Console.WriteLine("Danh sách ban đầu:");
        PrintList(list);

        // 2. Thêm số 315 vào trước số 900
        LinkedListNode<int> node900 = list.Find(900);
        if (node900 != null)
        {
            list.AddBefore(node900, 315);
        }
        Console.WriteLine("Sau khi thêm 315 trước 900:");
        PrintList(list);

        // 3. Sắp xếp dãy số theo thứ tự tăng dần
        List<int> tempList = new List<int>(list);
        tempList.Sort();
        list = new LinkedList<int>(tempList);
        Console.WriteLine("Sau khi sắp xếp tăng dần:");
        PrintList(list);

        // 4. Tìm và in ra nút đứng trước nút 113
        Console.WriteLine("Tìm các nút đứng trước nút 113:");
        LinkedListNode<int> current = list.First;
        bool found = false;
        while (current != null)
        {
            if (current.Value == 113 && current.Previous != null)
            {
                Console.WriteLine($"- Nút đứng trước 113 có giá trị: {current.Previous.Value}");
                found = true;
            }
            current = current.Next;
        }
        if (!found) Console.WriteLine("Không tìm thấy nút đứng trước 113 (hoặc 113 đứng đầu danh sách).");
    }

    // ================= BÀI NÂNG CAO 1 =================
    static void ChayBaiNangCao1()
    {
        Console.WriteLine("--- CHẠY BÀI NÂNG CAO 1 ---");
        Console.WriteLine("Tạo danh sách liên kết sao cho mỗi lần thêm số mới sẽ tự động đúng theo thứ tự tăng dần.");
        
        int[] inputArray = { 234, 77, 0, 113, 404, 94, 900, 113, 15, 300, 13, 135 };
        LinkedList<int> sortedList = new LinkedList<int>();

        foreach (int num in inputArray)
        {
            InsertSorted(sortedList, num);
        }

        Console.WriteLine("Kết quả danh sách tăng dần:");
        PrintList(sortedList);
    }

    // Hàm phụ trợ cho Nâng cao 1: Chèn phần tử vào đúng vị trí tăng dần
    static void InsertSorted(LinkedList<int> list, int value)
    {
        if (list.First == null || value <= list.First.Value)
        {
            list.AddFirst(value);
            return;
        }

        LinkedListNode<int> current = list.First;
        while (current != null && current.Value < value)
        {
            current = current.Next;
        }

        if (current == null)
        {
            list.AddLast(value);
        }
        else
        {
            list.AddBefore(current, value);
        }
    }

    // ================= BÀI NÂNG CAO 2 =================
    static void ChayBaiNangCao2()
    {
        Console.WriteLine("--- CHẠY BÀI NÂNG CAO 2 ---");
        LinkedList<int> list = new LinkedList<int>(new int[] { 234, 77, 0, 113, 404, 94, 900, 113, 15, 300, 13, 135 });
        
        Console.WriteLine("Danh sách ban đầu:");
        PrintList(list);

        // Xóa tất cả các số chia hết cho 2
        LinkedListNode<int> node = list.First;
        while (node != null)
        {
            LinkedListNode<int> nextNode = node.Next; // Lưu node tiếp theo trước khi xóa
            if (node.Value % 2 == 0)
            {
                list.Remove(node);
            }
            node = nextNode;
        }

        Console.WriteLine("Sau khi xóa tất cả các số chia hết cho 2 (số chẵn):");
        PrintList(list);
    }

    // ================= BÀI NÂNG CAO 3 =================
    static void ChayBaiNangCao3()
    {
        Console.WriteLine("--- CHẠY BÀI NÂNG CAO 3 ---");
        LinkedList<int> list = new LinkedList<int>(new int[] { 234, 77, 0, 113, 404, 94, 900, 113, 15, 300, 13, 135 });
        
        Console.WriteLine("Danh sách ban đầu:");
        PrintList(list);

        // Sắp xếp danh sách liên kết theo thứ tự giảm dần
        List<int> tempList = new List<int>(list);
        tempList.Sort((a, b) => b.CompareTo(a)); // Sắp xếp giảm dần
        list = new LinkedList<int>(tempList);

        Console.WriteLine("Sau khi sắp xếp theo thứ tự giảm dần:");
        PrintList(list);
    }

    // Hàm tiện ích in danh sách
    static void PrintList(LinkedList<int> list)
    {
        Console.WriteLine("{ " + string.Join(", ", list) + " }");
    }
}