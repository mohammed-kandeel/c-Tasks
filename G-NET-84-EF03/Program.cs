using G_NET_84_EF03.Contexts;
using G_NET_84_EF03.Enums;
using G_NET_84_EF03.Models;
using Microsoft.EntityFrameworkCore;

namespace G_NET_84_EF03;

internal class Program
{
    static async Task Main()
    {
        var dbContext = new AppDbContext();
        await dbContext.Database.MigrateAsync();

        //seeding Students Data
        await SeedStudentData(dbContext);

        //seeding Enrollments Data
        await SeedEnrollmentData(dbContext);

        #region Create

        var i = new Instructor
        {
            Id = 1,
            FullName = "Ahmed Mohamed",
            Email = "ahmed@exadccddmple.com",
            Bio = "Backend Developer",
            JoinedDate = new DateOnly(2025, 1, 10)
        };
        //await InsertNewInstructor(dbContext, i);

        var c = new Course
        {
            Id = 1,
            Title = "C# Fundamentals",
            Description = "Learn C# basics",
            Price = 500,
            Level = Level.Beginner,
            IsPublished = true,
            PublishedDate = new DateOnly(2025, 5, 1),
            InstructorId = 1,
            CategoryId = 5
        };
        //await InsertNewCourse(dbContext, c);

        //await AddSeveralStudents(dbContext);

        //await EnrollStudent(dbContext, 1, 5);

        #endregion

        #region Read
        //var courseById = await GetCourseById(dbContext, 1);
        //Console.WriteLine("Title: " + courseById?.Title);

        //var courseByTitle = await GetCourseByTitle(dbContext, "C# Fundamentals");
        //Console.WriteLine("Id: " + courseByTitle?.Id);

        //-----------

        //await PrintFilterCourses(dbContext,0,100000);

        //-----------

        //await PrintDirectSubCategories(dbContext, 1);

        //Console.WriteLine();
        //await PrintDirectSubCategories(dbContext, 2);

        //Console.WriteLine();
        //await PrintDirectSubCategories(dbContext, 3);

        //Console.WriteLine();
        //await PrintTopLevelCategories(dbContext);

        //-----------

        //await CourseRoster(dbContext,1);


        #endregion

        #region Update
        //await ChangeCoursePrice(dbContext, 1, 15000);

        //-----------

        //await UpdateEnrollmentProgress(dbContext, 1, 1, 100);

        //-----------

        //await PublishCourse(dbContext, 2);

        #endregion

        #region Delete
        //await DeleteEnrollment(dbContext, 5, 2);

        //-----------

        //await DeleteCategory(dbContext, 5);
        //await DeleteCategoryUnSafe(dbContext, 5);

        //-----------

        //await DeleteCourseHasEnrollments(dbContext,2);

        #endregion

        #region Bulk operations 
        //await BulkPrice(dbContext,Level.Beginner);

        //-----------

        await BulkDelete(dbContext);

        #endregion

    }
    static public async Task SeedStudentData(AppDbContext dbContext)
    {
        if (await dbContext.Set<Student>().AnyAsync())
            return;
        var students = new List<Student>
        {
            new Student
            {
                FullName = "Mohamed Ahmed",
                Email = "mohamed@example.com",
                DateOfBirth = new DateOnly(2000, 5, 10)
            },
            new Student
            {
                FullName = "Ali Hassan",
                Email = "ali@example.com",
                DateOfBirth = new DateOnly(2001, 3, 15)
            },
            new Student
            {
                FullName = "Omar Mohamed",
                Email = "omar@example.com",
                DateOfBirth = new DateOnly(1999, 8, 20)
            },
            new Student
            {
                FullName = "Ahmed Samir",
                Email = "ahmed@example.com",
                DateOfBirth = new DateOnly(2002, 1, 5)
            },
            new Student
            {
                FullName = "Mahmoud Ali",
                Email = "mahmoud@example.com",
                DateOfBirth = new DateOnly(2000, 11, 25)
            }
        };

        await dbContext.AddRangeAsync(students);

        await dbContext.SaveChangesAsync();

        Console.WriteLine("Students seeded successfully.");
    }
    static public async Task SeedEnrollmentData(AppDbContext dbContext)
    {
        if (await dbContext.Set<Enrollment>().AnyAsync())
            return;

        var enrollments = new List<Enrollment>
        {
        // Active
            new Enrollment
            {
                StudentId = 1,
                CourseId = 1,
                EnrollmentDate = new DateOnly(2026, 1, 10),
                ProgressPercentage = 30,
                Status = Status.Active
            },
            new Enrollment
            {
                StudentId = 2,
                CourseId = 1,
                EnrollmentDate = new DateOnly(2026, 1, 12),
                ProgressPercentage = 60,
                Status = Status.Active
            },
            new Enrollment
            {
                StudentId = 3,
                CourseId = 2,
                EnrollmentDate = new DateOnly(2026, 1, 15),
                ProgressPercentage = 45,
                Status = Status.Active
            },

            // Completed
            new Enrollment
            {
                StudentId = 1,
                CourseId = 2,
                EnrollmentDate = new DateOnly(2026, 1, 5),
                ProgressPercentage = 100,
                Status = Status.Completed,
                FinalGrade = 95
            },
            new Enrollment
            {
                StudentId = 4,
                CourseId = 1,
                EnrollmentDate = new DateOnly(2026, 1, 8),
                ProgressPercentage = 100,
                Status = Status.Completed,
                FinalGrade = 88
            },
            new Enrollment
            {
                StudentId = 5,
                CourseId = 2,
                EnrollmentDate = new DateOnly(2026, 1, 9),
                ProgressPercentage = 100,
                Status = Status.Completed
            },

            // Dropped
            new Enrollment
            {
                StudentId = 2,
                CourseId = 2,
                EnrollmentDate = new DateOnly(2026, 1, 20),
                ProgressPercentage = 20,
                Status = Status.Dropped
            },
            new Enrollment
            {
                StudentId = 3,
                CourseId = 1,
                EnrollmentDate = new DateOnly(2026, 1, 22),
                ProgressPercentage = 10,
                Status = Status.Dropped
            }
        };

        await dbContext.AddRangeAsync(enrollments);

        await dbContext.SaveChangesAsync();

        Console.WriteLine("Enrollments seeded successfully.");
    }

