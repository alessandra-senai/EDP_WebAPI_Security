namespace EDP_WebAPI_Security.Dtos
{
    public class FuncionarioRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public decimal Salario { get; set; }
        public int PermissaoId { get; set; }
    }
}
