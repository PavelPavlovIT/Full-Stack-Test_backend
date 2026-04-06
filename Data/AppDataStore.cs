using System.Collections.Concurrent;
using Common.Models;
using System.Collections.Generic;

namespace Data;

public sealed class AppDataStore
{
    public IReadOnlyDictionary<int, Student> Students { get; } = new Dictionary<int, Student>
    {
        [1] = new Student(1, "Alice", 17, 0),
        [2] = new Student(2, "Bob", 25, 1),
        [3] = new Student(3, "Charlie", 30, 3),
        [4] = new Student(4, "Diana", 20, 2),
    };

    public IReadOnlyDictionary<int, Course> Courses { get; } = new Dictionary<int, Course>
    {
        [1] = new Course(1, "C# Basics", 100m, false),
        [2] = new Course(2, "Advanced C#", 200m, true),
        [3] = new Course(3, "Algorithms", 150m, false),
    };
}
