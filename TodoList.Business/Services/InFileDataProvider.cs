using System.IO;
using TodoList.Business.Vo;

namespace TodoList.Business.Services
{
    public class InFileDataProvider
    {
        public void SaveToFile(TodoItem todoItem)
        {
            string line = todoItem.Id + " " + todoItem.Name + " " + todoItem.Description + " " + todoItem.Priority;
            string path = Directory.GetCurrentDirectory()+"\\Files\\TodoItems.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(line);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(line);
                }
            }
        }
        public void SaveToFile(Category category)
        {
            string line = category.Id + " " + category.Name;
            string path = Directory.GetCurrentDirectory() + "\\Files\\Categories.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(line);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(line);
                }
            }
        }
    }
}
