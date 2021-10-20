using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PaysTracker.Data;

namespace PaysTracker.Models
{
    public class SeedData
    {
        public static async void InitializeAsync(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                var regimes = context.ListeRegimes.Any();
                var pays = context.ListePays.Any();
                // Si vide, création de contenus
                if (regimes && pays )
                {
                    return;
                }

                if (!regimes)
                {
                    context.ListeRegimes.AddRange(
                        new Regime
                        {
                            Nom = "Republique"
                        },

                        new Regime
                        {
                            Nom = "Monarchie"
                        }

                        );
                    await context.SaveChangesAsync();
                }

                if (!pays)
                {
                    context.ListePays.AddRange(
                        new Pays
                        {
                            Nom = "France",
                            Dirigeant = "Macron",
                            Population = 60000000,
                            RegimeId = 9,
                            Surface = 40000000
                        },

                        new Pays
                        {
                            Nom = "Royaume-Uni",
                            Dirigeant = "Elizabeth II",
                            Population = 50000000,
                            RegimeId = 10,
                            Surface = 20000000
                        });
                    context.SaveChanges();
                }

                return;
            }
        }
    }
}
