using Microsoft.EntityFrameworkCore;
using Platform.Models.Entities;
using Platform.Models.Entities.Linkings;

namespace Platform.Models.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) { }

        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<MealType> MealType { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Site> Site { get; set; }
        public DbSet<Sitemap> Sitemap { get; set; }
        public DbSet<Synonym> Synonym { get; set; }

        public DbSet<IngredientSynonym> IngredientSynonym { get; set; }
        public DbSet<RecipeMealType> RecipeMealType { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredient { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Recipe>()
                .HasOne(r => r.Site)
                .WithMany(s => s.Recipes)
                .HasForeignKey(r => r.SiteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Sitemap>()
                .HasOne(sm => sm.Site)
                .WithMany(s => s.Sitemaps)
                .HasForeignKey(sm => sm.SiteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<RecipeMealType>()
                .HasKey(rmt => new { rmt.RecipeId, rmt.MealTypeId });

            modelBuilder
                .Entity<RecipeMealType>()
                .HasOne(rmt => rmt.Recipe)
                .WithMany(r => r.RecipeMealTypes)
                .HasForeignKey(rmt => rmt.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<RecipeMealType>()
                .HasOne(rmt => rmt.MealType)
                .WithMany(mt => mt.RecipeMealTypes)
                .HasForeignKey(rmt => rmt.MealTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            modelBuilder
                .Entity<RecipeIngredient>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<RecipeIngredient>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<IngredientSynonym>()
                .HasKey(isy => new { isy.IngredientId, isy.SynonymId });

            modelBuilder
                .Entity<IngredientSynonym>()
                .HasOne(isy => isy.Ingredient)
                .WithMany(i => i.IngredientSynonyms)
                .HasForeignKey(isy => isy.IngredientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<IngredientSynonym>()
                .HasOne(isy => isy.Synonym)
                .WithMany(s => s.IngredientSynonyms)
                .HasForeignKey(isy => isy.SynonymId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
