using Microsoft.EntityFrameworkCore;

namespace Library.Domain;
/// <summary>
/// LibraryDbContext is used to create database
/// </summary>
public class LibraryDbContext : DbContext
{
    /// <summary>
    /// Books is used to store collection of books
    /// </summary>
    public DbSet<Book> Books { get; set; }
    /// <summary>
    /// Cards is used to store collection of cards
    /// </summary>
    public DbSet<Card> Cards { get; set; }
    /// <summary>
    /// Departments is used to store collection of departments
    /// </summary>
    public DbSet<Department> Departments { get; set; }
    /// <summary>
    /// Readers is used to store collection of readers
    /// </summary>
    public DbSet<Reader> Readers { get; set; }
    /// <summary>
    /// TypesDepartment is used to store collection of types departments
    /// </summary>
    public DbSet<TypeDepartment> TypesDepartment { get; set; }
    /// <summary>
    /// TypesEdition is used to store collection of types editions
    /// </summary>
    public DbSet<TypeEdition> TypesEdition { get; set; }
    /// <summary>
    /// Library's DbContext constructor
    /// </summary>
    /// <param name="options"></param>
    public LibraryDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    /// <summary>
    /// Method for insert data into database
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var cards = new List<Card>
        {
            new Card { Id = 8, DateIssue = new DateTime(2022, 12, 29), DateReturn = new DateTime(2023, 1, 28), DayCount = 31, ReaderId = 1, BookId = 1 },
            new Card { Id = 1, DateIssue = new DateTime(2022, 12, 29), DateReturn = new DateTime(2023, 1, 28), DayCount = 31, ReaderId = 1, BookId = 4 },
            new Card { Id = 2, DateIssue = new DateTime(2022, 12, 29), DateReturn = new DateTime(2023, 1, 28), DayCount = 31, ReaderId = 2, BookId = 4 },
            new Card { Id = 3, DateIssue = new DateTime(2022, 12, 29), DateReturn = new DateTime(2023, 1, 28), DayCount = 31, ReaderId = 2, BookId = 2 },
            new Card { Id = 4, DateIssue = new DateTime(2022, 12, 29), DateReturn = new DateTime(2023, 1, 31), DayCount = 31, ReaderId = 2, BookId = 3 },
            new Card { Id = 5, DateIssue = new DateTime(2022, 12, 30), DateReturn = new DateTime(2023, 2, 14), DayCount = 30, ReaderId = 3, BookId = 3 },
            new Card { Id = 6, DateIssue = new DateTime(2022, 12, 30), DateReturn = new DateTime(2023, 2, 14), DayCount = 30, ReaderId = 4, BookId = 2 },
            new Card { Id = 7, DateIssue = new DateTime(2023, 2, 14), DateReturn = new DateTime(2023, 2, 28), DayCount = 21, ReaderId = 5, BookId = 1 }
        };

        modelBuilder.Entity<Card>().HasData(cards);

        var departmentsList = new List<Department>();

        for (int i = 0; i < 7; i++)
        {
            var department = new Department
            {
                Id = i+1,
                TypeDepartmentId = (i % 3) + 1,
                BookId = (i % 4) + 1,
                Count = (i + 2) * 2
            };
            departmentsList.Add(department);
        }

        modelBuilder.Entity<Department>().HasData(departmentsList);

        modelBuilder.Entity<TypeDepartment>().HasData(new List<TypeDepartment>
        {
            new TypeDepartment
            {
                Id = 3,
                Name = "IT"
            },
            new TypeDepartment
            {
                Id = 1,
                Name = "Study"
            },
            new TypeDepartment
            {
                Id = 2,
                Name = "Biology"
            }
        });

        modelBuilder.Entity<TypeEdition>().HasData(new List<TypeEdition>
        {
            new() { Id = 1, Name = "Tutorial" },
            new() { Id = 2, Name = "Monograph" },
            new() { Id = 3, Name = "Methodological guidelines" }
        });

        modelBuilder.Entity<Book>().HasData(new List<Book>
        {
            new Book
            {
                Id = 4,
                Cipher = "1234/5678",
                Author = "Иванов А.А.",
                Name = "Свет в конце туннеля",
                PlaceEdition = "Москва",
                YearEdition = 1999,
                TypeEditionId = 2
            },
            new Book
            {
                Id = 1,
                Cipher = "9876/5432",
                Author = "Петров В.В.",
                Name = "Шаг за шагом",
                PlaceEdition = "Санкт-Петербург",
                YearEdition = 2005,
                TypeEditionId = 1
            },
            new Book
            {
                Id = 2,
                Cipher = "2468/1357",
                Author = "Сидоров С.С.",
                Name = "В поисках смысла",
                PlaceEdition = "Екатеринбург",
                YearEdition = 2010,
                TypeEditionId = 3,
            },
            new Book
            {
                Id = 3,
                Cipher = "5555/0000",
                Author = "Федоров Л.И.",
                Name = "Секреты Вселенной",
                PlaceEdition = "Казань",
                YearEdition = 2018,
                TypeEditionId = 1,
            }
        });

        modelBuilder.Entity<Reader>().HasData(new List<Reader>
        {
            new Reader
            {
                Id = 6,
                FullName = "Иванов Иван Иванович",
                Address = "ул. Ленина, д. 10, кв. 5",
                Phone = "89123456789",
                RegistrationDate = new DateTime(2023, 3, 15)
            },
            new Reader
            {
                Id = 1,
                FullName = "Петров Петр Петрович",
                Address = "ул. Гагарина, д. 20, кв. 10",
                Phone = "89098765432",
                RegistrationDate = new DateTime(2023, 3, 16)
            },
            new Reader
            {
                Id = 2,
                FullName = "Сидоров Сидор Сидорович",
                Address = "ул. Пушкина, д. 30, кв. 15",
                Phone = "89987654321",
                RegistrationDate = new DateTime(2023, 3, 17)
            },
            new Reader
            {
                Id = 3,
                FullName = "Николаев Николай Николаевич",
                Address = "ул. Толстого, д. 40, кв. 20",
                Phone = "89991234567",
                RegistrationDate = new DateTime(2023, 3, 18)
            },
            new Reader
            {
                Id = 4,
                FullName = "Кузнецова Ольга Петровна",
                Address = "ул. Кирова, д. 50, кв. 25",
                Phone = "89876543210",
                RegistrationDate = new DateTime(2023, 3, 19)
            },
            new Reader
            {
                Id = 5,
                FullName = "Васильев Василий Васильевич",
                Address = "ул. Красной, д. 60, кв. 30",
                Phone = "89765432109",
                RegistrationDate = new DateTime(2023, 3, 20)
            }
        });
    }
}