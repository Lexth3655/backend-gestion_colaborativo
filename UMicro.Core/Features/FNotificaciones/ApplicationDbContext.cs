
internal class ApplicationDbContext
{
    public object Notificaciones { get; internal set; }
    public object Usuarios { get; internal set; }
    public object Comentarios { get; internal set; }
    public object Tareas { get; internal set; }

    internal async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}