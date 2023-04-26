using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Prototype.Data
    
{  // Permet interagir avec la base de données à l'aide d'Entity Framework Core.
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // On pourra y ajouter des propriétés DbSet pour définir les différentes entités à gérer et stocker dans la base de données
        // On pourra également y ajouter des méthodes pour définir des requêtes personnalisées
    }
}