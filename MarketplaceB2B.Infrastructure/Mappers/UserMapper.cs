using MarketplaceB2B.Application.Dtos;
using MarketplaceB2B.Domain.Entities;
using MarketplaceB2B.Infrastructure.Identities;

namespace MarketplaceB2B.Infrastructure.Mappers {
    public static class UserMapper {

       public static User UserIdentityToDomain(this AppUser appUser) {
            return new User {
                Id = appUser.Id,
                UserName = appUser.UserName,
                Email = appUser.Email,  
                CreatedAt = appUser.CreatedAt,
            };
        }

        public static UserResponseDTO UserDomainToResponse(this User user) {
            return new UserResponseDTO {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                CreatedAt = user.CreatedAt.ToString("dd/MM/yyyy HH:mm"),
                TypeUser = user.TypeUser.ToString()
            };
        }

    }
}
