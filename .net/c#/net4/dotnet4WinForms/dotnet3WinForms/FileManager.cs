using dotnet2;
using System.Text.Json;

namespace dotnet3WinForms;

public class FileManager
{
	private string _dataFolder;

    public FileManager()
    {
        _dataFolder = "Students";
    }

    public void SaveStudent(Student student)
    {
        if (!Directory.Exists(_dataFolder))
            Directory.CreateDirectory(_dataFolder);

        var studentJson = JsonSerializer.Serialize(student);

        var studentName = $"{student.FirstName} {student.LastName}";
        var studentFile = studentName + ".json";
        var studentPath = Path.Combine(_dataFolder, studentFile);

        File.WriteAllText(studentPath, studentJson);
    }

    public Student LoadStudent()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var currentPath = Path.Combine(currentDirectory, _dataFolder);

        OpenFileDialog fileDialog = new OpenFileDialog();
        fileDialog.DefaultExt = ".json";
        fileDialog.Multiselect = false;
        fileDialog.InitialDirectory = currentPath;

        fileDialog.ShowDialog();

        var fileStream = fileDialog.OpenFile();
        var streamReader = new StreamReader(fileStream);
        var studentJson = streamReader.ReadToEnd();
        var student = JsonSerializer.Deserialize<Student>(studentJson);

        return student;
    }
}
