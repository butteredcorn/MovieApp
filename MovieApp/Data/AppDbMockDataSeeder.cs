﻿using Bogus;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieApp.Enums;
using MovieApp.Models;
using System;

namespace MovieApp.Data
{
    public class AppDbMockDataSeeder
    {
        private static readonly string AvatarBaseUrl = "https://i.pravatar.cc/150?u=";
        private static readonly string ImageBaseUrl = "https://picsum.photos/seed/";

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            string GetImageUrl(string seed, int width = 200, int height = 200)
            {
                return $"{ImageBaseUrl}{seed}/{width}/{height}";
            }

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context =
                    serviceScope.ServiceProvider.GetService<AppDbContext>()
                    ?? throw new Exception();

                context.Database.EnsureCreated();

                // Cinema
                if (!context.Cinemas.Any())
                {
                    var index = 1;
                    var cinemaFaker = new Faker<Cinema>()
                        .RuleFor(x => x.Name, f => f.Company.CompanyName())
                        .RuleFor(x => x.Description, f => f.Lorem.Paragraph())
                        .RuleFor(x => x.LogoURL, f => GetImageUrl($"logo{index++}"));
                    var mockCinemas = cinemaFaker.Generate(10);
                    context.Cinemas.AddRange(mockCinemas);
                }

                // Actors
                if (!context.Actors.Any())
                {
                    var index = 1;
                    var actorFaker = new Faker<Actor>()
                        .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                        .RuleFor(x => x.LastName, f => f.Name.LastName())
                        .RuleFor(x => x.Biography, f => f.Lorem.Paragraph())
                        .RuleFor(x => x.AvatarURL, f => $"{AvatarBaseUrl}{index++}");
                    var mockActors = actorFaker.Generate(10);
                    context.Actors.AddRange(mockActors);
                }

                // Producers
                if (!context.Producers.Any())
                {
                    var index = 11; // offset from above, so duplicate images avoided
                    var producerFaker = new Faker<Producer>()
                        .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                        .RuleFor(x => x.LastName, f => f.Name.LastName())
                        .RuleFor(x => x.Biography, f => f.Lorem.Paragraph())
                        .RuleFor(x => x.AvatarURL, f => $"{AvatarBaseUrl}{index++}");
                    var mockProducers = producerFaker.Generate(10);
                    context.Producers.AddRange(mockProducers);
                }

                context.SaveChanges();

                // Movies
                if (!context.Movies.Any())
                {
                    var cinemas = context.Cinemas.ToList();
                    var actors = context.Actors.ToList();

                    var producerIds = context.Producers.Select(p => p.Id).ToList();

                    var genres = (Genre[])Enum.GetValues(typeof(Genre));

                    var imageIndex = 1;
                    var imageFaker = new Faker<Image>().RuleFor(
                        x => x.Url,
                        f => GetImageUrl($"movie{imageIndex++}")
                    );

                    var movieFaker = new Faker<Movie>()
                        .RuleFor(x => x.Title, f => f.Random.Words())
                        .RuleFor(x => x.Description, f => f.Lorem.Paragraph())
                        .RuleFor(x => x.Images, f => imageFaker.Generate(3))
                        .RuleFor(x => x.Price, f => f.Random.Decimal(5m, 25m))
                        .RuleFor(x => x.StartDate, f => f.Date.Recent())
                        .RuleFor(x => x.EndDate, (f, x) => x.StartDate.AddDays(f.Random.Int(7, 14)))
                        .RuleFor(x => x.Genre, f => f.PickRandom(genres))
                        .RuleFor(x => x.ProducerId, f => f.PickRandom(producerIds))
                        .RuleFor(
                            x => x.Cinemas,
                            f => f.Random.ListItems(cinemas, f.Random.Int(1, 5))
                        )
                        .RuleFor(
                            x => x.Actors,
                            f => f.Random.ListItems(actors, f.Random.Int(2, 4))
                        );

                    var mockMovies = movieFaker.Generate(50);
                    context.Movies.AddRange(mockMovies);
                }

                context.SaveChanges();
            }
        }
    }
}
