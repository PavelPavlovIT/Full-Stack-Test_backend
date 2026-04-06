using System.Collections.Concurrent;
using Common.Models;

namespace Data;

public sealed class AppDataStore
{
    public ConcurrentDictionary<int, Student> Students { get; } = new(
        new[]
        {
            new KeyValuePair<int, Student>(1, new Student(1, "Alice", 17, 0)),
            new KeyValuePair<int, Student>(2, new Student(2, "Bob", 25, 1)),
            new KeyValuePair<int, Student>(3, new Student(3, "Charlie", 30, 3)),
            new KeyValuePair<int, Student>(4, new Student(4, "Diana", 20, 2)),
        });

    public ConcurrentDictionary<int, Course> Courses { get; } = new(
        new[]
        {
            new KeyValuePair<int, Course>(1, new Course(1, "C# Basics", 100m, false)),
            new KeyValuePair<int, Course>(2, new Course(2, "Advanced C#", 200m, true)),
            new KeyValuePair<int, Course>(3, new Course(3, "Algorithms", 150m, false)),
        });
}
