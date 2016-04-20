using System;
using System.Linq;
using System.Web.Mvc;
using Modelo;
using Controle;

namespace GrupoRAI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (((Pessoas)Session["Logado"]) == null)
                return Redirect("~/Account/Login");
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            if (((Pessoas)Session["Logado"]) == null)
                return Redirect("~/Account/Login");

            Pessoas p = new NegociosControle().BuscarUsuario(id);
            if (p == null)
            {
                return HttpNotFound();
            }

            //ViewBag.User = p;
            return View(p);
        }
        
        
        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            if (((Pessoas)Session["Logado"]) == null)
                return Redirect("~/Account/Login");

            Pessoas p = new NegociosControle().BuscarUsuario(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            
            return View(p);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Email,Nome,Login,Senha,Nivel")]Pessoas p)
        {
            try
            {
                p.Senha = Utils.GetHashSenha(p.Senha);
                bool alterou = new NegociosControle().AtualizarUsuario(p);

                if (alterou)
                    return RedirectToAction("Index");
                else
                    return View(p);
            }
            catch(Exception ex)
            {
                return View(p);
            }
        }

        
        ///Listar Usuarios
        public ActionResult Listar()
        {
            Pessoas aux = (Pessoas)Session["Logado"];
            if (aux == null)
                return Redirect("~/Account/Login");
            if(aux.Nivel != 2)
                return Redirect("Index");

            var users = new NegociosControle().ListarUsuarios().OrderBy(u => u.Id);
            return View(users.ToList());
        }

        // POST: Home/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                NegociosControle nc = new NegociosControle();
                Pessoas del = nc.BuscarUsuario(id);
                bool excluiu = nc.DeletarUsuario(del);

                if(excluiu)
                    return RedirectToAction("Listar");

                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }        
    }
}
