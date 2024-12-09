
using _2._2Dars.Services;
using hurry.module;
using hurry.Service;
using _2._2Dars.Models;
using System.Security.Cryptography.X509Certificates;


namespace hurry
{
    internal class program
    {
        static void Main(string[] args)
        {
            FileMenu();
        }
        public static void FileMenu()
        {
            Console.WriteLine("1.Director");
            Console.WriteLine("2.Teacher");
            Console.WriteLine("3.Student");

            Console.WriteLine("choose =>> ");
            var option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                DirectorMenu();
            }
            if (option == 2)
            {
               TeacherMenu();
            }
            if (option == 3)
            {
                 StudentMenu();
            }
            
        }
        public static void DirectorMenu()
        {
            var teacherService = new TeacherService();
            var directorService = new DirectorService();

            while (true)
            {
                Console.WriteLine("Enter UserName");
                var username = Console.ReadLine();
                Console.WriteLine("Enter password");
                var password = Console.ReadLine();
                var result = directorService.CheckLogin(username, password);

                if (result is false)
                {
                    Console.WriteLine("error");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                else
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("1. AddTeacher");
                        Console.WriteLine("2. GetById");
                        Console.WriteLine("3. DeleteTeacher");
                        Console.WriteLine("4. UpdateTeacher");
                        Console.WriteLine("5. GetAllTeacher");
                        Console.WriteLine("6. UpdateLogin");
                        Console.WriteLine("choose =>> ");
                        var option = int.Parse(Console.ReadLine());
                        Console.Clear();
                        if (option == 1)
                        {
                            var newTeacher = new Teacher();
                            Console.WriteLine("Add FirstName");
                            newTeacher.Firstname = Console.ReadLine();
                            Console.WriteLine("Add LastName");
                            newTeacher.Lastname = Console.ReadLine();
                            Console.WriteLine("Add Age");
                            newTeacher.Age = int.Parse(Console.ReadLine());
                            Console.WriteLine("Add Subject");
                            newTeacher.Subject = Console.ReadLine();
                            Console.WriteLine("Add Gender");
                            newTeacher.Gender = Console.ReadLine();
                            Console.WriteLine("Add Likes");
                            newTeacher.Likes = int.Parse(Console.ReadLine());
                            Console.WriteLine("Add DisLikes");
                            newTeacher.DisLikes = int.Parse(Console.ReadLine());
                            Console.WriteLine("Add Username");
                            newTeacher.UserName = Console.ReadLine();
                            Console.WriteLine("Add Password");
                            newTeacher.Password = Console.ReadLine();

                            teacherService.AddTeacher(newTeacher);
                            Console.WriteLine("Added Successfully");
                        }
                        else if (option == 2)
                        {
                            Console.WriteLine("Enter Teachers Id");
                            var id = Guid.Parse(Console.ReadLine());
                            var ress = teacherService.GetById(id);
                            if (ress is null)
                            {
                                Console.WriteLine("Error Id");
                            }
                            else
                            {
                                Console.WriteLine($"Teachers Id : {ress.Id}");
                                Console.WriteLine($"teachers FirstName : {ress.Firstname}");
                                Console.WriteLine($"teachers Lastname : {ress.Lastname}");
                                Console.WriteLine($"teachers Age : {ress.Age}");
                                Console.WriteLine($"teachers Subject : {ress.Subject}");
                                Console.WriteLine($"teachers Gender : {ress.Gender}");
                                Console.WriteLine($"teachers Likes : {ress.Likes}");
                                Console.WriteLine($"teachers DisLikes : {ress.DisLikes}");
                                Console.WriteLine($"teachers UserName : {ress.UserName}");
                                Console.WriteLine($"teachers Passsword : {ress.Password}");
                            }
                        }
                        else if (option == 3)
                        {
                            Console.WriteLine("Delete teachers.Id");
                            var id = Guid.Parse(Console.ReadLine());
                            var ress = teacherService.DeleteTeacher(id);
                            if (ress is true)
                            {
                                Console.WriteLine("Deleted Teacher");
                            }
                            else
                            {
                                Console.WriteLine("error");
                            }
                        }
                        else if (option == 4)
                        {
                            var newTeacher = new Teacher();
                            Console.WriteLine("Enter Teachers Updated Id");
                            newTeacher.Id = Guid.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Teachers Updated Firstname");
                            newTeacher.Firstname = Console.ReadLine();
                            Console.WriteLine("Eneter Teachers Updated Lastname");
                            newTeacher.Lastname = Console.ReadLine();
                            Console.WriteLine("Enter Teachers Updated Age");
                            newTeacher.Age = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Teachers Updated Subject");
                            newTeacher.Subject = Console.ReadLine();
                            Console.WriteLine("Enter Teachers Updated Gender ");
                            newTeacher.Gender = Console.ReadLine();
                            Console.WriteLine("Enter Teachers Updated Likes");
                            newTeacher.Likes = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Teachers Updated DisLikes");
                            newTeacher.DisLikes = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Teachers Updated UserName");
                            newTeacher.UserName = Console.ReadLine();
                            Console.WriteLine("Enter Teachers Updated Password");
                            newTeacher.Password = Console.ReadLine();
                            var ress = teacherService.UpdateTeacher(newTeacher);
                            if (ress is true)
                            {
                                Console.WriteLine("Updated Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Error Occured");
                            }
                        }
                        else if (option == 5)
                        {
                            var allTeachers = teacherService.GetAllTeachers();

                            foreach (var ress in allTeachers)
                            {
                                Console.WriteLine($"Teachers Id : {ress.Id}");
                                Console.WriteLine($"Teachers FirstName : {ress.Firstname}");
                                Console.WriteLine($"Teachers LastName : {ress.Lastname}");
                                Console.WriteLine($"Teachers Age : {ress.Age}");
                                Console.WriteLine($"Teachers Subject : {ress.Subject}");
                                Console.WriteLine($"Teachers Gender : {ress.Gender}");
                                Console.WriteLine($"Teachers Likes : {ress.Likes}");
                                Console.WriteLine($"Teachers DisLikes : {ress.DisLikes}");
                                Console.WriteLine($"teachers UserName : {ress.UserName}");
                                Console.WriteLine($"teachers Password : {ress.Password}");
                                Console.WriteLine("\n");

                            }
                        }
                        else if (option == 6)
                        {
                            directorService.ChangeLogin();
                        }
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
               
            }
        }
        public static void TeacherMenu()
        {
            var teacherService = new TeacherService();
            var studentService = new StudentService();
            var testService = new TestService();

            while (true)
            {
                Console.WriteLine("enter username");
                var username = Console.ReadLine();
                Console.WriteLine("Enter password");
                var password = Console.ReadLine();

                var result = teacherService.CheckLogin(username, password);

                if (result is false)
                {
                    Console.WriteLine("error");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                else
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("1.Add Student");
                        Console.WriteLine("2.GetById");
                        Console.WriteLine("3.Delete Student");
                        Console.WriteLine("4.Update Student");
                        Console.WriteLine("5.Get All Students");
                        Console.WriteLine("6.Add Test");
                        Console.WriteLine("7.GetById");
                        Console.WriteLine("8.Delete Test");
                        Console.WriteLine("9.Update Test");
                        Console.WriteLine("10.Get All Test");

                        Console.WriteLine("Choose =>> ");
                        var option = int.Parse(Console.ReadLine());
                        Console.Clear();

                        if (option == 1)
                        {
                            var newStudent = new Student();
                            Console.WriteLine("Enter Students Firstname");
                            newStudent.Firstname = Console.ReadLine();
                            Console.WriteLine("Enter Students LastName");
                            newStudent.LastName = Console.ReadLine();
                            Console.WriteLine("Enter Students Age");
                            newStudent.Age = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Students Gender");
                            newStudent.Gender = Console.ReadLine();
                            Console.WriteLine("Enter Students Degree");
                            newStudent.Degree = Double.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Students userName");
                            newStudent.Username = Console.ReadLine();
                            Console.WriteLine("Enter Students password");
                            newStudent.Password = Console.ReadLine();

                            Console.WriteLine("Added Successfully");

                            studentService.AddStudent(newStudent);

                        }

                        else if (option == 2)
                        {
                            Console.WriteLine("enter id");
                            var id = Guid.Parse(Console.ReadLine());

                            var resultt = studentService.GetById(id);

                            if (resultt is null)
                            {
                                Console.WriteLine("id is wrong");
                            }
                            else
                            {
                                Console.WriteLine($"Students Id : {resultt.Id}");
                                Console.WriteLine($"Students Firstname : {resultt.Firstname}");
                                Console.WriteLine($"Students LastName : {resultt.LastName}");
                                Console.WriteLine($"Students Age : {resultt.Age}");
                                Console.WriteLine($"Students Degree : {resultt.Degree}");
                                Console.WriteLine($"Enter Students Gender : {resultt.Gender}");
                                Console.WriteLine($"Enter Stuents UserName : {resultt.Username}");
                                Console.WriteLine($"Enter Students Password : {resultt.Password}");

                                Console.WriteLine("student results");
                                foreach (var ress in resultt.Results)
                                {
                                    Console.WriteLine($"{ress}");
                                }
                            }
                        }

                        else if (option == 3)
                        {
                            Console.WriteLine("Enter Deleted id");
                            var id = Guid.Parse(Console.ReadLine());
                            var resultt = studentService.DeleteStudent(id);
                            if (resultt is true)
                            {
                                Console.WriteLine("Deleted Successfully");
                            }
                            else
                            {
                                Console.WriteLine("error occured");
                            }
                        }
                        else if (option == 4)
                        {

                            var newStudent = new Student();
                            Console.WriteLine("Enter Students Id");
                            newStudent.Id = Guid.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Students FirstName");
                            newStudent.Firstname = Console.ReadLine();
                            Console.WriteLine("Enter Students LastName");
                            newStudent.LastName = Console.ReadLine();
                            Console.WriteLine("Enter Students Age");
                            newStudent.Age = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Students Degree");
                            newStudent.Degree = double.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Students Gender");
                            newStudent.Gender = Console.ReadLine();
                            Console.WriteLine("Enter Students Username");
                            newStudent.Username = Console.ReadLine();
                            Console.WriteLine("Enter Students Password");
                            newStudent.Password = Console.ReadLine();
                            var resultt = studentService.UpdateStudent(newStudent);
                            if (result is true)
                            {
                                Console.WriteLine("updated Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Error occured");
                            }
                        }
                        else if (option == 5)
                        {
                            var resultt = studentService.GetAllStudents();
                            foreach (var ress in resultt)
                            {
                                Console.WriteLine($"Students Id : {ress.Id}");
                                Console.WriteLine($"Students Firstname : {ress.Firstname}");
                                Console.WriteLine($"Students Lastname : {ress.LastName}");
                                Console.WriteLine($"Students Age : {ress.Age}");
                                Console.WriteLine($"Students Degree : {ress.Degree}");
                                Console.WriteLine($"Students Gender : {ress.Gender}");
                                Console.WriteLine($"Students UserName : {ress.Username}");
                                Console.WriteLine($"Students password : {ress.Password}");

                                Console.WriteLine($"Students Result");
                                foreach (var info in ress.Results)
                                {
                                    Console.WriteLine($"{info}");
                                }
                            }
                        }
                        else if (option == 6)
                        {
                            var test = new Test();
                            Console.WriteLine("Enter TestQuestion");
                            test.QuestionText = Console.ReadLine();
                            Console.WriteLine("Enter A variant");
                            test.AVariant = Console.ReadLine();
                            Console.WriteLine("Enter BVariant");
                            test.BVariant = Console.ReadLine();
                            Console.WriteLine("Enter CVariant");
                            test.CVariant = Console.ReadLine();
                            Console.WriteLine("Enter Answer");
                            test.Answer = Console.ReadLine();
                            Console.WriteLine("Test Added");
                            testService.AddTest(test);

                        }

                        else if (option == 7)
                        {
                            Console.WriteLine("Enter Id");
                            var id = Guid.Parse(Console.ReadLine());
                            var resultt = testService.GetById(id);

                            if (resultt is null)
                            {
                                Console.WriteLine("error");
                            }
                            else
                            {
                                Console.WriteLine($"Test Id : {resultt.Id}");
                                Console.WriteLine($"Test QuestionText : {resultt.QuestionText}");
                                Console.WriteLine($"test AVariant : {resultt.BVariant}");
                                Console.WriteLine($"test Bvariant : {resultt.BVariant}");
                                Console.WriteLine($"Tests CVariant : {resultt.CVariant}");
                                Console.WriteLine($"tests Answer : {resultt.Answer}");
                            }
                        }
                        else if (option == 8)
                        {
                            Console.WriteLine("Enter Deleted Id");
                            var id = Guid.Parse(Console.ReadLine());
                            var resultt = testService.DeleteTest(id);
                            if (resultt is true)
                            {
                                Console.WriteLine("Deleted Successfully");
                            }

                            Console.WriteLine("Error");
                        }

                        else if (option == 9)
                        {
                            var test = new Test();

                            Console.WriteLine("Enter Id");
                            test.Id = Guid.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Question Text");
                            test.QuestionText = Console.ReadLine();
                            Console.WriteLine("Enter AVariant");
                            test.AVariant = Console.ReadLine();
                            Console.WriteLine("ENter bVariant");
                            test.BVariant = Console.ReadLine();
                            Console.WriteLine("Enter CVariant");
                            test.CVariant = Console.ReadLine();
                            Console.WriteLine("Enter Answer ");
                            test.Answer = Console.ReadLine();

                            var resultt = testService.UpdateTest(test);

                            if (resultt is true)
                            {
                                Console.WriteLine("Updated SuccessFully");
                            }
                            else
                            {
                                Console.WriteLine("error");
                            }
                        }

                        else if (option == 10)
                        {
                            var results = testService.GetAllTests();
                            foreach (var resultt in results)
                            {
                                Console.WriteLine($"{resultt.QuestionText}");
                                Console.WriteLine($"{resultt.AVariant}");
                                Console.WriteLine($"{resultt.BVariant}");
                                Console.WriteLine($"{resultt.CVariant}");
                                Console.WriteLine($"{resultt.Answer}");
                            }
                        }
                        Console.ReadKey();
                        Console.Clear();

                    }
                }
            }
        }
        public static void StudentMenu()
        {
            var studentService = new StudentService();
            var testService = new TestService();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter username");
                var username = Console.ReadLine();
                Console.WriteLine("Enter password");
                var password = Console.ReadLine();

                var resultCheck = studentService.CheckPassword(username, password);
                if (resultCheck is false)
                {
                    Console.WriteLine("wrong password");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                else
                {
                    while (true)
                    {
                        var allStudent = studentService.GetAllStudents();
                        var student = new Student();
                        foreach (var studentt in allStudent)
                        {
                            if (studentt.Username == username)
                            {
                                student = studentt;
                                break;
                            }    
                        }
                        Console.Clear();
                        Console.WriteLine("1.GetTestsById");
                        Console.WriteLine("2.Get All Tests");
                        Console.WriteLine("3.my Answers");
                        Console.WriteLine("choose =>> ");
                        var option = int.Parse(Console.ReadLine());
                        if (option == 1)
                        {
                            Console.WriteLine("Enter id");
                            var id = Guid.Parse(Console.ReadLine());

                            var result = testService.GetById(id);
                            if (result is null)
                            {
                                Console.WriteLine("error");
                            }
                            else
                            {
                                Console.WriteLine($"Test Id : {result.Id}");
                                Console.WriteLine($"Test QuestionText : {result.QuestionText}");
                                Console.WriteLine($"test AVariant : {result.AVariant}");
                                Console.WriteLine($"test BVariant : {result.BVariant}");
                                Console.WriteLine($"Test CVariant : {result.CVariant}");
                                Console.WriteLine($"test Answeer : {result.Answer}");

                                Console.WriteLine("Enter Answer");
                                var studentAnswer = Console.ReadLine();
                                if (studentAnswer == result.Answer)
                                {
                                    student.Results.Add(1);
                                    studentService.UpdateStudent(student);
                                }
                                else
                                {
                                    student.Results.Add(0);
                                    studentService.UpdateStudent(student);
                                }
                            }
                        }
                        else if (option == 2)
                        {
                            var allStudents = testService.GetAllTests();
                            foreach (var result in allStudents)
                            {
                                Console.WriteLine($"Tests Id : {result.Id}");
                                Console.WriteLine($"tests QuestionText : {result.QuestionText}");
                                Console.WriteLine($"tests AVariant : {result.AVariant}");
                                Console.WriteLine($"tests BVariant : {result.BVariant}");
                                Console.WriteLine($"tests CVariant : {result.Answer}");

                                Console.WriteLine("Enter Answer");
                                var studentAnswer = Console.ReadLine();
                                if (studentAnswer == result.Answer)
                                {
                                    student.Results.Add(1);
                                    studentService.UpdateStudent(student);
                                }
                                else
                                {
                                    student.Results.Add(0);
                                    studentService.UpdateStudent(student);
                                }
                            }
                        }
                        else if (option == 3)
                        {
                            foreach (var result in student.Results)
                            {
                                Console.WriteLine($"{result}");
                            }
                        }
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
        }

        //    public static void StudentMenu()
        //    {
        //        var studentService = new StudentService();
        //        var testService = new TestService();
        //        while (true)
        //        {
        //            Console.Clear();
        //            Console.WriteLine("Enter username");
        //            var username = Console.ReadLine();
        //            Console.WriteLine("Enter password");
        //            var password = Console.ReadLine();

        //            var resultCheck = studentService.CheckPassword(username, password);

        //            if (resultCheck is false)
        //            {
        //                Console.WriteLine("wrong password");
        //                Console.ReadKey();
        //                Console.Clear();
        //                continue;
        //            }
        //            else
        //            {
        //                while (true)
        //                {
        //                    var allStudent = studentService.GetAllStudents();
        //                    var student = new Student();
        //                    foreach (var studentt in allStudent)
        //                    {
        //                        if (studentt.UserName == username)
        //                        {
        //                            student = studentt;
        //                            break;
        //                        }
        //                    }
        //                    Console.Clear();
        //                    Console.WriteLine("1.GetTestsById");
        //                    Console.WriteLine("2.Get All Tests");
        //                    Console.WriteLine("3.my Answers");
        //                    Console.WriteLine("choose =>> ");
        //                    var option = int.Parse(Console.ReadLine());

        //                    if (option == 1)
        //                    {
        //                        Console.WriteLine("Enter Test Id");
        //                        var id = Guid.Parse(Console.ReadLine());

        //                        var result = testService.GetById(id);
        //                        if (result is null)
        //                        {
        //                            Console.WriteLine("id is wrong");
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine($"Test Id : {result.Id}");
        //                            Console.WriteLine($"Test QuestionText : {result.QuestionText}");
        //                            Console.WriteLine($"test AVariant : {result.AVariant}");
        //                            Console.WriteLine($"test BVariant : {result.BVariant}");
        //                            Console.WriteLine($"Test CVariant : {result.CVariant}");
        //                            Console.WriteLine($"test Answeer : {result.Answer}");

        //                            Console.WriteLine("Enter Answer");
        //                            var studentAnswer = Console.ReadLine();
        //                            if (studentAnswer == result.Answer)
        //                            {
        //                                student.Results.Add(1);
        //                                studentService.UpdateStudent(student);
        //                            }
        //                            else
        //                            {
        //                                student.Results.Add(0);
        //                                studentService.UpdateStudent(student);
        //                            }
        //                        }
        //                    }
        //                    else if (option == 2)
        //                    {
        //                        var allTests = testService.GetAllTest();
        //                        foreach (var result in allTests)
        //                        {
        //                            Console.WriteLine($"Tests Id : {result.Id}");
        //                            Console.WriteLine($"tests QuestionText : {result.QuestionText}");
        //                            Console.WriteLine($"tests AVariant : {result.AVariant}");
        //                            Console.WriteLine($"tests BVariant : {result.BVariant}");
        //                            Console.WriteLine($"tests CVariant : {result.Answer}");

        //                            Console.WriteLine("Enter Answer = >> ");
        //                            var studentAnswer = Console.ReadLine();
        //                            if (studentAnswer == result.Answer)
        //                            {
        //                                student.Results.Add(1);
        //                                studentService.UpdateStudent(student);
        //                            }
        //                            else
        //                            {
        //                                student.Results.Add(0);
        //                                studentService.UpdateStudent(student);
        //                            }
        //                        }
        //                    }
        //                    else if (option == 3)
        //                    {
        //                        foreach (var result in student.Results)
        //                        {
        //                            Console.Write($"{result}");
        //                        }
        //                    }
        //                    Console.ReadKey();
        //                    Console.Clear();
        //                }
        //            }
        //        }
        //    }

        //    public static void FileMenu()
        //    {
        //        Console.WriteLine("1.Director");
        //        Console.WriteLine("2.Teacher");
        //        Console.WriteLine("3.Student");
        //        Console.WriteLine("choose =>> ");
        //        var option = int.Parse(Console.ReadLine());
        //        if (option == 1)
        //        {
        //            directorMenu();
        //        }
        //        if (option == 2)
        //        {
        //            teacherMenu();
        //        }
        //        if (option == 3)
        //        {
        //            StudentMenu();
        //        }
        //    }
        //    public static void directorMenu()
        //    {
        //        var teacherService = new TeacherService();
        //        var directorService = new DirectorService();
        //        while (true)
        //        {
        //            Console.WriteLine("Enter UserName");
        //            var userName = Console.ReadLine();
        //            Console.WriteLine("Enter Password");
        //            var password = Console.ReadLine();
        //            var res = directorService.CheckLogin(userName, password);
        //            Console.Clear();
        //            if (res is false)
        //            {
        //                Console.WriteLine("Error");
        //                Console.ReadKey();
        //                Console.Clear();
        //                continue;
        //            }
        //            else
        //            {
        //                while (true)
        //                {
        //                    Console.WriteLine("1. AddTeacher");
        //                    Console.WriteLine("2. GetById");
        //                    Console.WriteLine("3. DeleteTeacher");
        //                    Console.WriteLine("4. UpdateTeacher");
        //                    Console.WriteLine("5. GetAllTeacher");
        //                    Console.WriteLine("6. UpdateLogin");
        //                    Console.WriteLine("choose =>> ");
        //                    var option = int.Parse(Console.ReadLine());
        //                    Console.Clear();
        //                    if (option == 1)
        //                    {
        //                        var newTeacher = new Teacher();
        //                        Console.WriteLine("Add FirstName");
        //                        newTeacher.FirstName = Console.ReadLine();
        //                        Console.WriteLine("Add LastName");
        //                        newTeacher.LastName = Console.ReadLine();
        //                        Console.WriteLine("Add Age");
        //                        newTeacher.Age = int.Parse(Console.ReadLine());
        //                        Console.WriteLine("Add Subject");
        //                        newTeacher.Subject = Console.ReadLine();
        //                        Console.WriteLine("Add Gender");
        //                        newTeacher.Gender = Console.ReadLine();
        //                        Console.WriteLine("Add Likes");
        //                        newTeacher.Likes = int.Parse(Console.ReadLine());
        //                        Console.WriteLine("Add DisLikes");
        //                        newTeacher.DisLikes = int.Parse(Console.ReadLine());
        //                        Console.WriteLine("Add Username");
        //                        newTeacher.UserName = Console.ReadLine();
        //                        Console.WriteLine("Add Password");
        //                        newTeacher.Password = Console.ReadLine();
        //                        teacherService.AddTeacher(newTeacher);
        //                        Console.WriteLine("Added Successfully");
        //                    }
        //                    else if (option == 2)
        //                    {
        //                        Console.WriteLine("Enter Teachers Id");
        //                        var id = Guid.Parse(Console.ReadLine());
        //                        var ress = teacherService.GetByid(id);
        //                        if (ress is null)
        //                        {
        //                            Console.WriteLine("Error Id");
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine($"Teachers Id : {ress.Id}");
        //                            Console.WriteLine($"teachers FirstName : {ress.FirstName}");
        //                            Console.WriteLine($"teachers Lastname : {ress.LastName}");
        //                            Console.WriteLine($"teachers Age : {ress.Age}");
        //                            Console.WriteLine($"teachers Subject : {ress.Subject}");
        //                            Console.WriteLine($"teachers Gender : {ress.Gender}");
        //                            Console.WriteLine($"teachers Likes : {ress.Likes}");
        //                            Console.WriteLine($"teachers DisLikes : {ress.DisLikes}");
        //                            Console.WriteLine($"teachers UserName : {ress.UserName}");
        //                            Console.WriteLine($"teachers Passsword : {ress.Password}");
        //                        }
        //                    }
        //                    else if (option == 3)
        //                    {
        //                        Console.WriteLine("Delete teachers.Id");
        //                        var id = Guid.Parse(Console.ReadLine());
        //                        var ress = teacherService.DeleteTeacher(id);
        //                        if (ress is true)
        //                        {
        //                            Console.WriteLine("Deleted Teacher");
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine("error");
        //                        }
        //                    }
        //                    else if (option == 4)
        //                    {
        //                        var newTeacher = new Teacher();
        //                        Console.WriteLine("Enter Teachers Updated Id");
        //                        newTeacher.Id = Guid.Parse(Console.ReadLine());
        //                        Console.WriteLine("Enter Teachers Updated Firstname");
        //                        newTeacher.FirstName = Console.ReadLine();
        //                        Console.WriteLine("Eneter Teachers Updated Lastname");
        //                        newTeacher.LastName = Console.ReadLine();
        //                        Console.WriteLine("Enter Teachers Updated Age");
        //                        newTeacher.Age = int.Parse(Console.ReadLine());
        //                        Console.WriteLine("Enter Teachers Updated Subject");
        //                        newTeacher.Subject = Console.ReadLine();
        //                        Console.WriteLine("Enter Teachers Updated Gender ");
        //                        newTeacher.Gender = Console.ReadLine();
        //                        Console.WriteLine("Enter Teachers Updated Likes");
        //                        newTeacher.Likes = int.Parse(Console.ReadLine());
        //                        Console.WriteLine("Enter Teachers Updated DisLikes");
        //                        newTeacher.DisLikes = int.Parse(Console.ReadLine());
        //                        Console.WriteLine("Enter Teachers Updated UserName");
        //                        newTeacher.UserName = Console.ReadLine();
        //                        Console.WriteLine("Enter Teachers Updated Password");
        //                        newTeacher.Password = Console.ReadLine();
        //                        var ress = teacherService.UpdateTeacher(newTeacher);
        //                        if (res is true)
        //                        {
        //                            Console.WriteLine("Updated Successfully");
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine("Error Occured");
        //                        }
        //                    }
        //                    else if (option == 5)
        //                    {
        //                        var allTeachers = teacherService.GetAllTeachers();

        //                        foreach (var ress in allTeachers)
        //                        {
        //                            Console.WriteLine($"Teachers Id : {ress.Id}");
        //                            Console.WriteLine($"Teachers FirstName : {ress.FirstName}");
        //                            Console.WriteLine($"Teachers LastName : {ress.LastName}");
        //                            Console.WriteLine($"Teachers Age : {ress.Age}");
        //                            Console.WriteLine($"Teachers Subject : {ress.Subject}");
        //                            Console.WriteLine($"Teachers Gender : {ress.Gender}");
        //                            Console.WriteLine($"Teachers Likes : {ress.Likes}");
        //                            Console.WriteLine($"Teachers DisLikes : {ress.DisLikes}");
        //                            Console.WriteLine($"teachers UserName : {ress.UserName}");
        //                            Console.WriteLine($"teachers Password : {ress.Password}");
        //                        }
        //                    }
        //                    else if (option == 6)
        //                    {
        //                        directorService.ChangeLogin();
        //                    }
        //                    Console.Clear();
        //                    Console.ReadKey();
        //                }
        //            }
        //        }
        //    }
        //    public static void teacherMenu()
        //    {
        //        Console.Clear();
        //        var teacherService = new TeacherService();
        //        var testService = new TestService();
        //        var studentService = new StudentService();
        //        while (true)
        //        {
        //            Console.WriteLine("Enter UserName");
        //            var userName = Console.ReadLine();
        //            Console.WriteLine("Enter Password");
        //            var password = Console.ReadLine();
        //            var res = teacherService.CheckLogin(userName, password);
        //            if (res is false)
        //            {
        //                Console.WriteLine("Wrong UseName or Password");
        //                Console.ReadKey();
        //                Console.Clear();
        //                continue;
        //            }
        //            else
        //            {
        //                while (true)
        //                {
        //                    Console.Clear();
        //                    Console.WriteLine("1.Add Student");
        //                    Console.WriteLine("2.GetById");
        //                    Console.WriteLine("3.Delete Student");
        //                    Console.WriteLine("4.Update Student");
        //                    Console.WriteLine("5.Get All Students");
        //                    Console.WriteLine("6.Add Test");
        //                    Console.WriteLine("7.GetById");
        //                    Console.WriteLine("8.Delete Test");
        //                    Console.WriteLine("9.Update Test");
        //                    Console.WriteLine("10.Get All Test");

        //                    Console.WriteLine("Choose =>> ");
        //                    var option = int.Parse(Console.ReadLine());
        //                    Console.Clear();

        //                    if (option == 1)
        //                    {
        //                        var newStudent = new Student();
        //                        Console.WriteLine("Enter Students Firstname");
        //                        newStudent.FirstName = Console.ReadLine();
        //                        Console.WriteLine("Enter Students LastName");
        //                        newStudent.LastName = Console.ReadLine();
        //                        Console.WriteLine("Enter Students Age");
        //                        newStudent.Age = int.Parse(Console.ReadLine());
        //                        Console.WriteLine("Enter Students Gender");
        //                        newStudent.Gender = Console.ReadLine();
        //                        Console.WriteLine("Enter Students Degree");
        //                        newStudent.Degree = Double.Parse(Console.ReadLine());
        //                        Console.WriteLine("Enter Students userName");
        //                        newStudent.UserName = Console.ReadLine();
        //                        Console.WriteLine("Enter Students password");
        //                        newStudent.Password = Console.ReadLine();

        //                        Console.WriteLine("Added Successfully");

        //                        studentService.AddStudent(newStudent);
        //                    }
        //                    else if (option == 2)
        //                    {
        //                        Console.WriteLine("Enter Students Id");
        //                        var id = Guid.Parse(Console.ReadLine());
        //                        var result = studentService.GetById(id);
        //                        if (result is null)
        //                        {
        //                            Console.WriteLine("Id is wrong");
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine($"Students Id : {result.Id}");
        //                            Console.WriteLine($"Students Firstname : {result.FirstName}");
        //                            Console.WriteLine($"Students LastName : {result.LastName}");
        //                            Console.WriteLine($"Students Age : {result.Age}");
        //                            Console.WriteLine($"Students Degree : {result.Degree}");
        //                            Console.WriteLine($"Enter Students Gender : {result.Gender}");
        //                            Console.WriteLine($"Enter Stuents UserName : {result.UserName}");
        //                            Console.WriteLine($"Enter Students Password : {result.Password}");
        //                            Console.WriteLine("Student Results");
        //                            foreach (var resultt in result.Results)
        //                            {
        //                                Console.WriteLine($"{resultt}");
        //                            }
        //                        }
        //                    }
        //                    else if (option == 3)
        //                    {
        //                        Console.WriteLine("Enter Deleted id");
        //                        var id = Guid.Parse(Console.ReadLine());
        //                        var result = studentService.DeleteStudent(id);
        //                        if (result is true)
        //                        {
        //                            Console.WriteLine("Deleted Successfully");
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine("error occured");
        //                        }
        //                    }
        //                    else if (option == 4)
        //                    {

        //                        var newStudent = new Student();
        //                        Console.WriteLine("Enter Students Id");
        //                        newStudent.Id = Guid.Parse(Console.ReadLine());
        //                        Console.WriteLine("Enter Students FirstName");
        //                        newStudent.FirstName = Console.ReadLine();
        //                        Console.WriteLine("Enter Students LastName");
        //                        newStudent.LastName = Console.ReadLine();
        //                        Console.WriteLine("Enter Students Age");
        //                        newStudent.Age = int.Parse(Console.ReadLine());
        //                        Console.WriteLine("Enter Students Degree");
        //                        newStudent.Degree = double.Parse(Console.ReadLine());
        //                        Console.WriteLine("Enter Students Gender");
        //                        newStudent.Gender = Console.ReadLine();
        //                        Console.WriteLine("Enter Students Username");
        //                        newStudent.UserName = Console.ReadLine();
        //                        Console.WriteLine("Enter Students Password");
        //                        newStudent.Password = Console.ReadLine();
        //                        var result = studentService.UpdateStudent(newStudent);
        //                        if (result is true)
        //                        {
        //                            Console.WriteLine("updated Successfully");
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine("Error occured");
        //                        }
        //                    }
        //                    else if (option == 5)
        //                    {
        //                        var result = studentService.GetAllStudents();
        //                        foreach (var ress in result)
        //                        {
        //                            Console.WriteLine($"Students Id : {ress.Id}");
        //                            Console.WriteLine($"Students Firstname : {ress.FirstName}");
        //                            Console.WriteLine($"Students Lastname : {ress.LastName}");
        //                            Console.WriteLine($"Students Age : {ress.Age}");
        //                            Console.WriteLine($"Students Degree : {ress.Degree}");
        //                            Console.WriteLine($"Students Gender : {ress.Gender}");
        //                            Console.WriteLine($"Students UserName : {ress.UserName}");
        //                            Console.WriteLine($"Students password : {ress.Password}");

        //                            Console.WriteLine($"Students Result");
        //                            foreach (var info in ress.Results)
        //                            {
        //                                Console.WriteLine($"{info}");
        //                            }
        //                        }
        //                    }
        //                    else if (option == 6)
        //                    {
        //                        var test = new Test();
        //                        Console.WriteLine("Enter TestQuestion");
        //                        test.QuestionText = Console.ReadLine();
        //                        Console.WriteLine("Enter A variant");
        //                        test.AVariant = Console.ReadLine();
        //                        Console.WriteLine("Enter BVariant");
        //                        test.BVariant = Console.ReadLine();
        //                        Console.WriteLine("Enter CVariant");
        //                        test.CVariant = Console.ReadLine();
        //                        Console.WriteLine("Enter Answer");
        //                        test.Answer = Console.ReadLine();

        //                        Console.WriteLine("Test Added");
        //                        testService.AddTest(test);
        //                    }
        //                    else if (option == 7)
        //                    {
        //                        Console.WriteLine("Enter Id");
        //                        var id = Guid.Parse(Console.ReadLine());
        //                        var result = testService.GetById(id);

        //                        if (result is null)
        //                        {
        //                            Console.WriteLine("error");
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine($"Test Id : {result.Id}");
        //                            Console.WriteLine($"Test QuestionText : {result.QuestionText}");
        //                            Console.WriteLine($"test AVariant : {result.BVariant}");
        //                            Console.WriteLine($"test Bvariant : {result.BVariant}");
        //                            Console.WriteLine($"Tests CVariant : {result.CVariant}");
        //                            Console.WriteLine($"tests Answer : {result.Answer}");
        //                        }
        //                    }
        //                    else if (option == 8)
        //                    {
        //                        Console.WriteLine("Enter Deleted Id");
        //                        var id = Guid.Parse(Console.ReadLine());
        //                        var result = testService.DeleteTest(id);
        //                        if (result is true)
        //                        {
        //                            Console.WriteLine("Deleted Successfully");
        //                        }

        //                        Console.WriteLine("Error");
        //                    }
        //                    else if (option == 9)
        //                    {
        //                        var test = new Test();

        //                        Console.WriteLine("Enter Id");
        //                        test.Id = Guid.Parse(Console.ReadLine());
        //                        Console.WriteLine("Enter Question Text");
        //                        test.QuestionText = Console.ReadLine();
        //                        Console.WriteLine("Enter AVariant");
        //                        test.AVariant = Console.ReadLine();
        //                        Console.WriteLine("ENter bVariant");
        //                        test.BVariant = Console.ReadLine();
        //                        Console.WriteLine("Enter CVariant");
        //                        test.CVariant = Console.ReadLine();
        //                        Console.WriteLine("Enter Answer ");
        //                        test.Answer = Console.ReadLine();

        //                        var result = testService.UpdateTest(test);

        //                        if (result is true)
        //                        {
        //                            Console.WriteLine("Updated SuccessFully");
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine("error");
        //                        }
        //                    }
        //                    else if (option == 10)
        //                    {
        //                        var results = testService.GetAllTest();
        //                        foreach (var result in results)
        //                        {
        //                            Console.WriteLine($"{result.QuestionText}");
        //                            Console.WriteLine($"{result.AVariant}");
        //                            Console.WriteLine($"{result.BVariant}");
        //                            Console.WriteLine($"{result.CVariant}");
        //                            Console.WriteLine($"{result.Answer}");
        //                        }
        //                    }
        //                    Console.ReadKey();
        //                    Console.Clear();
        //                }
        //            }
        //        }
        //    }
        //    public static void StudentMenu()
        //    {
        //        var studentService = new StudentService();
        //        var testService = new TestService();
        //        while (true)
        //        {
        //            Console.Clear();
        //            Console.WriteLine("Enter username");
        //            var username = Console.ReadLine();
        //            Console.WriteLine("Enter password");
        //            var password = Console.ReadLine();

        //            var resultCheck = studentService.CheckPassword(username, password);

        //            if (resultCheck is false)
        //            {
        //                Console.WriteLine("wrong password");
        //                Console.ReadKey();
        //                Console.Clear();
        //                continue;
        //            }
        //            else
        //            {
        //                while (true)
        //                {
        //                    var allStudent = studentService.GetAllStudents();
        //                    var student = new Student();
        //                    foreach (var studentt in allStudent)
        //                    {
        //                        if (studentt.UserName == username)
        //                        {
        //                            student = studentt;
        //                            break;
        //                        }
        //                    }
        //                    Console.Clear();
        //                    Console.WriteLine("1.GetTestsById");
        //                    Console.WriteLine("2.Get All Tests");
        //                    Console.WriteLine("3.my Answers");
        //                    Console.WriteLine("choose =>> ");
        //                    var option = int.Parse(Console.ReadLine());

        //                    if (option == 1)
        //                    {
        //                        Console.WriteLine("Enter Test Id");
        //                        var id = Guid.Parse(Console.ReadLine());

        //                        var result = testService.GetById(id);
        //                        if (result is null)
        //                        {
        //                            Console.WriteLine("id is wrong");
        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine($"Test Id : {result.Id}");
        //                            Console.WriteLine($"Test QuestionText : {result.QuestionText}");
        //                            Console.WriteLine($"test AVariant : {result.AVariant}");
        //                            Console.WriteLine($"test BVariant : {result.BVariant}");
        //                            Console.WriteLine($"Test CVariant : {result.CVariant}");
        //                            Console.WriteLine($"test Answeer : {result.Answer}");

        //                            Console.WriteLine("Enter Answer");
        //                            var studentAnswer = Console.ReadLine();
        //                            if (studentAnswer == result.Answer)
        //                            {
        //                                student.Results.Add(1);
        //                                studentService.UpdateStudent(student);
        //                            }
        //                            else
        //                            {
        //                                student.Results.Add(0);
        //                                studentService.UpdateStudent(student);
        //                            }
        //                        }
        //                    }
        //                    else if (option == 2)
        //                    {
        //                        var allTests = testService.GetAllTest();
        //                        foreach (var result in allTests)
        //                        {
        //                            Console.WriteLine($"Tests Id : {result.Id}");
        //                            Console.WriteLine($"tests QuestionText : {result.QuestionText}");
        //                            Console.WriteLine($"tests AVariant : {result.AVariant}");
        //                            Console.WriteLine($"tests BVariant : {result.BVariant}");
        //                            Console.WriteLine($"tests CVariant : {result.Answer}");

        //                            Console.WriteLine("Enter Answer = >> ");
        //                            var studentAnswer = Console.ReadLine();
        //                            if (studentAnswer == result.Answer)
        //                            {
        //                                student.Results.Add(1);
        //                                studentService.UpdateStudent(student);
        //                            }
        //                            else
        //                            {
        //                                student.Results.Add(0);
        //                                studentService.UpdateStudent(student);
        //                            }
        //                        }
        //                    }
        //                    else if (option == 3)
        //                    {
        //                        foreach (var result in student.Results)
        //                        {
        //                            Console.Write($"{result}");
        //                        }
        //                    }
        //                    Console.ReadKey();
        //                    Console.Clear();
        //                }
        //            }
        //        }
        //    }
    }
}

