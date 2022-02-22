using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data;

public static class DbInitializer
{
    public static async Task Initialize(ApplicationDbContext context)
    {
        await context.Database.EnsureCreatedAsync();

        if (!context.CatalogGenres.Any())
        {
            await context.CatalogGenres.AddRangeAsync(GetPreconfiguredCatalogGenres());

            await context.SaveChangesAsync();
        }

        if (!context.CatalogItems.Any())
        {
            await context.CatalogItems.AddRangeAsync(GetPreconfiguredItems());

            await context.SaveChangesAsync();
        }

        if (!context.CatalogItemGenres.Any())
        {
            await context.CatalogItemGenres.AddRangeAsync(GetPreconfiguredItemGenres());

            await context.SaveChangesAsync();
        }

        if (!context.CatalogStreams.Any())
        {
            await context.CatalogStreams.AddRangeAsync(GetPreconfiguredStreams());

            await context.SaveChangesAsync();
        }
    }

    private static IEnumerable<CatalogGenre> GetPreconfiguredCatalogGenres()
    {
        return new List<CatalogGenre>()
        {
            new CatalogGenre() { Genre = "Action" },
            new CatalogGenre() { Genre = "Adventure" },
            new CatalogGenre() { Genre = "Criminal" },
            new CatalogGenre() { Genre = "Detective" },
            new CatalogGenre() { Genre = "Drama" },
            new CatalogGenre() { Genre = "Fantasy" },
            new CatalogGenre() { Genre = "Thriller" }
        };
    }

    private static IEnumerable<CatalogStream> GetPreconfiguredStreams()
    {
        return new List<CatalogStream>()
        {
            new CatalogStream()
            {
                Title = "Netflix",
                CoverFileName = "netflix.jpeg",
                Description =
                    "Netflix is a subscription-based streaming service that allows our members to watch TV shows and movies without commercials on an internet-connected device. You can also download TV shows and movies to your iOS, Android, or Windows 10 device and watch without an internet connection.",
                Price = 7.99,
            },
            new CatalogStream()
            {
                Title = "Disney+",
                CoverFileName = "disney.jpg",
                Description =
                    "Disney+ is the home for your favorite movies and TV shows from Disney, Pixar, Marvel, Star Wars, and National Geographic.",
                Price = 9.99,
            },
            new CatalogStream()
            {
                Title = "HBO Max",
                CoverFileName = "hbo.png",
                Description =
                    "It's a platform offered by WarnerMedia that features 10,000 hours of premium content bundling all of HBO together with even more movies, shows, and Max Originals for the whole family, including Friends, South Park, The Big Bang Theory, Peacemaker, Hacks, Wonder Woman, the Studio Ghibli collection, and more.",
                Price = 8.99,
            },
        };
    }

