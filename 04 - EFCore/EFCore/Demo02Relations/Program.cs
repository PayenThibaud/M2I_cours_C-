// See https://aka.ms/new-console-template for more information
using Demo02Relations.Data;
using Demo02Relations.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

using ApplicationDbContext context = new ApplicationDbContext();

// Initialement, lorsque l'on charge les blogs depuis la db, les posts et les tags ne sont pas chargés
// On utilise le lazy loading pour économiser la mémoire et optimiser le programme
var blogs = context.Blogs.ToList();

var blogsCompletes = context.Blogs.Include(b => b.Posts).OrderBy(b => b.Nom).ToList();

blogsCompletes.ForEach(b =>
{
    Console.WriteLine($"Blog: {b.Nom}");
    b.Posts.ForEach(p => Console.WriteLine($"\tTitre: {p.Titre}"));
});

//var blogJohnny = context.Blogs.Find(1);
//blogJohnny.Posts.Add(new Post() { Titre = "La résurrection de Papa Johnny", Contenu = "Nouvel album les potos", BlogId = blogJohnny.Id });

//context.SaveChanges();

// Dans une relation One To Many, pas besoin d'utiliser le include pour charger l'entité
var post = context.Posts.Find(1);

Console.WriteLine(post.Titre);
Console.WriteLine(post.Blog.Nom);

//context.Tags.Add(new Tag() { Titre="Rouge"});
//context.Tags.Add(new Tag() { Titre="Information"});
//context.Tags.Add(new Tag() { Titre="Chanteur"});
//context.Tags.Add(new Tag() { Titre="Humour"});

//context.SaveChanges();

context.Tags.ToList().ForEach(t => Console.WriteLine(t.Titre));

//context.Tags.Find(1)?.Blogs.AddRange(blogs);

//context.SaveChanges();

var tagRouge = context.Tags.Include(t => t.Blogs).Where(t => t.Id == 1).FirstOrDefault();

tagRouge?.Blogs.ForEach(b => Console.WriteLine($"tag: Rouge {b.Nom}"));

blogs.ForEach(b => b.Tags.ForEach(t => Console.WriteLine(t.Titre)));

tagRouge.TagPosts.Add(new PostTag() { PostId=1, TagId=tagRouge.Id});
context.SaveChanges();