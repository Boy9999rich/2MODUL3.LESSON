

using System.Security.Cryptography.X509Certificates;

namespace hurry.Service;
using hurry.module;
using System.Text.Json;

public class TeacherService
{
    private string teacherFilePath;
    public TeacherService()
    {
        teacherFilePath = "../../../Data/teacher.json";
        if (File.Exists(teacherFilePath) is false)
        {
            File.WriteAllText(teacherFilePath, "[]");
        }

    }
    public Teacher AddTeacher(Teacher teacher)
    {
        teacher.Id = Guid.NewGuid();
        var teachers = GetTeachers();
        teachers.Add(teacher);
        SaveData(teachers);
        return teacher;
    }
    public Teacher GetById(Guid teacherId)
    {
        var teachers = GetTeachers();
        foreach (var teacher in teachers)
        {
            if (teacher.Id == teacherId)
            {
                return teacher;
            }
        }
        return null;
    }
    public bool DeleteTeacher(Guid teacher)
    {
        var teachers = GetTeachers();
        var teacherFromDb = GetById(teacher);
        if (teacherFromDb is null)
        {
            return false;
        }

        foreach(var teacherInRes in teachers)
        {
            if(teacherInRes.Id == teacher)
            {
                teachers.Remove(teacherInRes);
                break;
            }
        }
            SaveData(teachers);
            return true;
        
    }

    public bool UpdateTeacher(Teacher teacher)
    {
        var teachers = GetTeachers();
        var teachersFromDb = GetById(teacher.Id);
        if (teachersFromDb is null)
        {
            return false;
        }
        else
        {
            var index = teachers.IndexOf(teacher);
            teachers[index] = teacher;
            SaveData(teachers);
            return true;
        }
    }
    public bool CheckLogin(string password, string username)
    {
        var user = "boyka";
        var pass = "moyka";
        if (password == pass && username == user)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
  

    public List<Teacher> GetAllTeachers()
    {
        return GetTeachers();
    }

    public void SaveData(List<Teacher> teacher)
    {
        var result = JsonSerializer.Serialize(teacher);
        File.WriteAllText(teacherFilePath, result);
    }
    private List<Teacher> GetTeachers()
    {
        var result = File.ReadAllText(teacherFilePath);
        var ress = JsonSerializer.Deserialize<List<Teacher>>(result);
        return ress;
    }
   

    //private string teacherFile;
    //public TeacherService()
    //{
    //    teacherFile = "../../../Data/Teacher.Json";
    //    if (File.Exists(teacherFile) is false)
    //    {
    //        File.WriteAllText(teacherFile, "[]");
    //    }

    //}
    //public Teacher AddTeacher(Teacher teacher)
    //{
    //    teacher.Id = Guid.NewGuid();
    //    var teachers = GetTeachers();
    //    teachers.Add(teacher);
    //    SaveData(teachers);
    //    return teacher;
    //}
    //public Teacher GetByid(Guid teacherId)
    //{
    //    var teachers = GetTeachers();
    //    foreach (var teacher in teachers)
    //    {
    //        if (teacherId == teacher.Id)
    //        {
    //            return teacher;
    //        }
    //    }
    //    return null;
    //}
    //public bool CheckLogin(string username, string password)
    //{
    //    var user = "boyka";
    //    var pass = "moyka";
    //    if (username == user && password == pass)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }

    //}
    //public bool DeleteTeacher(Guid teacher)
    //{
    //    var teachers = GetTeachers();
    //    var teachersFromDb = GetByid(teacher);
    //    if (teachersFromDb is null)
    //    {
    //        return false;
    //    }
    //    teachers.Remove(teachersFromDb);
    //    SaveData(teachers);
    //    return true;
    //}
    //public bool UpdateTeacher(Teacher teacher)
    //{
    //    var teachers = GetTeachers();
    //    var teachersFromDb = GetByid(teacher.Id);
    //    if (teachersFromDb is null)
    //    {
    //        return false;
    //    }
    //    var index = teachers.IndexOf(teacher);
    //    teachers[index] = teacher;
    //    SaveData(teachers);
    //    return true;
    //}

    //public List<Teacher> GetAllTeachers()
    //{
    //    return GetTeachers();
    //}
    //private void SaveData(List<Teacher> teacher)
    //{
    //    var teacherJson = JsonSerializer.Serialize(teacher);
    //    File.WriteAllText(teacherFile, teacherJson);
    //}
    //private List<Teacher> GetTeachers()
    //{
    //    var teacherJson = File.ReadAllText(teacherFile);
    //    var teachers = JsonSerializer.Deserialize<List<Teacher>>(teacherJson);
    //    return teachers;
    //}
}
