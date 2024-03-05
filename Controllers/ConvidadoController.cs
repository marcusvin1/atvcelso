using atvcelso;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace atvcelso.Controllers
{
    public class ConvidadoController : Controller
    {
        private IList<Convidado> convidados = new List<Convidado>()
        {
          new Convidado()
          {
              Id = 1,
              nome= "maria",
              email = "maria12@gmail.com",
              telefone = "35988763",
              comparecimento = false

          },
          new Convidado()
          {
              Id = 2,
              nome= "vinicius",
              email = "viniciusvini@gmail.com",
              telefone = "35988764",
              comparecimento = true

          },
          new Convidado()
          {
              Id = 3,
              nome= "everton",
              email = "everton13@gmail.com",
              telefone = "35988760",
              comparecimento = true

          }
        };

        public IActionResult Index()
        {
            return View(convidados);
        }

        public IActionResult Create()
        {
            return View(convidados);
        }
        public IActionResult Edit(int id)
        {
            return View();
        }
        public bool retoronecomparecimento()
        {
            return true;
        }

        [HttpPost]
        public IActionResult Create(Convidado convidado)
        {
            convidados.Add(convidado);
            convidado.Id = convidados.Select(cat => cat.Id).Max() + 1;
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var convidado = convidados.FirstOrDefault(c => c.Id == id);
            if (convidado == null)
            {
                return NotFound();
            }
            return View(convidado);
        }

        public IActionResult Delete(int id)
        {
            var convidado = convidados.FirstOrDefault(c => c.Id == id);
            if (convidado == null)
            {
                return NotFound();
            }
            return View(convidado);
        }
        public IActionResult comparecimento()
        {
            bool resultado = retoronecomparecimento();

            return View();
        }

        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var convidado = convidados.FirstOrDefault(c => c.Id == id);
            if (convidado != null)
            {
                convidados.Remove(convidado);
            }
            return RedirectToAction("Index");
        }
    }
}