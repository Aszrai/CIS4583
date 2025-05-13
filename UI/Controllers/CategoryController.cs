using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CIS4583.IRepository;
using CIS4583.Model;
using System.Reflection;

namespace UI.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController

        ICategoriesRepository _irepository;
        public CategoryController(ICategoriesRepository _repository)
        {
            _irepository = _repository;
        }
        public ActionResult Index()
        {

            List<Categories> model =  _irepository.Categories_SelectList();
            return View(model);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Categories model = _irepository.Categories_Select(new Categories { categoryID = id });
            if (model == null)
            {
                return NotFound();
            }
            return View(model);

        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View(new Categories());
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categories model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model == null)
                    {
                        return View(model);
                    }
                    if (_irepository.Categories_Insert(model))
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }

        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            Categories model = _irepository.Categories_Select(new Categories { categoryID = id });
            if (model == null)
            {
                return NotFound();
            }
            return View(model);

        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Categories model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Categories Model = _irepository.Categories_Select(new Categories { categoryID = id });
                    if (Model == null)
                    {
                        return NotFound();
                    }
                    if (_irepository.Categories_Update(model))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(model);
                    }
                }
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Categories model = _irepository.Categories_Select(new Categories { categoryID = id });
            if (model == null)
            {
                return NotFound();
            }
            return View(model);

        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id, Categories model)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                Categories Model = _irepository.Categories_Select(new Categories { categoryID = id });
                if (Model == null)
                {
                    return NotFound();
                }
                if (_irepository.Categories_Delete(model))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(model);
                }


            }
            catch
            {
                return View(model);
            }

        }
    }
}
