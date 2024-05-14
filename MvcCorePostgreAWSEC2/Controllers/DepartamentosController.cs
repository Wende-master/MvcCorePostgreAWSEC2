using Microsoft.AspNetCore.Mvc;
using MvcCorePostgreAWSEC2.Models;
using MvcCorePostgreAWSEC2.Repositories;

namespace MvcCorePostgreAWSEC2.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Departamento> departamentos =
                await this.repo.GetDepartamentosAsync();
            return View(departamentos);
        }

        public async Task<IActionResult> Details(int iddept)
        {
            Departamento departamento = await this.repo.FindDepartamentoAsync(iddept);
            return View(departamento);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Departamento departamento)
        {
            await this.repo.InsertarDepartamentoAsyc(departamento);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int iddept)
        {
            await this.repo.DeleteAsync(iddept);
            return RedirectToAction("Index");
        }
    }
}
