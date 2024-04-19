namespace Library.Server.Dto;
/// <summary>
/// Class BookGetDto is used to store info about the books
/// </summary>
public class BookGetDto
{
    /// <summary>
    /// Идентификатор книги
    /// </summary>
    public int Id { set; get; }
    /// <summary>
    /// Шифр в алфавитном каталоге
    /// </summary>
    public string Cipher { set; get; } = string.Empty;
    /// <summary>
    /// Фамилия и инициалы
    /// </summary>
    public string Author { set; get; } = string.Empty;
    /// <summary>
    /// Название книги
    /// </summary>
    public string Name { set; get; } = string.Empty;
    /// <summary>
    /// Место издания
    /// </summary>
    public string PlaceEdition { set; get; } = string.Empty;
    /// <summary>
    /// Год издания
    /// </summary>
    public int YearEdition { set; get; }
    /// <summary>
    /// Идентификатор записи в таблице TypeEdition
    /// </summary>
    public int TypeEditionId { set; get; }
}