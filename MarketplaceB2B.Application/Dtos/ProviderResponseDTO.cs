namespace MarketplaceB2B.Application.Dtos {
    public class ProviderResponseDTO {
        public int Id { get; set; }
        public string? CPF { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
        public UserResponseDTO? User { get; set; }
    }
}