    static public async Task InsertNewInstructor(AppDbContext dbContext, Instructor instructor)
    {
        if (instructor is null ||
            string.IsNullOrWhiteSpace(instructor.FullName) ||
            string.IsNullOrWhiteSpace(instructor.Email))
        {
            Console.WriteLine("Invalid instructor data.");
            return;
        }

        var existingInstructor = await dbContext.Set<Instructor>()
        .FirstOrDefaultAsync(i => i.Email == instructor.Email);

        if (existingInstructor is not null)
        {
            Console.WriteLine("Instructor already exists.");
            Console.WriteLine($"ID: {existingInstructor.Id}");
            return;
        }


        var newInstructor = new Instructor
        {
            FullName = instructor.FullName,
            Email = instructor.Email,
            JoinedDate = instructor.JoinedDate,
            Bio = instructor.Bio
        };

        await dbContext.Set<Instructor>().AddAsync(newInstructor);

        await dbContext.SaveChangesAsync();

        Console.WriteLine("Instructor added successfully.");
        Console.WriteLine($"Generated ID: {newInstructor.Id}");
    }
    static public async Task InsertNewCourse(AppDbContext dbContext, Course course)
    {
        if (course is null || string.IsNullOrWhiteSpace(course.Title))
        {
            Console.WriteLine("Invalid course data.");
            return;
        }
        if (course.IsPublished && course.PublishedDate is null)
        {
            Console.WriteLine("Published courses must have a published date.");
            return;
        }

        if (!course.IsPublished && course.PublishedDate is not null)
        {
            Console.WriteLine("Unpublished courses cannot have a published date.");
            return;
        }

        if (!await dbContext.Set<Instructor>().AnyAsync(i => i.Id == course.InstructorId))
        {
            Console.WriteLine("Invalid instructor Id.");
            return;
        }

        if (!await dbContext.Set<Category>().AnyAsync(c => c.Id == course.CategoryId))
        {
            Console.WriteLine("Invalid Category Id.");
            return;
        }

        var newCourse = new Course
        {
            Title = course.Title,
            Description = course.Description,
            Price = course.Price,
            Level = course.Level,
            IsPublished = course.IsPublished,
            PublishedDate = course.PublishedDate,
            InstructorId = course.InstructorId,
            CategoryId = course.CategoryId
        };

        await dbContext.Set<Course>().AddAsync(newCourse);
        await dbContext.SaveChangesAsync();

        Console.WriteLine("Course added successfully.");
        Console.WriteLine($"Generated ID: {newCourse.Id}");
    }
    static public async Task AddSeveralStudents(AppDbContext dbContext)
    {
        var students = new List<Student>
        {
            new Student
            {
                FullName = "Mohamed Ali",
                Email = "mohamedAli@example.com",
                DateOfBirth = new DateOnly(2000, 5, 10)
            },
            new Student
            {
                FullName = "Ali Hassan",
                Email = "hassan@example.com",
                DateOfBirth = new DateOnly(2001, 3, 15)
            },
            new Student
            {
                FullName = "Omar Mohamed",
                Email = "omar@example.com",
                DateOfBirth = new DateOnly(1999, 8, 20)
            }
        };

        await dbContext.AddRangeAsync(students);

        await dbContext.SaveChangesAsync();

        Console.WriteLine("3 Students Added successfully.");
        foreach (var student in students)
        {
            Console.WriteLine($"Id = {student.Id}");
        }
    }
    static public async Task EnrollStudent(AppDbContext dbContext, int studentId, int courseId)
    {
        if (!await dbContext.Set<Student>().AnyAsync(s => s.Id == studentId))
        {
            Console.WriteLine("Enrollment refused: Student does not exist.");
            return;
        }

        var course = await dbContext.Set<Course>()
            .FirstOrDefaultAsync(c => c.Id == courseId);

        if (course is null)
        {
            Console.WriteLine("Enrollment refused: Course does not exist.");
            return;
        }

        if (!course.IsPublished)
        {
            Console.WriteLine("Enrollment refused: Course is not published.");
            return;
        }

        var isEnrolled = await dbContext.Set<Enrollment>()
            .AnyAsync(e => e.CourseId == courseId && e.StudentId == studentId);

        if (isEnrolled)
        {
            Console.WriteLine("Enrollment refused: Student is already enrolled.");
            return;
        }

        var enrollment = new Enrollment
        {
            StudentId = studentId,
            CourseId = courseId,
            EnrollmentDate = DateOnly.FromDateTime(DateTime.Today),
            ProgressPercentage = 0,
            Status = Status.Active
        };

        await dbContext.Set<Enrollment>().AddAsync(enrollment);
        await dbContext.SaveChangesAsync();

        Console.WriteLine("Student enrolled successfully.");
    }

