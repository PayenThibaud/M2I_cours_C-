using Demo01.Data;
using Demo01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo01.Controllers
{
    public class ContactsController : Controller
    {
        //private List<Contact> _contactList = new List<Contact>()
        //{
        //    new Contact { Id = 1, FirstName = "Bob", LastName="Marley", Email="bobo@ganjamail.com", Phone="0607080910"},
        //    new Contact { Id = 2, FirstName = "Elvis", LastName="Presley", Email="elvis@rock.com", Phone="0607080911"},
        //    new Contact { Id = 3, FirstName = "Michael", LastName="Jackson", Email="mj@popking.com", Phone="0607080912"},
        //};

        //private FakeContactDb _fakeContactDb = new FakeContactDb(); // sans injections de dépendances

        private FakeContactDb _fakeContactDb;

        // on récupère un FakeContactDb depuis le conteneur de dépendances (on l'injecte dans le controlleur)
        public ContactsController(FakeContactDb fakeContactDb)
        {
            _fakeContactDb = fakeContactDb;
        }

        // /Contacts/       => possible grace au app.MapControllerRoute("default", ...) de program.cs
        // /Contacts/Index
        public IActionResult Index()
        {

            //return "Je suis la page pour afficher les contacts.";
            //return View();


            //ViewData["contactList"] = contactList;
            //ViewBag.ContactList = contactList;

            //return View(_contactList); // View(model)

            //Contact? mich = new Contact()
            //{
            //    FirstName = "Michel",
            //    LastName = "Sardou",
            //    Email = "michmich@sardonux.fr",
            //    Phone = "0607080945"
            //};

            //_fakeContactDb.Add(mich);

            return View(_fakeContactDb.GetAll());
        }
        // /Contacts/Details/5
        public IActionResult Details(int id)
        {
            //return $"Je suis la page pour afficher le contact n°{id} en détail...";
            //return View();
            //return View("Details");

            //Contact contact = new Contact { Id = 1, FirstName = "Bob", LastName = "Marley", Email = "bobo@ganjamail.com", Phone = "0607080910" };

            //ViewData["contact"] = contact;
            //ViewBag.Contact = contact;

            //Contact? contact = _contactList.FirstOrDefault(c => c.Id == id);

            Contact? contact = _fakeContactDb.GetById(id);

            return View(contact);
        }

        public IActionResult AddMichel()
        {
            Contact? mich = new Contact()
            {
                FirstName = "Michel",
                LastName = "Sardou",
                Email = "michmich@sardonux.fr",
                Phone = "0607080945"
            };

            _fakeContactDb.Add(mich);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            //return "Je suis la page pour ajouter un contact...";
            return View();
        }
    }
}
