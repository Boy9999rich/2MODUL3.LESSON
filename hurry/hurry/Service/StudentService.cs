namespace hurry.Service;
using hurry.module;
using System.Text.Json;

public class StudentService
{
    private string studentFilePath;
    public StudentService()
    {
        studentFilePath = "../../../Data/Students.Json";
        if (File.Exists(studentFilePath) is false)
        {
            File.WriteAllText(studentFilePath, "[]");
        }
       
    }
    public bool CheckPassword(string username, string password)
    {
        
        var user = "fight";
        var pass = "again";
        if (username == user && password == pass)
        {
            return true;
        }
        return false;
    }
    public Student AddStudent(Student student)
    {
        student.Id = Guid.NewGuid();
        var students = GetStudents();
        students.Add(student);
        SaveData(students);
        return student;
    }
    public Student GetById(Guid StudentId)
    {
        var students = GetStudents();
        foreach (var student in students)
        {
            if (student.Id == StudentId)
            {
                return student;
            }
        }
        return null;
    }
    public bool DeleteStudent(Guid studentId)
    {
        var students = GetStudents();
        var studentFromDb = GetById(studentId);
        if (studentFromDb is null)
        {
            return false;
        }
        foreach (var resinInfo in students)
        {
            if (resinInfo.Id == studentId)
            {
                students.Remove(resinInfo);
                break;
            }
        }
        
        SaveData(students);
        return true;
    }
    public bool UpdateStudent(Student student)
    {
        var students = GetStudents();
        var studentFromDb = GetById(student.Id);
        if (studentFromDb is null)
        {
            return false;
        }
        var index = students.IndexOf(student);
        students[index] = student;
        SaveData(students);
        return true;
    }
    public List<Student> GetAllStudents()
    {
        return GetStudents();
    }
    private void SaveData(List<Student> students)
    {
        var studentsJson = JsonSerializer.Serialize(students);
        File.WriteAllText(studentFilePath, studentsJson);
    }
    private List<Student> GetStudents()
    {
        var studentsJson = File.ReadAllText(studentFilePath);
        var students = JsonSerializer.Deserialize<List<Student>>(studentsJson);
        return students;
    }
}   