    static public async Task<Course?> GetCourseById(AppDbContext dbContext, int id)
    {
        var result = await dbContext.Set<Course>().FindAsync(id);

        if (result is null)
            Console.WriteLine("Course not found.");

        return result;
    }
    static public async Task<Course?> GetCourseByTitle(AppDbContext dbContext, string title)
    {
        var result = await dbContext.Set<Course>()
            .FirstOrDefaultAsync(c => c.Title == title);

        if (result is null)
            Console.WriteLine("Course not found.");

        return result;
    }

    static public async Task PrintFilterCourses(AppDbContext dbContext, decimal minPrice, decimal maxPrice)
    {
        var result = await dbContext.Set<Course>()
            .AsNoTracking()
            .Where(c => c.Price > minPrice && c.Price < maxPrice)
            .OrderByDescending(c => c.Price)
            .Select(c => new { c.Title, c.Level, c.Price })
            .ToListAsync();

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
    static public async Task PrintDirectSubCategories(AppDbContext dbContext, int categoryId)
    {
        var result = await dbContext.Set<Category>()
            .AsNoTracking()
            .Where(c => c.ParentCategoryId == categoryId)
            .Select(c => new { c.Id, c.Name })
            .ToListAsync();

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
    static public async Task PrintTopLevelCategories(AppDbContext dbContext)
    {
        var result = await dbContext.Set<Category>()
          .AsNoTracking()
          .Where(c => c.ParentCategoryId == null)
          .Select(c => new { c.Id, c.Name })
          .ToListAsync();

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
    static public async Task CourseRoster(AppDbContext dbContext, int courseId)
    {
        var ids = await dbContext.Set<Enrollment>()
            .AsNoTracking()
            .Where(e => e.CourseId == courseId)
            .Select(e => e.StudentId)
            .ToListAsync();

        var students = await dbContext.Set<Student>()
            .AsNoTracking()
            .Where(s => ids.Contains(s.Id))
            .Select(s => s.FullName)
            .ToListAsync();

        Console.WriteLine($"students are enrolled in a course  : {ids.Count}");
        Console.WriteLine($"Students : [ {string.Join(", ", students)} ] ");
    }

    static public async Task ChangeCoursePrice(AppDbContext dbContext, int courseId, decimal newPrice)
    {
        var course = await dbContext.Set<Course>().FirstOrDefaultAsync(c => c.Id == courseId);

        if (course is null)
        {
            Console.WriteLine("Course not found.");
            return;
        }
        course.Price = newPrice;
        Console.WriteLine($"old Price = {dbContext.Entry(course).OriginalValues["Price"]:0.00}");
        Console.WriteLine($"new Price = {dbContext.Entry(course).CurrentValues["Price"]:0.00}");
        await dbContext.SaveChangesAsync();
    }
    static public async Task UpdateEnrollmentProgress(AppDbContext dbContext, int studentId, int courseId, int newProgress)
    {
        if (newProgress > 100 || newProgress < 0)
        {
            Console.WriteLine("Reject values outside 0–100");
            return;
        }

        var enrollment = await dbContext.Set<Enrollment>().FirstOrDefaultAsync(e => e.CourseId == courseId && e.StudentId == studentId);

        if (enrollment is null)
        {
            Console.WriteLine("No Enrollment Found.");
            return;
        }

        enrollment.ProgressPercentage = newProgress;
        if (newProgress == 100)
            enrollment.Status = Status.Completed;


        await dbContext.SaveChangesAsync();
        Console.WriteLine("Enrollment updated successfully.");
    }
    static public async Task PublishCourse(AppDbContext dbContext, int courseId)
    {
        var course = await dbContext.Set<Course>().FirstOrDefaultAsync(c => c.Id == courseId);

        if (course is null)
        {
            Console.WriteLine("Course not found.");
            return;
        }

        //if (course.IsPublished)
        //{
        //    Console.WriteLine("Course is already published.");
        //    return;
        //}

        course.IsPublished = true;
        course.PublishedDate = DateOnly.FromDateTime(DateTime.Today);

        await dbContext.SaveChangesAsync();
        Console.WriteLine("Course published successfully.");
    }

    static public async Task DeleteEnrollment(AppDbContext dbContext, int studentId, int courseId)
    {
        var enrollment = await dbContext.Set<Enrollment>().FirstOrDefaultAsync(e => e.CourseId == courseId && e.StudentId == studentId);

        if (enrollment is null)
        {
            Console.WriteLine("Enrollment not found.");
            return;
        }

        dbContext.Set<Enrollment>().Remove(enrollment);

        await dbContext.SaveChangesAsync();
        Console.WriteLine("Enrollment unenrolled successfully.");
    }

    static public async Task DeleteCategoryUnSafe(AppDbContext dbContext, int categoryId)
    {
        var category = await dbContext.Set<Category>().FirstOrDefaultAsync(c => c.Id == categoryId);
        if (category is null)
        {
            Console.WriteLine("category not found.");
            return;
        }

        try
        {
            dbContext.Set<Category>().Remove(category);
            await dbContext.SaveChangesAsync();

            Console.WriteLine("Category deleted successfully.");

        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e.Message);
        }
    }
    static public async Task DeleteCategory(AppDbContext dbContext, int categoryId)
    {
        var category = await dbContext.Set<Category>().FirstOrDefaultAsync(c => c.Id == categoryId);
        if (category is null)
        {
            Console.WriteLine("category not found.");
            return;
        }

        if (category.ParentCategoryId is not null)
        {
            Console.WriteLine("Cannot delete category because it has subcategories.");
            return;
        }

        dbContext.Set<Category>().Remove(category);
        await dbContext.SaveChangesAsync();
        Console.WriteLine("Category deleted successfully.");
    }

    static public async Task DeleteCourseHasEnrollments(AppDbContext dbContext, int courseId)
    {
        var course = await dbContext.Set<Course>().FindAsync(courseId);

        if (course is null)
        {
            Console.WriteLine("Course not found.");
            return;
        }

        var beforeCount = await dbContext.Set<Enrollment>().CountAsync(e => e.CourseId == courseId);

        Console.WriteLine($"Enrollments before deletion: {beforeCount}");

        dbContext.Set<Course>().Remove(course);
        await dbContext.SaveChangesAsync();

        var afterCount = await dbContext.Set<Enrollment>().CountAsync(e => e.CourseId == courseId);

        Console.WriteLine($"Enrollments after deletion: {afterCount}");

        //Enrollments are deleted automatically because of DeleteBehavior.Cascade.
    }

    static public async Task BulkPrice(AppDbContext dbContext, Level level)
    {
        var result = await dbContext.Set<Course>()
            .Where(c => c.IsPublished && c.Level == level)
            .ExecuteUpdateAsync(e =>
                e.SetProperty(c => c.Price, c => c.Price * 1.1m));

        Console.WriteLine($"Number of affected rows: {result}");
    }
    static public async Task BulkDelete(AppDbContext dbContext)
    {
        var result = await dbContext.Set<Enrollment>()
            .Where(e => e.Status == Status.Dropped)
            .ExecuteDeleteAsync();

        Console.WriteLine($"Number of affected rows: {result}");
    }

}

/*
Course
- The published date is recorded only when the course gets published, so it is empty for unpublished courses. 

Enrollment
-Progress must be between 0 and 100.An enrollment is Completed when its progressreaches 100.


 */

/*
Instructor - Course | many (optional) - one (mandatory) [publish]

Category - ParentCategory | many (optional) - one (optional) [self relation]

Category - Course | one (mandatory) - many (optional) [has]

Course - Student | many (optional) - many (optional) [Enrollment]

TO 

Student - Enrollment | one (mandatory) - many (optional)
Course - Enrollment | one (mandatory) - many (optional)

-- Student - Course is Many-to-Many through Enrollment.
-- Student can enroll in the same course only once.

*/

/*
BaseEntity
- Id

Person : BaseEntity
- FullName --> required, max length
- Email --> required, max length

Instructor : Person
- Bio ? --> max length
- JoinDate --> DateOnly

Category : BaseEntity
- Name --> required, max length
- Description ? --> max length
- ParentCategoryId ? --> FK

Course : BaseEntity
- Title --> required, max length
- Description ?
- Price --> decimal
- Level --> enum (Beginner, Intermediate, Advanced)
- IsPublished --> bool
- PublishedDate --> DateOnly ?

Student : Person
- DateOfBirth --> DateOnly

Enrollment
- StudentId --> FK
- CourseId --> FK
- EnrollmentDate --> DateOnly
- ProgressPercentage --> float
- Status --> enum (Active, Completed, Dropped)
- FinalGrade --> decimal ?
*/