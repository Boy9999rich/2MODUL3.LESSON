using _2._2Dars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _2._2Dars.Services;

public class TestService
{
    private string testFilePath;
    public TestService()
    {
        testFilePath = "../../../Data/test.Json";

    }
    public Test AddTest(Test test)
    {
        test.Id = Guid.NewGuid();
        var tests = GetTest();
        tests.Add(test);
        SaveData(tests);
        return test;
    }
   

    public List<Test> GetAllTests()
    {
        return GetTest();
    }

    public void SaveData(List<Test> test)
    {
        var result = JsonSerializer.Serialize(test);
        File.WriteAllText(testFilePath, result);
    }
    public List<Test> GetTest()
    {
        var result = File.ReadAllText(testFilePath);
        var ress = JsonSerializer.Deserialize<List<Test>>(result);
        return ress;
    }

    public Test GetById(Guid testId)
    {
        var tests = GetTest();
        foreach (var test in tests)
        {
            if (test.Id == testId)
            {
                return test;
            }
        }
        return null;
    }

    public bool DeleteTest(Guid testid)
    {
        var tests = GetTest();
        var testsFromDb = GetById(testid);
        if (testsFromDb is null)
        {
            return false;
        }
        else
        {
            tests.Remove(testsFromDb);
            SaveData(tests);
            return true;
        }
    }
    public bool UpdateTest(Test testId)
    {
        var tests = GetTest();
        var testFromDb = GetById(testId.Id);
        if (testFromDb is null)
        {
            return false;
        }
        else
        {
           for (var i = 0; i < tests.Count(); i++)
            {
                if (tests[i].Id == testId.Id)
                {
                    tests[i] = testId;
                }
            }
            SaveData(tests);
            return true;

        }
    }

    // private string testFilePath;
    // public TestService()
    // {
    //     testFilePath = "../../../Data/Test.json";
    //     if (File.Exists(testFilePath) is false)
    //     {
    //         File.WriteAllText(testFilePath, "[]");
    //     }
    // }
    // public Test AddTest(Test test)
    // {
    //     test.Id = Guid.NewGuid();
    //     var tests = GetTest();
    //     tests.Add(test);
    //     SaveInformation(tests);
    //     return test;
    // }
    // public Test GetById(Guid testId)
    // {
    //     var tests = GetTest();
    //     foreach (var test in tests)
    //     {
    //         if (test.Id == testId)
    //         {
    //             return test;
    //         }
    //     }
    //     return null;
    // }
    // public bool DeleteTest(Guid test)
    // {
    //     var tests = GetTest();
    //     var testFromDb = GetById(test);
    //     if (testFromDb is null)
    //     {
    //         return false;
    //     }
    //     tests.Remove(testFromDb);
    //     SaveInformation(tests);
    //     return true;
    // }
    // public bool UpdateTest(Test test)
    // {
    //     var tests = GetTest();
    //     var testFromDb = GetById(test.Id);
    //     if (testFromDb is null)
    //     {
    //         return false;
    //     }

    //     for (var i = 0; i < tests.Count(); i++)
    //     {
    //         if (tests[i].Id == test.Id)
    //         {
    //             tests[i] = test;
    //         }
    //     }
    //     SaveInformation(tests);
    //     return true;
    // }

    // public List<Test> GetAllTest()
    // {
    //     return GetTest();
    // }
    //public void SaveInformation(List<Test> test)
    // {
    //     var testJson = JsonSerializer.Serialize(test);
    //     File.WriteAllText(testFilePath, testJson);
    // }
    // public List<Test> GetTest()
    // {
    //     var testJson = File.ReadAllText(testFilePath);
    //     var result = JsonSerializer.Deserialize<List<Test>>(testJson);
    //     return result;
    // }
}