    private static IEnumerable<CatalogItem> GetPreconfiguredItems()
    {
        return new List<CatalogItem>()
        {
            new CatalogItem
            {
                Title = "The Lord of the Rings: The Two Towers",
                CoverFileName = "lotr-two-towers.jpg",
                Imdb = 8.7,
                Year = 2002,
                Description =
                    "While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron's new ally, Saruman, and his hordes of Isengard.",
                Price = 3.99,
            },
            new CatalogItem
            {
                Title = "Inception",
                CoverFileName = "inception.jpg",
                Imdb = 8.8,
                Year = 2010,
                Description =
                    "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.",
                Price = 3.99,
            },
            new CatalogItem
            {
                Title = "Forrest Gump",
                CoverFileName = "forrest.jpg",
                Imdb = 8.8,
                Year = 1994,
                Description =
                    "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.",
                Price = 3.99,
            },
            new CatalogItem
            {
                Title = "Fight Club",
                CoverFileName = "fight-club.jpg",
                Imdb = 8.8,
                Year = 1999,
                Description =
                    "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.",
                Price = 3.99,
            },
            new CatalogItem
            {
                Title = "The Lord of the Rings: The Fellowship of the Ring",
                CoverFileName = "lots-fellowship-of-ring.jpg",
                Imdb = 8.8,
                Year = 2001,
                Description =
                    "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.",
                Price = 3.99,
            },
            new CatalogItem
            {
                Title = "Il buono, il brutto, il cattivo",
                CoverFileName = "buono-brutto-cattivo.jpg",
                Imdb = 8.8,
                Year = 1966,
                Description =
                    "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery.",
                Price = 3.99,
            },
            new CatalogItem
            {
                Title = "Pulp Fiction",
                CoverFileName = "pulp-fiction.jpg",
                Imdb = 8.9,
                Year = 1994,
                Description =
                    "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                Price = 3.99,
            },
            new CatalogItem
            {
                Title = "Spider-Man: No Way Home",
                CoverFileName = "no-way-home.jpg",
                Imdb = 9.1,
                Year = 2021,
                Description =
                    "With Spider-Man's identity now revealed, Peter asks Doctor Strange for help. When a spell goes wrong, dangerous foes from other worlds start to appear, forcing Peter to discover what it truly means to be Spider-Man.",
                Price = 3.99,
            },
            new CatalogItem
            {
                Title = "The Lord of the Rings: The Return of the King",
                CoverFileName = "lotr-return-of-the-king.jpg",
                Imdb = 8.9,
                Year = 2003,
                Description =
                    "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                Price = 3.99,
            },
            new CatalogItem
            {
                Title = "Schindler's List",
                CoverFileName = "schindlers-list.jpg",
                Imdb = 8.9,
                Year = 1993,
                Description =
                    "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.",
                Price = 3.99,
            },
            new CatalogItem
            {
                Title = "12 Angry Men",
                CoverFileName = "angry-men.jpg",
                Imdb = 8.9,
                Year = 1957,
                Description =
                    "The jury in a New York City murder trial is frustrated by a single member whose skeptical caution forces them to more carefully consider the evidence before jumping to a hasty verdict.",
                Price = 3.99,
            },
            new CatalogItem
            {
                Title = "The Dark Knight",
                CoverFileName = "dark-knight.jpg",
                Imdb = 9.0,
                Year = 2008,
                Description =
                    "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                Price = 3.99,
            },
            new CatalogItem
            {
                Title = "The Godfather: Part II",
                CoverFileName = "godfather-part-two.jpg",
                Imdb = 9.0,
                Year = 1974,
                Description =
                    "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate.",
                Price = 3.99,
            },
            new CatalogItem
            {
                Title = "The Godfather: Part II",
                CoverFileName = "godfather.jpg",
                Imdb = 9.2,
                Year = 1972,
                Description =
                    "The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to his reluctant youngest son.",
                Price = 3.99,
            },
            new CatalogItem
            {
                Title = "The Shawshank Redemption",
                CoverFileName = "shawshank-redemption.jpg",
                Imdb = 9.3,
                Year = 1994,
                Description =
                    "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                Price = 3.99,
            },
        };
    }

    private static IEnumerable<CatalogItemGenre> GetPreconfiguredItemGenres()
    {
        return new List<CatalogItemGenre>()
        {
            new CatalogItemGenre
            {
                CatalogItemId = 1,
                CatalogGenreId = 2,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 1,
                CatalogGenreId = 6,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 2,
                CatalogGenreId = 1,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 2,
                CatalogGenreId = 7,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 3,
                CatalogGenreId = 5,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 4,
                CatalogGenreId = 3,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 4,
                CatalogGenreId = 7,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 5,
                CatalogGenreId = 2,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 5,
                CatalogGenreId = 6,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 6,
                CatalogGenreId = 3,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 6,
                CatalogGenreId = 7,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 7,
                CatalogGenreId = 3,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 7,
                CatalogGenreId = 7,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 8,
                CatalogGenreId = 1,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 8,
                CatalogGenreId = 2,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 9,
                CatalogGenreId = 2,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 9,
                CatalogGenreId = 6,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 10,
                CatalogGenreId = 5,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 11,
                CatalogGenreId = 4,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 11,
                CatalogGenreId = 7,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 12,
                CatalogGenreId = 1,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 12,
                CatalogGenreId = 7,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 13,
                CatalogGenreId = 3,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 13,
                CatalogGenreId = 5,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 14,
                CatalogGenreId = 3,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 14,
                CatalogGenreId = 5,
            },
            new CatalogItemGenre
            {
                CatalogItemId = 15,
                CatalogGenreId = 5,
            },
        };
    }
}