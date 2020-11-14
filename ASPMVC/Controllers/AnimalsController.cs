// Программы, игры и их исходные коды
// www.interestprograms.ru

using ASPMVC.Models;
using System.Web.Mvc;

namespace ASPMVC.Controllers
{
    public class AnimalsController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Animals animals = new Animals();

            return View(animals);
        }

        public ActionResult Dogs(string id)
        {
            Animals animals;

            // Если идентификатор нулевой, вызываем представление раздела Dogs,
            // иначе направляем запрос на страницу конкретного животного.
            if(id != null)
            {
                animals = new Animals("Dogs", id);

                // Для всех животных используем один шаблон представления
                return View("Id", animals);
            }

            animals = new Animals("Dogs");

            return View(animals);
        }

        public ActionResult Cats(string id)
        {
            Animals animals;

            // Если идентификатор нулевой, вызываем представление раздела Cats,
            // иначе направляем запрос на страницу конкретного животного.
            if (id != null)
            {
                animals = new Animals("Cats", id);

                // Для всех животных используем один шаблон представления
                return View("Id", animals);
            }

            animals = new Animals("Cats");

            return View(animals);
        }

        public ActionResult Fish(string id)
        {
            Animals animals;

            // Если идентификатор нулевой, вызываем представление раздела Fish,
            // иначе направляем запрос на страницу конкретного животного.
            if (id != null)
            {
                animals = new Animals("Fish", id);

                // Для всех животных используем один шаблон представления
                return View("Id", animals);
            }

            animals = new Animals("Fish");

            return View(animals);
        }
    }
}