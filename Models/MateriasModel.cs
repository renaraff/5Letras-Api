namespace Api.Models
{
    public class MateriasModel
    {
        public int MateriasId { get; set; }

        public string MateriasNome { get; set; } = string.Empty;

        public static implicit operator List<object>(MateriasModel v)
        {
            throw new NotImplementedException();
        }
    }
}
