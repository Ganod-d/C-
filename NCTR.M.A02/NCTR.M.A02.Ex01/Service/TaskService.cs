using NCTR.M.A02.Ex01.Entity;

namespace NCTR.M.A02.Ex01.Service;

public class TaskService
{
    public static List<TaskReminder> taskReminders = new List<TaskReminder>();

    public static void InputTask()
    {
        bool choose = false;
        do
        {
            TaskReminder taskReminder = new TaskReminder();

            System.Console.WriteLine("Moi ban nhap cong viec: ");
            string congViec = Console.ReadLine();

            // System.Console.WriteLine("Moi ban nhap ngay: ");
            // int ngay = int.Parse(Console.ReadLine());

            // System.Console.WriteLine("Moi ban nhap thang: ");
            // int thang = int.Parse(Console.ReadLine());

            // System.Console.WriteLine("Moi ban nhap nam: ");
            // int nam = int.Parse(Console.ReadLine());

            string ngayThucHien = "";

            do
            {
                System.Console.WriteLine("Nhap ngay thuc hien (dd/MM/yyyy or yyyy/MM/dd): ");
                ngayThucHien = Console.ReadLine();
            } while (ngayThucHien == "");

            string format = "dd/MM/yyyy";
            DateTime dateValue;

            bool success = DateTime.TryParseExact(ngayThucHien, format, 
                                              System.Globalization.CultureInfo.InvariantCulture, 
                                              System.Globalization.DateTimeStyles.None, 
                                              out dateValue);


            taskReminder.taskName = congViec;
            taskReminder.taskTime = dateValue;

            taskReminders.Add(taskReminder);

            System.Console.WriteLine("Ban co muon tiep tuc hay khong (Y/N)");
            string check = Console.ReadLine();
            if (check == "Y" || check == "y")
            {
                choose = true;
            }
            else
            {
                choose = false;
            }
        } while (choose == true);

    }

    public static void DisplayTask()
    {
        foreach (var item in taskReminders)
        {
            System.Console.WriteLine(String.Format("Task: {0} created on {1} - Reminder: {2}", item.taskName, item.taskTime, item.taskTime));
        }
    }
}
