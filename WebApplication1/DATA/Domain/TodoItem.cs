namespace TodoList.API.DATA.Domain
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Descripcion { get; set; }
        public bool EstaCompletada { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now; 
    }
}
