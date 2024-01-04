namespace MagicVilla.Models.Custom
{
    public class AutorizacionResponse
    {
        public string Token { get; set; }=string.Empty;
        public bool Resultado { get; set; }
        public string Msg { get; set; }=string.Empty;
    }
}